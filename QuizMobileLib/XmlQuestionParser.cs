using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizMobileLib
{
    /// <summary>
    /// A class used to help parse questions and answers in
    /// the questionbank xml file.
    /// </summary>
    public class XmlQuestionParser
    {
        #region Members
        XDocument xDocument;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructs an instance of the parser with the document.
        /// </summary>
        /// <param name="xDoc">The xml document to read and parse.</param>
        public XmlQuestionParser(XDocument xDoc)
        {
            xDocument = xDoc;
        }

        #endregion

        #region Properties
        /// <summary>
        /// The XML Document.
        /// </summary>
        public XDocument XDocument
        {
            get { return xDocument; }
            set
            {
                if (!xDocument.Equals(value))
                    xDocument = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// parses the xml file and creates a list of questions
        /// from it.
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuestions()
        {
            var questions = xDocument.Descendants("Question");
            List<Question> listQ = new List<Question>();
            questions.ToList().ForEach(n =>
            {
                Question q = new Question();
                List<Answer> answerList = new List<Answer>();
                q.Text = n.Element("Text").Value;
                var answers = n.Elements("Answer").ToList();
                answers.ForEach(m=>
                {
                    q.Answers.Add(m.Value);
                });
                var correct = answers.Where(x => x.Attribute("isCorrect").Value == "true").Single().Value;
                q.CorrectAnswer = q.Answers.Where(x => x.Text == correct).Single();
                listQ.Add(q);
            });

            return listQ;

        }

        
        #endregion
    }
}
