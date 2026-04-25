namespace TaskApi.Models;
public class TaskIteam
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description{ get; set; }= string.Empty;
    public bool IsCompleted { get; set; } = false;
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public string Priority { get; set; } = "Normal";
}