//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.PortableExecutable;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExaminationSystem.Questions
//{
//    public class MCQ_Question : Question
//    {
//        private readonly List<Answer> answers;
//        private readonly int correctAnswerId;



//        public MCQ_Question( string questionBody, int mark, List<Answer>answers, int correctAnswerId) 
//            : base(QuestionType.MCQ_Question, questionBody, mark, correctAnswerId)
//        {
//            this.answers = answers;
//            this.correctAnswerId = correctAnswerId;
//        }



//        public override Question CreateQuestion()
//        {
//            bool flag;
//            int Mark;
//            int CorrectedAnswerId;
//            #region QuestionBody
//            Console.WriteLine(QuestionType.MCQ_Question);
//            do
//            {
//                Console.WriteLine("Enter Question Body");
//                QuestionBody = Console.ReadLine();
//            } while (String.IsNullOrEmpty(QuestionBody)); 

//            #endregion

//            #region Input Question Mark
//            do
//            {
//                Console.WriteLine("Enter Question Mark");
//                flag = int.TryParse(Console.ReadLine(), out Mark);
//            } while (!flag || Mark <= 0);

//            #endregion

//            #region Input Answers
//            for (int j = 0; j < AnswerList.Count; j++)
//            {

//                    Console.WriteLine($"Enter Answer no{j + 1}");
//                    answers[j] = new Answer()
//                    {
//                        AnswerId = j + 1,

//                        AnswerText = Console.ReadLine()

//                    };

//            }
//            #endregion

//            #region CorrectAnswer
//            do
//                {
//                Console.WriteLine("Please Enter The Right Answer Id (1 For True | 2 for False)");
//                flag = int.TryParse(Console.ReadLine(), out CorrectedAnswerId);
//            } while (!flag || CorrectedAnswerId != 1 || CorrectedAnswerId != 2||correctAnswerId!=3);
//            #endregion

//            return new MCQ_Question(QuestionBody,Mark, answers,CorrectedAnswerId);

//        }

//        public override void showQuestion()
//        {

//            Console.WriteLine($"{QuestionHeader}\tMark:({Mark})\n{QuestionBody}\n");
//            for (int i = 0; i < AnswerList.Count; i++)
//            {
//                Console.WriteLine($"{i + 1}. {AnswerList[i].AnswerText}");

//            }
//        }

//    }
//}

using ExaminationSystem.ExamFolder;
using System;
using System.Collections.Generic;

namespace ExaminationSystem.Questions
{
    public class MCQ_Question : Question
    {
        private readonly List<Answer> answers=new List<Answer>();

        public MCQ_Question(string questionBody, int mark, List<Answer> answers, int correctAnswerId)
            : base(QuestionType.MCQ_Question, questionBody, mark, correctAnswerId)
        {
        }

        public override Question CreateQuestion()
        {
            bool flag;
            int Mark;
            int CorrectedAnswerId;
            string QuestionBody;

            #region QuestionBody
            Console.WriteLine(QuestionType.MCQ_Question);
            do
            {
                Console.WriteLine("Enter Question Body");
                QuestionBody = Console.ReadLine();
            } while (string.IsNullOrEmpty(QuestionBody));
            #endregion

            #region Input Question Mark
            do
            {
                Console.WriteLine("Enter Question Mark");
                flag = int.TryParse(Console.ReadLine(), out Mark);
            } while (!flag || Mark <= 0);
            #endregion

            #region Input Answers
            for (int j = 0; j < 3; j++)
            {
                string answerText;
                do
                {
                    Console.WriteLine($"Enter Answer no {j + 1}");
                    answerText = Console.ReadLine();
                } while (string.IsNullOrEmpty(answerText));

                answers.Add(new Answer()
                {
                    AnswerId = j + 1,
                    AnswerText = answerText
                });
            }
            #endregion

            #region CorrectAnswer
            do
            {
                Console.WriteLine("Please Enter The Right Answer Id (1, 2, or 3):");
                flag = int.TryParse(Console.ReadLine(), out CorrectedAnswerId);
            } while (!flag || (CorrectedAnswerId < 1 || CorrectedAnswerId > 3));
            #endregion

            return new MCQ_Question(QuestionBody, Mark, answers, CorrectedAnswerId);
        }

        public override void showQuestion()
        {
            Console.WriteLine($"{QuestionHeader}\tMark:({Mark})\n{QuestionBody}\n");
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AnswerList[i].AnswerText}");
            }


        }
    }
}
