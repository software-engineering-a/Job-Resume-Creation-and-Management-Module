using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobResume.Models
{
    public class UserInfo
    {
        public User getUserInfo(int userId)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            User u = new User();
            return (from x in db.Users
                    where x.Id == userId
                    select x).First();
        }
    }
}