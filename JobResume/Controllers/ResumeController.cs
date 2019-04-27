using JobResume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobResume.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult Create()
        {
            getAllLists obj = new getAllLists();
            ViewBag.Cities = obj.getCities();
            ViewBag.Countaries = obj.getCountaries();
            ViewBag.Degrees = obj.getDegrees();
            ViewBag.Institutes = obj.getInstitutes();

            return View();
        }
        [HttpPost]
        public ActionResult Basicinfo()
        {
            string fname = Request["fname"];
            string mname = Request["mname"];
            string lname = Request["lname"];

            string image = Request["image"];
            string date = Request["dob"];
            DateTime dob = Convert.ToDateTime(date);
            string gender = Request["gender"];

            string email = Request["email"];
            string ph1 = Request["ph1"];
            string ph2 = Request["ph2"];

            string address = Request["address"];
            string city = Request["city"];
            string country = Request["country"];

            string objective = Request["objective"];

            string depofint = Request["depoi"];
            string desofint = Request["desoi"];

            date = Request["joiningdate"];
            DateTime joiningdate = Convert.ToDateTime(date);

            string lastdegree = Request["lastdegree"];
            string lastinstitute = Request["lastinstitute"];
            string lastperform = Request["lastperform"];

            string scndlastdegree = Request["scndlastdegree"];
            string scndlastinstitute = Request["scndlastinstitute"];
            string scndlastperform = Request["scndlastperform"];

            string addqualification = Request["addqualification"];

            BasicInfo obj = new BasicInfo();
            obj.addBasicInfo(fname, lname, mname, image, dob, gender, email, ph1, ph2, address, city, country, objective, depofint, desofint, joiningdate, lastdegree, lastinstitute, lastperform, scndlastdegree, scndlastinstitute, scndlastperform, addqualification, 1);
            getAllLists obj1 = new getAllLists();
            ViewBag.Cities = obj1.getCities();
            ViewBag.Countaries = obj1.getCountaries();
            ViewBag.Degrees = obj1.getDegrees();
            ViewBag.Institutes = obj1.getInstitutes();
            return View("Create");
        }

        [HttpPost]
        public ActionResult Expinfo()
        {
            string skills = Request["skills"];
            int minsalary = Convert.ToInt32(Request["minsalary"]);
            string expsum = Request["expsum"];
            string expyrs = Request["expyrs"];
            string cemployer = Request["currentemp"];
            string cdes = Request["currentdes"];
            string expcorg = Request["exporg"];
            string respcjob = Request["respcjob"];

            string prevemp = Request["prevemp"];
            string prevdes = Request["prevdes"];
            string prevexporg = Request["prevexporg"];
            string respprevjob = Request["respprevjob"];
            string date = Request["dolj"];
            DateTime dolj = Convert.ToDateTime(date);

            ExpInfo obj = new ExpInfo();
            obj.addExpInfo(skills, minsalary, expsum, expyrs, cemployer, cdes, expcorg, respcjob, 1, prevemp, prevdes, prevexporg, respprevjob, dolj);
            getAllLists obj2 = new getAllLists();
            ViewBag.Cities = obj2.getCities();
            ViewBag.Countaries = obj2.getCountaries();
            ViewBag.Degrees = obj2.getDegrees();
            ViewBag.Institutes = obj2.getInstitutes();
            return View("Create");
        }

        [HttpPost]
        public ActionResult Extrainfo()
        {
            string extraact = Request["extraact"];
            string othrint = Request["othrint"];
            string refperson1 = Request["refperson1"];
            string affperson1 = Request["affperson1"];
            string phref1 = Request["phref1"];
            string refemail1 = Request["refemail1"];
            string refperson2 = Request["refperson2"];
            string affperson2 = Request["affperson2"];
            string phref2 = Request["phref2"];
            string refemail2 = Request["refemail2"];

            ExtraInfo obj = new ExtraInfo();
            obj.addExtraInfo(extraact, othrint, refperson1, affperson1, phref1, refemail1, refperson2, affperson2, phref2, refemail2,1);
            getAllLists obj3 = new getAllLists();
            ViewBag.Cities = obj3.getCities();
            ViewBag.Countaries = obj3.getCountaries();
            ViewBag.Degrees = obj3.getDegrees();
            ViewBag.Institutes = obj3.getInstitutes();
            return View("Create");
        }
    }
}