using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobResume.Models
{
    public class BasicInfo
    {
        int getCityId(string city)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var q = from x in db.Cities
                    where x.name == city
                    select x;
            int cityid=0;
            if (q.Count() > 0)
            {
                foreach (var c in q)
                {
                    cityid = c.Id;
                }
            }
            else
            {
                City newc = new City();
                newc.name = city;
                db.Cities.InsertOnSubmit(newc);
                db.SubmitChanges();

                q = from x in db.Cities
                    where x.name == city
                    select x;
                foreach (var c in q)
                {
                    cityid = c.Id;
                }
            }
            return cityid;
        }
        int getCountryId(string country)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var q = from x in db.Countaries
                    where x.name == country
                    select x;
            int countryid = 0;
            if (q.Count() > 0)
            {
                foreach (var c in q)
                {
                    countryid = c.Id;
                }
            }
            else
            {
                Countary newc = new Countary();
                newc.name = country;
                db.Countaries.InsertOnSubmit(newc);
                db.SubmitChanges();

                q = from x in db.Countaries
                    where x.name == country
                    select x;
                foreach (var c in q)
                {
                    countryid = c.Id;
                }
            }
            return countryid;
        }
        int getDegreeId(string degree)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var q = from x in db.Degrees
                    where x.name == degree
                    select x;
            int degreeid = 0;
            if (q.Count() > 0)
            {
                foreach (var d in q)
                {
                    degreeid = d.Id;
                }
            }
            else
            {
                Degree newc = new Degree();
                newc.name = degree;
                db.Degrees.InsertOnSubmit(newc);
                db.SubmitChanges();

                q = from x in db.Degrees
                    where x.name == degree
                    select x;
                foreach (var d in q)
                {
                    degreeid = d.Id;
                }
            }
            return degreeid;
        }
        int getInstituteId(string institute)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var q = from x in db.Institutes
                    where x.name == institute
                    select x;
            int instituteid = 0;
            if (q.Count() > 0)
            {
                foreach (var i in q)
                {
                    instituteid = i.Id;
                }
            }
            else
            {
                Institute newc = new Institute();
                newc.name = institute;
                db.Institutes.InsertOnSubmit(newc);
                db.SubmitChanges();

                q = from x in db.Institutes
                    where x.name == institute
                    select x;
                foreach (var i in q)
                {
                    instituteid = i.Id;
                }
            }
            return instituteid;
        }
        public bool isBasicInfoFound(int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var q = from x in db.JobResumeBasics
                    where x.userId == userId
                    select x;
            if (q.Count() > 0)
                return true;
            return false;
        }
        public void addBasicInfo(string fname, string lname, string mname, string imgpath, DateTime dob, string gender, string email, string ph1, string ph2, string address, string city, string country, string objective, string depofint, string desofint, DateTime joiningdate, string lastdegree, string lastinstitute, string lastperfor, string scndlastdegree, string scndlastinstitute, string scndlastperfor, string addqualification, int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            JobResumeBasic obj = new JobResumeBasic();

            int cityid = getCityId(city);
            int countryid = getCountryId(country);
            int lastdegreeid = getDegreeId(lastdegree);
            int lastinstituteid = getInstituteId(lastinstitute);
            int scndlastdegreeid = getDegreeId(scndlastdegree);
            int scndlastinstituteid = getInstituteId(scndlastinstitute);

            obj.mname = mname;
            obj.image = imgpath;
            obj.dob = dob;
            obj.gender = gender;
            obj.ph1 = ph1;
            obj.ph2 = ph2;
            obj.address = address;
            obj.city = cityid;
            obj.country = countryid;
            obj.objective = objective;
            obj.depofint = depofint;
            obj.desofint = desofint;
            obj.joiningdate = joiningdate;
            obj.lastdegree = lastdegreeid;
            obj.lastinstitute = lastinstituteid;
            obj.perflastdegree = lastperfor;
            obj.scndlastdegree = scndlastdegreeid;
            obj.scndlastinstitute = scndlastinstituteid;
            obj.perfscndlastdegree = scndlastperfor;
            obj.addqualification = addqualification;
            obj.userId = userId;

            db.JobResumeBasics.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
    }
}