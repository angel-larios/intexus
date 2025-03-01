namespace TaskManager.Application.DTOs
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
