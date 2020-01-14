using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestMeasurementService.DBUtility;
using RestMeasurementService.Model;

namespace RestMeasurementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private ManageMeasurements manageMeasurements = new ManageMeasurements();

        // GET: api/Measurements
        [HttpGet]
        [Route("/api/Measurements")]
        public IEnumerable<Measurement> GetAll()
        {
            return manageMeasurements.GetAll();
        }

        // GET: api/Measurements/5
        [HttpGet]
        [Route("/api/Measurements/{id}")]
        public Measurement GetById(int id)
        {
            return manageMeasurements.GetById(id);
        }

        // POST: api/Measurements
        [HttpPost]
        public void Add(Measurement measurement)
        {
            manageMeasurements.Add(measurement);
        }

        //// PUT: api/Measurements/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            manageMeasurements.Delete(id);
        }
    }
}
