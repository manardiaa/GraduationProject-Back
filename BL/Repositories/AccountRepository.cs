using BL.Bases;
using BL.Dtos;
using BL.StaticClasses;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class AccountRepository : BaseRepository<ApplicationStudentIdentity>
    {
        private readonly UserManager<ApplicationStudentIdentity> manager;
        private readonly RoleManager<IdentityRole> roleManager;
      
        public AccountRepository(DbContext db, UserManager<ApplicationStudentIdentity> manager, RoleManager<IdentityRole> roleManager) : base(db)
        {
            this.manager = manager;
            this.roleManager = roleManager;

        }

        public ApplicationStudentIdentity GetAccountById(string id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }

        public async Task<bool> UpdateUserInfo(string id,RegisterViewodel accountInfo)
        {
            ApplicationStudentIdentity user = GetFirstOrDefault(l => l.Id == id);
            if (user != null)
            {
                user.UserName = accountInfo.UserName;     
                user.Email = accountInfo.Email;     
                user.PhoneNumber = accountInfo.PhoneNumber;
                user.Image = accountInfo.Image;

                IdentityResult result = await manager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        
        public List<ApplicationStudentIdentity> GetAllAccounts()
        {            
            return GetAll().ToList();
        }
        public async Task<ApplicationStudentIdentity> FindByName(string userName)
        {
            ApplicationStudentIdentity result = await manager.FindByNameAsync(userName);
            return result;
        }
        public async Task<IEnumerable<string>> GetUserRoles(ApplicationStudentIdentity user)
        {
            var userRoles = await manager.GetRolesAsync(user);
            return userRoles;
        }

        public async Task<ApplicationStudentIdentity> FindById(string id)
        {
            ApplicationStudentIdentity result = await manager.FindByIdAsync(id);

            return result;

        }
        public async Task<ApplicationStudentIdentity> Find(string username, string password)
        {

            var user = await manager.FindByNameAsync(username);
            if (user != null && await manager.CheckPasswordAsync(user, password))
            {
                return user;
            }

            return null;
        }

        public async Task<IdentityResult> Register(ApplicationStudentIdentity user)
        {
            user.Id = Guid.NewGuid().ToString();
            IdentityResult result;
            result = await manager.CreateAsync(user, user.PasswordHash);

            return result;
        }
        public async Task<IdentityResult> AssignToRole(string userid, string rolename)
        {
            var user = await manager.FindByIdAsync(userid);
            if (user != null && await roleManager.RoleExistsAsync(rolename))
            {
                IdentityResult result = await manager.AddToRoleAsync(user, rolename);
                return result;
            }
            return null;
        }
        public async Task<bool> updatePassword(string stid, RegisterViewodel accountInfo,string oldPassword)
        {
            ApplicationStudentIdentity user = GetFirstOrDefault(l => l.Id == stid);
            var newPasswordHash = manager.PasswordHasher.HashPassword(user, accountInfo.PasswordHash);
            //var oldPasswordHash = manager.PasswordHasher.HashPassword(user, oldPassword);
            
            if (await manager.CheckPasswordAsync(user, oldPassword))
            {
                user.PasswordHash = newPasswordHash;
                IdentityResult result = await manager.UpdateAsync(user);
                if (result != null && result.Succeeded)
                {
                    return true;
                }
            }
           
            return false;

        }

        public async Task<bool> UpdateAccount(ApplicationStudentIdentity user)
        {
            IdentityResult result = await manager.UpdateAsync(user);
            return true;
        }

        public bool CheckAccountExistsByData(ApplicationStudentIdentity user)
        {
            return GetAny(std=> std.UserName == user.UserName && std.Email == user.Email);
        }
    }
}
