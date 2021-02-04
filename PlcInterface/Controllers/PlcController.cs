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
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigOne>>> GetConfigsOne()
        {
            return await _context.ConfigsOne.ToListAsync();
        }
*/

        [HttpGet]
        public async Task<ActionResult> plc()
        {
            try
            {
                var queries = HttpContext.Request.Query.ToDictionary(o => o.Key);

                var BrokerId = queries["ID"].Value;
                var machineId = queries["M1"].Value;
                int type = (int)decimal.Parse(queries["T"].Value);
                if (type == 1)
                {

                    int state = (int)decimal.Parse(queries["State"].Value);
                    decimal fault = decimal.Parse(queries["Fault"].Value);
                    decimal CO2 = decimal.Parse(queries["CO2"].Value);
                    decimal H2O = decimal.Parse(queries["H2O"].Value);
                    decimal SYRUP = decimal.Parse(queries["SYRUP"].Value);
                    var Timestamp = DateTime.Now;
                    ConfigOne reads = new ConfigOne
                    {
                        BrokerId = BrokerId,
                        MachineId=machineId,
                        State = state,
                        Fault = fault,
                        Co2 = CO2,
                        H2O = H2O,
                        Syrp = SYRUP,
                        TimeStamp = Timestamp
                    };
                    _context.ConfigsOne.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == 2)
                {
                    
                    int state = (int)decimal.Parse(queries["State"].Value);
                    decimal fault = decimal.Parse(queries["Fault"].Value);
                    int Prod_Counter = (int)decimal.Parse(queries["Prod_Counter"].Value);
                    decimal Prod_Speed = decimal.Parse(queries["Prod_Speed"].Value);
                    decimal Mix_Volu = decimal.Parse(queries["Mix_Volu"].Value);
                    int Program = (int)decimal.Parse(queries["Program"].Value);
                    var Timestamp = DateTime.Now;
                    ConfigTwo reads = new ConfigTwo
                    {
                        BrokerId = BrokerId,
                        MachineId = machineId,
                        State = state,
                        Fault = fault,
                        ProductionCount = Prod_Counter,
                        ActualSpeed = Prod_Speed,
                        MixVolume = Mix_Volu,
                        ProgramSelection = Program,
                        TimeStamp = Timestamp
                    };
                    _context.ConfigsTwo.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == 3)
                {
                    int state = (int)decimal.Parse(queries["State"].Value);
                    decimal fault = decimal.Parse(queries["Fault"].Value);
                    int Pallet_Count = (int)decimal.Parse(queries["Pallet_Count"].Value);
                    int Pack_Count = (int)decimal.Parse(queries["Pack_Count"].Value);
                    var Timestamp = DateTime.Now;
                    ConfigThree reads = new ConfigThree
                    {
                        BrokerId = BrokerId,
                        MachineId = machineId,
                        State = state,
                        Fault = fault,
                        PallateCount = Pallet_Count,
                        PackCount = Pallet_Count,
                        TimeStamp = Timestamp
                    };
                    _context.ConfigsThree.Add(reads);
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
        }

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
