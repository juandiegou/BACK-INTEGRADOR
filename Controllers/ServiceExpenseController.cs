using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters.Expenses.Servicess;

namespace API.Controllers
{
    /// <summary>
    /// ServiceExpenseController
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetServiceExpenseModel, PutServiceExpenseModel, PostServiceExpenseModel, DeleteServiceExpenseModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ServiceExpenseController : ControllerBase
    {
        private readonly Context _context;

        public ServiceExpenseController(Context context)
        {
            _context = context;
        }


        /// <summary>
        /// this method is used to get all the ServiceExpenseModel
        /// </summary>
        /// <returns>
        /// all the ServiceExpenseModel
        /// </returns>
        /// <response code="200">Returns all the ServiceExpenseModel</response>
        /// <response code="404">If the ServiceExpenseModel is null</response>
        /// <response code="500">If there is a problem in the database</response>
        /// <example> 
        /// Get api/ServiceExpense
        /// </example>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceExpenseModel>>> GetServiceExpenseModel()
        {
            if (_context.ServiceExpenseModel == null)
            {
                return NotFound();
            }
            return await _context.ServiceExpenseModel.ToListAsync();
        }

        /// <summary>
        /// this method is used to get a ServiceExpenseModel by id
        /// </summary>
        /// <param name="id">the id of the ServiceExpenseModel</param>
        /// <returns>this method returns a ServiceExpenseModel by id</returns>
        /// <example>
        /// Get api/ServiceExpense/5
        /// </example>
        // GET: api/ServiceExpense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceExpenseModel>> GetServiceExpenseModel(int id)
        {
            if (_context.ServiceExpenseModel == null)
            {
                return NotFound();
            }
            var serviceExpenseModel = await _context.ServiceExpenseModel.FindAsync(id);

            if (serviceExpenseModel == null)
            {
                return NotFound();
            }

            return serviceExpenseModel;
        }

        /// <summary>
        /// this method is used to update a ServiceExpenseModel by id
        /// </summary>
        /// <param name="id">the id of the ServiceExpenseModel</param>
        /// <param name="serviceExpenseModel">the ServiceExpenseModel to update</param>
        /// <returns>the updated ServiceExpenseModel</returns>
        /// <response code="204">Returns the updated ServiceExpenseModel</response>
        /// <response code="400">If the id of the ServiceExpenseModel is different from the id of the parameter</response>
        /// <response code="404">If the ServiceExpenseModel is null</response>
        /// <response code="500">If there is a problem in the database</response>
        /// <example>
        /// PUT: api/ServiceExpense/5
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceExpenseModel(int id, ServiceExpenseModel serviceExpenseModel)
        {
            if (id != serviceExpenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceExpenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExpenseModelExists(id))
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
        /// this method is used to create a ServiceExpenseModel
        /// </summary>
        /// <param name="serviceExpenseModel">the ServiceExpenseModel to create</param>
        /// <returns>the created ServiceExpenseModel</returns>
        /// <response code="201">Returns the created ServiceExpenseModel</response>
        /// <response code="400">If the ServiceExpenseModel is null</response>
        /// <response code="500">If there is a problem in the database</response>
        /// <example>
        // POST: api/ServiceExpense
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceExpenseModel>> PostServiceExpenseModel(ServiceExpenseModel serviceExpenseModel)
        {
            if (_context.ServiceExpenseModel == null)
            {
                return Problem("Entity set 'Context.ServiceExpenseModel'  is null.");
            }
            _context.ServiceExpenseModel.Add(serviceExpenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceExpenseModel", new { id = serviceExpenseModel.Id }, serviceExpenseModel);
        }

        /// <summary>
        /// this method is used to delete a ServiceExpenseModel by id
        /// </summary>
        /// <param name="id">the id of the ServiceExpenseModel</param>
        /// <returns>the deleted ServiceExpenseModel</returns>
        /// <response code="200">Returns the deleted ServiceExpenseModel</response>
        /// <response code="404">If the ServiceExpenseModel is null</response>
        /// <response code="500">If there is a problem in the database</response>
        /// <example>
        // DELETE: api/ServiceExpense/5
        /// </example>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceExpenseModel(int id)
        {
            if (_context.ServiceExpenseModel == null)
            {
                return NotFound();
            }
            var serviceExpenseModel = await _context.ServiceExpenseModel.FindAsync(id);
            if (serviceExpenseModel == null)
            {
                return NotFound();
            }

            _context.ServiceExpenseModel.Remove(serviceExpenseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// identifies if a ServiceExpenseModel exists by id
        /// </summary>
        /// <param name="id">the id of the ServiceExpenseModel</param>
        /// <returns>true if the ServiceExpenseModel exists, false otherwise</returns>

        private bool ServiceExpenseModelExists(int id)
        {
            return (_context.ServiceExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
