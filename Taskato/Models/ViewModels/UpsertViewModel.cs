using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskato.Models.ViewModels
{
    public class UpsertViewModel
    {
        public Tasks Tasks { get; set; }

        public IEnumerable<SelectListItem> Priority { get; set; }

    }
}
