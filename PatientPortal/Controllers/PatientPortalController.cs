using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PatientPortal.Entity;
using PatientPortal.ModelView;
using PatientPortal.Repository;

namespace PatientPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientPortalController : ControllerBase
    {
        private readonly IRepository<PatientsInformation> _Patientrepository;

        public PatientPortalController(IRepository<PatientsInformation> Patientrepository)
        {
            _Patientrepository = Patientrepository;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var patients = await _Patientrepository.GetAllAsync();
            return Ok(patients);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _Patientrepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientRequest patient) 
            {
            var patientEntity = new PatientsInformation()
            {
                PatientName = patient.PatientName,
                age = patient.age,
            };
            var createdPatientResponse = await _Patientrepository.AddAsync(patientEntity);
            return CreatedAtAction(nameof(GetById), new { id = createdPatientResponse.PatientId }, createdPatientResponse);
            }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PatientRequest patient)
        {
            var patientEntity = await _Patientrepository.GetByIdAsync(id);
           if(patientEntity == null)
            {
                return NotFound();
            }
           patientEntity.PatientName = patient.PatientName;
            patientEntity.age= patient.age;
            await _Patientrepository.UpdateAsync(patientEntity);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _Patientrepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            await _Patientrepository.DeleteAsync(patient);
            return NoContent();
        }



    }


}
