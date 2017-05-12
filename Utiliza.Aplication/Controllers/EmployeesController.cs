using EmployeesDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Utiliza.Aplication.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDbEntities entities = new EmployeeDbEntities())
            {
                return entities.Employees.ToList();
            }
        }
        public Employee Get(int id)
        {
            using (EmployeeDbEntities entities = new EmployeeDbEntities())
            {
                return entities.Employees.FirstOrDefault(e => e.ID == id);
            }
        }
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDbEntities entities = new EmployeeDbEntities())
                {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
