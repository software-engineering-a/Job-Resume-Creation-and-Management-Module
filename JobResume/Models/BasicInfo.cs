using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobResume.Models
{
    public class BasicInfo
    {
        public int getCityId(string city)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var q = from x in db.Cities
                    where x.name == city
                    select x;
            int cityid = 0;
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
        public int getCountryId(string country)
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
        public int getDegreeId(string degree)
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
        public int getInstituteId(string institute)
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
        public void addBasicInfo(JobResumeBasic obj)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            db.JobResumeBasics.InsertOnSubmit(obj);
            db.SubmitChanges();
        }

        public JobResumeBasic getBasicInfo(int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from x in db.JobResumeBasics
                    where x.userId == userId
                    select x).First();
        }

        public void updateBasicInfo(JobResumeBasic br)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var obj = (from x in db.JobResumeBasics
                       where x.userId == br.userId
                       select x).First();
            obj = br;
            db.SubmitChanges();
        }

    }

}