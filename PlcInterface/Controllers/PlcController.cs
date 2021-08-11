using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlcInterface.Context;
using PlcInterface.Models;
using PlcInterface.Models.CocaMesModels;
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
            var boilers = _mContext.Boilers.Where(r => r.FactoryId == Factory).ToList();
            var compressors = _mContext.Compressors.Where(r => r.FactoryId == Factory).ToList();
            var waterPumps = _mContext.WaterPumps.Where(r => r.FactoryId == Factory).ToList();
            var waterChems = _mContext.WaterChemicalTreatments.Where(r => r.FactoryId == Factory).ToList();
            var tanks = _mContext.Tanks.Where(r => r.FactoryId == Factory).ToList();
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
            TreeDTO treeDTO6 = new TreeDTO
            {
                name = "Compressors",
                id = 2,
                code = "Utilities",
                img = "factory.svg",
            };
            TreeDTO treeDTO7 = new TreeDTO
            {
                name = "Tanks",
                id = 2,
                code = "Utilities",
                img = "factory.svg",
            };
            TreeDTO treeDTO8 = new TreeDTO
            {
                name = "Water",
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
            foreach (var uti in boilers)
            {
                TreeDTO treeDTO2 = new TreeDTO
                {
                    name = uti.Name,
                    id = uti.Id,
                    code = uti.Name,
                    img = "function.svg",
                };

                var loads = _mContext.Loads.Where(r => r.BoilerId == uti.Id).Select(r => new { r.Id, r.EnergyCode, r.PlcCode, r.SignalCode, r.Name }).ToList();
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
            foreach (var uti in compressors)
            {
                TreeDTO treeDTO2 = new TreeDTO
                {
                    name = uti.Name,
                    id = uti.Id,
                    code = uti.Name,
                    img = "function.svg",
                };

                var loads = _mContext.Loads.Where(r => r.CompressorId == uti.Id).Select(r => new { r.Id, r.EnergyCode, r.PlcCode, r.SignalCode, r.Name }).ToList();
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
                treeDTO6.children.Add(treeDTO2);
            }
            treeDTO5.children.Add(treeDTO6);
            foreach (var uti in waterPumps)
            {
                TreeDTO treeDTO2 = new TreeDTO
                {
                    name = uti.Name,
                    id = uti.Id,
                    code = uti.Name,
                    img = "function.svg",
                };

                var loads = _mContext.Loads.Where(r => r.WaterPumpId == uti.Id).Select(r => new { r.Id, r.EnergyCode, r.PlcCode, r.SignalCode, r.Name }).ToList();
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
                treeDTO8.children.Add(treeDTO2);
            }
            foreach (var uti in waterChems)
            {
                TreeDTO treeDTO2 = new TreeDTO
                {
                    name = uti.Name,
                    id = uti.Id,
                    code = uti.Name,
                    img = "function.svg",
                };

                var loads = _mContext.Loads.Where(r => r.WaterChemicalTreatmentId == uti.Id).Select(r => new { r.Id, r.EnergyCode, r.PlcCode, r.SignalCode, r.Name }).ToList();
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
                treeDTO8.children.Add(treeDTO2);
            }
            treeDTO5.children.Add(treeDTO8);
            foreach (var uti in tanks)
            {
                TreeDTO treeDTO2 = new TreeDTO
                {
                    name = uti.Name,
                    id = uti.Id,
                    code = uti.Name,
                    img = "function.svg",
                };

                var loads = _mContext.Loads.Where(r => r.TankId == uti.Id).Select(r => new { r.Id, r.EnergyCode, r.PlcCode, r.SignalCode, r.Name }).ToList();
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
                treeDTO7.children.Add(treeDTO2);
            }
            treeDTO5.children.Add(treeDTO7);
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
                    if (Option == 1 || Option == 2 || Option == 3 || Option == 4 || Option == 5 || Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        foreach(var read in loadData)
                        {
                            
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.SignalCode,
                                    Name = load.Name,
                                };
                                if (read.MachineId1 != null)
                                {
                                    phase.Phase1 = read.state1;

                                }
                                else if (read.MachineId2 != null)
                                {
                                    phase.Phase1 = read.state2;

                                }
                                else if (read.MachineId3 != null)
                                {
                                    phase.Phase1 = read.state3;

                                }
                                else if (read.MachineId4 != null)
                                {
                                    phase.Phase1 = read.state4;

                                }


                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);

                            

                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 2)
                {
                    var from = DateTime.Today.AddDays(-1);
                    var to = DateTime.Today;
                    if (Option == 1 || Option == 2 || Option == 3 || Option == 4 || Option == 5 || Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {

                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.SignalCode,
                                Name = load.Name,
                            };
                            if (read.MachineId1 != null)
                            {
                                phase.Phase1 = read.state1;

                            }
                            else if (read.MachineId2 != null)
                            {
                                phase.Phase1 = read.state2;

                            }
                            else if (read.MachineId3 != null)
                            {
                                phase.Phase1 = read.state3;

                            }
                            else if (read.MachineId4 != null)
                            {
                                phase.Phase1 = read.state4;

                            }


                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                }
                else if (Duration == 3)
                {
                    var from = DateTime.Today.AddDays(-7);
                    var to = DateTime.Today;
                    if (Option == 1 || Option == 2 || Option == 3 || Option == 4 || Option == 5 || Option == 6)
                    {
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                        var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {

                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.SignalCode,
                                Name = load.Name,
                            };
                            if (read.MachineId1 != null)
                            {
                                phase.Phase1 = read.state1;

                            }
                            else if (read.MachineId2 != null)
                            {
                                phase.Phase1 = read.state2;

                            }
                            else if (read.MachineId3 != null)
                            {
                                phase.Phase1 = read.state3;

                            }
                            else if (read.MachineId4 != null)
                            {
                                phase.Phase1 = read.state4;

                            }


                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



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
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

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
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

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
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state1).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId2 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state2).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId3 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state3).FirstOrDefault();

                                }
                                else if (energyTime.FirstOrDefault().MachineId4 != null)
                                {
                                    phase.Phase1 = energyTime.OrderByDescending(r => r.Id).Select(r => r.state4).FirstOrDefault();

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
                var mixerLoad = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load).FirstOrDefault();
                var pallLoad = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load).FirstOrDefault();
                var fillLoad = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load).FirstOrDefault();
                var dePalLoad = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load).FirstOrDefault();
                var bmLoad = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load).FirstOrDefault();
                var labelLoad = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load).FirstOrDefault();
                if(mixerLoad != null)
                {
                    if(Duration == 1)
                    {
                        var from = DateTime.Today;
                        var to = DateTime.Now;
                        if (Option == 1)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp<= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.State;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.Fault;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Product_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                              

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = read.Product_Consumption;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Co2_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {


                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "KG"
                                    };
                                    phase.Phase1 = read.Co2_Consumption;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Water_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = read.Water_Consumption;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Syrup_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = read.Syrup_Consumption;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = read.Production_Hours;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

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
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Product_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Product_Consumption;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Co2_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "KG"
                                };
                                phase.Phase1 = read.Co2_Consumption;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Water_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Water_Consumption;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Syrup_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Syrup_Consumption;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Production_Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Product_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Product_Consumption;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Co2_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "KG"
                                };
                                phase.Phase1 = read.Co2_Consumption;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Water_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Water_Consumption;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Syrup_Consumption, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Syrup_Consumption;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Production_Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.State;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.Fault;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Packet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Pack"
                                    };
                                    phase.Phase1 = read.Packet_No;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Pallet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Pallet"
                                    };
                                    phase.Phase1 = read.Pallet_No;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = read.Production_Hours;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

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
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Packet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Pack"
                                };
                                phase.Phase1 = read.Packet_No;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Pallet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Pallet"
                                };
                                phase.Phase1 = read.Pallet_No;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Production_Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Packet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Pack"
                                };
                                phase.Phase1 = read.Packet_No;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Pallet_No, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Pallet"
                                };
                                phase.Phase1 = read.Pallet_No;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Production_Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {


                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.State;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);


                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                               
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.Fault;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {


                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "bottle/H"
                                    };
                                    phase.Phase1 = read.Speed;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                                var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                foreach(var read in loadData)
                                {
                                        PhaseValuesDTO phase = new PhaseValuesDTO
                                        {
                                            Code = load.PlcCode,
                                            Name = load.Name,
                                            Unit = "Bottle"
                                        };
                                        phase.Phase1 = read.Count;
                                        phase.TimeStamp = read.TimeStamp;

                                        phaseValues.Add(phase);

                                    

                                }
                                return Ok(phaseValues);
                           
                        }
                        else if (Option == 5)
                        {
                            if(Load == "AlFill5")
                            {
                                    var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_vol, r.TimeStamp }).ToList();
                                    List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                    var minuteCount = (to - from).TotalMinutes;
                                    var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                    foreach(var read in loadData)
                                    {
                                            PhaseValuesDTO phase = new PhaseValuesDTO
                                            {
                                                Code = load.PlcCode,
                                                Name = load.Name,
                                                Unit = "L"
                                            };
                                            phase.Phase1 = read.Mix_vol;
                                            phase.TimeStamp = read.TimeStamp;

                                            phaseValues.Add(phase);

                                        

                                    }
                                    return Ok(phaseValues);
                                
                            }
                            else
                            {
                                var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_select, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                foreach(var read in loadData)
                                {
                                   
                                        PhaseValuesDTO phase = new PhaseValuesDTO
                                        {
                                            Code = load.PlcCode,
                                            Name = load.Name,
                                            Unit = ""
                                        };
                                        phase.Phase1 = read.Mix_select;
                                        phase.TimeStamp = read.TimeStamp;

                                        phaseValues.Add(phase);

                                    

                                }
                                return Ok(phaseValues);

                            }
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                              
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = read.Production_Hours;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Rinse, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = read.Rinse;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

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
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);


                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "bottle/H"
                                };
                                phase.Phase1 = read.Speed;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle"
                                };
                                phase.Phase1 = read.Count;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);

                        }
                        else if (Option == 5)
                        {
                            if (Load == "AlFill5")
                            {
                                var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_vol, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                foreach (var read in loadData)
                                {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = read.Mix_vol;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);



                                }
                                return Ok(phaseValues);

                            }
                            else
                            {
                                var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_select, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                foreach (var read in loadData)
                                {

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.Mix_select;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);



                                }
                                return Ok(phaseValues);

                            }
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Production_Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Rinse, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Rinse;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);


                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {


                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "bottle/H"
                                };
                                phase.Phase1 = read.Speed;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle"
                                };
                                phase.Phase1 = read.Count;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);

                        }
                        else if (Option == 5)
                        {
                            if (Load == "AlFill5")
                            {
                                var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_vol, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                foreach (var read in loadData)
                                {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "L"
                                    };
                                    phase.Phase1 = read.Mix_vol;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);



                                }
                                return Ok(phaseValues);

                            }
                            else
                            {
                                var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_select, r.TimeStamp }).ToList();
                                List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                                var minuteCount = (to - from).TotalMinutes;
                                var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                                foreach (var read in loadData)
                                {

                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.Mix_select;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);



                                }
                                return Ok(phaseValues);

                            }
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Production_Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 7)
                        {
                            var loadData = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Rinse, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Rinse;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.State;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.Fault;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = read.Speed;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = read.Count;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = read.Hours;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

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
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle/H"
                                };
                                phase.Phase1 = read.Speed;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle"
                                };
                                phase.Phase1 = read.Count;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle/H"
                                };
                                phase.Phase1 = read.Speed;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle"
                                };
                                phase.Phase1 = read.Count;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.State;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.Fault;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = read.Speed;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Counts, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle"
                                    };
                                    phase.Phase1 = read.Counts;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = read.Hours;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

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
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle/H"
                                };
                                phase.Phase1 = read.Speed;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Counts, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle"
                                };
                                phase.Phase1 = read.Counts;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle/H"
                                };
                                phase.Phase1 = read.Speed;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Counts, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle"
                                };
                                phase.Phase1 = read.Counts;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.State;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = ""
                                    };
                                    phase.Phase1 = read.Fault;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Bottle/H"
                                    };
                                    phase.Phase1 = read.Speed;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_In, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Proform"
                                    };
                                    phase.Phase1 = read.Count_In;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_Out, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "Proform"
                                    };
                                    phase.Phase1 = read.Count_Out;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                                

                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach(var read in loadData)
                            {
                                    PhaseValuesDTO phase = new PhaseValuesDTO
                                    {
                                        Code = load.PlcCode,
                                        Name = load.Name,
                                        Unit = "H"
                                    };
                                    phase.Phase1 = read.Production_Hours;
                                    phase.TimeStamp = read.TimeStamp;

                                    phaseValues.Add(phase);

                               

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
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle/H"
                                };
                                phase.Phase1 = read.Speed;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_In, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Proform"
                                };
                                phase.Phase1 = read.Count_In;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_Out, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Proform"
                                };
                                phase.Phase1 = read.Count_Out;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Production_Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



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
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.State;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 2)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Fault;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 5)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Bottle/H"
                                };
                                phase.Phase1 = read.Speed;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 3)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_In, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Proform"
                                };
                                phase.Phase1 = read.Count_In;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 4)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_Out, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "Proform"
                                };
                                phase.Phase1 = read.Count_Out;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                        else if (Option == 6)
                        {
                            var loadData = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "H"
                                };
                                phase.Phase1 = read.Production_Hours;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);
                        }
                    }
                }
            }

            return Ok();
        }


        [HttpGet("ValueOfTree/{Load}/{Option}/{From}/{To}/{Resolution}")]
        public ActionResult ValueOfTreeDate(string Load, int Option, string From, string To, int Resolution)
        {
            var loadEnergy = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
            if (loadEnergy.EnergyCode != null)
            {
                
                    var from = DateTime.Parse(From);
                    var to = DateTime.Parse(To);
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
            else if (loadEnergy.SignalCode != null)
            {
               
                    var from = DateTime.Parse(From);
                    var to = DateTime.Parse(To);
                if (Option == 1)
                {
                    List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                    var loadData = _sContext.SignalBroker.Where(r => r.BrokerId == Load && r.TimeStamp >= from && r.TimeStamp < to).ToList();
                    var load = _mContext.Loads.Where(r => r.EnergyCode == Load || r.SignalCode == Load || r.PlcCode == Load).FirstOrDefault();
                    foreach (var read in loadData)
                    {

                        PhaseValuesDTO phase = new PhaseValuesDTO
                        {
                            Code = load.SignalCode,
                            Name = load.Name,
                        };
                        if (read.MachineId1 != null)
                        {
                            phase.Phase1 = read.state1;

                        }
                        else if (read.MachineId2 != null)
                        {
                            phase.Phase1 = read.state2;

                        }
                        else if (read.MachineId3 != null)
                        {
                            phase.Phase1 = read.state3;

                        }
                        else if (read.MachineId4 != null)
                        {
                            phase.Phase1 = read.state4;

                        }


                        phase.TimeStamp = read.TimeStamp;

                        phaseValues.Add(phase);



                    }
                    return Ok(phaseValues);
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
                if (mixerLoad != null)
                {
                        var from = DateTime.Parse(From);
                        var to = DateTime.Parse(To);
                    if (Option == 1)
                    {
                        var loadData = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {


                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.State;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        var loadData = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {


                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.Fault;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        var loadData = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Product_Consumption, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {


                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "L"
                            };
                            phase.Phase1 = read.Product_Consumption;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        var loadData = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Co2_Consumption, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {


                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "KG"
                            };
                            phase.Phase1 = read.Co2_Consumption;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        var loadData = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Water_Consumption, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {


                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "L"
                            };
                            phase.Phase1 = read.Water_Consumption;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 6)
                    {
                        var loadData = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Syrup_Consumption, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {


                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "L"
                            };
                            phase.Phase1 = read.Syrup_Consumption;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 7)
                    {
                        var loadData = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "H"
                            };
                            phase.Phase1 = read.Production_Hours;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }

                }
                else if (pallLoad != null)
                {
                        var from = DateTime.Parse(From);
                        var to = DateTime.Parse(To);
                    if (Option == 1)
                    {
                        var loadData = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.State;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        var loadData = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.Fault;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        var loadData = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Packet_No, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Pack"
                            };
                            phase.Phase1 = read.Packet_No;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        var loadData = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Pallet_No, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {

                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Pallet"
                            };
                            phase.Phase1 = read.Pallet_No;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        var loadData = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "H"
                            };
                            phase.Phase1 = read.Production_Hours;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }

                }
                else if (fillLoad != null)
                {
                        var from = DateTime.Parse(From);
                        var to = DateTime.Parse(To);
                    if (Option == 1)
                    {
                        var loadData = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {


                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.State;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);


                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        var loadData = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {

                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.Fault;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        var loadData = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {


                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "bottle/H"
                            };
                            phase.Phase1 = read.Speed;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        var loadData = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Bottle"
                            };
                            phase.Phase1 = read.Count;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);

                    }
                    else if (Option == 5)
                    {
                        if (Load == "AlFill5")
                        {
                            var loadData = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_vol, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {
                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = "L"
                                };
                                phase.Phase1 = read.Mix_vol;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);

                        }
                        else
                        {
                            var loadData = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Mix_select, r.TimeStamp }).ToList();
                            List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                            var minuteCount = (to - from).TotalMinutes;
                            var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                            foreach (var read in loadData)
                            {

                                PhaseValuesDTO phase = new PhaseValuesDTO
                                {
                                    Code = load.PlcCode,
                                    Name = load.Name,
                                    Unit = ""
                                };
                                phase.Phase1 = read.Mix_select;
                                phase.TimeStamp = read.TimeStamp;

                                phaseValues.Add(phase);



                            }
                            return Ok(phaseValues);

                        }
                    }
                    else if (Option == 6)
                    {
                        var loadData = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {

                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "H"
                            };
                            phase.Phase1 = read.Production_Hours;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 7)
                    {
                        var loadData = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Rinse, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "L"
                            };
                            phase.Phase1 = read.Rinse;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }

                }
                else if (dePalLoad != null)
                {
                        var from = DateTime.Parse(From);
                        var to = DateTime.Parse(To);
                    if (Option == 1)
                    {
                        var loadData = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.State;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        var loadData = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.Fault;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        var loadData = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Bottle/H"
                            };
                            phase.Phase1 = read.Speed;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        var loadData = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Bottle"
                            };
                            phase.Phase1 = read.Count;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        var loadData = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "H"
                            };
                            phase.Phase1 = read.Hours;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }

                }
                else if (labelLoad != null)
                {
                  
                        var from = DateTime.Parse(From);
                        var to = DateTime.Parse(To);
                    if (Option == 1)
                    {
                        var loadData = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.State;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        var loadData = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.Fault;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        var loadData = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Bottle/H"
                            };
                            phase.Phase1 = read.Speed;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        var loadData = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Counts, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Bottle"
                            };
                            phase.Phase1 = read.Counts;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        var loadData = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Hours, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "H"
                            };
                            phase.Phase1 = read.Hours;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }

                }
                else if (bmLoad != null)
                {
                        var from = DateTime.Parse(From);
                        var to = DateTime.Parse(To);
                    if (Option == 1)
                    {
                        var loadData = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.State, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.State;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 2)
                    {
                        var loadData = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Fault, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = ""
                            };
                            phase.Phase1 = read.Fault;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 5)
                    {
                        var loadData = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Speed, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Bottle/H"
                            };
                            phase.Phase1 = read.Speed;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 3)
                    {
                        var loadData = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_In, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Proform"
                            };
                            phase.Phase1 = read.Count_In;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 4)
                    {
                        var loadData = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Count_Out, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "Proform"
                            };
                            phase.Phase1 = read.Count_Out;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }
                    else if (Option == 6)
                    {
                        var loadData = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == Load && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => new { r.Id, r.Production_Hours, r.TimeStamp }).ToList();
                        List<PhaseValuesDTO> phaseValues = new List<PhaseValuesDTO>();
                        var minuteCount = (to - from).TotalMinutes;
                        var load = _mContext.Loads.Where(r => r.PlcCode == Load).FirstOrDefault();
                        foreach (var read in loadData)
                        {
                            PhaseValuesDTO phase = new PhaseValuesDTO
                            {
                                Code = load.PlcCode,
                                Name = load.Name,
                                Unit = "H"
                            };
                            phase.Phase1 = read.Production_Hours;
                            phase.TimeStamp = read.TimeStamp;

                            phaseValues.Add(phase);



                        }
                        return Ok(phaseValues);
                    }

                }
            }

            return Ok();
        }

        [HttpGet("GetMixerReads/{load}")]
        public ActionResult GetMixerReads(string load)
        {
            var from = ((DateTime.Today).AddHours(8)).AddMinutes(10);
            var to = ((DateTime.Today).AddHours(20)).AddMinutes(10);
            var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load && r.Co2_Consumption >= 0 && r.Co2_Consumption < 100 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);
            return Ok(mixerReads2);
        }

        [HttpGet("GetMachineDetails/{time}")]
        public ActionResult GetMachineDetails(int time)
        {
            var loads = _mContext.Loads.Where(r=>r.PlcCode != null).ToList();
            if(time == 1)
            {
                var from = ((DateTime.Today).AddHours(8)).AddMinutes(10);
                var to = ((DateTime.Today).AddHours(19)).AddMinutes(50);
                List<MachineDetailsDTO> machines = new List<MachineDetailsDTO>();
                var energyConsumption = _eContext.IotTransactions.Where(r => r.SourceId == "L_Line02_0" && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => r.Energy1 + r.Energy2 + r.Energy3).ToList().DefaultIfEmpty(0).Sum();
                MachineDetailsDTO factory = new MachineDetailsDTO
                {
                    MachineName="Alex(API)",
                    MachineCode="Alex",
                    PlcType = "1"
                };
                foreach (var load in loads)
                {
                    var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Co2_Consumption >= 0 && r.Co2_Consumption<100&& r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);
                    
                    var mixerReads = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Co2_Consumption >= 0&& r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp<=to).ToList();
                    if (mixerReads2.Any())
                    {
                       mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= mixerReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }


                    var pallReads2 = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Pallet_No == 0 && r.Pallet_No<=100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var pallReads = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Pallet_No >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (pallReads2.Any())
                    {
                        pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Pallet_No >= 0 && r.TimeStamp >= pallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var fillReads2 = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Count ==0 && r.Count<=100 &&r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var fillReads = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Count >=0 &&r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    if(fillReads2.Any())
                    {
                        fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count >= 0 && r.TimeStamp >= fillReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();

                    }

                    var dePallReads2 = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var dePallReads = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Count >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    if(dePallReads2.Any())
                    {
                        dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count >= 0 && r.TimeStamp >= dePallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var labelReads2 = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var labelReads = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    if(labelReads2.Any())
                    {
                        labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts >= 0 && r.TimeStamp >= labelReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var blowReads2 = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Count_In == 0 && r.Count_In <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var blowReads = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.Count_In >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if(blowReads2.Any())
                    {
                        blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count_In >= 0 && r.TimeStamp >= blowReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    decimal co2 = 0;
                    decimal water = 0;
                    decimal syrup = 0;
                    decimal pallet = 0;
                    decimal pack = 0;
                    decimal bottle = 0;
                    if (mixerReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Mixer"

                        };
                        var stateReadsCount = mixerReads.Select(r => r.State).ToList().Count;
                        var onReads = mixerReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;

                        var waterCo1 = mixerReads.Select(r => r.Water_Consumption).FirstOrDefault();
                        var waterCo2 = mixerReads.Select(r => r.Water_Consumption).LastOrDefault();
                        water = waterCo1 - waterCo2;
                        machine.WC = waterCo1 - waterCo2;

                        var coCo1 = mixerReads.Select(r => r.Co2_Consumption).FirstOrDefault();
                        var coCo2 = mixerReads.Select(r => r.Co2_Consumption).LastOrDefault();
                        co2 = coCo1 - coCo2;
                        machine.CO2 = coCo1 - coCo2;

                        var sCo1 = mixerReads.Select(r => r.Syrup_Consumption).FirstOrDefault();
                        var sCo2 = mixerReads.Select(r => r.Syrup_Consumption).LastOrDefault();
                        syrup = sCo1 - sCo2;
                        machine.SC = sCo1 - sCo2;

                        var hours1 = mixerReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = mixerReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);

                    }
                    else if (pallReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Palletizer"

                        };
                        var stateReadsCount = pallReads.Select(r => r.State).ToList().Count;
                        var onReads = pallReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;

                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;

                        var packCo1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                        var packCo2 = pallReads.Select(r => r.Packet_No).LastOrDefault();
                        machine.PackCount = packCo1 - packCo2;
                        pack = packCo1 - packCo2;
                        var palletCo1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                        var palletCo2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();
                        machine.PalletCount = palletCo1 - palletCo2;
                        pallet = palletCo1 - palletCo2;

                        var hours1 = pallReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = pallReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                    }
                    else if (fillReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Filler"

                        };
                        var stateReadsCount = fillReads.Select(r => r.State).ToList().Count;
                        var onReads = fillReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountCo1 = fillReads.Select(r => r.Count).FirstOrDefault();
                        var CountCo2 = fillReads.Select(r => r.Count).LastOrDefault();
                        machine.BottleCount = CountCo1 - CountCo2;
                        bottle = CountCo1 - CountCo2;
                        var Speed1 = fillReads.Select(r => r.Speed).Average();
                        var Speed2 = fillReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = fillReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = fillReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;


                        if (load.PlcCode == "AlFill3")
                        {
                            var fillerLine3 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == 3 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)(fillerLine3.Select(r => r.Counts).FirstOrDefault() - fillerLine3.Select(r => r.Counts).LastOrDefault())/(decimal)machine.BottleCount;
                        }
                        else if (load.PlcCode == "AlFill1")
                        {
                            var fillerLine5 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == 1 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)(fillerLine5.Select(r => r.Counts).FirstOrDefault() - fillerLine5.Select(r => r.Counts).LastOrDefault())/(decimal)machine.BottleCount ;
                        }
                        machines.Add(machine);
                    }
                    else if (dePallReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "DePalletizer"

                        };
                        var stateReadsCount = dePallReads.Select(r => r.State).ToList().Count;
                        var onReads = dePallReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountCo1 = dePallReads.Select(r => r.Count).FirstOrDefault();
                        var CountCo2 = dePallReads.Select(r => r.Count).LastOrDefault();
                        machine.BottleCount = CountCo1 - CountCo2;

                        var Speed1 = dePallReads.Select(r => r.Speed).Average();
                        var Speed2 = dePallReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = dePallReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = dePallReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);

                    }
                    else if (labelReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Label"

                        };
                        var stateReadsCount = labelReads.Select(r => r.State).ToList().Count;
                        var onReads = labelReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountCo1 = labelReads.Select(r => r.Counts).FirstOrDefault();
                        var CountCo2 = labelReads.Select(r => r.Counts).LastOrDefault();
                        machine.BottleCount = CountCo1 - CountCo2;

                        var Speed1 = labelReads.Select(r => r.Speed).Average();
                        var Speed2 = labelReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = labelReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = labelReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        if(load.PlcCode == "AlLabl3")
                        {
                            var fillerLine3 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == 3 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)machine.BottleCount / (decimal)(fillerLine3.Select(r => r.Count).FirstOrDefault() - fillerLine3.Select(r => r.Count).LastOrDefault());
                        }
                        else if(load.PlcCode == "AlLabl1")
                        {
                            var fillerLine5 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == 1 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)machine.BottleCount / (decimal)(fillerLine5.Select(r => r.Count).FirstOrDefault() - fillerLine5.Select(r => r.Count).LastOrDefault());
                        }

                        machines.Add(machine);
                    }
                    else if (blowReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Blow"

                        };
                        var stateReadsCount = blowReads.Select(r => r.State).ToList().Count;
                        var onReads = blowReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountIn1 = blowReads.Select(r => r.Count_In).FirstOrDefault();
                        var CountIn2 = blowReads.Select(r => r.Count_In).LastOrDefault();
                        machine.BottleCountIn = CountIn1 - CountIn2;

                        var CountOut1 = blowReads.Select(r => r.Count_Out).FirstOrDefault();
                        var CountOut2 = blowReads.Select(r => r.Count_Out).LastOrDefault();
                        machine.BottleCountOut = CountOut1 - CountOut2;

                        var Speed1 = blowReads.Select(r => r.Speed).Average();
                        var Speed2 = blowReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = blowReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = blowReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                    }

                }
                var ava = machines.ToList();
                factory.Avalability = ava.Select(r => r.Avalability).Sum() / ava.Count;
                factory.Performance = ava.Select(r => r.Performance).Sum() / ava.Count;
                factory.ProductionTime = ava.Where(r => r.ProductionTime >0 && r.ProductionTime < 1).Select(r => r.ProductionTime).Sum() / ava.Where(r => r.ProductionTime > 0 && r.ProductionTime < 1).ToList().Count;
                factory.EnergyConsumption = energyConsumption;

                var mixersConsumption = ava.Where(r => r.PlcType == "Mixer").ToList();
                var pallsConsumption = ava.Where(r => r.PlcType == "Palletizer").ToList();
                var labelsConsumption = ava.Where(r => r.PlcType == "Label").ToList();
                var dPallsConsumption = ava.Where(r => r.PlcType == "DePalletizer").ToList();
                var fillersConsumption = ava.Where(r => r.PlcType == "Filler").ToList();
                var blowsConsumption = ava.Where(r => r.PlcType == "Blow").ToList();

                factory.WC = mixersConsumption.Select(r => r.WC).Sum();
                factory.SC = mixersConsumption.Select(r => r.SC).Sum();
                factory.CO2 = mixersConsumption.Select(r => r.CO2).Sum();

                factory.PackCount = pallsConsumption.Select(r => r.PackCount).Sum();
                factory.PalletCount = pallsConsumption.Select(r => r.PalletCount).Sum();

                factory.BottleCount = labelsConsumption.Select(r => r.BottleCount).Sum();
                factory.BottleCountIn = blowsConsumption.Select(r => r.BottleCountIn).Sum();
                factory.BottleCountOut = blowsConsumption.Select(r => r.BottleCountOut).Sum();


                return Ok(new { machines,from,to,factory});
            }
            else if(time == 2)
            {
                var from = ((DateTime.Today).AddHours(-4)).AddMinutes(10);
                var to = ((DateTime.Today).AddHours(7)).AddMinutes(50);
                List<MachineDetailsDTO> machines = new List<MachineDetailsDTO>();
                var lines = _mContext.ProductionLines.ToList();
                var energyConsumption = _eContext.IotTransactions.Where(r => r.SourceId == "L_Line02_0" && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => r.Energy1 + r.Energy2 + r.Energy3).ToList().DefaultIfEmpty(0).Sum();
                MachineDetailsDTO factory = new MachineDetailsDTO
                {
                    MachineName = "Alex(API)",
                    MachineCode = "Alex",
                    PlcType = "1"
                };
                foreach (var load in loads)
                {
                    var mixerReads = _context.Mixers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var pallReads = _context.Palletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var fillReads = _context.Fillers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var dePallReads = _context.DPalletizers.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var labelReads = _context.Labels.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.TimeStamp >= from && r.TimeStamp <= to).ToList(); 
                    var blowReads = _context.Blow_Moulders.OrderByDescending(r=>r.Id).Where(r => r.MachineId == load.PlcCode && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    decimal co2 = 0;
                    decimal water = 0;
                    decimal syrup = 0;
                    decimal pallet = 0;
                    decimal pack = 0;
                    decimal bottle = 0;
                    if(mixerReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Mixer"

                        };
                        var stateReadsCount = mixerReads.Select(r => r.State).ToList().Count;
                        var onReads = mixerReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;

                        var waterCo1 = mixerReads.Select(r => r.Water_Consumption).FirstOrDefault();
                        var waterCo2 = mixerReads.Select(r => r.Water_Consumption).LastOrDefault();
                        water = waterCo1 - waterCo2;
                        machine.WC = waterCo1 - waterCo2;

                        var coCo1 = mixerReads.Select(r => r.Co2_Consumption).FirstOrDefault();
                        var coCo2 = mixerReads.Select(r => r.Co2_Consumption).LastOrDefault();
                        co2 = coCo1 - coCo2;
                        machine.CO2 = coCo1 - coCo2;

                        var sCo1 = mixerReads.Select(r => r.Syrup_Consumption).FirstOrDefault();
                        var sCo2 = mixerReads.Select(r => r.Syrup_Consumption).LastOrDefault();
                        syrup = sCo1 - sCo2;
                        machine.SC = sCo1 - sCo2;

                        var hours1 = mixerReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = mixerReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2)/(decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);

                    }
                    else if (pallReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Palletizer"

                        };
                        var stateReadsCount = pallReads.Select(r => r.State).ToList().Count;
                        var onReads = pallReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;

                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;

                        var packCo1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                        var packCo2 = pallReads.Select(r => r.Packet_No).LastOrDefault();
                        machine.PackCount = packCo1 - packCo2;
                        pack = packCo1 - packCo2;
                        var palletCo1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                        var palletCo2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();
                        machine.PalletCount = palletCo1 - palletCo2;
                        pallet = palletCo1 - palletCo2;

                        var hours1 = pallReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = pallReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                    }
                    else if (fillReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Filler"

                        };
                        var stateReadsCount = fillReads.Select(r => r.State).ToList().Count;
                        var onReads = fillReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountCo1 = fillReads.Select(r => r.Count).FirstOrDefault();
                        var CountCo2 = fillReads.Select(r => r.Count).LastOrDefault();
                        machine.BottleCount = CountCo1 - CountCo2;
                        bottle = CountCo1 - CountCo2;
                        var Speed1 = fillReads.Select(r => r.Speed).Average();
                        var Speed2 = fillReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = fillReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = fillReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                    }
                    else if (dePallReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "DePalletizer"

                        };
                        var stateReadsCount = dePallReads.Select(r => r.State).ToList().Count;
                        var onReads = dePallReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountCo1 = dePallReads.Select(r => r.Count).FirstOrDefault();
                        var CountCo2 = dePallReads.Select(r => r.Count).LastOrDefault();
                        machine.BottleCount = CountCo1 - CountCo2;

                        var Speed1 = dePallReads.Select(r => r.Speed).Average();
                        var Speed2 = dePallReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = dePallReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = dePallReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);

                    }
                    else if (labelReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Label"

                        };
                        var stateReadsCount = labelReads.Select(r => r.State).ToList().Count;
                        var onReads = labelReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountCo1 = labelReads.Select(r => r.Counts).FirstOrDefault();
                        var CountCo2 = labelReads.Select(r => r.Counts).LastOrDefault();
                        machine.BottleCount = CountCo1 - CountCo2;

                        var Speed1 = labelReads.Select(r => r.Speed).Average();
                        var Speed2 = labelReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = labelReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = labelReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                    }
                    else if (blowReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Blow"

                        };
                        var stateReadsCount = blowReads.Select(r => r.State).ToList().Count;
                        var onReads = blowReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountIn1 = blowReads.Select(r => r.Count_In).FirstOrDefault();
                        var CountIn2 = blowReads.Select(r => r.Count_In).LastOrDefault();
                        machine.BottleCountIn = CountIn1 - CountIn2;

                        var CountOut1 = blowReads.Select(r => r.Count_Out).FirstOrDefault();
                        var CountOut2 = blowReads.Select(r => r.Count_Out).LastOrDefault();
                        machine.BottleCountOut = CountOut1 - CountOut2;

                        var Speed1 = blowReads.Select(r => r.Speed).Average();
                        var Speed2 = blowReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = blowReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = blowReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)24;

                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                    }

                }
                var ava = machines.ToList();
                factory.Avalability = ava.Select(r => r.Avalability).Sum() / ava.Count;
                factory.Performance = ava.Select(r => r.Performance).Sum() / ava.Count;
                factory.ProductionTime = ava.Where(r => r.ProductionTime > 0 && r.ProductionTime < 1).Select(r => r.ProductionTime).Sum() / ava.Where(r => r.ProductionTime > 0 && r.ProductionTime < 1).ToList().Count;
                factory.EnergyConsumption = energyConsumption;

                var mixersConsumption = ava.Where(r => r.PlcType == "Mixer").ToList();
                var pallsConsumption = ava.Where(r => r.PlcType == "Palletizer").ToList();
                var labelsConsumption = ava.Where(r => r.PlcType == "Label").ToList();
                var dPallsConsumption = ava.Where(r => r.PlcType == "DePalletizer").ToList();
                var fillersConsumption = ava.Where(r => r.PlcType == "Filler").ToList();
                var blowsConsumption = ava.Where(r => r.PlcType == "Blow").ToList();

                factory.WC = mixersConsumption.Select(r => r.WC).Sum();
                factory.SC = mixersConsumption.Select(r => r.SC).Sum();
                factory.CO2 = mixersConsumption.Select(r => r.CO2).Sum();

                factory.PackCount = pallsConsumption.Select(r => r.PackCount).Sum();
                factory.PalletCount = pallsConsumption.Select(r => r.PalletCount).Sum();

                factory.BottleCount = labelsConsumption.Select(r => r.BottleCount).Sum();
                factory.BottleCountIn = blowsConsumption.Select(r => r.BottleCountIn).Sum();
                factory.BottleCountOut = blowsConsumption.Select(r => r.BottleCountOut).Sum();
                return Ok(new {machines,from,to,factory});
            }
            /*
            else if(time == 3)
            {
                var from = DateTime.Today.AddDays(-7);
                var to = DateTime.Today;
                List<MachineDetailsDTO> machines = new List<MachineDetailsDTO>();
                foreach (var load in loads)
                {
                    var machine
                    MachineDetailsDTO machine = new MachineDetailsDTO
                {
                    MachineName = load.Name,
                    MachineCode = load.PlcCode,

                };

                }
            }*/
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
