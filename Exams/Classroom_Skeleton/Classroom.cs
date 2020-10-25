using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Capacity <= Count)
            {
                
                return $"No seats in the classroom";
            }
            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            bool ifExist = students.Any(s => s.FirstName == firstName && s.LastName == lastName);
            if (! ifExist)
            {
                return $"Student not found";
            }
            var studenttToRemove = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            
            students.Remove(studenttToRemove);

            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            if (!students.Any(s => s.Subject == subject))
            {
                return "No students enrolled for the subject";
            }

            List<Student> bySubject = new List<Student>();

            foreach (var stud in students)
            {
                if (stud.Subject == subject)
                {
                    bySubject.Add(stud);
                }
            }

            StringBuilder sb = new StringBuilder();
            
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

            foreach (var item in bySubject)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            if (!students.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return null;
            }
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
