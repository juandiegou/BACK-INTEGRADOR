using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters;

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
                .Include(c => c.Registration)
                    .ThenInclude(r => r.Student)
                        .ThenInclude(s => s.Discount)
                .Include(c => c.Registration)
                    .ThenInclude(r => r.Subject)
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
            var cohortModel = await _context.CohortModel.
                Include(c => c.Expense)
                    .Include(c => c.Registration)
                        .ThenInclude(r => r.Student)
                            .ThenInclude(s => s.Discount)
                .Include(c => c.Registration)
                    .ThenInclude(r => r.Subject)
                    .ThenInclude(s => s.Teacher)
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

            return NoContent();
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
            if (_context.CohortModel == null)
            {
                return NotFound();
            }
            var cohortModel = await _context.CohortModel.FindAsync(id);
            if (cohortModel == null)
            {
                return NotFound();
            }

            _context.CohortModel.Remove(cohortModel);
            await _context.SaveChangesAsync();

            return NoContent();
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
