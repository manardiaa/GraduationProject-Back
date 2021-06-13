using BL.Dtos;
using DAL;
using BL.Bases;
using BL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Marten.Services;

namespace BL.AppServices
{
    public class StudentStoriesAppService : AppServiceBase
    {
        public StudentStoriesAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<StudentStoriesViewModel> GetAllStudentStories()
        {

            return Mapper.Map<List<StudentStoriesViewModel>>(TheUnitOfWork.studentStories.GetAllStudentStories());
        }
        public List<StudentStoriesViewModel> TopFiveStories()
        {
            return Mapper.Map<List<StudentStoriesViewModel>>(TheUnitOfWork.studentStories.GetTopFiveStudentStories());
        }
        public List<StudentStoriesViewModel> GetTopStudentStories(int id)
        {

            return Mapper.Map<List<StudentStoriesViewModel>>(TheUnitOfWork.studentStories.GetTopStdStory(id));
        }
        public StudentStoriesViewModel GetStudentStories(int id)
        {
            return Mapper.Map<StudentStoriesViewModel>(TheUnitOfWork.studentStories.GetById(id));
        }
        public bool SaveNewStudentStories(StudentStoriesViewModel studentStoriesViewModel)
        {
            if (studentStoriesViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var studentStories = Mapper.Map<StudentStories>(studentStoriesViewModel);
            if (TheUnitOfWork.studentStories.InsertStudentStories(studentStories))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateStudentStories(StudentStoriesViewModel studentStoriesViewModel)
        {
            var studentStories = Mapper.Map<StudentStories>(studentStoriesViewModel);
            TheUnitOfWork.studentStories.Update(studentStories);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteStudentStories(int id)
        {
            bool result = false;

            TheUnitOfWork.studentStories.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckStudentStoriesExists(StudentStoriesViewModel studentStoriesViewModel)
        {
            var studentStories = Mapper.Map<StudentStories>(studentStoriesViewModel);
            return TheUnitOfWork.studentStories.CheckStudentStoriesExists(studentStories);
        }
        #endregion



    }
}
