using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlcInterface.Context;
using PlcInterface.Models;
using PlcInterface.Models.DTO;

namespace PlcInterface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly MesContext _mContext;
        private readonly EnergyContext _eContext;
        private readonly EnergyReportContext _erContext;
        private readonly SignalContext _sContext;

        public PlcController(ApplicationDbContext context, MesContext mContext, EnergyContext eContext, EnergyReportContext erContext, SignalContext sContext)
        {
            _context = context;
            _mContext = mContext;
            _eContext = eContext;
            _erContext = erContext;
            _sContext = sContext;
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

        [HttpGet("Hierarchy/{Factory}")]
        public ActionResult Hierarchy(int Factory)
        {
            var factory = _mContext.Factories.Where(r => r.Id == Factory).FirstOrDefault();
            TreeDTO treeDTO = new TreeDTO
            {
                name = factory.Name,
                id = factory.Id,
                code = factory.Name,
                img = "factory.svg",
            };
            var functions = _mContext.ProductionLines.Where(r => r.FactoryId == Factory).ToList();
            var utilities = _mContext.Utilities.Where(r => r.FactoryId == Factory).ToList();
            TreeDTO treeDTO4 = new TreeDTO
            {
                name = "Production Lines",
                id = 1,
                code = "Production Lines",
                img = "factory.svg",
            };
            TreeDTO treeDTO5 = new TreeDTO
            {
                name = "Utilities",
                id = 2,
                code = "Utilities",
                img = "factory.svg",
            };
            foreach (var function in functions)
            {
                TreeDTO treeDTO2 = new TreeDTO
                {
                    name = function.Name,
                    id = function.Id,
                    code = function.Name,
                    img = "function.svg",
                };

                var loads = _mContext.Loads.Where(r => r.ProductionLineId == function.Id).Select(r => new { r.Id, r.EnergyCode,r.PlcCode,r.SignalCode, r.Name }).ToList();
                foreach (var load in loads)
                {
                    TreeDTO treeDTO3 = new TreeDTO
                    {
                        name = load.Name,
                        id = load.Id,
                        energyCode = load.EnergyCode,
                        plcCode = load.PlcCode,
                        signalCode = load.SignalCode,
                        img = "load.svg",
                    };
                    treeDTO2.children.Add(treeDTO3);
                }
                treeDTO4.children.Add(treeDTO2);
            }
            treeDTO.children.Add(treeDTO4);
            foreach (var uti in utilities)
            {
                TreeDTO treeDTO2 = new TreeDTO
                {
                    name = uti.Name,
                    id = uti.Id,
                    code = uti.Name,
                    img = "function.svg",
                };

                var loads = _mContext.Loads.Where(r => r.UtilityId == uti.Id).Select(r => new { r.Id, r.EnergyCode, r.PlcCode, r.SignalCode, r.Name }).ToList();
                foreach (var load in loads)
                {
                    TreeDTO treeDTO3 = new TreeDTO
                    {
                        name = load.Name,
                        id = load.Id,
                        energyCode = load.EnergyCode,
                        plcCode = load.PlcCode,
                        signalCode = load.SignalCode,
                        img = "load.svg",
                    };
                    treeDTO2.children.Add(treeDTO3);
                }
                treeDTO5.children.Add(treeDTO2);
            }
            treeDTO.children.Add(treeDTO5);
            return Ok(treeDTO);
        }
        [HttpGet("Parameters/{load}")]
        public ActionResult Hierarchy(string load)
        {
            var loadDetails = _mContext.Loads.Where(r => r.PlcCode == load || r.SignalCode == load || r.EnergyCode == load).FirstOrDefault();
            var loadParameters = _mContext.MachineParameters.Where(r => r.MachineCode == load).ToList();
            TreeDTO treeDTO = new TreeDTO
            {
                name = loadDetails.Name,
                id = loadDetails.Id,
                energyCode = loadDetails.EnergyCode,
                signalCode = loadDetails.SignalCode,
                plcCode = loadDetails.PlcCode,
                img = "factory.svg",
            };
            foreach (var function in loadParameters)
            {
                TreeDTO treeDTO2 = new TreeDTO
                {
                    name = function.ParameterName,
                    id = function.Id,
                    code = function.ParameterName,
                    img = "function.svg",
                };

                treeDTO.children.Add(treeDTO2);
            }
            
            return Ok(treeDTO);
        }
        [HttpGet("ValueOfTree/{Load}/{Option}/{Duration}/{Resolution}")]
        public ActionResult ValueOfTree(string Load, int Option, int Duration, int Resolution)
        {
            var loadEnergy = _mContext.Loads.Where(r=>r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
            if (loadEnergy.EnergyCode != null)
            {
                if (Duration == 1)
                {
                    var from = DateTime.Today;
                    var to = DateTime.Now;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.I1, r.I2, r.I3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "Amper"
                                };
                                phase.Phase1 = energyTime.Select(r => r.I1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.I2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.I3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.V1, r.V2, r.V3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "Voltage"
                                };
                                phase.Phase1 = energyTime.Select(r => r.V1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.V2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.V3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.PF1, r.PF2, r.PF3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = energyTime.Select(r => r.PF1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.PF2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.PF3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.Pact1, r.Pact2, r.Pact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.Pact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.Pact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.Pact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.Preact1, r.Preact2, r.Preact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVAR"
                                };
                                phase.Phase1 = energyTime.Select(r => r.Preact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.Preact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.Preact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.Papp1, r.Papp2, r.Papp3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVA"
                                };
                                phase.Phase1 = energyTime.Select(r => r.Papp1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.Papp2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.Papp3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 7)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.Energy1, r.Energy2, r.Energy3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.Energy1).DefaultIfEmpty(0).Sum();
                                phase.Phase2 = energyTime.Select(r => r.Energy2).DefaultIfEmpty(0).Sum();
                                phase.Phase3 = energyTime.Select(r => r.Energy3).DefaultIfEmpty(0).Sum();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 8)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.THDi1, r.THDi2, r.THDi3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.THDi1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.THDi2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.THDi3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 9)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.THDv1, r.THDv2, r.THDv3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.THDv1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.THDv2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.THDv3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 2)
                {
                    var from = DateTime.Today.AddDays(-1);
                    var to = DateTime.Today;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgI1, r.AvgI2, r.AvgI3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "Amper"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgI1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgI2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgI3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgV1, r.AvgV2, r.AvgV3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "V"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgV1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgV2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgV3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPF1, r.AvgPF2, r.AvgPF3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPF1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPF2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPF3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPact1, r.AvgPact2, r.AvgPact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPreact1, r.AvgPreact2, r.AvgPreact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVAR"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPreact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPreact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPreact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPapp1, r.AvgPapp2, r.AvgPapp3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVA"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPapp1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPapp2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPapp3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 7)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.SumEnergy1, r.SumEnergy2, r.SumEnergy3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.SumEnergy1).DefaultIfEmpty(0).Sum();
                                phase.Phase2 = energyTime.Select(r => r.SumEnergy2).DefaultIfEmpty(0).Sum();
                                phase.Phase3 = energyTime.Select(r => r.SumEnergy3).DefaultIfEmpty(0).Sum();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 8)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgTHDi1, r.AvgTHDi2, r.AvgTHDi3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgTHDi1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgTHDi2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgTHDi3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 9)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotMins.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgTHDv1, r.AvgTHDv2, r.AvgTHDv3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgTHDv1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgTHDv2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgTHDv3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 3)
                {
                    var from = DateTime.Today.AddDays(-7);
                    var to = DateTime.Today;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgI1, r.AvgI2, r.AvgI3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "Amper"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgI1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgI2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgI3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgV1, r.AvgV2, r.AvgV3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "V"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgV1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgV2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgV3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPF1, r.AvgPF2, r.AvgPF3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPF1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPF2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPF3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPact1, r.AvgPact2, r.AvgPact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPreact1, r.AvgPreact2, r.AvgPreact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVAR"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPreact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPreact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPreact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPapp1, r.AvgPapp2, r.AvgPapp3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVA"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPapp1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPapp2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPapp3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 7)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.SumEnergy1, r.SumEnergy2, r.SumEnergy3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.SumEnergy1).DefaultIfEmpty(0).Sum();
                                phase.Phase2 = energyTime.Select(r => r.SumEnergy2).DefaultIfEmpty(0).Sum();
                                phase.Phase3 = energyTime.Select(r => r.SumEnergy3).DefaultIfEmpty(0).Sum();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 8)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgTHDi1, r.AvgTHDi2, r.AvgTHDi3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgTHDi1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgTHDi2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgTHDi3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 9)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgTHDv1, r.AvgTHDv2, r.AvgTHDv3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgTHDv1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgTHDv2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgTHDv3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 4)
                {
                    var from = DateTime.Today.AddMonths(-1);
                    var to = DateTime.Today;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgI1, r.AvgI2, r.AvgI3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "Amper"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgI1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgI2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgI3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgV1, r.AvgV2, r.AvgV3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "V"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgV1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgV2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgV3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPF1, r.AvgPF2, r.AvgPF3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPF1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPF2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPF3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPact1, r.AvgPact2, r.AvgPact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPreact1, r.AvgPreact2, r.AvgPreact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVAR"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPreact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPreact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPreact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPapp1, r.AvgPapp2, r.AvgPapp3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVA"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPapp1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPapp2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPapp3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 7)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.SumEnergy1, r.SumEnergy2, r.SumEnergy3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.SumEnergy1).DefaultIfEmpty(0).Sum();
                                phase.Phase2 = energyTime.Select(r => r.SumEnergy2).DefaultIfEmpty(0).Sum();
                                phase.Phase3 = energyTime.Select(r => r.SumEnergy3).DefaultIfEmpty(0).Sum();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 8)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgTHDi1, r.AvgTHDi2, r.AvgTHDi3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgTHDi1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgTHDi2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgTHDi3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 9)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgTHDv1, r.AvgTHDv2, r.AvgTHDv3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgTHDv1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgTHDv2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgTHDv3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 5)
                {
                    var from = DateTime.Today.AddMonths(-3);
                    var to = DateTime.Today;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgI1, r.AvgI2, r.AvgI3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "Amper"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgI1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgI2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgI3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgV1, r.AvgV2, r.AvgV3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "V"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgV1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgV2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgV3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPF1, r.AvgPF2, r.AvgPF3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPF1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPF2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPF3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPact1, r.AvgPact2, r.AvgPact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPreact1, r.AvgPreact2, r.AvgPreact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVAR"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPreact1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPreact2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPreact3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgPapp1, r.AvgPapp2, r.AvgPapp3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVA"
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgPapp1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgPapp2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgPapp3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 7)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.SumEnergy1, r.SumEnergy2, r.SumEnergy3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = energyTime.Select(r => r.SumEnergy1).DefaultIfEmpty(0).Sum();
                                phase.Phase2 = energyTime.Select(r => r.SumEnergy2).DefaultIfEmpty(0).Sum();
                                phase.Phase3 = energyTime.Select(r => r.SumEnergy3).DefaultIfEmpty(0).Sum();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 8)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgTHDi1, r.AvgTHDi2, r.AvgTHDi3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgTHDi1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgTHDi2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgTHDi3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 9)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _erContext.AggregatedIotDays.Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.AvgTHDv1, r.AvgTHDv2, r.AvgTHDv3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name
                                };
                                phase.Phase1 = energyTime.Select(r => r.AvgTHDv1).DefaultIfEmpty(0).Average();
                                phase.Phase2 = energyTime.Select(r => r.AvgTHDv2).DefaultIfEmpty(0).Average();
                                phase.Phase3 = energyTime.Select(r => r.AvgTHDv3).DefaultIfEmpty(0).Average();
                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 6)
                {
                    var from = DateTime.Today;
                    var to = DateTime.Now;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.I1, r.I2, r.I3, r.TimeStamp }).ToList();
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "Amper"
                                };
                                phase.Phase1 = loadD.I1;
                                phase.Phase2 = loadD.I2;
                                phase.Phase3 = loadD.I3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.V1, r.V2, r.V3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "V"
                                };
                                phase.Phase1 = loadD.V1;
                                phase.Phase2 = loadD.V2;
                                phase.Phase3 = loadD.V3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.PF1, r.PF2, r.PF3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = loadD.PF1;
                                phase.Phase2 = loadD.PF2;
                                phase.Phase3 = loadD.PF3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.Pact1, r.Pact2, r.Pact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = loadD.Pact1;
                                phase.Phase2 = loadD.Pact2;
                                phase.Phase3 = loadD.Pact3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.Preact1, r.Preact2, r.Preact3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVAR"
                                };
                                phase.Phase1 = loadD.Preact1;
                                phase.Phase2 = loadD.Preact2;
                                phase.Phase3 = loadD.Preact3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.Papp1, r.Papp2, r.Papp3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KVA"
                                };
                                phase.Phase1 = loadD.Papp1;
                                phase.Phase2 = loadD.Papp2;
                                phase.Phase3 = loadD.Papp3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 7)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.Energy1, r.Energy2, r.Energy3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = "KWH"
                                };
                                phase.Phase1 = loadD.Energy1;
                                phase.Phase2 = loadD.Energy2;
                                phase.Phase3 = loadD.Energy3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 8)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.THDi1, r.THDi2, r.THDi3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = loadD.THDi1;
                                phase.Phase2 = loadD.THDi2;
                                phase.Phase3 = loadD.THDi3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 9)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _eContext.IotTransactions.OrderByDescending(r => r.Id).Take(100).Where(r => r.SourceId == Load && r.TimeStamp >= from && r.TimeStamp < to).Select(r => new { r.Id, r.THDv1, r.THDv2, r.THDv3, r.TimeStamp }).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load).FirstOrDefault();
                        foreach (var loadD in loadData)
                        {
                            if (loadData.Any())
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.EnergyCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = loadD.THDv1;
                                phase.Phase2 = loadD.THDv2;
                                phase.Phase3 = loadD.THDv3;
                                phase.TimeStamp = loadD.TimeStamp;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
            }
            else if(loadEnergy.SignalCode != null)
            {
                if (Duration == 1)
                {
                    var from = DateTime.Today;
                    var to = DateTime.Now;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.SignalCode,
                                    Name = load.Name,
                                };
                                if (energyTime.FirstOrDefault().MachineId1 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

                                }


                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 2)
                {
                    var from = DateTime.Today.AddDays(-1);
                    var to = DateTime.Today;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.SignalCode,
                                    Name = load.Name,
                                };
                                if (energyTime.FirstOrDefault().MachineId1 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

                                }


                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 3)
                {
                    var from = DateTime.Today.AddDays(-7);
                    var to = DateTime.Today;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.SignalCode,
                                    Name = load.Name,
                                };
                                if (energyTime.FirstOrDefault().MachineId1 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

                                }


                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 4)
                {
                    var from = DateTime.Today.AddMonths(-1);
                    var to = DateTime.Today;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.SignalCode,
                                    Name = load.Name,
                                };
                                if (energyTime.FirstOrDefault().MachineId1 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

                                }


                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 5)
                {
                    var from = DateTime.Today.AddMonths(-3);
                    var to = DateTime.Today;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.SignalCode,
                                    Name = load.Name,
                                };
                                if (energyTime.FirstOrDefault().MachineId1 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

                                }


                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 6)
                {
                    var from = DateTime.Today;
                    var to = DateTime.Now;
                    if (Option == 1)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        for (int i = 0; i < minuteCount; i += Resolution)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + Resolution);
                            if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                            {

                                var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.SignalCode,
                                    Name = load.Name,
                                };
                                if (energyTime.FirstOrDefault().MachineId1 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.signal = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

                                }


                                phase.TimeStamp = currentTimeTo;

                                phaseValues.Add(phase);

                            }

                        }
                        return Ok(phaseValues);
                    }
                }
            }
            else if (loadEnergy.PlcCode != null)
            {
                var mixerLoad = _context.Mixers.Where(r => r.MachineId == Load).FirstOrDefault();
                var pallLoad = _context.Palletizers.Where(r => r.MachineId == Load).FirstOrDefault();
                var fillLoad = _context.Fillers.Where(r => r.MachineId == Load).FirstOrDefault();
                var dePalLoad = _context.DPalletizers.Where(r => r.MachineId == Load).FirstOrDefault();
                var bmLoad = _context.Blow_Moulders.Where(r => r.MachineId == Load).FirstOrDefault();
                var labelLoad = _context.Labels.Where(r => r.MachineId == Load).FirstOrDefault();
                if(mixerLoad != null)
                {
                    if(Duration == 1)
                    {
                        var from = DateTime.Today;
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp<= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r=>r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Product_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Product_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Co2_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "KG"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Co2_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Water_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Water_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Syrup_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Syrup_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 2)
                    {
                        var from = DateTime.Today.AddDays(-1);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Product_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Product_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Co2_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "KG"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Co2_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Water_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Water_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Syrup_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Syrup_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 3)
                    {
                        var from = DateTime.Today.AddDays(-7);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Product_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Product_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Co2_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "KG"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Co2_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Water_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Water_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Syrup_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Syrup_Consumption).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                }
                else if (pallLoad != null)
                {
                    if (Duration == 1)
                    {
                        var from = DateTime.Today;
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Packet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Pack"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r=>r.Id).Select(r => r.Packet_No).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Pallet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Pallet"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Pallet_No).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 2)
                    {
                        var from = DateTime.Today.AddDays(-1);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Packet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Pack"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Packet_No).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Pallet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Pallet"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Pallet_No).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 3)
                    {
                        var from = DateTime.Today.AddDays(-7);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Packet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Pack"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Packet_No).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Palletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Pallet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Pallet"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Pallet_No).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                }
                else if (fillLoad != null)
                {
                    if (Duration == 1)
                    {
                        var from = DateTime.Today;
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                                var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                for (int i = 0; i < minuteCount; i += Resolution)
                                {
                                    var currentTimeFrom = from.AddMinutes(i);
                                    var currentTimeTo = from.AddMinutes(i + Resolution);
                                    if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                    {

                                        var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                        PhaseValuesDTO phase = new PhaseValuesDTO
                                        {
                                            Code = load.PlcCode,
                                            Name = load.Name,
                                            Unit = "Bottle"
                                        };
                                        phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count).FirstOrDefault();
                                        phase.TimeStamp = currentTimeTo;

                                        phaseValues.Add(phase);

                                    }

                                }
                                return Ok(phaseValues);
                           
                        }
                        else if (Option == 5)
                        {
                            if(Load == "AlFill5")
                            {
                                    var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_vol, r.TimeStamp }).ToList();
                                    List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                    var minuteCount = (to - from).TotalMinutes;
                                    var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                    for (int i = 0; i < minuteCount; i += Resolution)
                                    {
                                        var currentTimeFrom = from.AddMinutes(i);
                                        var currentTimeTo = from.AddMinutes(i + Resolution);
                                        if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                        {

                                            var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                            PhaseValuesDTO phase = new PhaseValuesDTO
                                            {
                                                Code = load.PlcCode,
                                                Name = load.Name,
                                                Unit = "L"
                                            };
                                            phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Mix_vol).FirstOrDefault();
                                            phase.TimeStamp = currentTimeTo;

                                            phaseValues.Add(phase);

                                        }

                                    }
                                    return Ok(phaseValues);
                                
                            }
                            else
                            {
                                var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_select, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                for (int i = 0; i < minuteCount; i += Resolution)
                                {
                                    var currentTimeFrom = from.AddMinutes(i);
                                    var currentTimeTo = from.AddMinutes(i + Resolution);
                                    if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                    {

                                        var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                        PhaseValuesDTO phase = new PhaseValuesDTO
                                        {
                                            Code = load.PlcCode,
                                            Name = load.Name,
                                            Unit = ""
                                        };
                                        phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Mix_select).FirstOrDefault();
                                        phase.TimeStamp = currentTimeTo;

                                        phaseValues.Add(phase);

                                    }

                                }
                                return Ok(phaseValues);

                            }
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Rinse, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Rinse).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 2)
                    {
                        var from = DateTime.Today.AddDays(-1);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);

                        }
                        else if (Option == 5)
                        {
                            if (Load == "AlFill5")
                            {
                                var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_vol, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                for (int i = 0; i < minuteCount; i += Resolution)
                                {
                                    var currentTimeFrom = from.AddMinutes(i);
                                    var currentTimeTo = from.AddMinutes(i + Resolution);
                                    if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                    {

                                        var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                        PhaseValuesDTO phase = new PhaseValuesDTO
                                        {
                                            Code = load.PlcCode,
                                            Name = load.Name,
                                            Unit = "L"
                                        };
                                        phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Mix_vol).FirstOrDefault();
                                        phase.TimeStamp = currentTimeTo;

                                        phaseValues.Add(phase);

                                    }

                                }
                                return Ok(phaseValues);

                            }
                            else
                            {
                                var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_select, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                for (int i = 0; i < minuteCount; i += Resolution)
                                {
                                    var currentTimeFrom = from.AddMinutes(i);
                                    var currentTimeTo = from.AddMinutes(i + Resolution);
                                    if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                    {

                                        var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                        PhaseValuesDTO phase = new PhaseValuesDTO
                                        {
                                            Code = load.PlcCode,
                                            Name = load.Name,
                                            Unit = ""
                                        };
                                        phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Mix_select).FirstOrDefault();
                                        phase.TimeStamp = currentTimeTo;

                                        phaseValues.Add(phase);

                                    }

                                }
                                return Ok(phaseValues);

                            }
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Rinse, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Rinse).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 3)
                    {
                        var from = DateTime.Today.AddDays(-7);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);

                        }
                        else if (Option == 5)
                        {
                            if (Load == "AlFill5")
                            {
                                var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_vol, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                for (int i = 0; i < minuteCount; i += Resolution)
                                {
                                    var currentTimeFrom = from.AddMinutes(i);
                                    var currentTimeTo = from.AddMinutes(i + Resolution);
                                    if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                    {

                                        var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                        PhaseValuesDTO phase = new PhaseValuesDTO
                                        {
                                            Code = load.PlcCode,
                                            Name = load.Name,
                                            Unit = "L"
                                        };
                                        phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Mix_vol).FirstOrDefault();
                                        phase.TimeStamp = currentTimeTo;

                                        phaseValues.Add(phase);

                                    }

                                }
                                return Ok(phaseValues);

                            }
                            else
                            {
                                var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_select, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                for (int i = 0; i < minuteCount; i += Resolution)
                                {
                                    var currentTimeFrom = from.AddMinutes(i);
                                    var currentTimeTo = from.AddMinutes(i + Resolution);
                                    if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                    {

                                        var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                        PhaseValuesDTO phase = new PhaseValuesDTO
                                        {
                                            Code = load.PlcCode,
                                            Name = load.Name,
                                            Unit = ""
                                        };
                                        phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Mix_select).FirstOrDefault();
                                        phase.TimeStamp = currentTimeTo;

                                        phaseValues.Add(phase);

                                    }

                                }
                                return Ok(phaseValues);

                            }
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Fillers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Rinse, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Rinse).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                }
                else if (dePalLoad != null)
                {
                    if (Duration == 1)
                    {
                        var from = DateTime.Today;
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 2)
                    {
                        var from = DateTime.Today.AddDays(-1);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 3)
                    {
                        var from = DateTime.Today.AddDays(-7);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.DPalletizers.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                }
                else if (labelLoad != null)
                {
                    if (Duration == 1)
                    {
                        var from = DateTime.Today;
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Counts, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Counts).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 2)
                    {
                        var from = DateTime.Today.AddDays(-1);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Counts, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Counts).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 3)
                    {
                        var from = DateTime.Today.AddDays(-7);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Counts, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Counts).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Labels.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                }
                else if (bmLoad != null)
                {
                    if (Duration == 1)
                    {
                        var from = DateTime.Today;
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_In, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Proform"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count_In).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_Out, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Proform"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count_Out).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 2)
                    {
                        var from = DateTime.Today.AddDays(-1);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_In, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Proform"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count_In).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_Out, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Proform"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count_Out).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                    else if (Duration == 3)
                    {
                        var from = DateTime.Today.AddDays(-7);
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.State).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Fault).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Speed).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_In, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Proform"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count_In).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_Out, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Proform"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Count_Out).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Blow_Moulders.Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            for (int i = 0; i < minuteCount; i += Resolution)
                            {
                                var currentTimeFrom = from.AddMinutes(i);
                                var currentTimeTo = from.AddMinutes(i + Resolution);
                                if (loadData.Any(r => r.TimeStamp >= currentTimeFrom && r.TimeStamp <= currentTimeTo))
                                {

                                    var energyTime = loadData.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo);

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.Production_Hours).FirstOrDefault();
                                    phase.TimeStamp = currentTimeTo;

                                    phaseValues.Add(phase);

                                }

                            }
                            return Ok(phaseValues);
                        }
                    }
                }
            }

            return Ok();
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
