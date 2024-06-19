using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MyLibrary;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Генерація випадкових студентів
            var randomStudents = GenerateRandomStudents(10);
            var dtoList = randomStudents.Select(s => new StudentDTO(s)).ToList();

            // Серіалізація в JSON
            string jsonFilePath = "students.json";
            SerializeToJsonFile(dtoList, jsonFilePath);

            // Десеріалізація з JSON
            var deserializedStudents = DeserializeFromJsonFile(jsonFilePath);
            foreach (var student in deserializedStudents)
            {
                Console.WriteLine(student);
            }
        }

        static List<Student> GenerateRandomStudents(int count)
        {
            var random = new Random();
            var firstNames = new[] { "John", "Jane", "Alex", "Emily", "Chris", "Pat" };
            var lastNames = new[] { "Smith", "Johnson", "Brown", "Williams", "Jones", "Garcia" };
            var educationLevels = Enum.GetValues(typeof(EducationLevel)).Cast<EducationLevel>().ToArray();
            var students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                var firstName = firstNames[random.Next(firstNames.Length)];
                var lastName = lastNames[random.Next(lastNames.Length)];
                var birthDate = DateTime.Now.AddYears(-random.Next(18, 25)).AddDays(random.Next(365));
                var educationLevel = educationLevels[random.Next(educationLevels.Length)];
                var student = new Student(firstName, lastName, birthDate, educationLevel);

                for (int j = 0; j < random.Next(1, 6); j++)
                {
                    var examName = $"Exam{j + 1}";
                    var grade = random.Next(60, 101);
                    var examDate = DateTime.Now.AddDays(-random.Next(30, 365));
                    student.AddExam(new Exam(examName, grade, examDate));
                }

                students.Add(student);
            }

            return students;
        }

        static void SerializeToJsonFile(List<StudentDTO> students, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(students, options);
            File.WriteAllText(filePath, jsonString);
        }

        static List<Student> DeserializeFromJsonFile(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var dtoList = JsonSerializer.Deserialize<List<StudentDTO>>(jsonString);
            return dtoList.Select(dto => dto.ToStudent()).ToList();
        }
    }
}
