using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTodoApplication.Models
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string OwnerId { get; set; }
        public string ItemDescription { get; set; }

        public bool IsCompleted { get; set; }
    }
}
