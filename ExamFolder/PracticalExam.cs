using ExaminationSystem.Questions;

namespace ExaminationSystem.ExamFolder
{
    public class PracticalExam : Exam
    {

        public PracticalExam(TimeSpan time, int no_of_Questions) : base(time, no_of_Questions)
        {
            Answers = new List<Answer>(3);
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

                List<Answer> answerList = new List<Answer>(); // Create new answer list for each MCQ

                #region Input Answers
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

            //Console.WriteLine($"Practical Exam for {Subject.SubjectName}");
            foreach (var question in Questions)
            {
                question.showQuestion();
            }
            Console.WriteLine("Exam Finished. Here are your answers and grade.");
        }

    }
        
    
}