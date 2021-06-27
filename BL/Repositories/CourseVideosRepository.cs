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
    public class CourseVideosRepository : BaseRepository<CourseVideos>
    {

        private DbContext U_DbContext;

        public CourseVideosRepository(DbContext U_DbContext) : base(U_DbContext)
        {
            this.U_DbContext = U_DbContext;
        }
        #region CRUB

        public List<CourseVideos> GetAllCourseVideos()
        {
            return GetAll().ToList();
        }
        public List<CourseVideos> GetAllCourseVideosByLessonId(int lessonId)
        {
            return GetWhere(l=>l.LessonId==lessonId).ToList();
        }
        public bool InsertCourseVideos(CourseVideos courseVideos)
        {
            return Insert(courseVideos);
        }
        public void UpdateCourseVideos(CourseVideos courseVideos)
        {
            Update(courseVideos);
        }
        public void DeleteCourseVideos(int id)
        {
            Delete(id);
        }

        public bool CheckCourseVideosExists(CourseVideos courseVideos)
        {
            return GetAny(l => l.Id == courseVideos.Id);
        }
        public CourseVideos GetOCourseVideosById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }

        public bool CheckCourseVideosExistsByData(CourseVideos courseVideos)
        {
            return GetAny(crsVideo =>crsVideo.VideoName == courseVideos.VideoName &&crsVideo.VideoURL==courseVideos.VideoURL);
        }

       
        #endregion
    }
}

