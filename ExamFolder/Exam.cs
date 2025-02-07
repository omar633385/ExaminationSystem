using ExaminationSystem.Questions;

namespace ExaminationSystem.ExamFolder
{
    public abstract class Exam
    {
        private TimeSpan _time;

        public TimeSpan Time
        {
            get => _time;

            set
            {
                double minutes = value.TotalMinutes;
                if (minutes < 30)
                    _time = TimeSpan.FromMinutes(30);
                else if (minutes > 180)
                    _time = TimeSpan.FromMinutes(180);
                else
                    _time = value;
            }

        }
        public int No_of_Questions { get; set; }
        public Subject Subject { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; } 
        public Answer RightAnswer { get; set; }

        #region Constructor
        public Exam(TimeSpan time, int no_of_Questions)
        {
            Time = time;
            No_of_Questions = no_of_Questions;
            Questions = new List<Question>();
        }
        #endregion
        public abstract void CreateExam();
        public abstract void ShowExam();
    }
}