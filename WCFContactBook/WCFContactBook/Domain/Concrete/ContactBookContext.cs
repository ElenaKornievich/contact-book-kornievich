using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WCFContactBook.Domain.Concrete
{
    public class ContactBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}