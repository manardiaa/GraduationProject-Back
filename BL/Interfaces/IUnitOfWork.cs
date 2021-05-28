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
        lessonContentRepository lessonContent { get; }
        lessonRepository lesson { get; }
        QuestionGroupRepository questionGroup { get; }
        QuestionOptionsRepository questionOptions { get; }
        QuestionRepository question { get; }
        StudentAnswerRepository studentAnswer { get; }
        TrueAndFalseRepository trueAndFalse { get; }
        CourseRepository course { get; }
        CourseVideosRepository courseVideos { get; }
        EnrollCourseRepository enrollcourse { get; }
        DragAndDropRepository dragAndDrop { get; }
        lectureRepository lecture { get; }
<<<<<<< HEAD
       // AccountRepository Account { get; }
        RoleRepository Role { get; }

=======
        AccountRepository account { get; }
>>>>>>> 146e59dd21fc56058eb12ee4fde2ea4c9d4675d7



    }
}
