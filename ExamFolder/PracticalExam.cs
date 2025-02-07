using ExaminationSystem.Questions;

namespace ExaminationSystem.ExamFolder
{
    public class PracticalExam : Exam
    {

        public PracticalExam(TimeSpan time, int no_of_Questions) : base(time, no_of_Questions)
        {
            Questions = new List<Question>(no_of_Questions);
        }
        public override void CreateExam()
        {
            for (int i = 0; i < No_of_Questions; i++)
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
                } while (String.IsNullOrEmpty(QuestionBody));

                #endregion

                #region Input Question Mark
                do
                {
                    Console.WriteLine("Enter Question Mark");
                    flag = int.TryParse(Console.ReadLine(), out Mark);
                } while (!flag || Mark <= 0);

                #endregion


                #region Input Answers
                List<Answer> answerList = new List<Answer>();
                for (int j = 0; j < 3; j++)
                {
                    string answerText;
                    do
                    {
                        Console.WriteLine($"Enter Answer no {j + 1}:");
                        answerText = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(answerText));

                    answerList.Add(new Answer()
                    {
                        AnswerId = j + 1,
                        AnswerText = answerText
                    });
                }
                #endregion

                #region CorrectAnswer Validation
                do
                {
                    Console.WriteLine("Please Enter The Correct Answer Id (1, 2, or 3):");
                    flag = int.TryParse(Console.ReadLine(), out CorrectedAnswerId);
                } while (!flag || (CorrectedAnswerId < 1 || CorrectedAnswerId > 3));
                #endregion

                Questions.Add(new MCQ_Question(QuestionBody, Mark, answerList, CorrectedAnswerId));
            }
        }



        public override void ShowExam()
        {

            Console.WriteLine($"Practical Exam for {Subject.SubjectName}");
            foreach (var question in Questions)
            {
                question.showQuestion();
                for (int i = 0; i < question.AnswerList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.AnswerList[i].AnswerText}");

                }
                bool flag;
                int studentAnswer;
                do
                {
                    Console.WriteLine("Enter your answer (1-3):");
                    flag = int.TryParse(Console.ReadLine(), out studentAnswer);
                    flag = flag && studentAnswer >= 1 && studentAnswer <= 3;
                } while (!flag);


            }
            for (int i = 0; i < No_of_Questions; i++)
            {
                string correctAnswerText = Questions[i].GetAnswerText(Questions[i].RightAnswer.AnswerId);

                Console.WriteLine($"Right Answer => {Questions[i].RightAnswer.AnswerId}. {correctAnswerText}");
            }
            


        }

    }
        
    
}