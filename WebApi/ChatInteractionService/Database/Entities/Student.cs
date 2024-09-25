namespace ChatInteractionService.Database.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string ClassName { get; set; }

        public List<ActivityHistory> ActivityHistories { get; set; }
    }
}
