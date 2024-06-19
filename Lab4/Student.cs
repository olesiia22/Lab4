using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary
{
    public class Student : Person
    {
        private EducationLevel _educationLevel;
        private List<Exam> _exams;

        public Student(string firstName, string lastName, DateTime birthDate, EducationLevel educationLevel)
            : base(firstName, lastName, birthDate)
        {
            _educationLevel = educationLevel;
            _exams = new List<Exam>();
        }

        public EducationLevel EducationLevel => _educationLevel;
        public List<Exam> Exams => _exams;

        public void AddExam(Exam exam)
        {
            _exams.Add(exam);
        }

        public override string ToString()
        {
            var examsInfo = string.Join(", ", _exams.Select(e => e.ToString()));
            return $"{base.ToString()}, Education Level: {_educationLevel}, Exams: [{examsInfo}]";
        }

        public string ToStringShort()
        {
            double averageGrade = _exams.Any() ? _exams.Average(e => e.Grade) : 0;
            return $"{LastName}, Average Grade: {averageGrade:F2}";
        }
    }
}
