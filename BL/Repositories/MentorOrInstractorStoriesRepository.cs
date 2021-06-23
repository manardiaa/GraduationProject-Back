using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Repositories
{
    public class MentorOrInstractorStoriesRepository : BaseRepository<MentorOrInstractorStories>
    {

        private DbContext U_DbContext;

        public MentorOrInstractorStoriesRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<MentorOrInstractorStories> GetAllMentorOrInstractorStories()
        {
            return GetAll().ToList();
        }

        public bool InsertMentorOrInstractorStories(MentorOrInstractorStories mentorOrInstractor)
        {
            return Insert(mentorOrInstractor);
        }
        public void UpdateMentorOrInstractorStories(MentorOrInstractorStories mentorOrInstractor)
        {
            Update(mentorOrInstractor);
        }
        public void DeleteMentorOrInstractorStories(int id)
        {
            Delete(id);
        }

        public bool CheckMentorOrInstractorStoriesExists(MentorOrInstractorStories mentorOrInstractor)
        {
            return GetAny(l => l.id == mentorOrInstractor.id);
        }
        public MentorOrInstractorStories GetOMentorOrInstractorStoriesById(int id)
        {
            return GetFirstOrDefault(l => l.id == id);
        }

        public List<MentorOrInstractorStories> GetTopFourInstractorStories()
        {
            return GetWhere(Inst => Inst.MemberType == "Instractor" && Inst.ShowOrNot==1).Take(4).ToList();
        }

        public List<MentorOrInstractorStories> GetTopFourMentorStories()
        {
            return GetWhere(Inst => Inst.MemberType == "Mentor" && Inst.ShowOrNot == 1).Take(4).ToList();
        }
        public List<MentorOrInstractorStories> AllInstractors()
        {
            return GetWhere(Inst => Inst.MemberType == "Instractor" ).ToList();
        }

        public List<MentorOrInstractorStories> AllMentors()
        {
            List<MentorOrInstractorStories> MentorList= GetWhere(Inst => Inst.MemberType == "Mentor" ).ToList();
            return MentorList;
        }
        #endregion
    }
}

