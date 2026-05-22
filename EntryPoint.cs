namespace CourseManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Встановлюємо кодування UTF-8 для коректного відображення кирилиці в консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CourseManager manager = new CourseManager();

            // 1. Створення студентів
            Student student1 = new Student("S101", "Іванченко Дмитро Петрович", "КН-22");
            Student student2 = new Student("S102", "Мельник Ольга Володимирівна", "КН-21");

            // 2. Реєстрація в системі
            manager.RegisterStudent(student1);
            manager.RegisterStudent(student2);

            // 3. Запис на курси
            manager.EnrollStudentInCourse(student1, "Вступ до C#", "Синтаксис та типи даних");
            manager.EnrollStudentInCourse(student1, "Бази даних", "Реляційна модель");
            manager.EnrollStudentInCourse(student2, "Вступ до C#", "Синтаксис та типи даних");

            // 4. Симуляція навчального процесу (оновлення прогресу)
            Console.WriteLine("\n--- Процес навчання ---");
            manager.UpdateProgress(student1, "Вступ до C#", "Умовні оператори та цикли", 15.5);
            manager.UpdateProgress(student1, "Вступ до C#", "Класи та об'єкти", 20.0);
            manager.UpdateProgress(student2, "Вступ до C#", "Умовні оператори та цикли", 18.0);
            manager.UpdateProgress(student1, "Бази даних", "Проєктування схем (ERD)", 12.0);

            // 5. Виведення фінального звіту
            manager.DisplayAllReports();

            Console.ReadKey();
        }
    }
}