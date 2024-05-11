namespace ASP.NET_Core_TODO_List.Models
{
    public class TodoItemViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
    }
}
