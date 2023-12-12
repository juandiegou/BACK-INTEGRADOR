// Purpose: Controlls the Discount Model
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Api.Models.parameters;

namespace API.Controllers
{
    /// <summary>
    /// this class represents the controller of the discount model.
    /// </summary>
    /// <remarks>
    /// This controller has the following methods: GetDiscountModel, PutDiscountModel, PostDiscountModel, DeleteDiscountModel.
    /// </remarks>
    /// <example>
    /// GET: api/Discount
    /// </example>
    [Route("api/[controller]")]
    [ApiController]
    ///[Authorize]
    public class DiscountController : ControllerBase
    {
        private readonly Context _context;
        public DiscountController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// This method gets all the discounts.
        /// </summary>
        /// <returns>all the discounts</returns>
        /// <response code="200">returns all the discounts</response>
        /// <response code="404">if the discounts are null</response>
        /// <response code="500">if the entity set 'Context.DiscountModel' is null</response>
        /// <example>
        /// GET: api/Discount
        /// </example>

        // GET: api/Discount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountModel>>> GetDiscountModel()
        {
            if (_context.DiscountModel == null)
            {
                return NotFound();
            }
            return await _context.DiscountModel.ToListAsync();
        }

        /// <summary>
        /// this method gets a discount by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a discount by id</returns>
        /// <response code="200">returns a discount by id</response>
        /// <response code="404">if the discount is null</response>
        /// <response code="500">if the entity set 'Context.DiscountModel' is null</response>
        /// <example>
        /// GET: api/Discount/5
        /// </example>

        // GET: api/Discount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountModel>> GetDiscountModel(int id)
        {
            if (_context.DiscountModel == null)
            {
                return NotFound();
            }
            var discountModel = await _context.DiscountModel.FindAsync(id);

            if (discountModel == null)
            {
                return NotFound();
            }

            return discountModel;
        }

        /// <summary>
        /// this method updates a discount.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="discountModel"></param>
        /// <returns>an updated discount</returns>
        /// <response code="204">returns an updated discount</response>
        /// <response code="400">if the id is not equal to the discount id</response>
        /// <response code="404">if the discount is null</response>
        /// <response code="500">if the entity set 'Context.DiscountModel' is null</response>
        /// <example>
        /// PUT: api/Discount/5
        /// </example>
        /// 
        // PUT: api/Discount/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscountModel(int id, DiscountModel discountModel)
        {
            if (id != discountModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(discountModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountModelExists(id))
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
        /// this method creates a discount.
        /// </summary>
        /// <param name="discountModel"></param>
        ///  <returns>a created discount</returns>
        /// <response code="201">returns a created discount</response>
        /// <response code="500">if the entity set 'Context.DiscountModel' is null</response>
        /// <example>
        /// POST: api/Discount
        /// </example>
        // POST: api/Discount
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiscountModel>> PostDiscountModel(DiscountModel discountModel)
        {
            if (_context.DiscountModel == null)
            {
                return Problem("Entity set 'Context.DiscountModel'  is null.");
            }
            _context.DiscountModel.Add(discountModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscountModel", new { id = discountModel.Id }, discountModel);
        }

        /// <summary>
        /// this method deletes a discount.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a deleted discount</returns>
        /// <response code="204">returns a deleted discount</response>
        ///  <response code="404">if the discount is null</response>
        /// <response code="500">if the entity set 'Context.DiscountModel' is null</response>
        /// <example>
        /// DELETE: api/Discount/5
        /// </example>
        // DELETE: api/Discount/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountModel(int id)
        {
            if (_context.DiscountModel == null)
            {
                return NotFound();
            }
            var discountModel = await _context.DiscountModel.FindAsync(id);
            if (discountModel == null)
            {
                return NotFound();
            }

            _context.DiscountModel.Remove(discountModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// this method checks if a discount exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> a boolean value</returns>
        private bool DiscountModelExists(int id)
        {
            return (_context.DiscountModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
