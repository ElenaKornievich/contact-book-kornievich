using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFContactBookClient.Proxy;

namespace WCFContactBookClient.Controllers
{
    public class HomeController : Controller
    {
        ContactBookClient client = new ContactBookClient();

        public ActionResult Index(string groupName)
        {
            if(groupName != null)
            {
                return PartialView(client.GetContactsByGroup(groupName));
            }
            return PartialView(client.GetAllContacts());
        }

        public RedirectToRouteResult DeleteContact(int id)
        {
            client.DeleteContact(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult EditContact(int id)
        {
            Contact contact = client.GetAllContacts()
                .Where(x => x.ContactID == id)
                .FirstOrDefault();
            ViewBag.Groups = new SelectList(client.GetAllGroups(), "GroupID", "GroupName", contact.GroupID);
            return PartialView(contact);
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            ViewBag.Groups = new SelectList(client.GetAllGroups(), "GroupID", "GroupName", contact.GroupID);
            client.UpdateContact(contact);
            return PartialView(client.GetAllContacts()
                .Where(x => x.ContactID == contact.ContactID)
                .FirstOrDefault());
        }

        [HttpGet]
        public PartialViewResult CreateContact()
        {
            ViewBag.Groups = new SelectList(client.GetAllGroups(), "GroupID", "GroupName", 0);
            return PartialView();
        }

        [HttpPost]
        public RedirectToRouteResult CreateContact(Contact contact)
        {
            ViewBag.Groups = new SelectList(client.GetAllGroups(), "GroupID", "GroupName", contact.GroupID);
            client.CreateContact(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult CreateGroup()
        {
            return PartialView();
        }

        [HttpPost]
        public RedirectToRouteResult CreateGroup(Group group)
        {
            client.CreateGroup(group);
            return RedirectToAction("Index");
        }
    }
}