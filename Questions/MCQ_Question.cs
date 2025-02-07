using ExaminationSystem.ExamFolder;
using System;
using System.Collections.Generic;

namespace ExaminationSystem.Questions
{
    public class MCQ_Question : Question
    {

        public MCQ_Question(string questionBody, int mark, List<Answer> answers, int correctAnswerId)
            : base(QuestionType.MCQ_Question, questionBody, mark, correctAnswerId,answers)
        {
            AnswerList = answers;
        }


        public override void showQuestion()
        {
            Console.WriteLine($"{QuestionHeader}\tMark:({Mark})\n{QuestionBody}\n");

        }
        public override string GetAnswerText(int userAnswerId)
        {
            return AnswerList.FirstOrDefault(a => a.AnswerId == userAnswerId)?.AnswerText ?? "Invalid Answer";
        }

    }
}
