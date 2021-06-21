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
   public class LessonAppService : AppServiceBase
    {
        public LessonAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        { }

        #region CURD

        public List<lessonViewModel> AllLesson()
        {
            return Mapper.Map<List<lessonViewModel>>(TheUnitOfWork.lesson.GetAllLesson());
        }
        public List<lessonViewModel> GetAllLessonByCrsID(int CrsID)
        {
            return Mapper.Map<List<lessonViewModel>>(TheUnitOfWork.lesson.GetAllLessonByCrsID(CrsID));
        }
        public lessonViewModel Getlesson(int id)
        {
            return Mapper.Map<lessonViewModel>(TheUnitOfWork.lesson.GetById(id));
        }
        public List<lessonViewModel> GetLessonByLecture(int LecId)
        {
            return Mapper.Map<List<lessonViewModel>>(TheUnitOfWork.lesson.GetAllLessonByLecture(LecId));
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
