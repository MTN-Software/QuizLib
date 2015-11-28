using System;

namespace QuizMobileLib
{
    /// <summary>
    /// Contains the answer for a specific question.
    /// </summary>
    public class Answer : IComparable<Answer>, IEquatable<Answer>
    {
        #region Property
        /// <summary>
        /// The string representation of the answer.
        /// </summary>
        public string Text { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize an <code>Answer</code> object
        /// </summary>
        /// <param name="answer">The string representation of the answer.</param>
        public Answer(string answer)
        {
            Text = answer;   
        }
        #endregion

        #region Interface Implemetations
        #region IComparable<Answer>
        /// <summary>
        /// Compares this instance to a specified Answer and returns an indication
        /// of their relative values.
        /// </summary>
        /// <param name="other">An Answer to compare.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value.Return
        /// Value Description Less than zero This instance is less than value. Zero This
        /// instance is equal to value. Greater than zero This instance is greater than value.
        /// </returns>
        public int CompareTo(Answer other)
        {
            return Text.CompareTo(other.Text);
        }
        #endregion
        #region IEquatable<Answer>
        /// <summary>
        /// Determines if this instance contains the same value as the compared one.
        /// </summary>
        /// <param name="other">The answer to compare.</param>
        /// <returns>True if the instances' values are equal, otherwise false.</returns>
        public bool Equals(Answer other)
        {
            return Text == other.Text;
        }
        #endregion
        #endregion
        #region Operators
        /// <summary>
        /// Allows you to instatiate an answer by just providing the string.
        /// </summary>
        /// <param name="val">The string to pass.</param>
        /// <example>
        /// An example of this would be:
        /// <code>
        /// Answer correct = "foobar";  // equivalent to Answer correct = new Answer("foobar");
        /// </code>
        /// </example>
        public static implicit operator Answer(string val)
        {
            return new Answer(val);
        }

        /// <summary>
        /// Overrided "==" operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns></returns>
        public static bool operator ==(Answer lhs, Answer rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Overrided "!=" operator
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns></returns>
        public static bool operator !=(Answer lhs, Answer rhs) => !lhs.Equals(rhs);
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether the specified object is equal to the current one.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            
            if (obj is Answer)
                return Equals(obj as Answer);
            else
                return false;
            
        }

        /// <summary>
        /// Returns hash code for this instance.
        /// </summary>
        /// <returns>The hash code for this instance.</returns>
        public override int GetHashCode()
        {
            // Temporary solution to generate hash code
            return Text.GetHashCode();
        }
        #endregion

    }
}
