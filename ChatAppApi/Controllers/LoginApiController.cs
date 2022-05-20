#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatAppMVC.Data;
using ChatAppMVC.Models;

namespace ChatAppMVC.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class LoginApiController : Controller
    {
        private readonly ChatAppMVCContext _context;

        public LoginApiController(ChatAppMVCContext context)
        {
            _context = context;

        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        

        


        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        public async Task<IActionResult> Login([Bind("id,password")] User user)
        {
            if (ModelState.IsValid)
            {
                var q = _context.User.Where(u => u.Id == user.Id && u.Password == user.Password);
                if (q.Any())
                {
                    HttpContext.Session.SetString("id", q.First().Id);
                    return Json(q.First());
                }
                return Json("{}");
            }
            return BadRequest();
        }
        

        /*
        [HttpGet]
        public async Task<IActionResult> contacts()
        {
            if (HttpContext.Session.GetString("id") == null)
                return RedirectToAction("Login", "Users");
            string id = HttpContext.Session.GetString("id");
            var q = from u in _context.User
                    where u.id == id
                    select u.contacts;

            return Json(q);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> contacts([Bind("id,name, server")] Contact contact)
        {

            if (HttpContext.Session.GetString("id") == null)
                return RedirectToAction("Login", "Users");
            if (ModelState.IsValid)
            {
                var q = from u in _context.User
                        where u.id == HttpContext.Session.GetString("id")
                        select u;
                if (q.Count() < 0)
                {
                    ViewData["Error"] = "no user";
                }
                
                else
                {
                    contact.Userid = HttpContext.Session.GetString("id");
                    _context.Contact.Add(contact);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
            }
            return Json("{}");
        }
       // public async Task<IActionResult> messages(string id, )
            // GET: Users/Edit/5
            public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,name,password")] User user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.id == id);
        }
        */
    }
}
