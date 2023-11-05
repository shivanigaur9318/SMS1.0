using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS1._0TransactionServices.DB_Context;
using SMS1._0TransactionServices.Models;

namespace SMS1._0TransactionServices.Controllers
{

    [Route("api/[controller]/action")]
    [ApiController]
    public class SMSMembershipController : Controller
    {
        private readonly DataBaseContext _dbContext;
        public SMSMembershipController(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SMSMembershipMapping>>> GetSMSMembershipMapping()
        {
            return await _dbContext.SMSMembershipMapping.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SMSMembershipMapping>> GetSMSMembershipMapping(int id)
        {
            var SMSMembershipMapping = await _dbContext.SMSMembershipMapping.ToListAsync();
            if (SMSMembershipMapping == null)
            {
                return NotFound();
            }
            return Ok(SMSMembershipMapping);
        }
        [HttpPut("{id}")]
        public async Task<Boolean> PutSMSMembershipMapping(int id, SMSMembershipMapping SMSMembershipMapping)
        {
            if (id != SMSMembershipMapping.MembershipMappingId)
            {
                return false;
            }
            else
            {
                _dbContext.Entry(SMSMembershipMapping).State = EntityState.Modified;
            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!smsMebershipMappingExists(id))
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
        public async Task<ActionResult<SMSMembershipMapping>> PostSMSMembershipMapping(SMSMembershipMapping SMSMembershipMapping)
        {
            _dbContext.SMSMembershipMapping.Add(SMSMembershipMapping);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetSMSMembershipMapping", SMSMembershipMapping);
        }

        private bool smsMebershipMappingExists(int id)
        {
            return _dbContext.SMSMembershipMapping.Any(e => e.MembershipMappingId == id);
        }
    }

}
