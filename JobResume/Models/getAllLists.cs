using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobResume.Models
{
    public class getAllLists
    {
        public List<City> getCities()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<City> var = (from x in db.Cities
                              select x).ToList();
            return var;
        }

        public List<Countary> getCountaries()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<Countary> var = (from x in db.Countaries
                              select x).ToList();
            return var;
        }

        public List<Degree> getDegrees()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<Degree> var = (from x in db.Degrees
                                  select x).ToList();
            return var;
        }
        public List<Institute> getInstitutes()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<Institute> var = (from x in db.Institutes
                                select x).ToList();
            return var;
        }
    }
}