using System;
using Phonebook.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Data;

namespace Phonebook.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        public IActionResult Create (Contact contact)
        {
            DataAccess.Contacts.Add(contact);

            return RedirectToAction("Index", "Home");
        }
    }
}