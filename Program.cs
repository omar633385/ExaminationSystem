using ExaminationSystem.ExamFolder;
using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Subject sub1 = new Subject(1, "OOP");
                Exam exam=sub1.CreateExam();
                exam.Subject = sub1;

                Console.Clear();
                bool flag;
                char UserInput;
                do
                {
                    Console.WriteLine("Do You Want To Start The Exam (y | n): ");
                    flag = char.TryParse(Console.ReadLine(), out UserInput);
                } while (!flag);
                if (UserInput == 'y')
                {
                    Console.Clear();
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    exam.ShowExam();
                    Console.WriteLine($"The Elapsed Time = {stopwatch.Elapsed}");
                    Console.WriteLine("Thank You");
                }
                else
                    Console.WriteLine("Thank You");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
