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
  public  class LessonContentAppService : AppServiceBase
    {
        public LessonContentAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        { }

        #region CURD

        public List<lessonContentViewModel> AllLessonContent()
        {
            return Mapper.Map<List<lessonContentViewModel>>(TheUnitOfWork.lessonContent.GetAlllessonContent());
        }
        public List<lessonContentViewModel> GetAllLessonContentByCrsID(int crsId)
        {
            return Mapper.Map<List<lessonContentViewModel>>(TheUnitOfWork.lessonContent.GetAllLessonContentByCrsID(crsId));
        }   
        public int lessonContentCount(int crsId)
        {
            return TheUnitOfWork.lessonContent.lessonContentCount(crsId);
        }   
        public int GetFirstLessonContentByLessonId(int lessonId)
        {
            return TheUnitOfWork.lessonContent.GetFirstLessonContentByLessonId(lessonId);
        }        

        public lessonContentViewModel GetlessonContent(int id)
        {
            return Mapper.Map<lessonContentViewModel>(TheUnitOfWork.lessonContent.GetById(id));
        }
        public List<lessonContentViewModel> GetLessonContentByLesson(int LesId)
        {
            return Mapper.Map<List<lessonContentViewModel>>(TheUnitOfWork.lessonContent.GetAllLessonContentByLesson(LesId));
        }
        public bool SaveNewlessonContent(lessonContentViewModel lessonContentViewModel)
        {
            if (lessonContentViewModel == null)

                throw new ArgumentNullException();
            bool result = false;
            var lessonContent = Mapper.Map<lessonContent>(lessonContentViewModel);
            if (TheUnitOfWork.lessonContent.Insert(lessonContent))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdatelessonContent(lessonContentViewModel lessonContentViewModel)
        {
            var lessonContent = Mapper.Map<lessonContent>(lessonContentViewModel);
            TheUnitOfWork.lessonContent.Update(lessonContent);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool DeletelessonContent(int id)
        {
            bool result = false;
            TheUnitOfWork.lessonContent.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool ChecklessonContentExists(lessonContentViewModel lessonContentViewModel)
        {
            lessonContent lessonContent = Mapper.Map<lessonContent>(lessonContentViewModel);
            return TheUnitOfWork.lessonContent.ChecklessonContentExists(lessonContent);
        }
        #endregion
    }
}
