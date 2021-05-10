using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskato.Data;
using Taskato.Models;
using Taskato.Models.ViewModels;

namespace Taskato.Controllers
{
    public class TasksController : Controller
    {
        private readonly DatabaseContext _context;

        public TasksController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            
            List<Tasks> Task = _context.Tasks.Include(t => t.Priority).Where(u => u.IsCompleted == false && u.TaskDate == DateTime.Today).ToList();
          
            return View(Task);

        }

        public IActionResult Complete(int id)
        {

            var task = _context.Tasks.Find(id);
            task.IsCompleted = !task.IsCompleted;
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {

            var task = _context.Tasks.Find(id);

            _context.Tasks.Remove(task);
            _context.SaveChanges();


            return RedirectToAction("Index");

        }



        public IActionResult Upsert(int? id)
        {

            UpsertViewModel model = new UpsertViewModel();
            model.Priority = _context.Priorities.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            });
            if (id == null)
            {
                return View(model);

            }

            model.Tasks = _context.Tasks.FirstOrDefault(u => u.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(UpsertViewModel model)
        {
            if (model.Tasks.Id == 0)
            {
                //this is Create
                model.Tasks.CreatedDate = DateTime.Now;
                _context.Tasks.Add(model.Tasks);
            }
            else
            {
                //this is Update
                _context.Tasks.Update(model.Tasks);

            }


            _context.SaveChanges();
            return RedirectToAction(nameof(Index));




        }


        [HttpPost]
        public IActionResult Upcoming(UpcomingViewModel model) 
        {
            if (model != null)
            {
                List<Tasks> task = _context.Tasks.Include(t => t.Priority).Where(u => u.TaskDate == model.Date).ToList();
                return View("ShowTask", task);
            }

            return View(model);
        }
       
         public IActionResult Upcoming( ) 
        {
            UpcomingViewModel model = new UpcomingViewModel()
            {
                Date = DateTime.Today
            };
           
            return View(model);
        }
         
        }
       
    }

