using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS1._0MasterServices.DBContext;
using SMS1._0MasterServices.Models;

namespace SMS1._0MasterServices.Controllers
{

    [Route("api/[controller]/action")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly DatabaseContext _dbContext;
        public ProductController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        // Get:api/Product

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _dbContext.Product.ToListAsync();
        }

        //Get:api/Product/id

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProudct(int id)
        {
            var Product = await _dbContext.Product.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Product;
        }

        //Put:api/Product/id

        [HttpPut("{id}")]
        public async Task<Boolean> PutProduct(int id, Product Product)
        {
            if (id != Product.ProductId)
            {
                return false;
            }
            else
            {
                _dbContext.Entry(Product).State = EntityState.Modified;
            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        //Post:api/Prouduct

        [HttpPost]
        public async Task<ActionResult<Product>>PostProduct(Product Product)
        {
            _dbContext.Product.Add(Product);
            await _dbContext.SaveChangesAsync();
          
            return CreatedAtAction("GetProduct", Product);
        } 


        private bool ProductExists(int id)
        {
          return _dbContext.Product.Any(e=>e.ProductId == id);
        }
    }
}
