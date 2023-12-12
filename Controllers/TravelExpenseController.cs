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
    /// this class is used to manage the travel expenses
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetTravelExpenseModel, PutTravelExpenseModel, PostTravelExpenseModel, DeleteTravelExpenseModel.
    /// </remarks>

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TravelExpenseController : ControllerBase
    {
        private readonly Context _context;

        public TravelExpenseController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// this method is used to get all the travel expenses
        /// </summary>
        /// <returns>
        /// it returns a list of travel expenses
        /// </returns>
        /// <response code="200">returns the list of travel expenses</response>
        /// <response code="404">if the list of travel expenses is null</response>
        /// <response code="500">if the entity set 'Context.TravelExpenseModel' is null</response>
        /// <example>
        /// GET: api/TravelExpense
        /// </example>
        // GET: api/TravelExpense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelExpenseModel>>> GetTravelExpenseModel()
        {
          if (_context.TravelExpenseModel == null)
          {
              return NotFound();
          }
            return await _context.TravelExpenseModel.ToListAsync();
        }


        /// <summary>
        /// this method is used to get a travel expense by id
        /// </summary>
        /// <param name="id">this is the id of the travel expense</param>
        /// <returns>
        /// it returns a travel expense
        /// </returns>
        /// <response code="200">returns the travel expense</response>
        /// <response code="404">if the travel expense is null</response>
        /// <response code="500">if the entity set 'Context.TravelExpenseModel' is null</response>
        /// <example>
        /// GET: api/TravelExpense/5
        /// </example>

        // GET: api/TravelExpense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelExpenseModel>> GetTravelExpenseModel(int id)
        {
          if (_context.TravelExpenseModel == null)
          {
              return NotFound();
          }
            var travelExpenseModel = await _context.TravelExpenseModel.FindAsync(id);

            if (travelExpenseModel == null)
            {
                return NotFound();
            }

            return travelExpenseModel;
        }

        /// <summary>
        /// this method is used to update a travel expense
        /// </summary>
        /// <param name="id">this is the id of the travel expense</param>
        /// <param name="travelExpenseModel">this is the travel expense</param>
        /// <returns>
        /// it returns a updated travel expense
        /// </returns>
        /// <response code="204">returns the updated travel expense</response>
        /// <response code="400">if the id of the travel expense is not the same as the id of the travel expense to update</response>
        /// <response code="404">if the travel expense is null</response>
        /// <response code="500">if the entity set 'Context.TravelExpenseModel' is null</response>
        /// <example>
        /// PUT: api/TravelExpense/5
        /// </example>

        // PUT: api/TravelExpense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelExpenseModel(int id, TravelExpenseModel travelExpenseModel)
        {
            if (id != travelExpenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(travelExpenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelExpenseModelExists(id))
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
        /// this method is used to create a travel expense
        /// </summary>
        /// <param name="travelExpenseModel">this is the travel expense</param>
        /// <returns>
        /// it returns a created travel expense
        /// </returns>
        /// <response code="201">returns the created travel expense</response>
        /// <response code="400">if the travel expense is null</response>
        /// <response code="500">if the entity set 'Context.TravelExpenseModel' is null</response>
        /// <example>
        /// POST: api/TravelExpense
        /// </example>
        // POST: api/TravelExpense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelExpenseModel>> PostTravelExpenseModel(TravelExpenseModel travelExpenseModel)
        {
          if (_context.TravelExpenseModel == null)
          {
              return Problem("Entity set 'Context.TravelExpenseModel'  is null.");
          }
            _context.TravelExpenseModel.Add(travelExpenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelExpenseModel", new { id = travelExpenseModel.Id }, travelExpenseModel);
        }


        /// <summary>
        /// this method is used to delete a travel expense
        /// </summary>
        /// <param name="id">this is the id of the travel expense</param>
        /// <returns>
        /// it returns a deleted travel expense
        /// </returns>
        /// <response code="204">returns the deleted travel expense</response>
        /// <response code="404">if the travel expense is null</response>
        /// <response code="500">if the entity set 'Context.TravelExpenseModel' is null</response>
        /// <example>
        /// DELETE: api/TravelExpense/5
        /// </example>
        /// 
        // DELETE: api/TravelExpense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelExpenseModel(int id)
        {
            if (_context.TravelExpenseModel == null)
            {
                return NotFound();
            }
            var travelExpenseModel = await _context.TravelExpenseModel.FindAsync(id);
            if (travelExpenseModel == null)
            {
                return NotFound();
            }

            _context.TravelExpenseModel.Remove(travelExpenseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method is used to identify if a travel expense exists
        /// </summary>
        /// <param name="id">this is the id of the travel expense</param>
        /// <returns>
        /// it returns a boolean that represents if the travel expense exists or not
        /// </returns>
        
        /// 
        private bool TravelExpenseModelExists(int id)
        {
            return (_context.TravelExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
