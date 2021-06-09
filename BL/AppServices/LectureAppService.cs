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
     public class LectureAppService :AppServiceBase
    {
        public LectureAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        { }

        #region CURD

        public List<lectureViewModel> AllLecture()
        {

            return Mapper.Map<List<lectureViewModel>>(TheUnitOfWork.lecture.GetAllLecture());
        }

        public List<lectureViewModel> AllCrsLecture(int CrsID)
        {

            return Mapper.Map<List<lectureViewModel>>(TheUnitOfWork.lecture.GetCrsLectures(CrsID));
        }

        public lectureViewModel GetLecture(int id)
        {
            return Mapper.Map<lectureViewModel>(TheUnitOfWork.lecture.GetById(id));
        }
        public bool SaveNewlecture(lectureViewModel lectureViewModel)
        {
            if (lectureViewModel == null)

                throw new ArgumentNullException();
            bool result = false;
            var lecture = Mapper.Map<lecture>(lectureViewModel);
            if (TheUnitOfWork.lecture.Insert(lecture))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool Updatelecture(lectureViewModel lectureViewModel)
        {
            var lecture = Mapper.Map<lecture>(lectureViewModel);
            TheUnitOfWork.lecture.Update(lecture);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool Deletelecture(int id)
        {
            bool result = false;
            TheUnitOfWork.lecture.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool ChecklectureExists(lectureViewModel lectureViewModel)
        {
            var lecture = Mapper.Map<lecture>(lectureViewModel);
            return TheUnitOfWork.lecture.ChecklectureExists(lecture);
        }
        #endregion
    }
}
