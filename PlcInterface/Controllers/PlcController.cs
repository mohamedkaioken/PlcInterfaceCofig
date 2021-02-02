using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlcInterface.Context;
using PlcInterface.Models;

namespace PlcInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Plc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigOne>>> GetConfigsOne()
        {
            return await _context.ConfigsOne.ToListAsync();
        }


        /*[HttpGet]
        public async Task<ActionResult> plc()
        {
            try
            {
                var queries = HttpContext.Request.Query.ToDictionary(o => o.Key);

                var BrokerId = queries["ID"].Value;
                int type = (int)decimal.Parse(queries["T"].Value);
                if (type == 1)
                {
                    var machine1 = queries["M1"].Value;
                    var machine2 = queries["M2"].Value;
                    var machine3 = queries["M3"].Value;
                    var machine4 = queries["M4"].Value;

                    int state1 = (int)decimal.Parse(queries["S1"].Value);
                    int state2 = (int)decimal.Parse(queries["S2"].Value);
                    int state3 = (int)decimal.Parse(queries["S3"].Value);
                    int state4 = (int)decimal.Parse(queries["S4"].Value);
                    var Timestamp = DateTime.Now;
                    Reads reads = new Reads
                    {
                        BrokerId = BrokerId,
                        MachineId1 = machine1,
                        MachineId2 = machine2,
                        MachineId3 = machine3,
                        MachineId4 = machine4,
                        state1 = state1,
                        state2 = state2,
                        state3 = state3,
                        state4 = state4,
                        TimeStamp = Timestamp
                    };
                    _context.ConfigsOne.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == 2)
                {
                    var machineId = queries["M1"].Value;

                    int In = int.Parse(queries["IN"].Value);
                    int Out = int.Parse(queries["OUT"].Value);
                    int Diff = int.Parse(queries["DIFF"].Value);
                    var Timestamp = DateTime.Now;
                    ReadsTypetwo reads = new ReadsTypetwo
                    {
                        BrokerId = BrokerId,
                        MachineId = machineId,
                        In = In,
                        Out = Out,
                        Diff = Diff,
                        TimeStamp = Timestamp
                    };
                    _context.SignalBrokerTypeTwo.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == 3)
                {
                    var machineId = queries["M1"].Value;

                    int In = int.Parse(queries["IN"].Value);
                    int Out = int.Parse(queries["OUT"].Value);
                    int Diff = int.Parse(queries["DIFF"].Value);
                    var Timestamp = DateTime.Now;
                    ReadsTypetwo reads = new ReadsTypetwo
                    {
                        BrokerId = BrokerId,
                        MachineId = machineId,
                        In = In,
                        Out = Out,
                        Diff = Diff,
                        TimeStamp = Timestamp
                    };
                    _context.SignalBrokerTypeTwo.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else
                {
                    return Ok("ok0");

                }

            }
            catch (Exception e)
            {
                return Ok("ok" + e.Message);
            }
        }*/

        // GET: api/Plc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigOne>> GetConfigOne(int id)
        {
            var configOne = await _context.ConfigsOne.FindAsync(id);

            if (configOne == null)
            {
                return NotFound();
            }

            return configOne;
        }

        // PUT: api/Plc/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigOne(int id, ConfigOne configOne)
        {
            if (id != configOne.Id)
            {
                return BadRequest();
            }

            _context.Entry(configOne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigOneExists(id))
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

        // POST: api/Plc
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ConfigOne>> PostConfigOne(ConfigOne configOne)
        {
            _context.ConfigsOne.Add(configOne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigOne", new { id = configOne.Id }, configOne);
        }

        // DELETE: api/Plc/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConfigOne>> DeleteConfigOne(int id)
        {
            var configOne = await _context.ConfigsOne.FindAsync(id);
            if (configOne == null)
            {
                return NotFound();
            }

            _context.ConfigsOne.Remove(configOne);
            await _context.SaveChangesAsync();

            return configOne;
        }

        private bool ConfigOneExists(int id)
        {
            return _context.ConfigsOne.Any(e => e.Id == id);
        }
    }
}
