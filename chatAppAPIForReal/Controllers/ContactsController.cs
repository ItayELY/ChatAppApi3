#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChatAppMVC.Models;
using chatAppAPIForReal.Models;
using chatAppAPIForReal;
using chatAppAPIForReal.Controllers;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace ChatAppMVC.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IService<User> uService;
        private readonly ChatService cService;
        private Context context;

        public ContactsController()
        {
            uService = new UserService();
            cService = new ChatService();
            context = new Context();

        }

        // GET: Contacts
        [HttpGet]
        //[Route("/api/contacts")]
        public IActionResult Get(string userId)
        {

            /* string currentUser = HttpContext.Session.GetString("id");
             var q = from currentUserContacts in service.Contact
                     where currentUserContacts.UserId == currentUser
                     select currentUserContacts;
             List<Contact> contactsList = q.ToList();
             return Json(contactsList);*/
            List<Contact> contacts = context.Contacts.ToList();
            List<Contact> relevant = contacts.Where(c => c.UserId == userId).ToList();
            foreach (Contact contact in relevant)
            {
                Message m = cService.GetLastMessage(userId, contact.Id);
                contact.LastMessageContent = m.Content;
                contact.LastMessageDate = m.Created;
            }
            return Ok(relevant);
        }

        [HttpGet]
        [Route("/api/contacts/{id}")]
        public IActionResult GetSpecific(string userId, string id)
        {

            /* string currentUser = HttpContext.Session.GetString("id");
             var q = from currentUserContacts in service.Contact
                     where currentUserContacts.UserId == currentUser
                     select currentUserContacts;
             List<Contact> contactsList = q.ToList();
             return Json(contactsList);*/
            List<Contact> contacts = context.Contacts.ToList();
            var cont = contacts.Find(x => x.Id == id);
            if(cont == null)
            {
                return NotFound();
            }
            Message last = cService.GetLastMessage(userId, id);
            if(last != null)
            {
                cont.LastMessageContent = last.Content;
                cont.LastMessageDate = last.Created;
            }
           
            return Ok(cont);
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



        [HttpPost]
        [Route("/api/contacts/{id}")]
        public IActionResult Contact([Bind("Id,Name,Server")] Contact contact, string userId)
        {
            var curUser = uService.GetById(userId);
          //  List<string> inter = new List<string>();
           // inter.Add(userId);
           // inter.Add(contact.Id);
            List<Message> messages = new List<Message>();
            Chat c = cService.GetBy2Users(userId, contact.Id);
            if(c == null)
            {
                Chat cNew = new Chat(userId + " " + contact.Id, userId, contact.Id);
                cService.Create(cNew);

            }
            if (context.Contacts.ToList().Any(x => x.UserId.Equals(contact.UserId) && x.Id == contact.Id))
            {
                return StatusCode(201);
            }
            User u =uService.GetById(contact.Id);
            if(u != null)
            {
                contact.Server = u.Server;
                contact.LastMessageContent = "";
                contact.LastMessageDate = "";
                context.Contacts.Add(contact);
                context.SaveChanges();
                return StatusCode(201);
            }
            return StatusCode(404);
            
        }

        [HttpPut]
        [Route("/api/contacts/{id}")]
        public IActionResult PutSpecific([Bind("Name,Server")] Contact con, string id, string userId)
        {
            con.Id = id;
            var curUser = uService.GetById(userId);
            curUser.UpdateContact(id, con);
            return StatusCode(204);
        }


        [HttpDelete]
        [Route("/api/contacts/{id}")]
        public IActionResult DeleteSpecific(string id, string userId)
        {
            User user = uService.GetById(userId);
            // Contact c = user.Contacts.Find(x => x.Id == id);
            Contact c = null;
            user.RemoveContact(c);
            return StatusCode(204);
        }




        [HttpGet]
        [Route("/api/contacts/{id}/messages")]
        public IActionResult GetAllMessages(string userId, string id)
        {
            Chat c = cService.GetBy2Users(id, userId);
            List<Message> messages = context.messages.ToList();
            List<Message> relevant = new List<Message>();
            if (c != null)
            {
                relevant = messages.Where(m => m.ChatId == c.Id).ToList();

            }

            foreach (Message m in relevant)
            {
                if (m.SentBy == userId)
                {
                    m.Sent = true;
                }
                else
                {
                    m.Sent = false;
                }

            }
            return Ok(relevant);
    
        }


        [HttpPost]
        [Route("/api/contacts/{id}/messages")]
        public async Task<IActionResult> PostNewMessage([FromBody] string content, string userId, string id)
        {
            Chat c = cService.GetBy2Users(id, userId);
            
            context.messages.Add(new Message(content, DateTime.Now.ToString("MM-dd-yy, hh-mm"), true, userId, c.Id));
            context.SaveChanges();
            TransferObj obj = new TransferObj();
            obj.Content = content;
            obj.From = userId;
            obj.To = id;
            await SendMessageByFirebase(obj);
            return StatusCode(201);
        }



        [HttpGet]
        [Route("/api/contacts/{id}/messages/{id2}")]
        public IActionResult GetSpecificMessage(string userId, string id, string id2)
        {
            Chat c = cService.GetBy2Users(id, userId);
            List<Message> messages = context.messages.ToList();

            Message m =  messages.Find(x => (x.Id == Int32.Parse(id2)) && x.ChatId.Equals(c.Id));
            return Ok(c);

        }

        [HttpPut]
        [Route("/api/contacts/{id}/messages/{id2}")]
        public IActionResult PutSpecificMessage([FromBody] string content, string userId, string id, string id2)
        {
            Chat c = cService.GetBy2Users(id, userId);
           // Message m = c.Messages.Find(x => x.Id == Int32.Parse(id2));
            //m.Content = content;
            return StatusCode(204);
        }

        [HttpDelete]
        [Route("/api/contacts/{id}/messages/{id2}")]
        public IActionResult DeleteSpecificMessage(string userId, string id, string id2)
        {
            Chat c = cService.GetBy2Users(id, userId);
          //  Message m = c.Messages.Find(x => x.Id == Int32.Parse(id2));
          //  c.Messages.Remove(m);
            return StatusCode(204);
        }




        [HttpPost]
        [Route("/api/invitation")]
        public IActionResult Invite([Bind("From, To, Server")] Invitation invitation)
        {
            User user = uService.GetById(invitation.To);
            if (user != null)
            {
                Contact contact = new Contact(user.Id, invitation.From, invitation.From, invitation.Server);
                context.Contacts.Add(contact);
                context.SaveChanges();

                return StatusCode(201);
            }
            else
            {
                return StatusCode(422);

            }
        }

        [HttpPost]
        [Route("/api/transfer")]
        public async Task<IActionResult> Tranfer([FromBody] TransferObj transferObj)
        {
            User receiver = uService.GetById(transferObj.To);
            User sender = uService.GetById(transferObj.From);
            if (sender == null)
            {
                uService.Create(new Models.User(transferObj.From, transferObj.From, "elad"));
            }
            if (receiver == null) return NotFound();

            if (sender != null && receiver != null)
            {
                Chat ch = cService.GetBy2Users(receiver.Id, sender.Id);

                Message m = new Message(transferObj.Content, DateTime.Now.ToString("MM-dd-yy, hh-mm"), true, transferObj.From, ch.Id);
                context.messages.Add(m);
                await SendMessageByFirebase(transferObj);
                context.SaveChanges();

                return StatusCode(201);
            }
            else
            {
                return StatusCode(422);

            }
        }

        private async Task SendMessageByFirebase(TransferObj transfer)
        {
            if (transfer == null)
                return;
            if (!TokenController.IdToFirebase.ContainsKey(transfer.To))
                return;
            var toToken = TokenController.IdToFirebase[transfer.To];

            if (FirebaseApp.DefaultInstance == null)
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile("secureKey.json")
                });

            FirebaseAdmin.Messaging.Message msg = new FirebaseAdmin.Messaging.Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "Sent By:", transfer.From},
                    {"Content:", transfer.Content }
                },
                Token = toToken,
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Title = "New Message",
                    Body = transfer.Content
                }
            };
            var response = await FirebaseAdmin.Messaging.FirebaseMessaging.DefaultInstance.SendAsync(msg);

        }










        /*
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
        public async Task<IActionResult> Messages(string contactId, [Bind("content, created, sent")] Message message)
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
        }
        */

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
