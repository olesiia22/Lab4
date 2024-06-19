using System;

namespace MyLibrary
{
    public class Exam
    {
        private string _examName;
        private int _grade;
        private DateTime _examDate;

        public Exam(string examName, int grade, DateTime examDate)
        {
            _examName = examName;
            _grade = grade;
            _examDate = examDate;
        }

        public string ExamName => _examName;
        public int Grade => _grade;
        public DateTime ExamDate => _examDate;

        public override string ToString()
        {
            return $"{_examName}: Grade: {_grade}, Date: {_examDate.ToShortDateString()}";
        }
    }
}
