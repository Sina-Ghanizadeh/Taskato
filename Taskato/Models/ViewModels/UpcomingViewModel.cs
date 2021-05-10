using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taskato.Models.ViewModels
{
    public class UpcomingViewModel
    {
        [Required]
        [DataType("Date")]
        public DateTime Date { get; set; }
    }
}
