using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.Repositories;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methode
        int Commit();
        #endregion
        CategoryRepository category { get; }
<<<<<<< HEAD
        lessonContentRepository lessonContent { get; }
        lessonRepository lesson { get; }
        QuestionGroupRepository questionGroup { get; }
        QuestionOptionsRepository questionOptions { get; }
        QuestionRepository question { get; }

        StudentAnswerRepository studentAnswer { get; }
        TrueAndFalseRepository trueAndFalse { get; }
=======
        CourseRepository course { get; }
        CourseVideosRepository courseVideos { get; }
        EnrollCourseRepository enrollcourse { get; }
        DragAndDropRepository dragAndDrop { get; }
        lectureRepository lecture { get; }



>>>>>>> ebf14f31e3709e65ae3fde02d6d32fb3a0082a1f

    }
}
