namespace QuizMobileLib
{
    /// <summary>
    /// Contains the answer for a specific question.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Initialize an <code>Answer</code> object
        /// </summary>
        /// <param name="answer">The string representation of the answer.</param>
        public Answer(string answer)
        {
            Text = answer;
        }

        /// <summary>
        /// The string representation of the answer.
        /// </summary>
        public string Text { get; set; }

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

    }
}
