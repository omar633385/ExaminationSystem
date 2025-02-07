using ExaminationSystem;
using ExaminationSystem.ExamFolder;
using ExaminationSystem.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    [Flags]
    public enum ExamType : byte
    {
        Practical = 1,
        Final = 2
    }  
    public class Subject
    {

        #region Properties
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        #endregion

        #region Construcor
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        #endregion

        public Exam CreateExam()
        {
            ExamType examType;
            TimeSpan ExamTime;
            int No_of_Questions;
            bool flag;
            double minutes;

            do
            {
                Console.WriteLine("Please Enter The Type of Exam (1 for Pracical,2 For Final)");
                flag = Enum.TryParse(Console.ReadLine(), out examType);
            } while (!flag);

            do
            {
                Console.WriteLine("Enter the time of exam from (30 mins to 180 mins)");
                flag = double.TryParse(Console.ReadLine(), out minutes);
            } while (!flag || minutes <= 0);
            ExamTime = TimeSpan.FromMinutes(minutes);
            do
            {
                Console.WriteLine("Enter No of Questions");
                flag = int.TryParse(Console.ReadLine(), out No_of_Questions);
            } while (!flag || No_of_Questions <= 0);
            Console.Clear();

            Exam exam = examType == ExamType.Final ?
                new FinalExam(ExamTime, No_of_Questions) :
                new PracticalExam(ExamTime, No_of_Questions);

            exam.CreateExam();
            return exam;

        }


          
        public override string ToString()
        {
            return $"SubjectId:{SubjectId} :: SubjectName:{SubjectName}";
        }
    }
}
        

    

