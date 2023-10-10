using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS1._0MasterServices.DBContext;
using SMS1._0MasterServices.Models;

namespace SMS1._0MasterServices.Controllers
{
    [ApiController]
    [Route("api/[controller]/action")]
    public class RoleController : Controller
    {
        private readonly DatabaseContext _dbContext;
        public RoleController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRole()
        {
            return await _dbContext.Role.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>>GetRole(int id)
        {
            var Role = await _dbContext.Role.ToListAsync();
            if(Role == null)
            {
                NotFound();
            }
            return Ok(Role) ;
        }

        [HttpPut("{id}")]
        public async Task<Boolean>PutRole(int id,Role Role)
        {
            if (id != Role.RoleId)
            {
                return false;
            }
            else
            {
                _dbContext.Entry(Role).State = EntityState.Modified;
            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        public async Task<ActionResult<Role>>PostRole(Role Role)
        {
            _dbContext.Role.Add(Role);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetRole", Role);
        }


        private bool  RoleExists(int id)
        {
            return _dbContext.Role.Any(e => e.RoleId == id); 
        }

    }
}
