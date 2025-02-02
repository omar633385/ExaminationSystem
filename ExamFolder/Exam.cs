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
        public Question[] Questions { get; set; }
        public abstract void ShowExam();
    }
}