using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace QuizMobileLib
{
    /// <summary>
    /// An object to hold data about a question.
    /// </summary>
    public class Question : IEquatable<Question>
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
        /// <remarks>
        /// Use of this constructor is discouraged b/c of the lack of
        /// initializing a correct answer.
        /// </remarks>
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

        /// <summary>
        /// Overrides the == operator to work with the type Question.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Question lhs, Question rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Overrides the != operator to work with the type Question.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Question lhs, Question rhs) => !lhs.Equals(rhs);
        #endregion

        #region Interface Implementations
        /// <summary>
        /// Determines if this instance is equal to another.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>Whether or not the two instances have the same property values (i.e. if they are equal).</returns>
        public bool Equals(Question other)
        {
            if (other == null) return false;
            bool isTextEqual = other.Text == this.Text;
            bool isImageURIEqual = other.ImageURI == this.ImageURI;
            bool isCorrectAnswerEqual = Answer.Equals(CorrectAnswer, other.CorrectAnswer);
            bool areAnswersEqual = Answers.SequenceEqual(other.Answers);

            return isTextEqual && isImageURIEqual && isCorrectAnswerEqual && areAnswersEqual;
        }
        #endregion

        #region Override Methods
        
        /// <summary>
        /// Determines whether a specified object is equal to the current one.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Question);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string to represent the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Text;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Determines whether the answer submitted by the user
        /// is the correct answer to the question.
        /// </summary>
        /// <param name="userAnswer">The answer submitted by the user.</param>
        /// <returns>Whether or not the user was correct.</returns>
        public bool IsUserGuessCorrect(Answer userAnswer) => userAnswer == CorrectAnswer;
        #endregion
    }
}
