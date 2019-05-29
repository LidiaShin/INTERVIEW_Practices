using Practice04_WebAPI_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice04_WebAPI_SQL
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using(InterviewPracticeEntities entities = new InterviewPracticeEntities())
            {
               
                 return entities.Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
            }
        }
    }
}