using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMobileLib
{
    /// <summary>
    /// The QuestionBank class is a way to easily implement
    /// a list of Questions to be loaded into an instance of
    /// a Quiz.
    /// </summary>
    public class QuestionBank : IEnumerable
    {
        #region Members
        private List<Question> questionList = new List<Question>();
        private const int DEFAULT_CAPACITY = 4;
        #endregion

        #region Constuctors
        /// <summary>
        /// Initializes a blank QuestionBank
        /// </summary>
        public QuestionBank()
        {
            questionList.Capacity = DEFAULT_CAPACITY;
        }

        /// <summary>
        /// Initializes a blank QuestionBank with an initial capacity.
        /// </summary>
        /// <param name="Capacity"></param>
        public QuestionBank(int Capacity)
        {
            questionList.Capacity = Capacity;
        }

        /// <summary>
        /// Initializes a QuestionBank with questions.
        /// </summary>
        /// <param name="questions">Questions to add to the QuestionBank.</param>
        public QuestionBank(params Question[] questions)
        {
            questionList.AddRange(questionList);
        }
        #endregion

        #region Interface Implemenations
        /// <summary>
        /// Returns an enumerator that enumerates through the QuestionBank
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)questionList).GetEnumerator();
        }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return Equals(this.questionList, obj as List<QuestionBank>);
        }

        static bool Equals(QuestionBank a, QuestionBank b)
        {
            if (a == null) return b == null;
            if (b == null || a.QuestionList.Count != b.QuestionList.Count) return false;
            for (int i = 0; i < a.QuestionList.Count; i++)
            {
                if (!object.Equals(a.QuestionList[i], b.QuestionList[i]))
                    return false;
            }
            return true;
        }
        #endregion

        #region Operators
        public static bool operator ==(QuestionBank a, QuestionBank b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(QuestionBank a, QuestionBank b)
        {
            return !Equals(a, b);
        }
        #endregion

        #region Properties
        /// <summary>
        /// The list of questions in the question bank.
        /// </summary>
        public List<Question> QuestionList
        {
            get { return questionList; }
            set
            {
                if (questionList != value)
                    questionList = value;
            }
        }
        #endregion
    }
}
