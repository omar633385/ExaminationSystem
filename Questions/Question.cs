namespace ExaminationSystem.Questions
{
    [Flags]
    public enum QuestionType : byte
    {
        True_False_Question = 1,
        MCQ_Question = 2
    }
    public abstract class Question
    {
        private readonly int correctAnswerId;

        public QuestionType QuestionHeader { get; set; }
        public string QuestionBody { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }=new List<Answer>();
        public Answer RightAnswer { get; set; }
        //public Answer ChosenAnswer { get; set; }

        #region Constructor
        public Question(QuestionType questionHeader, string questionBody, int mark,int correctAnswerId)
        {
            QuestionHeader = questionHeader;
            QuestionBody = questionBody;
            Mark = mark;
            this.correctAnswerId = correctAnswerId;
            RightAnswer = new Answer(correctAnswerId,"");
        }
        #endregion
        public abstract Question CreateQuestion();
        public abstract void showQuestion();

        public  int CompareAnswers(Answer answer)
        {
            return this.correctAnswerId.CompareTo(answer.AnswerId);
        }

      
    }
}