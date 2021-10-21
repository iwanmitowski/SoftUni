using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> classroom;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            this.classroom = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count => GetStudentsCount();


        public string RegisterStudent(Student student)
        {
            if (this.Count == this.Capacity)
            {
                return "No seats in the classroom";
            }

            classroom.Add(student);

            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var studentToDismiss = GetStudent(firstName, lastName);

            if (studentToDismiss == null)
            {
                return "Student not found";
            }

            classroom.Remove(studentToDismiss);

            return $"Dismissed student {firstName} {lastName}";
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return classroom.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public string GetSubjectInfo(string subject)
        {
            var sb = new StringBuilder();

            var classRoom = classroom.Where(x => x.Subject == subject).ToList();

            if (!classRoom.Any())
            {
                return "No students enrolled for the subject";
            }

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in classRoom)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().Trim();
        }
        public int GetStudentsCount()
        {
            return this.classroom.Count;
        }
    }
}
