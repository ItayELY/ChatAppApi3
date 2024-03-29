﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChatAppMVC.Models;

namespace ChatAppMVC.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MessagesControllerAPI : Controller
    {
        private readonly IService<User> _userService;
        private readonly IService<Chat> _chatService;

        public MessagesControllerAPI()
        {
            _userService = new UserService();
            _chatService = new ChatService();
        }

        /* // GET: Messages
         [HttpGet]
         public async Task<IActionResult> Index()
         {
             var userId = HttpContext.Session.GetString("id");

             return Json(await _context.Message.ToListAsync());
         }

         // GET: Messages/Details/5
         [HttpGet("{id}")]
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var message = await _context.Message
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (message == null)
             {
                 return NotFound();
             }

             return Json(message);
         }

         // GET: Messages/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Messages/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("id,content,created,sent")] Message message)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(message);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(message);
         }

         // GET: Messages/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var message = await _context.Message.FindAsync(id);
             if (message == null)
             {
                 return NotFound();
             }
             return View(message);
         }

         // POST: Messages/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("id,content,created,sent")] Message message)
         {
             if (id != message.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(message);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!MessageExists(message.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(message);
         }

         // GET: Messages/Delete/5
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var message = await _context.Message
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (message == null)
             {
                 return NotFound();
             }

             return View(message);
         }

         // POST: Messages/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             var message = await _context.Message.FindAsync(id);
             _context.Message.Remove(message);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         private bool MessageExists(int id)
         {
             return _context.Message.Any(e => e.Id == id);
         }*/
        //}
    }
}