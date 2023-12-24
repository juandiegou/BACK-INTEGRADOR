using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters;
using Microsoft.AspNetCore.Http.HttpResults;
using Api.Models.parameters.Expenses;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the cohort model, it inherits from ControllerBase.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetCohortModel, PutCohortModel, PostCohortModel, DeleteCohortModel.
    /// </remarks>
    /// <example>
    /// GET: api/Cohort
    /// </example>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // this attribute is used to authorize the user to access the controller
    public class CohortController : ControllerBase
    {
        private readonly Context _context;

        public CohortController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method returns all the cohort models.
        /// </summary>
        /// <returns>all the cohort models</returns>
        /// <response code="200">returns all the cohort models</response>
        /// <response code="404">if the cohort models are null</response>
        /// <response code="500">if the entity set 'Context.CohortModel' is null</response>
        // GET: api/Cohort
        [HttpGet]
        public ActionResult<IEnumerable<CohortModel>> GetCohort()
        {
            if (_context.CohortModel == null)
            {
                return NotFound();
            }
            return _context.CohortModel.Include(c => c.Expense)
                .Include(c => c.Registration!)
                    .ThenInclude(r => r.Student)
                        .ThenInclude(s => s.Discount)
                .Include(c => c.Registration!)
                    .ThenInclude(r => r.Subject)
                    .ThenInclude(s => s.Teacher)
                        .ThenInclude(t => t.Leader)
                .ToList();
        }
        /// <summary>
        ///  this method returns a cohort model by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a cohort model by id</returns>
        /// <response code="200">returns a cohort model by id</response>
        /// <response code="404">if the cohort model is null</response>
        /// <response code="500">if the entity set 'Context.CohortModel' is null</response>
        /// <example>
        /// GET: api/Cohort/5
        /// </example>

        // GET: api/Cohort/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CohortModel>> GetCohortModel(int id)
        {
            if (_context.CohortModel == null)
            {
                return NotFound();
            }
            var cohortModel = await _context.CohortModel
                .Include(c => c.Expense)
                .Include(c => c.Registration!)
                    .ThenInclude(r => r.Student)
                        .ThenInclude(s => s.Discount)
                .Include(c => c.Registration!)
                    .ThenInclude(r => r.Subject)
                    .ThenInclude(s => s.Teacher)
                        .ThenInclude(t => t.Leader)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cohortModel == null)
            {
                return NotFound();
            }

            return cohortModel;
        }
        /// <summary>
        /// this method updates a cohort model.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cohortModel"></param>
        /// <returns>an updated cohort model</returns>
        /// <response code="204">returns an updated cohort model</response>
        /// <response code="400">if the id is different to the cohort model id</response>
        /// <response code="404">if the cohort model is null</response>
        /// <response code="500">if the entity set 'Context.CohortModel' is null</response>
        /// <example>
        /// PUT: api/Cohort/5
        /// </example>

        // PUT: api/Cohort/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCohortModel(int id, CohortModel cohortModel)
        {
            if (id != cohortModel.Id)
            {
                return BadRequest();
            }

            if (cohortModel.Registration != null)
            {
                foreach (var registration in cohortModel.Registration)
                {
                    if (registration.Subject != null)
                    {
                        foreach (var subject in registration.Subject)
                        {
                            if (subject.Teacher != null)
                            {

                                if (subject.Teacher.Leader != null)
                                {
                                    _context.Entry(subject.Teacher.Leader).State = EntityState.Modified;
                                }
                                _context.Entry(subject.Teacher).State = EntityState.Modified;
                            }

                            _context.Entry(subject).State = EntityState.Modified;
                        }
                    }

                    if (registration.Student != null)
                    {
                        var student = registration.Student; // Use a single instance of StudentModel
                        if (student.Discount != null)
                        {
                            foreach (var discount in student.Discount)
                            {
                                _context.Entry(discount).State = EntityState.Modified;
                            }
                        }
                        _context.Entry(student).State = EntityState.Modified;
                    }
                    _context.Entry(registration).State = EntityState.Modified;
                }
            }

            if (cohortModel.Expense != null)
            {
                foreach (var expense in cohortModel.Expense)
                {
                    _context.Entry(expense).State = EntityState.Modified;
                }
            }

            _context.Entry(cohortModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CohortModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cohortModel);
        }

        /// <summary>
        /// this method creates a cohort model.
        /// </summary>
        /// <param name="cohortModel"></param>
        /// <returns>a new cohort model</returns>
        /// <response code="201">returns a new cohort model</response>
        /// <response code="400">if the cohort model is null</response>
        /// <response code="500">if the entity set 'Context.CohortModel' is null</response>
        /// <example>
        /// POST: api/Cohort 
        /// </example>

        // POST: api/Cohort
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CohortModel>> PostCohortModel(CohortModel cohortModel)
        {
            if (_context.CohortModel == null)
            {
                return Problem("Entity set 'Context.CohortModel'  is null.");
            }

            _context.CohortModel.Add(cohortModel);
            await _context.SaveChangesAsync();
            Console.WriteLine(cohortModel);
            return CreatedAtAction("GetCohortModel", new { id = cohortModel.Id }, cohortModel);
        }

        /// <summary>
        /// this method deletes a cohort model.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a deleted cohort model</returns>
        /// <response code="204">returns a deleted cohort model</response>
        /// <response code="404">if the cohort model is null</response>
        /// <response code="500">if the entity set 'Context.CohortModel' is null</response>
        /// <example>
        /// DELETE: api/Cohort/5
        /// </example>
        // DELETE: api/Cohort/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCohortModel(int id)
        {

            // var cohortModel = await _context.CohortModel.FindAsync(id);

            // if (cohortModel == null)
            // {
            //     return NotFound();
            // }

            // Console.WriteLine(cohortModel);

            // _context.CohortModel.Remove(cohortModel);
            // await _context.SaveChangesAsync();

            // try
            // {
            //     await _context.SaveChangesAsync();
            //     return Ok(cohortModel);
            // }
            // catch (DbUpdateException ex)
            // {
            // Handle exception (log, return appropriate response, etc.)
            //     return StatusCode(500, $"Error deleting cohort: {ex.Message}");
            // }

            /// method that deletes a cohort model and its related entities like expenses, registrations, subjects, teachers, leaders, students and discounts.
            /// <param name="id"></param>
            /// <returns>a deleted cohort model</returns>
            /// <response code="204">returns a deleted cohort model</response>
            /// <response code="404">if the cohort model is null</response>
            /// <response code="500">if the entity set 'Context.CohortModel' is null</response>
            /// <example>
            /// DELETE: api/Cohort/5
            /// </example>
            /// 
            var cohortModel = await _context.CohortModel
                .Include(c => c.Expense)
                .Include(c => c.Registration!)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cohortModel == null)
            {
                return NotFound();
            }

            if (cohortModel.Registration != null)
            {
                foreach (var registration in cohortModel.Registration)
                {
                    if (registration.Subject != null)
                    {
                        foreach (var subject in registration.Subject)
                        {
                            if (subject.Teacher != null)
                            {

                                if (subject.Teacher.Leader != null)
                                {
                                    _context.Entry(subject.Teacher.Leader).State = EntityState.Deleted;
                                }
                                _context.Entry(subject.Teacher).State = EntityState.Deleted;
                            }

                            _context.Entry(subject).State = EntityState.Deleted;
                        }
                    }

                    if (registration.Student != null)
                    {
                        var student = registration.Student; // Use a single instance of StudentModel
                        if (student.Discount != null)
                        {
                            foreach (var discount in student.Discount)
                            {
                                _context.Entry(discount).State = EntityState.Deleted;
                            }
                        }
                        _context.Entry(student).State = EntityState.Deleted;
                    }
                    _context.Entry(registration).State = EntityState.Deleted;
                }
            }

            if (cohortModel.Expense != null)
            {
                foreach (var expense in cohortModel.Expense)
                {
                    _context.Entry(expense).State = EntityState.Deleted;
                }
            }

            _context.Entry(cohortModel).State = EntityState.Deleted;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(cohortModel);
            }
            catch (DbUpdateException ex)
            {
                // Handle exception (log, return appropriate response, etc.)
                return StatusCode(500, $"Error deleting cohort: {ex.Message}");
            }





        }
        /// <summary>
        /// this method verifies if a cohort model exists.
        /// </summary>
        /// <param name="id"> the id of the cohort model</param>
        /// <returns>bool</returns>
        /// <example>
        /// api/Cohort/Exists/5
        /// </example>

        private bool CohortModelExists(int id)
        {
            return (_context.CohortModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
