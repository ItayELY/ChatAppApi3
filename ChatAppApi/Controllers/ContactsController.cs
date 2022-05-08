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
    public class ContactsController : Controller
    {
        private readonly ChatAppMVCContext _context;

        public ContactsController(ChatAppMVCContext context)
        {
            _context = context;

        }

        // GET: Contacts
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = new List<Contact>();
            Contact c = new Contact { id = "itay", name = "itti", server = "server", };
            contacts.Add(c);
            User u = new User { id = "u", password = "u", contacts = contacts, name = "u" };
            var user = await _context.User.FindAsync("u");
            if (user == null)
            {
                _context.Add(u);
                await _context.SaveChangesAsync();
            }
            var q = from currentUserContacts in _context.Contact
                    where currentUserContacts.Userid == HttpContext.Session.GetString("id")
                    select currentUserContacts;
            List<Contact> contactsList = q.ToList();
            return Json(contactsList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getContacts(string id)
        {
            var q = from currentUserContact in _context.Contact
                    where currentUserContact.Userid == HttpContext.Session.GetString("id")
                    && currentUserContact.id == id
                    select currentUserContact;
            if(q.Count() == 0)
            {
                return Json(null);
            }
            return Json(q.First());
        }


        /*

        // GET: Users/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        */

        [HttpPost]
        public async Task<IActionResult> Register([Bind("id,name,password")] User user)
        {

            if (ModelState.IsValid)
            {
                var q = from u in _context.User
                        where u.id == user.id
                        select u;
                if (q.Count() > 0)
                {
                    return BadRequest();
                    ;
                }
                else
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return Created(string.Format("/api/UsersApi/{0}", user.id), user);
                }
            }
            return BadRequest();


        }

        /*
        public IActionResult Login()
        {

            return View();
        }
        */

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("id,password")] User user)
        {
            if (ModelState.IsValid)
            {
                var q = _context.User.Where(u => u.id == user.id && u.password == user.password);
                if (q.Any())
                {
                    HttpContext.Session.SetString("id", q.First().id);
                    return Json(q);
                }
                return Json("{}");
            }
            return View(user);
        }
        */

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
