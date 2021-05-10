using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Taskato.Models
{
    public class Tasks
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [DataType("Date")]
        public DateTime CreatedDate  { get; set; }

        [Required]
        [DataType("Date")]
        public DateTime TaskDate { get; set; }

        public string Description { get; set; }


        public bool IsCompleted { get; set; }



        [ForeignKey("Priority")]
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

    }
}
