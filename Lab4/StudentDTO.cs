using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class StudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public List<ExamDTO> Exams { get; set; }

        public StudentDTO() { }

        public StudentDTO(Student student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            EducationLevel = student.EducationLevel;
            Exams = new List<ExamDTO>(student.Exams.Select(e => new ExamDTO(e)));
        }

        public Student ToStudent()
        {
            var student = new Student(FirstName, LastName, BirthDate, EducationLevel);
            foreach (var exam in Exams)
            {
                student.AddExam(exam.ToExam());
            }
            return student;
        }
    }

    public class ExamDTO
    {
        public string ExamName { get; set; }
        public int Grade { get; set; }
        public DateTime ExamDate { get; set; }

        public ExamDTO() { }

        public ExamDTO(Exam exam)
        {
            ExamName = exam.ExamName;
            Grade = exam.Grade;
            ExamDate = exam.ExamDate;
        }

        public Exam ToExam()
        {
            return new Exam(ExamName, Grade, ExamDate);
        }
    }
}
