using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        /// <summary>
        /// Initializes a QuestionBank from reading through an
        /// xml file.
        /// </summary>
        /// <param name="XmlQuizLayout">The XDocument containing the contents of the xml file.</param>
        public QuestionBank(XDocument XmlQuizLayout)
        {
            this.questionList = new XmlQuestionParser(XmlQuizLayout).GetQuestions();
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
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the hashcode of the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Adds a question to the list.
        /// </summary>
        /// <param name="question">The question to add.</param>
        public void Add(Question question)
        {
            QuestionList.Add(question);
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
                if (!questionList.Equals(value))
                    questionList = value;
            }
        }

        /// <summary>
        /// Gets the Question at "index" of the QuestionList
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Question this[int index]
        {
            get { return QuestionList[index]; }
            set
            {
                if (questionList[index] != value)
                {
                    questionList[index] = value;
                }
            }
        }
        #endregion
    }
}
