namespace CourseManagementWebAPI
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
