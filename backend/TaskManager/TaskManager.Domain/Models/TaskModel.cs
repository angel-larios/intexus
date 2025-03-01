namespace TaskManager.Domain.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public TaskModel() { }

        public TaskModel(string title) 
        {
            Id = Guid.NewGuid();
            Title = title;
            IsCompleted = false;
        }
        public void Complete() => IsCompleted = true;
        public void MarkAsPending() => IsCompleted = false;
    }
}
