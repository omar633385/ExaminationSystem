using System;

namespace ExaminationSystem.Questions
{


    internal class TF_Question : Question
    {
        
        public TF_Question(string questionBody, int mark, int correctedAnswerId,List<Answer>answers)
            : base(QuestionType.True_False_Question, questionBody, mark, correctedAnswerId,answers)
        {
            AnswerList = answers;
        }

        public override string GetAnswerText(int userAnswerId)
        {
            return userAnswerId == 1 ? "True" : userAnswerId == 2 ? "False" : "Invalid Answer";
        }

        public override void showQuestion()
        {
            Console.WriteLine($"{QuestionHeader}\n{QuestionBody} (True/False)");
        }

    }
}
