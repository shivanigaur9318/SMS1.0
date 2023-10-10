using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS1._0MasterServices.DBContext;
using SMS1._0MasterServices.Models;

namespace SMS1._0MasterServices.Controllers
{ 
    [ApiController]
    [Route("api/[controller]/action")]
  
    public class SMSUserController : Controller { 

    private readonly DatabaseContext _dbContext;
        public SMSUserController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SMSUser>>> GetSMSUser()
        {
            return await _dbContext.SMSUser.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SMSUser>> GetSMSUser(int id)
        {
            var SMSUser = await _dbContext.SMSUser.ToListAsync();
            if (SMSUser == null)
            {
                NotFound();
            }
            return Ok(SMSUser);
        }

        [HttpPut("{id}")]
        public async Task<Boolean> PutRole(int id,SMSUser SMSUser)
        {
            if (id != SMSUser.UserId)
            {
                return false;
            }
            else
            {
                _dbContext.Entry(SMSUser).State = EntityState.Modified;
            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SMSUserExists(id))
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
        public async Task<ActionResult<Role>> PostSMSUser(SMSUser SMSUser)
        {
            _dbContext.SMSUser.Add(SMSUser);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetSMSUser", SMSUser);
        }



        private bool SMSUserExists(int id)
        {
            return _dbContext.SMSUser.Any(e => e.UserId == id);
        }

    }
}
