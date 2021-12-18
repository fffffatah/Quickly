using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Task
{
    public class CreateTaskModel
    {
        public long Id { get; set; }
        [Required]
        public string? TaskTitle { get; set; }
        [Required]
        public string? TaskDescription { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Required]
        public DateTime? Deadline { get; set; }
        [Required]
        public string? TaskStatus { get; set; }
        [Required]
        public string? TaskType { get; set; }
        [Required]
        public long? ProjectId { get; set; }
        [Required]
        public long? AssignedTo { get; set; }
    }
}
