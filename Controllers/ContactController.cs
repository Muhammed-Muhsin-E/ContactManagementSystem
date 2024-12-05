using ContactManagementSystem.Logic;
using ContactManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManagementSystem.Controllers
{
    public class ContactController : Controller
    {
        private clsContact _objClsContact;
        public ContactController()
        {
            _objClsContact = new clsContact();
        }

        public ActionResult Contact()
        {
            try
            {
                List<Contact> contactlist = _objClsContact.RetriveContacts();
                return View(contactlist);
            }
            catch 
            {
                throw;
            }
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact objContact)
        {
            try
            {
                _objClsContact.CreateContact(objContact);
                return RedirectToAction("Contact", "Contact");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            List<Contact> contactlist = _objClsContact.RetriveContacts();
            Contact objContact = contactlist.FirstOrDefault(x => x.Id == id);
            if (objContact != null)
            {
                return View(objContact);
            }
            return RedirectToAction("Contact", "Contact");
        }

        [HttpPost]
        public ActionResult Edit(Contact objContact)
        {
            try
            {
                _objClsContact.UpdateContact(objContact);
                return RedirectToAction("Contact", "Contact");
            }
            catch
            {
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            List<Contact> contactlist = _objClsContact.RetriveContacts();
            Contact objContact = contactlist.FirstOrDefault(x => x.Id == id);
            if (objContact != null)
            {
                return View(objContact);
            }
            return RedirectToAction("Contact", "Contact");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteData(int id)
        {
            try
            {
                List<Contact> contactlist = _objClsContact.RetriveContacts();
                Contact objContact = contactlist.FirstOrDefault(x => x.Id == id);
                if (objContact != null)
                {
                    _objClsContact.DeleteContact(objContact);
                }
                return RedirectToAction("Contact", "Contact");
            }
            catch
            {
                throw;
            }
        }
    }
}