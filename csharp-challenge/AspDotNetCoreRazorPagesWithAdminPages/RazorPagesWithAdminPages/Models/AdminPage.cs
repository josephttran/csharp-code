using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesWithAdminPages.Models
{
    public class AdminPage
    {
        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int MaxTodoIsIncompleted { get; set; } = 5;
    }
}
