namespace ExaminationSystem
{
    public class Answer:IComparable<Answer>
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        public Answer()
        {
            
        }
        public override string ToString()
        {
            return $"{AnswerId}:{AnswerText}";
        }

        public int CompareTo(Answer? other)
        {
             return this.AnswerId.CompareTo(other?.AnswerId);
        }
    }

}