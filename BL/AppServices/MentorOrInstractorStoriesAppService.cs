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
    public class MentorOrInstractorStoriesAppService : AppServiceBase
    {
        public MentorOrInstractorStoriesAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        #region CURD

        public List<MentorOrInstractorStoriesViewModel> GetAllMentorOrInstractorStoriess()
        {

            return Mapper.Map<List<MentorOrInstractorStoriesViewModel>>(TheUnitOfWork.mentorOrInstractor.GetAllMentorOrInstractorStories());
        }
        public MentorOrInstractorStoriesViewModel GetMentorOrInstractorStories(int id)
        {
            return Mapper.Map<MentorOrInstractorStoriesViewModel>(TheUnitOfWork.mentorOrInstractor.GetById(id));
        }
        public bool SaveNewMentorOrInstractorStories(MentorOrInstractorStoriesViewModel mentorOrInstractorViewModel)
        {
            if (mentorOrInstractorViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var mentorOrInstractor = Mapper.Map<MentorOrInstractorStories>(mentorOrInstractorViewModel);
            if (TheUnitOfWork.mentorOrInstractor.InsertMentorOrInstractorStories(mentorOrInstractor))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateMentorOrInstractorStories(MentorOrInstractorStoriesViewModel mentorOrInstractorViewModel)
        {
            var mentorOrInstractor = Mapper.Map<MentorOrInstractorStories>(mentorOrInstractorViewModel);
            TheUnitOfWork.mentorOrInstractor.Update(mentorOrInstractor);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteMentorOrInstractorStories(int id)
        {
            bool result = false;

            TheUnitOfWork.mentorOrInstractor.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckMentorOrInstractorStoriesExists(MentorOrInstractorStoriesViewModel mentorOrInstractorViewModel)
        {
            var mentorOrInstractor = Mapper.Map<MentorOrInstractorStories>(mentorOrInstractorViewModel);
            return TheUnitOfWork.mentorOrInstractor.CheckMentorOrInstractorStoriesExists(mentorOrInstractor);
        }

        public List<MentorOrInstractorStoriesViewModel> GetFourInstractors()
        {
            return Mapper.Map<List<MentorOrInstractorStoriesViewModel>>(TheUnitOfWork.mentorOrInstractor.GetTopFourInstractorStories());
        }


        public List<MentorOrInstractorStoriesViewModel> GetFourMentors()
        {
            return Mapper.Map<List<MentorOrInstractorStoriesViewModel>>(TheUnitOfWork.mentorOrInstractor.GetTopFourMentorStories());
        }

        public List<MentorOrInstractorStoriesViewModel> GetAllMentors()
        {
            return Mapper.Map<List<MentorOrInstractorStoriesViewModel>>(TheUnitOfWork.mentorOrInstractor.AllMentors());
        }

        public List<MentorOrInstractorStoriesViewModel> GetAllInstractor()
        {
            return Mapper.Map<List<MentorOrInstractorStoriesViewModel>>(TheUnitOfWork.mentorOrInstractor.AllInstractors());
        }
        #endregion



    }
}
