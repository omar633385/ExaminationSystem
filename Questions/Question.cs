namespace ExaminationSystem.Questions
{
    [Flags]
    public enum QuestionType : byte
    {
        True_False_Question = 1,
        MCQ_Question = 2
    }
    public class Question
    {
        public QuestionType QuestionHeader { get; set; }
        public string QuestionBody { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer ChosenAnswer { get; set; }
    }
}