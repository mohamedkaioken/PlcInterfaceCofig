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

                var machineId = queries["ID"].Value;
                var type = queries["Type"].Value;
                if (type == "Blow")
                {

                    int state = (int)decimal.Parse(queries["State"].Value);
                    int line = (int)decimal.Parse(queries["Line"].Value);
                    int fault = (int)decimal.Parse(queries["Fault"].Value);
                    var factory = queries["Factory"].Value;
                    decimal speed = decimal.Parse(queries["Speed"].Value);
                    int count_in = (int)decimal.Parse(queries["Count_In"].Value);
                    int count_out = (int)decimal.Parse(queries["Count_Out"].Value);
                    int hours = (int)decimal.Parse(queries["Hours"].Value);
                    decimal Temp = decimal.Parse(queries["Temp"].Value);
                    decimal Pressure = decimal.Parse(queries["Pressure"].Value);
                    var Timestamp = DateTime.Now;
                    Blow_Moulder reads = new Blow_Moulder
                    {
                        MachineId=machineId,
                        State = state,
                        Fault = fault,
                        Factory = factory,
                        Line = line,
                        Count_In = count_in,
                        Count_Out = count_out,
                        Pressure = Pressure,
                        Temperature = Temp,
                        Production_Hours = hours,
                        Speed = speed,
                        TimeStamp = Timestamp
                    };
                    _context.Blow_Moulders.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == "Dpal")
                {

                    int state = (int)decimal.Parse(queries["State"].Value);
                    int line = (int)decimal.Parse(queries["Line"].Value);
                    int fault = (int)decimal.Parse(queries["Fault"].Value);
                    var factory = queries["Factory"].Value;
                    decimal speed = decimal.Parse(queries["Speed"].Value);
                    int Count = (int)decimal.Parse(queries["Count"].Value);
                    int hours = (int)decimal.Parse(queries["Hours"].Value);
                    var Timestamp = DateTime.Now;
                    DPalletizer reads = new DPalletizer
                    {
                        MachineId = machineId,
                        State = state,
                        Fault = fault,
                        Factory = factory,
                        Line = line,
                        Count = Count,
                        Hours = hours,
                        Speed = speed,
                        TimeStamp = Timestamp
                    };
                    _context.DPalletizers.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == "Labl")
                {

                    int state = (int)decimal.Parse(queries["State"].Value);
                    int line = (int)decimal.Parse(queries["Line"].Value);
                    int fault = (int)decimal.Parse(queries["Fault"].Value);
                    var factory = queries["Factory"].Value;
                    decimal speed = decimal.Parse(queries["Speed"].Value);
                    int count = (int)decimal.Parse(queries["Count"].Value);
                    int hours = (int)decimal.Parse(queries["Hours"].Value);
                    var Timestamp = DateTime.Now;
                    Label reads = new Label
                    {
                        MachineId = machineId,
                        State = state,
                        Fault = fault,
                        Factory = factory,
                        Line = line,
                        Counts = count,
                        Hours = hours,
                        Speed = speed,
                        TimeStamp = Timestamp
                    };
                    _context.Labels.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == "Cart" || type == "Shrink")
                {

                    int state = (int)decimal.Parse(queries["State"].Value);
                    int line = (int)decimal.Parse(queries["Line"].Value);
                    int fault = (int)decimal.Parse(queries["Fault"].Value);
                    var factory = queries["Factory"].Value;
                    decimal speed = decimal.Parse(queries["Speed"].Value);
                    int count = (int)decimal.Parse(queries["Count"].Value);
                    int hours = (int)decimal.Parse(queries["Hours"].Value);
                    var Timestamp = DateTime.Now;
                    Cartonizer_Shrink reads = new Cartonizer_Shrink
                    {
                        MachineId = machineId,
                        State = state,
                        Fault = fault,
                        Factory = factory,
                        Line = line,
                        Counts = count,
                        Hours = hours,
                        Speed = speed,
                        TimeStamp = Timestamp
                    };
                    _context.Cartonizers_Shrinks.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == "Fill")
                {

                    int state = (int)decimal.Parse(queries["State"].Value);
                    int line = (int)decimal.Parse(queries["Line"].Value);
                    int fault = (int)decimal.Parse(queries["Fault"].Value);
                    var factory = queries["Factory"].Value;
                    decimal speed = decimal.Parse(queries["Speed"].Value);
                    decimal co2 = decimal.Parse(queries["Co2"].Value);
                    int count = (int)decimal.Parse(queries["Count"].Value);
                    int alarms = (int)decimal.Parse(queries["Alarms"].Value);
                    int hours = (int)decimal.Parse(queries["Hours"].Value);
                    decimal Mix_Vol = decimal.Parse(queries["Mix_vol"].Value);
                    int Mix_select = (int)decimal.Parse(queries["Mix_select"].Value);
                    int Rinse = (int)decimal.Parse(queries["Rinse"].Value);
                    var Timestamp = DateTime.Now;
                    Filler reads = new Filler
                    {
                        MachineId = machineId,
                        State = state,
                        Fault = fault,
                        Factory = factory,
                        Line = line,
                        Count = count,
                        Alarms = alarms,
                        Mix_vol = Mix_Vol,
                        Mix_select = Mix_select,
                        Production_Hours = hours,
                        Speed = speed,
                        Rinse = Rinse,
                       Co2_Consumption = co2,
                        TimeStamp = Timestamp
                    };
                    _context.Fillers.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if (type == "Pall")
                {
                    int state = (int)decimal.Parse(queries["State"].Value);
                    int line = (int)decimal.Parse(queries["Line"].Value);
                    int fault = (int)decimal.Parse(queries["Fault"].Value);
                    var factory = queries["Factory"].Value;
                    int Pallet_Count = (int)decimal.Parse(queries["Pallet_No"].Value);
                    int Pack_Count = (int)decimal.Parse(queries["Packet_No"].Value);
                    int hours = (int)decimal.Parse(queries["Hours"].Value);
                    var Timestamp = DateTime.Now;
                    Palletizer reads = new Palletizer
                    {
                        MachineId = machineId,
                        State = state,
                        Fault = fault,
                        Pallet_No = Pallet_Count,
                        Packet_No = Pack_Count,
                        Line =line,
                        Production_Hours= hours,
                        Factory = factory,
                        TimeStamp = Timestamp
                    };
                    _context.Palletizers.Add(reads);
                    await _context.SaveChangesAsync();
                    return Ok("ok");
                }
                else if(type == "Mixx")
                {
                    int state = (int)decimal.Parse(queries["State"].Value);
                    int line = (int)decimal.Parse(queries["Line"].Value);
                    int fault = (int)decimal.Parse(queries["Fault"].Value);
                    var factory = queries["Factory"].Value;
                    decimal Product = decimal.Parse(queries["Product"].Value);
                    decimal Water = decimal.Parse(queries["Water"].Value);
                    decimal Co2 = decimal.Parse(queries["Co2"].Value);
                    decimal Syrup = decimal.Parse(queries["Syrup"].Value);
                    int hours = (int)decimal.Parse(queries["Hours"].Value);
                    var Timestamp = DateTime.Now;
                    Mixer reads = new Mixer
                    {
                        MachineId = machineId,
                        State = state,
                        Fault = fault,
                        Water_Consumption = Water,
                        Co2_Consumption = Co2,
                        Product_Consumption = Product,
                        Syrup_Consumption = Syrup,
                        Line = line,
                        Production_Hours = hours,
                        Factory = factory,
                        TimeStamp = Timestamp
                    };
                    _context.Mixers.Add(reads);
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
            var configOne = await _context.ConfigOne.FindAsync(id);

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
            _context.ConfigOne.Add(configOne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigOne", new { id = configOne.Id }, configOne);
        }

        // DELETE: api/Plc/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConfigOne>> DeleteConfigOne(int id)
        {
            var configOne = await _context.ConfigOne.FindAsync(id);
            if (configOne == null)
            {
                return NotFound();
            }

            _context.ConfigOne.Remove(configOne);
            await _context.SaveChangesAsync();

            return configOne;
        }

        private bool ConfigOneExists(int id)
        {
            return _context.Fillers.Any(e => e.Id == id);
        }
    }
}
