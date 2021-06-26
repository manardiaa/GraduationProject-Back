using BL.Bases;
using BL.Interfaces;
using BL.StaticClasses;
using BL.Dtos;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BL.AppServices
{
    public class AccountAppService : AppServiceBase
    {
        IConfiguration _configuration;
 
        public AccountAppService(IUnitOfWork theUnitOfWork,IConfiguration configuration,
             IMapper mapper) : base(theUnitOfWork, mapper)
        {
            this._configuration = configuration;
           
        }
      
        public List<RegisterViewodel> GetAllAccounts()
        {
            return Mapper.Map<List<RegisterViewodel>>(TheUnitOfWork.account.GetAllAccounts().Where(ac => ac.isDeleted == false));
        }
        public RegisterViewodel GetAccountById(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            return Mapper.Map<RegisterViewodel>(TheUnitOfWork.account.GetAccountById(id));

        }

        public bool DeleteAccount(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            bool result = false;
            ApplicationStudentIdentity user = TheUnitOfWork.account.GetAccountById(id);
            user.isDelete = true;
            TheUnitOfWork.account.Update(user);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        public async Task<ApplicationStudentIdentity> Find(string name, string password)
        {
            ApplicationStudentIdentity user = await TheUnitOfWork.account.Find(name, password);

            if (user != null && user.isDeleted == false)
                return user;
            return null;
        }
        public async Task<bool> UpdateUserInfo(string id, RegisterViewodel accountInfo)
        {
            return await(TheUnitOfWork.account.UpdateUserInfo(id, accountInfo));
        }        
        public async Task<ApplicationStudentIdentity> FindByName(string userName)
        {
            ApplicationStudentIdentity user = await TheUnitOfWork.account.FindByName(userName);

            if (user != null && user.isDeleted == false)
                return user;
            return null;
        }
        public async Task<IdentityResult> Register(RegisterViewodel user)
        {
            bool isExist = await checkUserNameExist(user.UserName);
            if(isExist)
                return IdentityResult.Failed(new IdentityError
                { Code = "error", Description = "user name already exist" });

            ApplicationStudentIdentity identityUser = Mapper.Map<RegisterViewodel, ApplicationStudentIdentity>(user);
            var result = await TheUnitOfWork.account.Register(identityUser);
            // create user cart and wishlist 
            if (result.Succeeded)
            {
               // CreateUserCartAndWishlist(identityUser.Id);
            }
            return result;
        }
        public async Task<IdentityResult> AssignToRole(string userid, string rolename)
        {
            if (userid == null || rolename == null)
                return null;
            return await TheUnitOfWork.account.AssignToRole(userid, rolename);
        }
        public async Task<bool> UpdatePassword(string userID, RegisterViewodel accountInfo, string oldPassword)
        {                 
            return await TheUnitOfWork.account.updatePassword(userID, accountInfo,oldPassword);

        }

        public async Task<bool> Update(RegisterViewodel user)
        {
            //    ApplicationUserIdentity identityUser = TheUnitOfWork.Account.FindById(user.Id);

            //    Mapper.Map(user, identityUser);

            //    return TheUnitOfWork.Account.UpdateAccount(identityUser);


            ApplicationStudentIdentity identityUser = await TheUnitOfWork.account.FindById(user.Id);
            var oldPassword = identityUser.PasswordHash;
            Mapper.Map(user, identityUser);
            identityUser.PasswordHash = oldPassword;
            return await TheUnitOfWork.account.UpdateAccount(identityUser);

        }
        public async Task<bool> checkUserNameExist(string userName)
        {
            var user = await TheUnitOfWork.account.FindByName(userName);
            return user == null ? false : true;
        }
        public async Task<IEnumerable<string>> GetUserRoles (ApplicationStudentIdentity user)
        {
            return await TheUnitOfWork.account.GetUserRoles(user);
        }
       public async Task<dynamic> CreateToken(ApplicationStudentIdentity user)
        {
            var userRoles = await GetUserRoles(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim("role",userRoles.FirstOrDefault()),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            } ;

           
        }

        public async Task CreateFirstAdmin()
        {
            var firstAdmin = new RegisterViewodel()
            {
                Id = null,
                Email = "test@gmail.com",
                UserName = "Admin",
                PasswordHash = "@Admin12345",

            };
            Register(firstAdmin).Wait();
            ApplicationStudentIdentity foundedAdmin = await FindByName(firstAdmin.UserName);
            if (foundedAdmin != null)
                AssignToRole(foundedAdmin.Id, UserRoles.Admin).Wait();
        }

         public bool CheckAccountExistsByData(RegisterViewodel accountInfo)
        {
            ApplicationStudentIdentity std = Mapper.Map<ApplicationStudentIdentity>(accountInfo);
            if (std == null)
            {
                return false;
            }
            else
            {
                return TheUnitOfWork.account.CheckAccountExistsByData(std);
            }
        }
    }
}
