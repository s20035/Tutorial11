using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial11.Entities;
using Tutorial11.Models;

namespace Tutorial11.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorDbContext _dcontext;

        public DoctorController(DoctorDbContext dcontext)
        {
            _dcontext = dcontext;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            var Docs = _dcontext.Doctors.Select(g => new DoctorResponse
            {
                IdDoctor = g.IdDoctor,
                Firstname = g.FirstName,
                Lastname = g.LastName,
                Email = g.EMail
            });

            return Ok(Docs);
        }

        [HttpPut]
        public IActionResult NewDoctor()
        {


            DoctorResponse enter = new DoctorResponse
            {
                IdDoctor = 456,
                Firstname = "Vuyo",
                Lastname = "Ndabandaba",
                Email = "Tsembalami@yazi.com"

            };

            var add = new Doctor
            {
                IdDoctor = enter.IdDoctor,
                FirstName = enter.Firstname,
                LastName = enter.Lastname,
                EMail = enter.Email

            };

            _dcontext.Doctors.Add(add);

            _dcontext.SaveChanges();

            return Ok("Doctor has been added");
        }

        [HttpPut]
        public IActionResult UpdateDoctor()
        {


            var change = new Doctor
            {
                IdDoctor = 24
            };
            _dcontext.Attach(change);
            _dcontext.Entry(change).Property("IdDoctor").IsModified = true;
            _dcontext.SaveChanges();


            return Ok("Doctor has been updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {

            var exc = _dcontext.Doctors.Find(id);
            if (exc is null)
            {
                return NotFound("Student does not exist");
            }
            _dcontext.Doctors.Remove(exc);
            _dcontext.SaveChanges();

            return Ok("Doctor has been Deleted");
        }
    }
}