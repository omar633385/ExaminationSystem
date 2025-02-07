//using System.Reflection.PortableExecutable;
//using System.Runtime.CompilerServices;

//namespace ExaminationSystem.Questions
//{
//    [Flags]
//    public enum TrueFalseAnswer:byte
//    {
//        True=1,
//        False=2

//    }
//    internal class TF_Question : Question
//    {

//        public TF_Question(string questionBody, int mark, int correctedAnswerId)
//        : base(QuestionType.True_False_Question, questionBody, mark, correctedAnswerId)
//        {
//        }



//        public override void showQuestion()
//        {
//            Console.WriteLine($"{QuestionHeader}\n{QuestionBody} (True/False)");

//        }

//        public override Question CreateQuestion()
//        {
//            bool flag;
//            int Mark;
//            int CorrectedAnswerId;
//            #region QuestionBody
//            Console.WriteLine(QuestionType.True_False_Question);
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

//            #region CorrectAnswer
//            do
//            {
//                Console.WriteLine("Please Enter The Right Answer Id (1 For True | 2 for False)");
//                flag = int.TryParse(Console.ReadLine(), out CorrectedAnswerId);
//            } while (!flag|| CorrectedAnswerId!=1||CorrectedAnswerId!=2); 
//            #endregion

//            return new TF_Question(QuestionBody,Mark,CorrectedAnswerId);


//        }



//    }
//}

using System;

namespace ExaminationSystem.Questions
{
    [Flags]
    public enum TrueFalseAnswer : byte
    {
        True = 1,
        False = 2
    }

    internal class TF_Question : Question
    {
        public TF_Question(string questionBody, int mark, int correctedAnswerId)
            : base(QuestionType.True_False_Question, questionBody, mark, correctedAnswerId)
        {
            AnswerList = new List<Answer>(2);
        }

        public override void showQuestion()
        {
            Console.WriteLine($"{QuestionHeader}\n{QuestionBody} (True/False)");
        }

        public override Question CreateQuestion()
        {
            bool flag;
            int Mark;
            int CorrectedAnswerId;
            string QuestionBody;

            #region QuestionBody
            Console.WriteLine(QuestionType.True_False_Question);
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

            #region CorrectAnswer
            do
            {
                Console.WriteLine("Please Enter The Right Answer Id (1 for True | 2 for False):");
                flag = int.TryParse(Console.ReadLine(), out CorrectedAnswerId);
            } while (!flag || (CorrectedAnswerId != 1 && CorrectedAnswerId != 2));
            #endregion

            return new TF_Question(QuestionBody, Mark, CorrectedAnswerId);
        }
    }
}
