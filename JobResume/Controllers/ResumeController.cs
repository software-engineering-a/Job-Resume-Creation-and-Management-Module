using JobResume.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobResume.Controllers
{
    public class ResumeController : Controller
    {
        int uid = 3;
        // GET: Resume
        public ActionResult Create()
        {
            getAllLists obj = new getAllLists();
            ViewBag.Cities = obj.getCities();
            ViewBag.Countaries = obj.getCountaries();
            ViewBag.Degrees = obj.getDegrees();
            ViewBag.Institutes = obj.getInstitutes();
            BasicInfo b = new BasicInfo();
            ExpInfo e1 = new ExpInfo();
            ExtraInfo e2 = new ExtraInfo();
            ViewBag.isBasicInfoExist = b.isBasicInfoFound(uid);
            ViewBag.isExpInfoExist = e1.isExpInfoFound(uid);
            ViewBag.isExtraInfoExist = e2.isExtraInfoFound(uid);

            UserInfo u = new UserInfo();
            ViewBag.UserInfo = u.getUserInfo(uid);

            return View();
        }
        public ActionResult Update()
        {
            getAllLists obj = new getAllLists();
            ViewBag.Cities = obj.getCities();
            ViewBag.Countaries = obj.getCountaries();
            ViewBag.Degrees = obj.getDegrees();
            ViewBag.Institutes = obj.getInstitutes();
            BasicInfo b = new BasicInfo();
            ExpInfo e1 = new ExpInfo();
            ExtraInfo e2 = new ExtraInfo();
            ViewBag.isBasicInfoExist = b.isBasicInfoFound(uid);
            if(ViewBag.isBasicInfoExist)
                ViewBag.allBasicInfo = b.getBasicInfo(uid);
            ViewBag.isExpInfoExist = e1.isExpInfoFound(uid);
            if (ViewBag.isExpInfoExist)
            {
                ViewBag.allExpInfo = e1.getExpInfo(uid);
                ViewBag.allPreExp = e1.getPreviousHistory(uid);
            }
            ViewBag.isExtraInfoExist = e2.isExtraInfoFound(uid);
            if(ViewBag.isExtraInfoExist)
                ViewBag.allExraInfo = e2.getExtraInfo(uid);

            UserInfo u = new UserInfo();
            ViewBag.UserInfo = u.getUserInfo(uid);

            return View();
        }
        [HttpPost]
        public ActionResult CreateBasicinfo()
        {
            JobResumeBasic br = new JobResumeBasic();
            BasicInfo obj = new BasicInfo();

            string fname = Request["fname"];
            string lname = Request["lname"];
            string email = Request["email"];

            br.mname = Request["mname"];
            br.image = Request["image"];
            string date = Request["dob"];
            br.dob = Convert.ToDateTime(date);
            br.gender = Request["gender"];
            br.ph1 = Request["ph1"];
            br.ph2 = Request["ph2"];
            br.address = Request["address"];
            string city = Request["city"];
            br.city = obj.getCityId(city);
            string country = Request["country"];
            br.country = obj.getCountryId(country);
            br.objective = Request["objective"];
            br.depofint = Request["depoi"];
            br.desofint = Request["desoi"];
            date = Request["joiningdate"];
            br.joiningdate = Convert.ToDateTime(date);
            string lastdegree = Request["lastdegree"];
            br.lastdegree = obj.getDegreeId(lastdegree);
            string lastinstitute = Request["lastinstitute"];
            br.lastinstitute = obj.getInstituteId(lastinstitute);
            br.perflastdegree = Request["lastperform"];
            string scndlastdegree = Request["scndlastdegree"];
            br.scndlastdegree = obj.getDegreeId(scndlastdegree);
            string scndlastinstitute = Request["scndlastinstitute"];
            br.scndlastinstitute = obj.getInstituteId(scndlastinstitute);
            br.perfscndlastdegree = Request["scndlastperform"];

            br.addqualification = Request["addqualification"];
            br.userId = uid;
            obj.addBasicInfo(br);
            getAllLists obj1 = new getAllLists();
            ViewBag.Cities = obj1.getCities();
            ViewBag.Countaries = obj1.getCountaries();
            ViewBag.Degrees = obj1.getDegrees();
            ViewBag.Institutes = obj1.getInstitutes();
            BasicInfo b = new BasicInfo();
            ExpInfo e1 = new ExpInfo();
            ExtraInfo e2 = new ExtraInfo();
            ViewBag.isBasicInfoExist = b.isBasicInfoFound(uid);
            ViewBag.isExpInfoExist = e1.isExpInfoFound(uid);
            ViewBag.isExtraInfoExist = e2.isExtraInfoFound(uid);

            UserInfo u = new UserInfo();
            ViewBag.UserInfo = u.getUserInfo(uid);
            return View("Create");
        }

        [HttpPost]
        public ActionResult CreateExpinfo()
        {
            JobResumeExp er = new JobResumeExp();
            er.skills = Request["skills"];
            er.minsalary = Convert.ToInt32(Request["minsalary"]);
            er.expsummary = Request["expsum"];
            er.expyrs = Request["expyrs"];
            er.cemployer = Request["currentemp"];
            er.cdes = Request["currentdes"];
            er.expcorg = Request["exporg"];
            er.rescjob = Request["respcjob"];
            er.userId = uid;
            PreviousHistory ph = new PreviousHistory();
            
            ph.pemployer = Request["prevemp"];
            ph.pdes = Request["prevdes"];
            ph.expporg = Request["prevexporg"];
            ph.resppjob = Request["respprevjob"];
            string date = Request["dolj"];
            ph.dateofleaving = Convert.ToDateTime(date);
            ph.userid = uid;

            ExpInfo obj = new ExpInfo();
            obj.addExpInfo(er, ph);
            getAllLists obj2 = new getAllLists();
            ViewBag.Cities = obj2.getCities();
            ViewBag.Countaries = obj2.getCountaries();
            ViewBag.Degrees = obj2.getDegrees();
            ViewBag.Institutes = obj2.getInstitutes();
            BasicInfo b = new BasicInfo();
            ExpInfo e1 = new ExpInfo();
            ExtraInfo e2 = new ExtraInfo();
            ViewBag.isBasicInfoExist = b.isBasicInfoFound(uid);
            ViewBag.isExpInfoExist = e1.isExpInfoFound(uid);
            ViewBag.isExtraInfoExist = e2.isExtraInfoFound(uid);

            UserInfo u = new UserInfo();
            ViewBag.UserInfo = u.getUserInfo(uid);
            return View("Create");
        }

        [HttpPost]
        public ActionResult CreateExtrainfo()
        {
            JobResumeExtra er = new JobResumeExtra();
            er.extraactivities = Request["extraact"];
            er.otherinterests = Request["othrint"];
            er.namep1 = Request["refperson1"];
            er.affp1 = Request["affperson1"];
            er.php1 = Request["phref1"];
            er.emailp1 = Request["refemail1"];
            er.namep2 = Request["refperson2"];
            er.affp2 = Request["affperson2"];
            er.php2 = Request["phref2"];
            er.emailp2 = Request["refemail2"];
            er.userId = uid;
            ExtraInfo obj = new ExtraInfo();
            obj.addExtraInfo(er);
            getAllLists obj3 = new getAllLists();
            ViewBag.Cities = obj3.getCities();
            ViewBag.Countaries = obj3.getCountaries();
            ViewBag.Degrees = obj3.getDegrees();
            ViewBag.Institutes = obj3.getInstitutes();
            BasicInfo b = new BasicInfo();
            ExpInfo e1 = new ExpInfo();
            ExtraInfo e2 = new ExtraInfo();
            ViewBag.isBasicInfoExist = b.isBasicInfoFound(uid);
            ViewBag.isExpInfoExist = e1.isExpInfoFound(uid);
            ViewBag.isExtraInfoExist = e2.isExtraInfoFound(uid);

            UserInfo u = new UserInfo();
            ViewBag.UserInfo = u.getUserInfo(uid);
            return View("Create");
        }

        [HttpPost]
        public ActionResult UpdateBasicinfo()
        {
            JobResumeBasic br = new JobResumeBasic();
            BasicInfo obj = new BasicInfo();

            string fname = Request["fname"];
            string lname = Request["lname"];
            string email = Request["email"];

            br.mname = Request["mname"];
            br.image = Request["image"];
            string date = Request["dob"];
            br.dob = Convert.ToDateTime(date);
            br.gender = Request["gender"];
            br.ph1 = Request["ph1"];
            br.ph2 = Request["ph2"];
            br.address = Request["address"];
            string city = Request["city"];
            br.city = obj.getCityId(city);
            string country = Request["country"];
            br.country = obj.getCountryId(country);
            br.objective = Request["objective"];
            br.depofint = Request["depoi"];
            br.desofint = Request["desoi"];
            date = Request["joiningdate"];
            br.joiningdate = Convert.ToDateTime(date);
            string lastdegree = Request["lastdegree"];
            br.lastdegree = obj.getDegreeId(lastdegree);
            string lastinstitute = Request["lastinstitute"];
            br.lastinstitute = obj.getInstituteId(lastinstitute);
            br.perflastdegree = Request["lastperform"];
            string scndlastdegree = Request["scndlastdegree"];
            br.scndlastdegree = obj.getDegreeId(scndlastdegree);
            string scndlastinstitute = Request["scndlastinstitute"];
            br.scndlastinstitute = obj.getInstituteId(scndlastinstitute);
            br.perfscndlastdegree = Request["scndlastperform"];

            br.addqualification = Request["addqualification"];
            br.userId = uid;
            obj.updateBasicInfo(br);
            getAllLists obj1 = new getAllLists();
            ViewBag.Cities = obj1.getCities();
            ViewBag.Countaries = obj1.getCountaries();
            ViewBag.Degrees = obj1.getDegrees();
            ViewBag.Institutes = obj1.getInstitutes();
            BasicInfo b = new BasicInfo();
            ExpInfo e1 = new ExpInfo();
            ExtraInfo e2 = new ExtraInfo();
            ViewBag.isBasicInfoExist = b.isBasicInfoFound(uid);
            if (ViewBag.isBasicInfoExist)
                ViewBag.allBasicInfo = b.getBasicInfo(uid);
            ViewBag.isExpInfoExist = e1.isExpInfoFound(uid);
            if (ViewBag.isExpInfoExist)
            {
                ViewBag.allExpInfo = e1.getExpInfo(uid);
                ViewBag.allPreExp = e1.getPreviousHistory(uid);
            }
            ViewBag.isExtraInfoExist = e2.isExtraInfoFound(uid);
            if (ViewBag.isExtraInfoExist)
                ViewBag.allExraInfo = e2.getExtraInfo(uid);

            UserInfo u = new UserInfo();
            ViewBag.UserInfo = u.getUserInfo(uid);

            return View("Update");
        }

        [HttpPost]
        public ActionResult UpdateExpinfo()
        {
            JobResumeExp er = new JobResumeExp();
            er.skills = Request["skills"];
            er.minsalary = Convert.ToInt32(Request["minsalary"]);
            er.expsummary = Request["expsum"];
            er.expyrs = Request["expyrs"];
            er.cemployer = Request["currentemp"];
            er.cdes = Request["currentdes"];
            er.expcorg = Request["exporg"];
            er.rescjob = Request["respcjob"];
            er.userId = uid;
            PreviousHistory ph = new PreviousHistory();

            ph.pemployer = Request["prevemp"];
            ph.pdes = Request["prevdes"];
            ph.expporg = Request["prevexporg"];
            ph.resppjob = Request["respprevjob"];
            string date = Request["dolj"];
            ph.dateofleaving = Convert.ToDateTime(date);
            ph.userid = uid;

            ExpInfo obj = new ExpInfo();
            obj.updateExpInfo(er, ph);
            getAllLists obj2 = new getAllLists();
            ViewBag.Cities = obj2.getCities();
            ViewBag.Countaries = obj2.getCountaries();
            ViewBag.Degrees = obj2.getDegrees();
            ViewBag.Institutes = obj2.getInstitutes();
            BasicInfo b = new BasicInfo();
            ExpInfo e1 = new ExpInfo();
            ExtraInfo e2 = new ExtraInfo();
            ViewBag.isBasicInfoExist = b.isBasicInfoFound(uid);
            if (ViewBag.isBasicInfoExist)
                ViewBag.allBasicInfo = b.getBasicInfo(uid);
            ViewBag.isExpInfoExist = e1.isExpInfoFound(uid);
            if (ViewBag.isExpInfoExist)
            {
                ViewBag.allExpInfo = e1.getExpInfo(uid);
                ViewBag.allPreExp = e1.getPreviousHistory(uid);
            }
            ViewBag.isExtraInfoExist = e2.isExtraInfoFound(uid);
            if (ViewBag.isExtraInfoExist)
                ViewBag.allExraInfo = e2.getExtraInfo(uid);

            UserInfo u = new UserInfo();
            ViewBag.UserInfo = u.getUserInfo(uid);

            return View("Update");
        }

        [HttpPost]
        public ActionResult UpdateExtrainfo()
        {
            JobResumeExtra er = new JobResumeExtra();
            er.extraactivities = Request["extraact"];
            er.otherinterests = Request["othrint"];
            er.namep1 = Request["refperson1"];
            er.affp1 = Request["affperson1"];
            er.php1 = Request["phref1"];
            er.emailp1 = Request["refemail1"];
            er.namep2 = Request["refperson2"];
            er.affp2 = Request["affperson2"];
            er.php2 = Request["phref2"];
            er.emailp2 = Request["refemail2"];
            er.userId = uid;
            ExtraInfo obj = new ExtraInfo();
            obj.updateExtraInfo(er);
            getAllLists obj3 = new getAllLists();
            ViewBag.Cities = obj3.getCities();
            ViewBag.Countaries = obj3.getCountaries();
            ViewBag.Degrees = obj3.getDegrees();
            ViewBag.Institutes = obj3.getInstitutes();
            BasicInfo b = new BasicInfo();
            ExpInfo e1 = new ExpInfo();
            ExtraInfo e2 = new ExtraInfo();
            ViewBag.isBasicInfoExist = b.isBasicInfoFound(uid);
            if (ViewBag.isBasicInfoExist)
                ViewBag.allBasicInfo = b.getBasicInfo(uid);
            ViewBag.isExpInfoExist = e1.isExpInfoFound(uid);
            if (ViewBag.isExpInfoExist)
            {
                ViewBag.allExpInfo = e1.getExpInfo(uid);
                ViewBag.allPreExp = e1.getPreviousHistory(uid);
            }
            ViewBag.isExtraInfoExist = e2.isExtraInfoFound(uid);
            if (ViewBag.isExtraInfoExist)
                ViewBag.allExraInfo = e2.getExtraInfo(uid);

            UserInfo u = new UserInfo();
            ViewBag.UserInfo = u.getUserInfo(uid);

            return View("Update");
        }


    }
}