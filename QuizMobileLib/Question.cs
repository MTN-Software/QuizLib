using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMobileLib
{
    /// <summary>
    /// An object to hold data about a question.
    /// </summary>
    public class Question
    {
        #region Properties
        
        /// <summary>
        /// The Universal Resource Identifier for the image (if there is one).
        /// </summary>
        public string ImageURI { get; set; }
        
        /// <summary>
        /// The string that represents the question.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The collection of possible answers to choose from.
        /// </summary>
        public ObservableCollection<Answer> Answers { get; set; }

        /// <summary>
        /// The correct answer to the question.
        /// </summary>
        public Answer CorrectAnswer { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Initialize an empty question.
        /// </summary>
        public Question()
        {
            ImageURI = string.Empty;
            Text = string.Empty;
            CorrectAnswer = string.Empty;
        }

        /// <summary>
        /// Initialize a question with an image
        /// </summary>
        /// <param name="imageUri">The Universal Resource Identifier for the image.</param>
        /// <param name="text">The string that represents the question.</param>
        /// <param name="correctAnswer">The correct answer to the question.</param>
        public Question(string imageUri, string text, Answer correctAnswer)
        {
            ImageURI = imageUri;
            Text = text;
            CorrectAnswer = correctAnswer;
        }
        #endregion
    }
}
