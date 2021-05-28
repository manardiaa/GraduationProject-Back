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
   public class LessonAppServices : AppServiceBase
    {
        public LessonAppServices(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        { }

        #region CURD

        public List<lessonViewModel> AllLesson()
        {

            return Mapper.Map<List<lessonViewModel>>(TheUnitOfWork.lesson.GetAllLesson());
        }
        public lessonViewModel Getlesson(int id)
        {
            return Mapper.Map<lessonViewModel>(TheUnitOfWork.lesson.GetById(id));
        }
        public bool SaveNewlesson(lessonViewModel lessonViewModel)
        {
            if (lessonViewModel == null)

                throw new ArgumentNullException();
            bool result = false;
            var lesson = Mapper.Map<lesson>(lessonViewModel);
            if (TheUnitOfWork.lesson.Insert(lesson))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool Updatelesson(lessonViewModel lessonViewModel)
        {
            var lesson = Mapper.Map<lesson>(lessonViewModel);
            TheUnitOfWork.lesson.Update(lesson);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool Deletelesson(int id)
        {
            bool result = false;
            TheUnitOfWork.lesson.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool ChecklessonExists(lessonViewModel lessonViewModel)
        {
            lesson lesson = Mapper.Map<lesson>(lessonViewModel);
            return TheUnitOfWork.lesson.ChecklessonExists(lesson);
        }
        #endregion
    }
}
