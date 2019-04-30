using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobResume.Models
{
    public class ExpInfo
    {
        public bool isExpInfoFound(int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var q = from x in db.JobResumeExps
                    where x.userId == userId
                    select x;
            if (q.Count() > 0)
                return true;
            return false;
        }
        public void addExpInfo(string skills, int minsalary, string expsummary, string expyrs, string cemployer, string cdes, string expcorg, string rescjob, int userId, string pemployer, string pdes, string expporg, string resppjob, DateTime dol)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            JobResumeExp obj = new JobResumeExp();
            obj.skills = skills;
            obj.minsalary = minsalary;
            obj.expsummary = expsummary;
            obj.expyrs = expyrs;
            obj.cemployer = cemployer;
            obj.cdes = cdes;
            obj.expcorg = expcorg;
            obj.rescjob = rescjob;
            obj.userId = userId;
            db.JobResumeExps.InsertOnSubmit(obj);
            db.SubmitChanges();

            PreviousHistory obj1 = new PreviousHistory();
            obj1.pemployer = pemployer;
            obj1.pdes = pdes;
            obj1.expporg = expporg;
            obj1.resppjob = resppjob;
            obj1.dateofleaving = dol;
            obj1.userid = userId;
            db.PreviousHistories.InsertOnSubmit(obj1);
            db.SubmitChanges();

        }
        public JobResumeExp getExpInfo(int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from x in db.JobResumeExps
                    where x.userId == userId
                    select x).First();
        }
        public PreviousHistory getPreviousHistory(int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from x in db.PreviousHistories
                    where x.userid == userId
                    select x).First();
        }
        public void updateExpInfo(string skills, int minsalary, string expsummary, string expyrs, string cemployer, string cdes, string expcorg, string rescjob, int userId, string pemployer, string pdes, string expporg, string resppjob, DateTime dol)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var obj = (from x in db.JobResumeExps
                       where x.userId == userId
                       select x).First();
            obj.skills = skills;
            obj.minsalary = minsalary;
            obj.expsummary = expsummary;
            obj.expyrs = expyrs;
            obj.cemployer = cemployer;
            obj.cdes = cdes;
            obj.expcorg = expcorg;
            obj.rescjob = rescjob;
            obj.userId = userId;
            db.SubmitChanges();

            var obj1 = (from x in db.PreviousHistories
                        where x.userid == userId
                        select x).First();
            obj1.pemployer = pemployer;
            obj1.pdes = pdes;
            obj1.expporg = expporg;
            obj1.resppjob = resppjob;
            obj1.dateofleaving = dol;
            obj1.userid = userId;
            db.SubmitChanges();

        }
    }
}