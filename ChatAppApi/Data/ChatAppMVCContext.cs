#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatAppMVC.Models;

namespace ChatAppMVC.Data
{
    public class ChatAppMVCContext : DbContext
    {
        public ChatAppMVCContext (DbContextOptions<ChatAppMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ChatAppMVC.Models.User> User { get; set; }

        public DbSet<ChatAppMVC.Models.Contact> Contact { get; set; }

        public DbSet<ChatAppMVC.Models.Message> Message { get; set; }
    }
}
