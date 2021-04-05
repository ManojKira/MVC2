using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //Authorise user
        [HttpPost]
        public ActionResult Authorize(user _user)
        {
            bool isValid = ValidateUser(_user);
            if (isValid)
            {
                Session["UserContext"] = _user;
                return RedirectToAction("Create", "Notes");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public bool ValidateUser(user _user)
        {
            string query = "select 1 from users where userName = '" + _user.userName + "' and psword = '" + _user.psword + "'";
            using (SqlConnection con = new SqlConnection("data source=.; database=webApp; integrated security=SSPI"))
            {
                SqlDataAdapter sde = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}