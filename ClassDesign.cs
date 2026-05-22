using System;
using System.Collections.Generic;

namespace CourseManagementSystem
{
    // Клас, що описує студента
    public class Student
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }

        public Student(string id, string fullName, string group)
        {
            Id = id;
            FullName = fullName;
            Group = group;
        }

        // Перевизначення Equals для коректної роботи Dictionary
        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return Id == other.Id; // Ідентифікуємо студента за унікальним ID
            }
            return false;
        }

        // Перевизначення GetHashCode разом із Equals
        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return $"{FullName} (ID: {Id}, Група: {Group})";
        }
    }

    // Клас, що відображає прогрес у конкретному курсі
    public class CourseProgress
    {
        public string CourseName { get; set; }
        public double CurrentScore { get; set; }
        public List<string> CompletedTopics { get; set; }
        public string CurrentTopic { get; set; }

        public CourseProgress(string courseName, double currentScore, string currentTopic)
        {
            CourseName = courseName;
            CurrentScore = currentScore;
            CurrentTopic = currentTopic;
            CompletedTopics = new List<string>();
        }

        public void CompleteCurrentTopic(string nextTopic, double scoreGained)
        {
            if (!string.IsNullOrEmpty(CurrentTopic))
            {
                CompletedTopics.Add(CurrentTopic);
            }
            CurrentTopic = nextTopic;
            CurrentScore += scoreGained;
        }

        public override string ToString()
        {
            return $"Курс: \"{CourseName}\" | Поточний бал: {CurrentScore} | Поточна тема: {CurrentTopic} | Завершено тем: {CompletedTopics.Count}";
        }
    }
}