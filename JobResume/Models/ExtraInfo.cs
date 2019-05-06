using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobResume.Models
{
    public class ExtraInfo
    {
        public bool isExtraInfoFound(int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var q = from x in db.JobResumeExtras
                    where x.userId == userId
                    select x;
            if (q.Count() > 0)
                return true;
            return false;
        }
        public void addExtraInfo(JobResumeExtra obj)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            db.JobResumeExtras.InsertOnSubmit(obj);
            db.SubmitChanges();
        }
        public JobResumeExtra getExtraInfo(int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return (from x in db.JobResumeExtras
                    where x.userId == userId
                    select x).First();
        }
        public void updateExtraInfo(JobResumeExtra er)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var obj = (from x in db.JobResumeExtras
                       where x.userId == er.userId
                       select x).First();
            obj = er;
            db.SubmitChanges();
        }
    }
}