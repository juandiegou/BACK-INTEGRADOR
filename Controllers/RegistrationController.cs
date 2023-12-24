using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the registration model.
    /// </summary>
    /// <remarks>
    /// This controller has the CRUD methods for the registration model.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RegistrationController : ControllerBase
    {
        private readonly Context _context;

        public RegistrationController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the registration models.
        /// </summary>
        /// <returns>
        /// a list of registration models.
        /// </returns>
        /// <response code="200">returns the list of registration models.</response>
        /// <response code="404">if the list of registration models is null.</response>
        /// <response code="500">if the entity set 'Context.RegistrationModel' is null.</response>
        /// <example>
        /// GET: api/Registration
        ///</example> 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationModel>>> GetRegistrationModel()
        {
            if (_context.RegistrationModel == null)
            {
                return NotFound();
            }
            return await _context.RegistrationModel.Include(r => r.Student)
                .ThenInclude(s => s.Discount)
                .Include(r => r.Subject)
                .ToListAsync();
        }


        /// <summary>
        /// this method gets a registration model by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> a registration model.</returns>
        /// <response code="200">returns the registration model.</response>
        /// <response code="404">if the registration model is null.</response>
        /// <response code="500">if the entity set 'Context.RegistrationModel' is null.</response>
        /// <example>
        // GET: api/Registration/5
        ///</example>
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationModel>> GetRegistrationModel(int id)
        {
            if (_context.RegistrationModel == null)
            {
                return NotFound();
            }
            var registrationModel = await _context.RegistrationModel.Include(r => r.Student)
                .ThenInclude(s => s.Discount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (registrationModel == null)
            {
                return NotFound();
            }

            return registrationModel;
        }

        /// <summary>
        /// this method gets a registration model by id.
        /// </summary>
        /// <param name="id">the id of the registration model.</param>
        /// <param name="registrationModel">the registration model.</param>
        /// <returns> a registration model updated.</returns>
        /// <response code="200">returns the registration model updated.</response>
        /// <response code="400">if the id of the registration model is different from the id of the registration model.</response>
        /// <response code="404">if the registration model is null.</response>
        /// <response code="500">if the entity set 'Context.RegistrationModel' is null.</response>
        /// <example>
        // PUT: api/Registration/5
        ///</example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrationModel(int id, RegistrationModel registrationModel)
        {
            if (id != registrationModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(registrationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(registrationModel);
        }

        /// <summary>
        /// this method creates a registration model.
        /// </summary>
        /// <param name="registrationModel">the registration model.</param>
        /// <returns> a registration model created.</returns>
        /// <response code="201">returns the registration model created.</response> 
        /// <response code="400">if the registration model is null.</response>
        /// <response code="500">if the entity set 'Context.RegistrationModel' is null.</response> 
        /// <example>
        // POST: api/Registration
        ///</example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistrationModel>> PostRegistrationModel(RegistrationModel registrationModel)
        {
            if (_context.RegistrationModel == null)
            {
                return Problem("Entity set 'Context.RegistrationModel'  is null.");
            }
            _context.RegistrationModel.Add(registrationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistrationModel", new { id = registrationModel.Id }, registrationModel);
        }

        /// <summary>
        /// this method deletes a registration model.
        /// </summary>
        /// <param name="id">the id of the registration model.</param>
        /// <returns> a registration model deleted.</returns>
        /// <response code="200">returns the registration model deleted.</response>
        /// <response code="404">if the registration model is null.</response>
        /// <response code="500">if the entity set 'Context.RegistrationModel' is null.</response>
        /// <example>
        /// DELETE: api/Registration/5
        /// </example>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationModel(int id)
        {
            if (_context.RegistrationModel == null)
            {
                return NotFound();
            }
            var registrationModel = await _context.RegistrationModel.FindAsync(id);
            if (registrationModel == null)
            {
                return NotFound();
            }

            _context.RegistrationModel.Remove(registrationModel);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        /// <summary>
        /// this method gets a registration model by id.
        /// </summary>
        /// <param name="id">the id of the registration model.</param>
        /// <returns> if this registration model exists.</returns>

        private bool RegistrationModelExists(int id)
        {
            return (_context.RegistrationModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
