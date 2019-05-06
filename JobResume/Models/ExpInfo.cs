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
        public void addExpInfo(JobResumeExp obj, PreviousHistory obj1)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            
            db.JobResumeExps.InsertOnSubmit(obj);
            db.SubmitChanges();
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
        public void updateExpInfo(JobResumeExp er, PreviousHistory ph)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var obj = (from x in db.JobResumeExps
                       where x.userId == er.userId
                       select x).First();
            obj = er;
            db.SubmitChanges();

            var obj1 = (from x in db.PreviousHistories
                        where x.userid == ph.userid
                        select x).First();
            obj1 = ph;
            db.SubmitChanges();

        }
    }
}