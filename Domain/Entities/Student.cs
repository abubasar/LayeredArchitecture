namespace Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Grade { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
