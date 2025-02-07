using ExaminationSystem.Questions;

namespace ExaminationSystem.ExamFolder
{ 
    public class FinalExam : Exam
    {

        public FinalExam(TimeSpan time, int no_of_Questions) : base(time, no_of_Questions)
        {
        }
        int Grade = 0, TotalMarks = 0;

        public override void CreateExam()
        {
            for (int i = 0; i < No_of_Questions; i++)
            {
                bool flag;
                int Mark;
                int CorrectedAnswerId;
                string QuestionBody;
                QuestionType questionType;

                #region Question Type
                do
                {
                    Console.WriteLine("Please Enter The Question Type (1 For True_False | 2 for MCQ)");
                    flag = Enum.TryParse(Console.ReadLine(), out questionType);
                } while (!flag);
                #endregion

                Console.WriteLine($"You selected: {questionType}");

                #region QuestionBody
                do
                {
                    Console.WriteLine("Enter Question Body:");
                    QuestionBody = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(QuestionBody));
                #endregion

                #region Input Question Mark
                do
                {
                    Console.WriteLine("Enter Question Mark:");
                    flag = int.TryParse(Console.ReadLine(), out Mark);
                } while (!flag || Mark <= 0);
                TotalMarks += Mark;
                #endregion

                if (questionType == QuestionType.MCQ_Question)
                {
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
                else  // True/False Question
                {
                    #region CorrectAnswer Validation for TF
                    do
                    {
                        Console.WriteLine("Please Enter The Correct Answer Id (1 for True | 2 for False):");
                        flag = int.TryParse(Console.ReadLine(), out CorrectedAnswerId);
                    } while (!flag || (CorrectedAnswerId != 1 && CorrectedAnswerId != 2));
                    #endregion

                    Questions.Add(new TF_Question(QuestionBody, Mark, CorrectedAnswerId));
                    Console.Clear();
                }
            }
        }
        public override void ShowExam()
        {
            Grade = 0;
            List<int> userAnswers = new List<int>();

            for (int i = 0; i < Questions.Count; i++)
            {
                try
                {
                    Console.WriteLine($"\nQuestion {i + 1}: {Questions[i].QuestionBody}");

                    if (Questions[i] is MCQ_Question mcqQuestion)
                    {
                        if (mcqQuestion.AnswerList != null && mcqQuestion.AnswerList.Any())
                        {
                            foreach (var answer in mcqQuestion.AnswerList)
                            {
                                Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("No answers found for MCQ question");
                        }

                        bool flag;
                        int studentAnswer;
                        do
                        {
                            Console.WriteLine("Enter your answer (1-3):");
                            flag = int.TryParse(Console.ReadLine(), out studentAnswer);
                            flag = flag && studentAnswer >= 1 && studentAnswer <= 3;
                        } while (!flag);

                        userAnswers.Add(studentAnswer); // Store user's answer

                        Answer studentAnswerObj = new Answer(studentAnswer, "");
                        if (Questions[i].CompareAnswers(studentAnswerObj) == 0)
                        {
                            Grade += Questions[i].Mark;
                        }
                    }
                    else if (Questions[i] is TF_Question)
                    {
                        Console.WriteLine("1. True");
                        Console.WriteLine("2. False");

                        bool flag;
                        int studentAnswer;
                        do
                        {
                            Console.WriteLine("Enter your answer (1 for True, 2 for False):");
                            flag = int.TryParse(Console.ReadLine(), out studentAnswer);
                            flag = flag && (studentAnswer == 1 || studentAnswer == 2);
                        } while (!flag);

                        userAnswers.Add(studentAnswer); // Store user's answer

                        Answer studentAnswerObj = new Answer(studentAnswer, "");
                        if (Questions[i].CompareAnswers(studentAnswerObj) == 0)
                        {
                            Grade += Questions[i].Mark;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error showing question {i + 1}: {ex.Message}");
                    userAnswers.Add(-1); // Add invalid answer marker
                    continue;
                }
            }

            // Show exam results with answer comparison
            Console.WriteLine("\nExam Finished. Here are your results:");
            for (int i = 0; i < No_of_Questions; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {Questions[i].QuestionBody}");

                if (Questions[i] is MCQ_Question mcqQuestion)
                {
                    // Show the selected answer text
                    string userAnswerText = userAnswers[i] >= 1 && userAnswers[i] <= 3
                        ? mcqQuestion.AnswerList.FirstOrDefault(a => a.AnswerId == userAnswers[i])?.AnswerText ?? "Invalid Answer"
                        : "Invalid Answer";

                    // Show the correct answer text
                    string correctAnswerText = mcqQuestion.AnswerList.FirstOrDefault(a => a.AnswerId == Questions[i].RightAnswer.AnswerId)?.AnswerText ?? "Unknown";

                    Console.WriteLine($"Your Answer => {userAnswers[i]}. {userAnswerText}");
                    Console.WriteLine($"Right Answer => {Questions[i].RightAnswer.AnswerId}. {correctAnswerText}");
                }
                else if (Questions[i] is TF_Question)
                {
                    string userAnswerText = userAnswers[i] == 1 ? "True" : "False";
                    string correctAnswerText = Questions[i].RightAnswer.AnswerId == 1 ? "True" : "False";

                    Console.WriteLine($"Your Answer => {userAnswers[i]}. {userAnswerText}");
                    Console.WriteLine($"Right Answer => {Questions[i].RightAnswer.AnswerId}. {correctAnswerText}");
                }
            }

            Console.WriteLine($"\nGrade: {Grade} out of {TotalMarks}");
            Console.WriteLine("Thank You");
        }
    }
}

