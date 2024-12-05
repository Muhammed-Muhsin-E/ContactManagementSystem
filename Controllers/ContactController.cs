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
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View();
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
                if (objContact.Name == null)
                {
                    throw new Exception("Name is Required");
                }
                _objClsContact.CreateContact(objContact);
                TempData["Message"] = "New Contact Created Successfully";
                return RedirectToAction("Contact", "Contact");
            }
            catch (Exception ex)
            {
                TempData["CreateExceptionMessage"] = ex.Message;
                return RedirectToAction("Create", "Contact", new { @objContact = objContact });
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
                if (objContact.Name == null)
                {
                    throw new Exception("Name is Required");
                }
                _objClsContact.UpdateContact(objContact);
                TempData["Message"] = "Updated Sucessfully";
                return RedirectToAction("Contact", "Contact");
            }
            catch (Exception ex)
            {
                TempData["EditExceptionMessage"] = ex.Message;
                return RedirectToAction("Edit", "Contact", new { @objContact = objContact });
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
                    TempData["Message"] ="Deleted Successfully";
                }
                return RedirectToAction("Contact", "Contact", new { @id = id });
            }
            catch (Exception ex)
            {
                TempData["DeleteExceptionMessage"] = ex.Message;
                return RedirectToAction("Delete", "Contact");
            }
        }
    }
}