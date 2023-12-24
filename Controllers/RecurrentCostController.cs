using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters.Expenses;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the recurrent cost model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetRecurrentCostModel, PutRecurrentCostModel, PostRecurrentCostModel, DeleteRecurrentCostModel.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RecurrentCostController : ControllerBase
    {
        private readonly Context _context;

        public RecurrentCostController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method gets all the recurrent cost models.
        /// </summary>
        /// <returns> all the recurrent cost models.</returns>
        /// <response code="200">Returns all the recurrent cost models.</response>
        /// <response code="404">If the recurrent cost models are null.</response>
        /// <response code="500">If there is a problem in the database.</response>
        /// <example>
        // GET: api/RecurrentCost
        /// </example>
        /// <remarks>
        /// This method returns all the recurrent cost models.
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecurrentCostModel>>> GetRecurrentCostModel()
        {
            if (_context.RecurrentCostModel == null)
            {
                return NotFound();
            }
            return await _context.RecurrentCostModel.ToListAsync();
        }

        /// <summary>
        /// this method gets a recurrent cost model by id.
        /// </summary>
        /// <param name="id">The id of the recurrent cost model.</param>
        /// <returns> a recurrent cost model.</returns>
        /// <response code="200">Returns a recurrent cost model.</response>
        /// <response code="404">If the recurrent cost model is null.</response>
        /// <response code="500">If there is a problem in the database.</response>
        /// <example> 
        // GET: api/RecurrentCost/5
        /// </example>
        [HttpGet("{id}")]
        public async Task<ActionResult<RecurrentCostModel>> GetRecurrentCostModel(int id)
        {
            if (_context.RecurrentCostModel == null)
            {
                return NotFound();
            }
            var recurrentCostModel = await _context.RecurrentCostModel.FindAsync(id);

            if (recurrentCostModel == null)
            {
                return NotFound();
            }

            return recurrentCostModel;
        }

        /// <summary>
        /// this method updates a recurrent cost model.
        /// </summary>
        /// <param name="id">The id of the recurrent cost model.</param>
        /// <param name="recurrentCostModel">The recurrent cost model.</param>
        /// <returns> a recurrent cost model updated.</returns>        
        /// <response code="204">Returns a recurrent cost model updated.</response>
        /// <response code="400">If the id of the recurrent cost model is different from the id of the recurrent cost model.</response>
        /// <response code="404">If the recurrent cost model is null.</response>
        /// <response code="500">If there is a problem in the database.</response>
        /// <example>
        // PUT: api/RecurrentCost/5
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurrentCostModel(int id, RecurrentCostModel recurrentCostModel)
        {
            if (id != recurrentCostModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(recurrentCostModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecurrentCostModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(recurrentCostModel);
        }


        /// <summary>
        /// this method creates a recurrent cost model.
        /// </summary>
        /// <param name="recurrentCostModel">The recurrent cost model.</param>
        /// <returns> a recurrent cost model created.</returns>
        /// <response code="201">Returns a recurrent cost model created.</response>
        /// <response code="400">If the recurrent cost model is null.</response>
        /// <response code="500">If there is a problem in the database.</response>
        /// <example>
        // POST: api/RecurrentCost
        /// </example>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecurrentCostModel>> PostRecurrentCostModel(RecurrentCostModel recurrentCostModel)
        {
            if (_context.RecurrentCostModel == null)
            {
                return Problem("Entity set 'Context.RecurrentCostModel'  is null.");
            }
            _context.RecurrentCostModel.Add(recurrentCostModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurrentCostModel", new { id = recurrentCostModel.Id }, recurrentCostModel);
        }


        /// <summary>
        /// this method deletes a recurrent cost model.
        /// </summary>
        /// <param name="id">The id of the recurrent cost model.</param>
        /// <returns> a recurrent cost model deleted.</returns>
        /// <response code="204">Returns a recurrent cost model deleted.</response>
        /// <response code="404">If the recurrent cost model is null.</response>
        /// <response code="500">If there is a problem in the database.</response>
        /// <example>
        // DELETE: api/RecurrentCost/5
        /// </example>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurrentCostModel(int id)
        {
            if (_context.RecurrentCostModel == null)
            {
                return NotFound();
            }
            var recurrentCostModel = await _context.RecurrentCostModel.FindAsync(id);
            if (recurrentCostModel == null)
            {
                return NotFound();
            }

            _context.RecurrentCostModel.Remove(recurrentCostModel);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        /// <summary>
        /// this method gets the recurrent cost models by parameters.
        /// </summary>
        /// <param name="parameters">if exists, the parameters of the recurrent cost model.</param>
        /// /// 
        private bool RecurrentCostModelExists(int id)
        {
            return (_context.RecurrentCostModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
