namespace ToDoAPI.ViewModel
{
    public class TasksViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool? iscompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? Priority { get; set; }
    }
}
