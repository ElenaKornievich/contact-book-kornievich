using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity;
using WCFContactBook.Domain.Concrete;

namespace WCFContactBook
{
    public class ContactBook : IContactBook
    {
        ContactBookContext context = new ContactBookContext();

        public void CreateContact(Contact contact)
        {
            context.Entry(contact).State = EntityState.Added;
            context.SaveChanges();
        }

        public void CreateGroup(Group group)
        {
            context.Entry(group).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteContact(int contactID)
        {
            Contact contact = context.Contacts
                .Find(contactID);

            if (contact != null)
            {
                context.Entry(contact).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void DeleteGroup(int groupID)
        {
            Group group = context.Groups
                .Find(groupID);

            if(group != null)
            {
                context.Entry(group).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Contact> GetAllContacts()
        {
            return context.Contacts
                .Include(x => x.Group)
                .ToList();
        }

        public List<Group> GetAllGroups()
        {
            return context.Groups
                .ToList();
        }

        public List<Contact> GetContactsByGroup(string groupName)
        {
            return context.Contacts
                .Include(x => x.Group)
                .Where(x => x.Group.GroupName == groupName)
                .ToList();
        }

        public void UpdateContact(Contact contact)
        {
            context.Entry(contact).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}