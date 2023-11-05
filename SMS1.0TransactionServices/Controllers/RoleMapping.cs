using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS1._0TransactionServices.DB_Context;
using SMS1._0TransactionServices.Models;

namespace SMS1._0TransactionServices.Controllers
{

    [Route("api/[controller]/action")]
    [ApiController]
    public class RoleMappingController : Controller
    {
        private readonly DataBaseContext _dbContext;
        public RoleMappingController(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleMapping>>> GetRoleMapping()
        {
            return await _dbContext.RoleMapping.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleMapping>> GetRoleMapping(int id)
        {
            var RoleMapping = await _dbContext.RoleMapping.ToListAsync();
            if (RoleMapping == null)
            {
                return NotFound();
            }
            return Ok(RoleMapping);
        }
        [HttpPut("{id}")]
        public async Task<Boolean> PutRoleMapping(int id, RoleMapping RoleMapping)
        {
            if (id != RoleMapping.RoleMappingId)
            {
                return false;
            }
            else
            {
                _dbContext.Entry(RoleMapping).State = EntityState.Modified;
            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roleMappingExists(id))
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
        public async Task<ActionResult<RoleMapping>> PostRoleMapping(RoleMapping RoleMapping)
        {
            _dbContext.RoleMapping.Add(RoleMapping);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetRoleMapping", RoleMapping);
        }

        private bool roleMappingExists(int id)
        {
            return _dbContext.RoleMapping.Any(e => e.RoleMappingId == id);
        }
    }

}
