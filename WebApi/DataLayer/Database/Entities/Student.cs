namespace ChatInteractionService.Database.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SchoolGeneratedId { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Class { get; set; }  // e.g., Prep, Nursery
        public DateTime DOB { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string PhoneNumber { get; set; }
    }
}
