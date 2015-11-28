using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
        [Required(ErrorMessage = "For any question, there must be at least one correct answer.")]
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
        /// Initialize a question.
        /// </summary>
        /// <param name="text">The string that represents the question.</param>
        public Question(string text)
        {
            ImageURI = string.Empty;
            Text = text;
        }

        /// <summary>
        /// Initialize a question with a preset correct answer.
        /// </summary>
        /// <param name="text">The string that represents the question.</param>
        /// <param name="correctAnswer">The correct answer to the question.</param>
        public Question(string text, Answer correctAnswer)
        {
            ImageURI = string.Empty;
            Text = text;
            CorrectAnswer = correctAnswer;
        }

        /// <summary>
        /// Initialize a question with an image.
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

        #region Operators
        /// <summary>
        /// Allows you to instantiate a <see cref="Question"/> by only providing the string.
        /// </summary>
        /// <param name="val">The string that represents the question.</param>
        /// <remarks>This is only provided for convenience, recommended that you instantiate the proper way.</remarks>
        public static implicit operator Question(string val) => new Question(val);
        #endregion

        #region Methods

        #endregion
    }
}
