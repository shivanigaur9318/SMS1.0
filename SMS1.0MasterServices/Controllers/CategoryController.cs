using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS1._0MasterServices.DBContext;
using SMS1._0MasterServices.Models;

namespace SMS1._0MasterServices.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class CategoryContrller : Controller
    {
        private readonly DatabaseContext _dbContext;
        public CategoryContrller(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GetCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _dbContext.Category.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var Category = await _dbContext.Category.ToListAsync();
            if (Category == null)
            {
                return NotFound();
            }
            return Ok(Category);
        }
        [HttpPut("{id}")]
        public async Task<Boolean> PutCategory(int id, Category Category)
        {
            if (id != Category.CategoryId)
            {
                return false;
            }
            else
            {
                _dbContext.Entry(Category).State = EntityState.Modified;
            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        [HttpPost]
        public async Task<ActionResult<Category>>PostCategory(Category Category)
        {
             _dbContext.Category.Add(Category);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetCategory", Category);
        }

        private bool categoryExists(int id)
        {
            return _dbContext.Category.Any(e => e.CategoryId == id);
        }
    }
}
