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
    public class StudentStoriesRepository : BaseRepository<StudentStories>
    {

        private DbContext U_DbContext;

        public StudentStoriesRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<StudentStories> GetAllStudentStories()
        {
            return GetAll().ToList();
        }
        public List<StudentStories> GetTopFiveStudentStories()
        {
            return GetWhere(stdSrory => stdSrory.ShowOrNot == 1).Take(5).ToList();
        }
        public List<StudentStories> GetTopStdStory(int id)
        {
            return GetWhere(stdStory => stdStory.ShowOrNot == 1&&stdStory.CategoryId==id).Take(1).ToList();
        }
        public bool InsertStudentStories(StudentStories studentStories)
        {
            return Insert(studentStories);
        }
        public void UpdateStudentStories(StudentStories studentStories)
        {
            Update(studentStories);
        }
        public void DeleteStudentStories(int id)
        {
            Delete(id);
        }

        public bool CheckStudentStoriesExists(StudentStories studentStories)
        {
            return GetAny(l => l.Id == studentStories.Id);
        }
        public StudentStories GetOStudentStoriesById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}

