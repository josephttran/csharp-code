namespace RazorPagesWithAdminPages.Models
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string OwnerId { get; set; }
        public string ItemDescription { get; set; }
        public bool IsCompleted { get; set; }
    }
}
