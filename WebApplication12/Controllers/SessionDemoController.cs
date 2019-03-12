using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication12.Controllers
{
    public class Counter
    {
        public int Number { get; set; }
    }

    public class SessionDemoController : Controller
    {
        public ActionResult Index()
        {
            Counter c = null;
            if (Session["counter"] != null)
            {
                c = (Counter) Session["counter"];
            }
            else
            {
                c = new Counter();
                Session["counter"] = c;
            }

            c.Number++;
            return View(c);
        }

        public ActionResult ViewForm()
        {
            NameClass nc = new NameClass
            {
                Name = (string) Session["name"]
            };
            return View(nc);
        }

        public ActionResult FormPost(string name)
        {
            Session["name"] = name;
            
            return Redirect("/sessiondemo/viewform");
        }
    }

    public class NameClass
    {
        public string Name { get; set; }
    }
}