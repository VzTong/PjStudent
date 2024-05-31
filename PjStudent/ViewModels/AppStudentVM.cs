namespace PjStudent.ViewModels
{
	public class AppStudentVM
	{
		public int Id { get; set; }
		public string CodeID { get; set; }
		public string FullName { get; set; }
        public int BirthYear { get; set; }
        public string HomeTown { get; set; }
		public string PhoneNumber { get; set; }
		public IFormFile Avatar { get; set; }
	}
}
