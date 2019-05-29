using Practice04_WebAPI_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Practice04_WebAPI_SQL.Controllers
{
    // cors decorating
    //[EnableCorsAttribute("*", "*", "*")]
    public class EmployeesController : ApiController
    {
        // GET METHOD

        // Default Name Get
        //public IEnumerable<Employee> Get()
        //{
        //    using (InterviewPracticeEntities entities = new InterviewPracticeEntities())
        //        // create instance
        //    {
        //        return entities.Employees.ToList();
        //        // employee entity
        //    }
        //}
        // respond to http get (read) verb (without parameter)






        // Custom Name LoadEmployees
        //[HttpGet]
        //public IEnumerable<Employee> LoadingAllEmployees()
        //{
        //    using (InterviewPracticeEntities entities = new InterviewPracticeEntities())
        //    {
        //        return entities.Employees.ToList();
        //    }
        //}



        // With Filtering Function      

        //[DisableCors]
        //[BasicAuthentication]
        public HttpResponseMessage Get(string gender = "All")
        {

            string username = Thread.CurrentPrincipal.Identity.Name;

            using (InterviewPracticeEntities entities = new InterviewPracticeEntities())
            {
                switch (gender.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.ToList());

                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                        entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());

                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                        entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());

                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, 
                        "Value for gender must be male, female or all" + gender + " is invalid request. Please try again");
                }
            }
        }


        public HttpResponseMessage Get(int id)
        {
            using (InterviewPracticeEntities entities = new InterviewPracticeEntities())
            {
                var entity = entities.Employees.FirstOrDefault(e => e.ID == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID  " + id.ToString() + " is not exist, please check again");
                }
            }
        }
        // Respond to http get verb(with id parameter)



        // POST METHOD
        // made by Dodam
        //public IHttpActionResult Post(Employee person)
        //{
        //    using (var p = new InterviewPracticeEntities())
        //    {
        //        p.Employees.Add(new Employee()
        //        {
        //            ID = person.ID,
        //            FirstName = person.FirstName,
        //            LastName = person.LastName,
        //            Gender = person.Gender,
        //            Salary = person.Salary
        //        });

        //        p.SaveChanges();
        //    }

        //    return Ok();
        //}

        // made from Youtube lecture
        // ver1

        //public void Post([FromBody]Employee newemployeeinfo)
        //{
        //    using(InterviewPracticeEntities entities = new InterviewPracticeEntities())
        //    {
        //        entities.Employees.Add(newemployeeinfo);
        //        entities.SaveChanges();
        //    }
        //}

        // ver2
        //[HttpPost]
        public HttpResponseMessage Post([FromBody]Employee newemployeeinfo)
        {
            try
            {
                using (InterviewPracticeEntities entities = new InterviewPracticeEntities())
                {
                    entities.Employees.Add(newemployeeinfo);
                    entities.SaveChanges();

                    var msg = Request.CreateResponse(HttpStatusCode.Created, newemployeeinfo);
                    msg.Headers.Location = new Uri(Request.RequestUri + newemployeeinfo.ID.ToString());
                    return msg;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }            
        }




        // DELETE METHOD VER 1
        //public void Delete(int id)
        //{
        //    using(InterviewPracticeEntities entities = new InterviewPracticeEntities())
        //    {
        //        entities.Employees.Remove(entities.Employees.FirstOrDefault(e => e.ID == id));
        //        entities.SaveChanges();
        //    }
        //}

        // DELETE METHOD VER2

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using(InterviewPracticeEntities entities = new InterviewPracticeEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);

                    if(entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID = " + id.ToString() + " is not exist");
                    }
                    else
                    {
                        entities.Employees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }

            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // PUT ver1
        //public void Put(int id,[FromBody]Employee updatedEmployeeInfo)
        //{
        //    using(InterviewPracticeEntities entities = new InterviewPracticeEntities())
        //    {
        //        var entity = entities.Employees.FirstOrDefault(e => e.ID == id);

        //        entity.FirstName = updatedEmployeeInfo.FirstName;
        //        entity.LastName = updatedEmployeeInfo.LastName;
        //        entity.Gender = updatedEmployeeInfo.Gender;
        //        entity.Salary = updatedEmployeeInfo.Salary;

        //        entities.SaveChanges();
        //    }
        //}

        // PUT ver 2

        public HttpResponseMessage Put([FromBody]int id, [FromUri]Employee employee)
        {
            try
            {
                using (InterviewPracticeEntities entities = new InterviewPracticeEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id " + id.ToString() + " not exist, please try again");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
