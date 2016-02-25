using System;
using System.Web.Mvc;

namespace TrustMoi.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult ManageUsers()
        {
            return View();
        }

        public ActionResult ManageQuestions()
        {
            return View();
        }

        public ActionResult ManageRoles()
        {
            throw new NotImplementedException();
        }
    }
}
