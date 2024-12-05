using ContactManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ContactManagementSystem.Logic
{
    public class clsContact
    {
        private DataAccess.DataAccess _objDataAccess;
        public clsContact()
        {
            _objDataAccess = new DataAccess.DataAccess();
        }
        public List<Contact> RetriveContacts()
        {
            DataTable dt = _objDataAccess.Retrieve(SQLQueries.SelectQuery);
            List<Contact> contactList = new List<Contact>();
            foreach (DataRow dr in dt.Rows)
            {
                contactList.Add(new Contact
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    Name = Convert.ToString(dr["Name"]),
                    EmailId = Convert.ToString(dr["EmailId"]),
                    PhoneNumber = Convert.ToInt64(dr["PhoneNumber"]),
                    Address = Convert.ToString(dr["Address"])
                });
            }
            return contactList;
        }

        public void CreateContact(Contact objContact)
        {
            string sqlQuery = string.Format(SQLQueries.InsertQuery, objContact.Name, objContact.EmailId, objContact.PhoneNumber, objContact.Address);
            _objDataAccess.Insert(sqlQuery);
        }

        public void DeleteContact(Contact objContact)
        {
            string sqlQuery = string.Format(SQLQueries.DeleteQuery, objContact.Id);
            _objDataAccess.Delete(sqlQuery);
        }

        public void UpdateContact(Contact objContact)
        {
            string sqlQuery = string.Format(SQLQueries.UpdateQuery, objContact.Id, objContact.Name, objContact.EmailId, objContact.PhoneNumber, objContact.Address);
            _objDataAccess.Update(sqlQuery);
        }
    }
}