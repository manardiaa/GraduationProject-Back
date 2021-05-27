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

    }
}
