using ExaminationSystem.ExamFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    [Flags]
    public enum ExamType:byte
    {
        Practical=1,
        Final=2
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

        public void CreateExam()
        {
            ExamType examType;
            bool flag;
            do
            {
                Console.WriteLine("Please Enter The Type of Exam (1 for Pracical,2 For Final)");
                flag = Enum.TryParse(Console.ReadLine(), out examType);
            }while(!flag);
            if (examType == ExamType.Practical)
            {
                 new PracticalExam().ShowExam();
            }
            else if(examType==ExamType.Final)
                 new FinalExam().ShowExam();
        }
        public override string ToString()
        {
            return $"SubjectId:{SubjectId} :: SubjectName:{SubjectName}";
        }

    }
}
