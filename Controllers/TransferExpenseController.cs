using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters.Expenses.Special;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the special expense model.
    /// </summary>
    /// <remarks>
    /// This controller has the CRUD methods for the special expense model.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TransferExpenseController : ControllerBase
    {
        private readonly Context _context;

        public TransferExpenseController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// This method gets all the special expense models.
        /// </summary>
        /// <returns>
        /// The list of all the special expense models.
        /// </returns>
        /// <response code="200">Returns the list of all the special expense models.</response> 
        /// <response code="404">If the list of special expense models is null.</response>
        /// <response code="500">If there was an internal server error.</response>
        /// <example>
        /// GET: api/TransferExpense
        /// </example>
        // GET: api/TransferExpense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferExpenseModel>>> GetTransferExpenseModel()
        {
          if (_context.TransferExpenseModel == null)
          {
              return NotFound();
          }
            return await _context.TransferExpenseModel.ToListAsync();
        }

        /// <summary>
        /// This method gets a special expense model.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// A special expense model  by id.
        /// </returns>
        /// <response code="200">Returns the special expense model with the specified id.</response>
        /// <response code="404">If the special expense model is null.</response>
        /// <response code="500">If there was an internal server error.</response>
        /// <example>
        /// GET: api/TransferExpense/5
        /// </example>

        // GET: api/TransferExpense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransferExpenseModel>> GetTransferExpenseModel(int id)
        {
          if (_context.TransferExpenseModel == null)
          {
              return NotFound();
          }
            var transferExpenseModel = await _context.TransferExpenseModel.FindAsync(id);

            if (transferExpenseModel == null)
            {
                return NotFound();
            }

            return transferExpenseModel;
        }


        /// <summary>
        /// This method gets a special expense model.
        /// </summary>
        /// <param name="id"> The id of the special expense model.</param>
        /// <param name="transferExpenseModel"> The special expense model to be modified.</param>
        /// <returns> the modified special expense model.</returns>
        /// <response code="200">Returns the modified special expense model.</response>
        /// <response code="400">If the id of the special expense model is different from the id of the parameter.</response>
        /// <response code="404">If the special expense model is null.</response>
        /// <response code="500">If there was an internal server error.</response>
        /// <example>
        /// PUT: api/TransferExpense/5
        /// </example>
        /// 

        // PUT: api/TransferExpense/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransferExpenseModel(int id, TransferExpenseModel transferExpenseModel)
        {
            if (id != transferExpenseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(transferExpenseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferExpenseModelExists(id))
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
        /// This method creates a special expense model.
        /// </summary>
        /// <param name="transferExpenseModel"> The special expense model to be created.</param>
        /// <returns> The created special expense model.</returns>
        /// <response code="201">Returns the created special expense model.</response>
        /// <response code="400">If the special expense model is null.</response>
        /// <response code="500">If there was an internal server error.</response>
        /// <example>
        /// POST: api/TransferExpense
        /// </example>
        // POST: api/TransferExpense
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransferExpenseModel>> PostTransferExpenseModel(TransferExpenseModel transferExpenseModel)
        {
          if (_context.TransferExpenseModel == null)
          {
              return Problem("Entity set 'Context.TransferExpenseModel'  is null.");
          }
            _context.TransferExpenseModel.Add(transferExpenseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransferExpenseModel", new { id = transferExpenseModel.Id }, transferExpenseModel);
        }

        /// <summary>
        /// This method deletes a special expense model.
        /// </summary>
        /// <param name="id"> The id of the special expense model to be deleted.</param>
        /// <returns> The deleted special expense model.</returns>
        /// <response code="200">Returns the deleted special expense model.</response>
        /// <response code="404">If the special expense model is null.</response>
        /// <response code="500">If there was an internal server error.</response>
        /// <example>
        /// DELETE: api/TransferExpense/5
        /// </example>
        /// 

        // DELETE: api/TransferExpense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransferExpenseModel(int id)
        {
            if (_context.TransferExpenseModel == null)
            {
                return NotFound();
            }
            var transferExpenseModel = await _context.TransferExpenseModel.FindAsync(id);
            if (transferExpenseModel == null)
            {
                return NotFound();
            }

            _context.TransferExpenseModel.Remove(transferExpenseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// This method gets a special expense model.
        /// </summary>
        /// <param name="id"> The id of the special expense model.</param>
        /// <param name="bool"> The boolean to verify if the special expense model exists.</param>

        private bool TransferExpenseModelExists(int id)
        {
            return (_context.TransferExpenseModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
