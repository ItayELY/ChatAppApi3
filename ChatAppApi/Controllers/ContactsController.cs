﻿#nullable disable
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
        private readonly IService<User> uService;
        private readonly IService<Chat> cService;

        public ContactsController()
        {
            uService = new UserService();
            cService = new ChatService();

        }

        // GET: Contacts
        [HttpGet]
        [Route("/api/contacts/?userid={user}")]
        public IActionResult Get(string user)
        {

            /* string currentUser = HttpContext.Session.GetString("id");
             var q = from currentUserContacts in service.Contact
                     where currentUserContacts.UserId == currentUser
                     select currentUserContacts;
             List<Contact> contactsList = q.ToList();
             return Json(contactsList);*/
            User x = uService.GetById(user);
            return Ok(x.Contacts);
        }

        // GET: Contacts
        [HttpGet]
        [Route("/api/contacts/default")]
        public IActionResult Default()
        {

           
            return Ok("Hi!!!!");
        }


        /*[HttpGet("{id}")]
        public async Task<IActionResult> Contact(string id)
        {
            var q = from currentUserContact in service.Contact
                    where currentUserContact.UserId == HttpContext.Session.GetString("id")
                    && currentUserContact.ContactId == id
                    select currentUserContact;
            if(q.Count() == 0)
            {
                return Json(null);
            }
            return Json(q.First());
        }*/

        /*

                [HttpPost]
                public async Task<IActionResult> Contact([Bind("Userid, Contactid,name,Server")] Contact contact)
                {

                    if (ModelState.IsValid)
                    {
                        var q = from u in service.Contact
                                where u.ContactId == contact.ContactId && u.UserId == contact.UserId
                                select u;
                        if (q.Count() > 0)
                        {
                            return BadRequest();
                        }
                        else
                        {
                            service.Contact.Add(contact);
                            await service.SaveChangesAsync();
                            return Created(string.Format("/api/UsersApi/{0}", contact.Id), contact);
                        }
                    }
                    return BadRequest();
                }

                [HttpGet("{id}/Messages")]
                public async Task<IActionResult> Messages(string id)
                {
                    string curUs = HttpContext.Session.GetString("id");
                    var q = from currentUserContact in service.Contact
                            where currentUserContact.UserId == curUs
                            && currentUserContact.ContactId == id
                            select currentUserContact;
                    if (q.Count() == 0)
                    {
                        return Json("");
                    }
                    int connection = q.First().Id;
                    var q2 = from u in service.Message
                             where u.Contactid == connection
                             select u;
                    return Json(q2);
                }
                [HttpPost("{contactId}/Messages")]
                public async Task<IActionResult> Messages(string contactId, [Bind("content, created, sent")]  Message message )
                {
                    string userr = HttpContext.Session.GetString("id");

                    if (ModelState.IsValid)
                    {
                        var q = from u in service.Contact
                                where u.UserId == userr && u.ContactId == contactId
                                select u;
                        if (q.Count() == 0)
                        {
                            return BadRequest();
                        }
                        else
                        {
                            message.ContactId = q.First().Id;
                                service.Message.Add(message);
                            await service.SaveChangesAsync();
                            return Created(string.Format("/api/UsersApi/{0}", message.Id), message);
                        }
                    }
                    return BadRequest();
                }*/

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
