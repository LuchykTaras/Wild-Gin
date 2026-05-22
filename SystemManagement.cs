namespace CourseManagementSystem
{
    public class CourseManager
    {
        // Основне сховище даних за умовою завдання
        private readonly Dictionary<Student, List<CourseProgress>> _repository;

        public CourseManager()
        {
            _repository = new Dictionary<Student, List<CourseProgress>>();
        }

        // Додати нового студента в систему
        public void RegisterStudent(Student student)
        {
            if (!_repository.ContainsKey(student))
            {
                _repository.Add(student, new List<CourseProgress>());
                Console.WriteLine($"[Система]: Студента {student.FullName} успішно зареєстровано.");
            }
            else
            {
                Console.WriteLine($"[Помилка]: Студент з ID {student.Id} вже існує.");
            }
        }

        // Записати студента на курс
        public void EnrollStudentInCourse(Student student, string courseName, string startingTopic)
        {
            if (_repository.TryGetValue(student, out var progressList))
            {
                // Перевірка, чи студент вже не записаний на цей курс
                if (progressList.Exists(p => p.CourseName.Equals(courseName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"[Помилка]: {student.FullName} вже вивчає курс \"{courseName}\".");
                    return;
                }

                progressList.Add(new CourseProgress(courseName, 0.0, startingTopic));
                Console.WriteLine($"[Система]: {student.FullName} записаний на курс \"{courseName}\".");
            }
            else
            {
                Console.WriteLine("[Помилка]: Студента не знайдено в системі. Спочатку зареєструйте його.");
            }
        }

        // Оновити прогрес (завершити тему та нарахувати бали)
        public void UpdateProgress(Student student, string courseName, string nextTopic, double scoreGained)
        {
            if (_repository.TryGetValue(student, out var progressList))
            {
                var course = progressList.Find(p => p.CourseName.Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (course != null)
                {
                    string oldTopic = course.CurrentTopic;
                    course.CompleteCurrentTopic(nextTopic, scoreGained);
                    Console.WriteLine($"[Прогрес]: {student.FullName} завершив тему \"{oldTopic}\" у курсі \"{courseName}\". Нараховано {scoreGained} балів.");
                }
                else
                {
                    Console.WriteLine($"[Помилка]: Студент не записаний на курс \"{courseName}\".");
                }
            }
        }

        // Вивести звіт про прогрес усіх студентів
        public void DisplayAllReports()
        {
            Console.WriteLine("\n================ ЗВІТ ПРО УСПІШНІСТЬ СТУДЕНТІВ ================");
            foreach (var kvp in _repository)
            {
                Student student = kvp.Key;
                List<CourseProgress> courses = kvp.Value;

                Console.WriteLine($"\nСтудент: {student}");
                if (courses.Count == 0)
                {
                    Console.WriteLine("  > Не записаний на жоден курс.");
                    continue;
                }

                foreach (var course in courses)
                {
                    Console.WriteLine($"  -> {course}");
                    if (course.CompletedTopics.Count > 0)
                    {
                        Console.WriteLine($"     Завершені теми: {string.Join(", ", course.CompletedTopics)}");
                    }
                }
            }
            Console.WriteLine("===============================================================\n");
        }
    }
}