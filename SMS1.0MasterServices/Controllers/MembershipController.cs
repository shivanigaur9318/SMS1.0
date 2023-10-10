using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS1._0MasterServices.DBContext;
using SMS1._0MasterServices.Models;

namespace SMS1._0MasterServices.Controllers
{
    [ApiController]
    [Route("api/[controller]/action")]
    public class MembershipController:Controller
    {
        private readonly DatabaseContext _dbcontext;
        public MembershipController(DatabaseContext dbcontext) {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<Membership>>> GetMembership()
        {
            return await _dbcontext.Membership.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Membership>>GetMembership(int id)
        {
            var Membership=await _dbcontext.Membership.FindAsync(id);
            if (Membership==null)
            {
                return NotFound(); 
            }
            return Ok(Membership); 
        }
        [HttpPut("{id}")]
        public async Task<Boolean> PutMembership(int id, Membership Membership)
        {
            if (id != Membership.MembershipId)
            {
                return false;
            }
            else
            {
                _dbcontext.Entry(Membership).State = EntityState.Modified;
            }
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipExist(id))
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

        public async Task<ActionResult<Membership>> PostMembership(Membership Membership)
        {
            _dbcontext.Membership.Add(Membership);
            await _dbcontext.SaveChangesAsync();

            return CreatedAtAction("GetMembership", Membership);
        }


        private bool MembershipExist(int id)
            {
                return _dbcontext.Membership.Any(e => e.MembershipId == id);
            }



        }
}
