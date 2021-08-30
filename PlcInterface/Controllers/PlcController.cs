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

                var loads = _mContext.Loads.Where(r => r.ProductionLineId == function.Id && r.PlcCode != null).Select(r => new { r.Id, r.EnergyCode,r.PlcCode,r.SignalCode, r.Name }).ToList();
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

        [HttpGet("GetMachinesDetails/{time}")]
        public ActionResult GetMachinesDetails(int time)
        {
            var loads = _mContext.Loads.Where(r=>r.PlcCode != null).ToList();
            var From = (DateTime.Today.AddHours(8)).AddMinutes(20);
            var To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8)).AddMinutes(20);
                To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(20) && DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(20)).AddMinutes(10);
                To = ((DateTime.Today.AddDays(1)).AddHours(7)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4)).AddMinutes(10);
                To = (DateTime.Today.AddHours(7)).AddMinutes(50);
            }
            if (time == 1)
            {
                var from = From;
                var to = To;
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
                    var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Co2_Consumption >= 0 && r.Co2_Consumption < 100 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);

                    var mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (mixerReads2.Any())
                    {
                        mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= mixerReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }


                    var pallReads2 = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Pallet_No == 0 && r.Pallet_No <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Pallet_No >= 0 && r.Packet_No > 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (pallReads2.Any())
                    {
                        pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Pallet_No >= 0 && r.TimeStamp >= pallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var fillReads2 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count >= 0 && r.Speed >= 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (fillReads2.Any())
                    {
                        fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count >= 0 && r.TimeStamp >= fillReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();

                    }

                    var dePallReads2 = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (dePallReads2.Any())
                    {
                        dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count >= 0 && r.TimeStamp >= dePallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var labelReads2 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (labelReads2.Any())
                    {
                        labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts >= 0 && r.TimeStamp >= labelReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var cartReads2 = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (cartReads2.Any())
                    {
                        cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts >= 0 && r.TimeStamp >= cartReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var blowReads2 = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count_In == 0 && r.Count_In <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Count_In >= 0 && r.Count_Out > 0 && r.Production_Hours > 0 && r.Speed >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (blowReads2.Any())
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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                        machine.EnergyConsumption = energyConsumption;

                        var maxSpeed = 0;
                        var minuteCount = (pallReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                        for (int i = 0; i < minuteCount; i += 60)
                        {
                            OEEDTO perValue = new OEEDTO { };
                            OEEDTO avaValue = new OEEDTO { };
                            var currentTimeFrom = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                            var currentTimeTo = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                            if (currentTimeTo >= DateTime.Now)
                            {
                                currentTimeFrom = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                                currentTimeTo = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                            }
                            var sC1 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Pallet_No;
                            var sC2 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Pallet_No;

                            var avaCount = pallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                            var avaCount2 = pallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                            var sC = sC1 - sC2;
                            if (sC > maxSpeed)
                            {
                                maxSpeed = sC;
                            }
                            machine.Speed = sC;
                            if (maxSpeed == 0)
                            {
                                maxSpeed = 1;
                            }
                            machine.Performance = (decimal)sC / (decimal)maxSpeed;

                            perValue.Value = machine.Performance;
                            perValue.TimeStamp = currentTimeFrom;
                            machine.perValues.Add(perValue);

                            avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                            avaValue.TimeStamp = currentTimeFrom;
                            machine.avaValues.Add(avaValue);
                        }
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
                        machine.Speed = fillReads.Select(r => r.Speed).FirstOrDefault();

                        var hours1 = fillReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = fillReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);

                        machine.EnergyConsumption = energyConsumption;
                        var minuteCount = (fillReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                        for (int i = 0; i < minuteCount; i += 60)
                        {
                            OEEDTO perValue = new OEEDTO { };
                            OEEDTO avaValue = new OEEDTO { };
                            var currentTimeFrom = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                            var currentTimeTo = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                            if (currentTimeTo >= DateTime.Now && currentTimeFrom < DateTime.Now.AddHours(1))
                            {
                                currentTimeFrom = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                                currentTimeTo = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                            }
                            var sC1 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                            var avaCount = fillReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                            var avaCount2 = fillReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                            perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                            perValue.TimeStamp = currentTimeFrom;
                            machine.perValues.Add(perValue);

                            avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                            avaValue.TimeStamp = currentTimeFrom;
                            machine.avaValues.Add(avaValue);
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
                        machine.Speed = dePallReads.Select(r => r.Speed).FirstOrDefault();

                        var hours1 = dePallReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = dePallReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                        var minuteCount = (DateTime.Now - from).TotalMinutes;
                        for (int i = 0; i < minuteCount; i += 60)
                        {
                            OEEDTO perValue = new OEEDTO { };
                            OEEDTO avaValue = new OEEDTO { };
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + 60);
                            if (currentTimeTo >= DateTime.Now)
                            {
                                currentTimeFrom = from.AddMinutes(i - 60);
                                currentTimeTo = from.AddMinutes(i);
                            }
                            var sC1 = dePallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                            var avaCount = dePallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                            var avaCount2 = dePallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                            perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                            perValue.TimeStamp = currentTimeFrom;
                            machine.perValues.Add(perValue);

                            avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                            avaValue.TimeStamp = currentTimeFrom;
                            machine.avaValues.Add(avaValue);
                        }

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
                        machine.Speed = labelReads.Select(r => r.Speed).FirstOrDefault();

                        var hours1 = labelReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = labelReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                        machine.EnergyConsumption = energyConsumption;
                        /*if (load.PlcCode == "AlLabl3")
                        {
                            var fillerLine3 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == 3 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)machine.BottleCount / (decimal)(fillerLine3.Select(r => r.Count).FirstOrDefault() - fillerLine3.Select(r => r.Count).LastOrDefault());
                        }
                        else if (load.PlcCode == "AlLabl1")
                        {
                            var fillerLine5 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == 1 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)machine.BottleCount / (decimal)(fillerLine5.Select(r => r.Count).FirstOrDefault() - fillerLine5.Select(r => r.Count).LastOrDefault());
                        }*/
                        machine.Quality = 1;
                        var minuteCount = (labelReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                        for (int i = 0; i < minuteCount; i += 60)
                        {
                            OEEDTO perValue = new OEEDTO { };
                            OEEDTO avaValue = new OEEDTO { };
                            var currentTimeFrom = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                            var currentTimeTo = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                            if (currentTimeTo >= DateTime.Now)
                            {
                                currentTimeFrom = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                                currentTimeTo = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                            }
                            var sC1 = labelReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                            var avaCount = labelReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                            var avaCount2 = labelReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                            
                            if(sC1.Max() == 0)
                            {
                                perValue.Value = (decimal)sC1.Average() / 1;
                            }
                            else
                            {
                                perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();
                            }
                            

                            perValue.TimeStamp = currentTimeFrom;
                            machine.perValues.Add(perValue);

                            avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                            avaValue.TimeStamp = currentTimeFrom;
                            machine.avaValues.Add(avaValue);
                        }

                        machines.Add(machine);
                    }
                    else if (cartReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Cartonizer"

                        };
                        var stateReadsCount = cartReads.Select(r => r.State).ToList().Count;
                        var onReads = cartReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountCo1 = cartReads.Select(r => r.Counts).FirstOrDefault();
                        var CountCo2 = cartReads.Select(r => r.Counts).LastOrDefault();
                        machine.BottleCount = CountCo1 - CountCo2;
                        machine.Speed = cartReads.Select(r => r.Speed).FirstOrDefault();
                        var Speed1 = cartReads.Select(r => r.Speed).Average();
                        var Speed2 = cartReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = cartReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = cartReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                        machine.EnergyConsumption = energyConsumption;
                        var minuteCount = (DateTime.Now - from).TotalMinutes;
                        for (int i = 0; i < minuteCount; i += 60)
                        {
                            OEEDTO perValue = new OEEDTO { };
                            OEEDTO avaValue = new OEEDTO { };
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + 60);
                            if (currentTimeTo >= DateTime.Now)
                            {
                                currentTimeFrom = from.AddMinutes(i - 60);
                                currentTimeTo = from.AddMinutes(i);
                            }
                            var sC1 = cartReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                            var avaCount = cartReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                            var avaCount2 = cartReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                            perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                            perValue.TimeStamp = currentTimeFrom;
                            machine.perValues.Add(perValue);

                            avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                            avaValue.TimeStamp = currentTimeFrom;
                            machine.avaValues.Add(avaValue);
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
                        machine.Speed = blowReads.Select(r => r.Speed).FirstOrDefault();
                        machine.BottleCountIn = CountIn1 - CountIn2;

                        var CountOut1 = blowReads.Select(r => r.Count_Out).FirstOrDefault();
                        var CountOut2 = blowReads.Select(r => r.Count_Out).LastOrDefault();
                        machine.BottleCountOut = CountOut1 - CountOut2;

                        var Speed1 = blowReads.Select(r => r.Speed).Average();
                        var Speed2 = blowReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = blowReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = blowReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                        var minuteCount = (DateTime.Now - from).TotalMinutes;
                        for (int i = 0; i < minuteCount; i += 60)
                        {
                            OEEDTO perValue = new OEEDTO { };
                            OEEDTO avaValue = new OEEDTO { };
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + 60);
                            if (currentTimeTo >= DateTime.Now)
                            {
                                currentTimeFrom = from.AddMinutes(i - 60);
                                currentTimeTo = from.AddMinutes(i);
                            }
                            var sC1 = blowReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                            var avaCount = blowReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                            var avaCount2 = blowReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                            perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                            perValue.TimeStamp = currentTimeFrom;
                            machine.perValues.Add(perValue);

                            avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                            avaValue.TimeStamp = currentTimeFrom;
                            machine.avaValues.Add(avaValue);
                        }
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
                        machine.ProductionTime = (decimal)(hours1 - hours2)/(decimal)12;

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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;

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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;

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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;

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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;

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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;

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

        [HttpGet("GetMachineDetails/{id}")]
        public ActionResult GetMachineDetails(string id)
        {
            var loads = _mContext.Loads.Where(r => r.PlcCode == id).ToList();

            var From = (DateTime.Today.AddHours(8)).AddMinutes(20);
            var To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8)).AddMinutes(20);
                To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(20) && DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(20)).AddMinutes(10);
                To = ((DateTime.Today.AddDays(1)).AddHours(7)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4)).AddMinutes(10);
                To = (DateTime.Today.AddHours(7)).AddMinutes(50);
            }

                    var from = From;
                        var to = To;
                        List<MachineDetailsDTO> machines = new List<MachineDetailsDTO>();
                        var energyConsumption = _eContext.IotTransactions.Where(r => r.SourceId == "L_Line02_0" && r.TimeStamp >= from && r.TimeStamp <= to).Select(r => r.Energy1 + r.Energy2 + r.Energy3).ToList().DefaultIfEmpty(0).Sum();
               
                        foreach (var load in loads)
                        {
                        var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Co2_Consumption >= 0 && r.Co2_Consumption < 100 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);

                        var mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        if (mixerReads2.Any())
                        {
                            mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= mixerReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                        }


                        var pallReads2 = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Pallet_No == 0 && r.Pallet_No <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        var pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Pallet_No >= 0 && r.Packet_No > 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        if (pallReads2.Any())
                        {
                            pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Pallet_No >= 0 && r.TimeStamp >= pallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                        }

                        var fillReads2 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        var fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count >= 0 && r.Speed >= 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        if (fillReads2.Any())
                        {
                            fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count >= 0 && r.TimeStamp >= fillReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();

                        }

                        var dePallReads2 = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        var dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        if (dePallReads2.Any())
                        {
                            dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count >= 0 && r.TimeStamp >= dePallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                        }

                        var labelReads2 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        var labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        if (labelReads2.Any())
                        {
                            labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Counts >= 0 && r.TimeStamp >= labelReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                        }

                        var cartReads2 = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        var cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        if (cartReads2.Any())
                        {
                           cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode && r.Counts >= 0 && r.TimeStamp >= cartReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                        }

                        var blowReads2 = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count_In == 0 && r.Count_In <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        var blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count_In >= 0 && r.Count_Out > 0 && r.Production_Hours > 0 && r.Speed >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                        if (blowReads2.Any())
                        {
                            blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == load.PlcCode  && r.Count_In >= 0 && r.TimeStamp >= blowReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
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
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                         machine.EnergyConsumption = energyConsumption;

                    var maxSpeed = 0;
                    var minuteCount = (pallReads.OrderByDescending(r=>r.Id).FirstOrDefault().TimeStamp - pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }
                        var sC1 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Pallet_No;
                        var sC2 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Pallet_No;

                        var avaCount = pallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = pallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                        var sC = sC1 - sC2;
                        if (sC > maxSpeed)
                        {
                            maxSpeed = sC;
                        }
                        machine.Speed = sC;
                        if (maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        machine.Performance = (decimal)sC / (decimal)maxSpeed;

                        perValue.Value = machine.Performance;
                        perValue.TimeStamp = currentTimeFrom;
                        machine.perValues.Add(perValue);

                        avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                        avaValue.TimeStamp = currentTimeFrom;
                        machine.avaValues.Add(avaValue);
                    }
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
                        machine.Speed = fillReads.Select(r => r.Speed).FirstOrDefault();

                        var hours1 = fillReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = fillReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);

                        machine.EnergyConsumption = energyConsumption;
                        var minuteCount = (DateTime.Now - from).TotalMinutes;
                        for (int i = 0; i < minuteCount; i += 60)
                        {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now && currentTimeFrom < DateTime.Now.AddHours(1))
                        {
                            currentTimeFrom = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }
                        var sC1 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                        var avaCount = fillReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = fillReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                        perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                        perValue.TimeStamp = currentTimeFrom;
                        machine.perValues.Add(perValue);

                        avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                        avaValue.TimeStamp = currentTimeFrom;
                        machine.avaValues.Add(avaValue);
                    }

                    if (load.PlcCode == "AlFill3")
                        {
                            var fillerLine3 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == 3 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)(fillerLine3.Select(r => r.Counts).FirstOrDefault() - fillerLine3.Select(r => r.Counts).LastOrDefault()) / (decimal)machine.BottleCount;
                        }
                        else if (load.PlcCode == "AlFill1")
                        {
                            var fillerLine5 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == 1 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)(fillerLine5.Select(r => r.Counts).FirstOrDefault() - fillerLine5.Select(r => r.Counts).LastOrDefault()) / (decimal)machine.BottleCount;
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
                    machine.Speed = dePallReads.Select(r => r.Speed).FirstOrDefault();

                    var hours1 = dePallReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = dePallReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                    machine.ProductionHours = (decimal)(hours1 - hours2);
                    machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                    var minuteCount = (DateTime.Now - from).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = from.AddMinutes(i);
                        var currentTimeTo = from.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = from.AddMinutes(i - 60);
                            currentTimeTo = from.AddMinutes(i);
                        }
                        var sC1 = dePallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                        var avaCount = dePallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = dePallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                        perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                        perValue.TimeStamp = currentTimeFrom;
                        machine.perValues.Add(perValue);

                        avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                        avaValue.TimeStamp = currentTimeFrom;
                        machine.avaValues.Add(avaValue);
                    }

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
                    machine.Speed = labelReads.Select(r => r.Speed).FirstOrDefault();

                    var hours1 = labelReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = labelReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                        machine.EnergyConsumption = energyConsumption;
                        if (load.PlcCode == "AlLabl3")
                        {
                            var fillerLine3 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == 3 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)machine.BottleCount / (decimal)(fillerLine3.Select(r => r.Count).FirstOrDefault() - fillerLine3.Select(r => r.Count).LastOrDefault());
                        }
                        else if (load.PlcCode == "AlLabl1")
                        {
                            var fillerLine5 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == 1 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                            machine.Quality = (decimal)machine.BottleCount / (decimal)(fillerLine5.Select(r => r.Count).FirstOrDefault() - fillerLine5.Select(r => r.Count).LastOrDefault());
                        }
                    var minuteCount = (DateTime.Now - from).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = from.AddMinutes(i);
                        var currentTimeTo = from.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = from.AddMinutes(i - 60);
                            currentTimeTo = from.AddMinutes(i);
                        }
                        var sC1 = labelReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                        var avaCount = labelReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = labelReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                        perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                        perValue.TimeStamp = currentTimeFrom;
                        machine.perValues.Add(perValue);

                        avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                        avaValue.TimeStamp = currentTimeFrom;
                        machine.avaValues.Add(avaValue);
                    }

                    machines.Add(machine);
                    }
                    else if (cartReads.Any())
                    {
                        MachineDetailsDTO machine = new MachineDetailsDTO
                        {
                            MachineName = load.Name,
                            MachineCode = load.PlcCode,
                            LineId = (int)load.ProductionLineId,
                            PlcType = "Cartonizer"

                        };
                        var stateReadsCount = cartReads.Select(r => r.State).ToList().Count;
                        var onReads = cartReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        machine.Avalability = (decimal)onReads / (decimal)stateReadsCount;
                        machine.WC = water;
                        machine.CO2 = co2;
                        machine.SC = syrup;
                        machine.PackCount = pack;
                        machine.PalletCount = pallet;
                        var CountCo1 = cartReads.Select(r => r.Counts).FirstOrDefault();
                        var CountCo2 = cartReads.Select(r => r.Counts).LastOrDefault();
                        machine.BottleCount = CountCo1 - CountCo2;
                    machine.Speed = cartReads.Select(r => r.Speed).FirstOrDefault();
                    var Speed1 = cartReads.Select(r => r.Speed).Average();
                        var Speed2 = cartReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = cartReads.Select(r => r.Hours).FirstOrDefault();
                        var hours2 = cartReads.Select(r => r.Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                        machine.EnergyConsumption = energyConsumption;
                    var minuteCount = (DateTime.Now - from).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = from.AddMinutes(i);
                        var currentTimeTo = from.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = from.AddMinutes(i - 60);
                            currentTimeTo = from.AddMinutes(i);
                        }
                        var sC1 = cartReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                        var avaCount = cartReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = cartReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                        perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                        perValue.TimeStamp = currentTimeFrom;
                        machine.perValues.Add(perValue);

                        avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                        avaValue.TimeStamp = currentTimeFrom;
                        machine.avaValues.Add(avaValue);
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
                    machine.Speed = blowReads.Select(r => r.Speed).FirstOrDefault();
                    machine.BottleCountIn = CountIn1 - CountIn2;

                        var CountOut1 = blowReads.Select(r => r.Count_Out).FirstOrDefault();
                        var CountOut2 = blowReads.Select(r => r.Count_Out).LastOrDefault();
                        machine.BottleCountOut = CountOut1 - CountOut2;

                        var Speed1 = blowReads.Select(r => r.Speed).Average();
                        var Speed2 = blowReads.Select(r => r.Speed).Max();
                        machine.Performance = (decimal)Speed1 / (decimal)Speed2;


                        var hours1 = blowReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var hours2 = blowReads.Select(r => r.Production_Hours).LastOrDefault();
                        machine.ProductionTime = (decimal)(hours1 - hours2) / (decimal)12;
                        machine.ProductionHours = (decimal)(hours1 - hours2);
                        machine.EnergyConsumption = energyConsumption;
                        machines.Add(machine);
                    var minuteCount = (DateTime.Now - from).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = from.AddMinutes(i);
                        var currentTimeTo = from.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = from.AddMinutes(i - 60);
                            currentTimeTo = from.AddMinutes(i);
                        }
                        var sC1 = blowReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).Select(r => r.Speed).ToList();


                        var avaCount = blowReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = blowReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;

                        perValue.Value = (decimal)sC1.Average() / (decimal)sC1.Max();

                        perValue.TimeStamp = currentTimeFrom;
                        machine.perValues.Add(perValue);

                        avaValue.Value = (decimal)avaCount / (decimal)avaCount2;
                        avaValue.TimeStamp = currentTimeFrom;
                        machine.avaValues.Add(avaValue);
                    }
                }

                }
               

                return Ok(new { machines, from, to });
           
        }


        [HttpGet("MachineKPIs/{MachineId}")]
        public ActionResult MachineKPIs(string MachineId)
        {
           /* var From = (DateTime.Today.AddHours(8));
            var To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8));
                To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(20) && DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(20));
                To = ((DateTime.Today.AddDays(1)).AddHours(7)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4));
                To = (DateTime.Today.AddHours(7)).AddMinutes(50);
            }*/
            var From = (DateTime.Today.AddHours(8));
            var To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8));
                To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(20) && DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(8));
                To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4));
                To = (DateTime.Today.AddHours(7)).AddMinutes(45);
            }
            var from = From;
            var to = To;
            int Count = 0;
            
            
            var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Co2_Consumption >= 0 && r.Co2_Consumption < 100 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);

            var mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            if (mixerReads2.Any())
            {
                from = mixerReads2.Select(r => r.TimeStamp).LastOrDefault();
                mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= mixerReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
            }
            var fillReads2 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count == 0 && r.Count <= 1000 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            var fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count >= 0 && r.Speed >= 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            if (fillReads2.Any())
            {
                from = fillReads2.Select(r => r.TimeStamp).LastOrDefault();
                fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count >= 0 && r.TimeStamp >= fillReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();

            }

            var dePallReads2 = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            var dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            if (dePallReads2.Any())
            {
                from = dePallReads2.Select(r => r.TimeStamp).LastOrDefault();
                dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count >= 0 && r.TimeStamp >= dePallReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
            }

            var labelReads2 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            var labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            if (labelReads2.Any())
            {
                from = labelReads2.Select(r => r.TimeStamp).LastOrDefault();
                labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Counts >= 0 && r.TimeStamp >= labelReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
            }

            var cartReads2 = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            var cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            if (cartReads2.Any())
            {
                from = cartReads2.Select(r => r.TimeStamp).LastOrDefault();
                cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Counts >= 0 && r.TimeStamp >= cartReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
            }

            var blowReads2 = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count_In == 0 && r.Count_In <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            var blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count_In >= 0 && r.Count_Out > 0 && r.Production_Hours > 0 && r.Speed >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            if (blowReads2.Any())
            {
                from = blowReads2.Select(r => r.TimeStamp).LastOrDefault();
                blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Count_In >= 0 && r.TimeStamp >= blowReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
            }
            var pallReads2 = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Pallet_No == 0 && r.Pallet_No <= 200 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            var pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Pallet_No >= 0 && r.Packet_No > 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
            if (pallReads2.Any())
            {
                pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId && r.Pallet_No >= 0 && r.TimeStamp >= pallReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
                from = pallReads2.Select(r => r.TimeStamp).LastOrDefault();
            }
            var loadDetails = _mContext.Loads.Where(r => r.PlcCode == MachineId).FirstOrDefault();
            MachineKPIs machine = new MachineKPIs { from = from, to = to, MachineId = MachineId, MachineName = loadDetails.Name };
            if (pallReads.Any())
            {
                /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                {
                    if(read.Pallet_No == 0 || read.Pallet_No )
                }*/
                var fromMonth = DateTime.Today.AddMonths(-1);
                var toMonth = DateTime.Today;
                
                decimal avgNo = 0;
                DateTime firstTimeStamp = new DateTime { };
                DateTime lastTimeStamp = new DateTime { };
                List<int> palletsCount = new List<int>();
                /*var monthlyReads = _context.Palletizers.Where(r => r.MachineId == MachineId && r.Pallet_No >= 0 && r.Packet_No >= 0 && r.Production_Hours >= 0 && r.TimeStamp >= fromMonth && r.TimeStamp <= toMonth).ToList();
                foreach (var read in monthlyReads)
                {
                    
                    if(read.Pallet_No == 0)
                    {
                        if(monthlyReads.OrderByDescending(r => r.Id).Where(r=>r.TimeStamp < read.TimeStamp).FirstOrDefault().Pallet_No != 0)
                        {
                           
                            palletsCount.Add(monthlyReads.OrderByDescending(r=>r.Id).Where(r => r.TimeStamp < read.TimeStamp).FirstOrDefault().Pallet_No);
                        }
                    }
                }
                var readsss = palletsCount;
                machine.MPerformance = ((decimal)palletsCount.Sum()/(decimal)30);
                machine.MAVA = palletsCount.Max();*/
                /*machine.MAVA = machine.MonthlyData.Select(r => r.Availability).Average();
                machine.MOEE = machine.MonthlyData.Select(r => r.OEE).Average();*/



                machine.MachineType = "Palletizer";
                var reads = pallReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                var readsAll = pallReads.OrderBy(r => r.Id).ToList();
                decimal timeChange = 0;
                List<DateTime> dates = new List<DateTime>();
                List<DateTime> upTime = new List<DateTime>();

                for (int i = 1; i < reads.Count; i++)
                {
                    var count = reads[i].Pallet_No - reads[i - 1].Pallet_No;
                    if (count == 0)
                    {
                        dates.Add(reads[i].TimeStamp);
                    }
                }
                machine.ChangeTimeCount = dates.Count;
                machine.BreakdownCount = readsAll.Where(r => r.State == 0 && r.Fault == 1).ToList().Count;
                machine.WaitingCount = readsAll.Where(r => r.State == 0 && r.Fault == 0).ToList().Count;
                machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                var totalReads = pallReads.Count;
                var stateOneReads = pallReads.Where(r => r.State == 1).ToList().Count;
                var stateZeroReads = pallReads.Where(r => r.State == 0).ToList().Count;
                var faultReadsCount = pallReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                var faultReads = pallReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                var Counter = 0;
                for (int i = 1; i < faultReads.Count; i++)
                {
                    if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                    {

                        Count++;
                        if (Count >= 2)
                        {
                            Count = 0;
                            Counter++;
                        }

                    }
                }
                faultReadsCount = faultReadsCount - Counter;
                if (faultReadsCount == 0)
                {
                    faultReadsCount = 1;
                }
                machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                var productionHours = pallReads.FirstOrDefault().Production_Hours - pallReads.LastOrDefault().Production_Hours;
                var producedUnits = pallReads.FirstOrDefault().Pallet_No - pallReads.LastOrDefault().Pallet_No;
                if (producedUnits == 0)
                {
                    producedUnits = 1;
                }
                machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                machine.ProductionHours = productionHours;
                machine.Production_OutPut = producedUnits;
                for (int i = 1; i < readsAll.Count; i++)
                {

                    StateTime state = new StateTime
                    {
                        State = readsAll[i].State,
                        Fault = readsAll[i].Fault,
                        StartTime = readsAll[i - 1].TimeStamp,
                        EndTime = readsAll[i].TimeStamp,
                    };
                    if (readsAll[i].State != readsAll[i - 1].State)
                    {
                        upTime.Add(readsAll[i].TimeStamp);
                    }
                    machine.StateTimes.Add(state);

                }
                decimal value = 0;
                for (int i = 1; i < upTime.Count; i++)
                {

                    value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                }
                machine.UpTime = value;
                var upTimeReads = upTime.ToList();
                var maxSpeed = 0;
                var minuteCount = (pallReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                for (int i = 0; i < minuteCount; i += 60)
                {
                   
                    OEEDTO perValue = new OEEDTO { };
                    OEEDTO avaValue = new OEEDTO { };
                    var currentTimeFrom = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    var currentTimeTo = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                    if (currentTimeTo >= DateTime.Now)
                    {
                        currentTimeFrom = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                        currentTimeTo = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    }
                    LineKPIData data = new LineKPIData
                    {
                        MachineName = loadDetails.Name,
                        TimeStamp = currentTimeTo
                    };
                    var sC1 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Pallet_No;
                    var sC2 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Pallet_No;
                    var pH1 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Production_Hours;
                    var pH2 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Production_Hours;
                    
                    var t1 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().TimeStamp;
                    var t2 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().TimeStamp;
                    var t = (t1 - t2).TotalHours;
                    data.Uptime = (decimal)t;

                    var pH = pH1 - pH2;
                    var avaCount = pallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                    var avaCount2 = pallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                    var sC = sC1 - sC2;
                    machine.Throughput = sC;
                    if (sC > maxSpeed)
                    {
                        maxSpeed = sC;
                        machine.Max_Production_Capacity = maxSpeed;
                    }
                    if (maxSpeed == 0)
                    {
                        maxSpeed = 1;
                    }
                    if(sC == 0)
                    {
                        sC = 1;
                    }    
                    data.Performance = (decimal)sC/(decimal)maxSpeed;
                    data.Availability = (decimal)avaCount / (decimal)avaCount2;
                    data.Quality = 1;
                    data.OEE = data.Performance * data.Availability * data.Quality;
                    data.Throughput = sC;
                    data.ProductionOutPut = sC1;
                    data.CycleTime = (decimal)pH / (decimal)sC;
                    machine.LineData.Add(data);

                }
                var lineCount = machine.LineData.Count;
                machine.LineData = machine.LineData.ToList().ToList();
                machine.Performance = (decimal)machine.LineData.Select(r=>r.Performance).Average();
                machine.Availability = (decimal)machine.LineData.Select(r=>r.Availability).Average();
                
                machine.Quality = 1;
                machine.Utiliztion = (decimal)712 / (decimal)720;
                machine.OEE = machine.Availability * machine.Performance * machine.Quality;
                //machine.MOEE = avaMonth * machine.Performance * machine.Quality;
                machine.TEEP = machine.Utiliztion * machine.OEE;
                //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                var time = (DateTime.Now - from).TotalHours;
                machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;




            }
            if (mixerReads.Any())
            {
                /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                {
                    if(read.Pallet_No == 0 || read.Pallet_No )
                }*/
                machine.MachineType = "Mixer";
                var reads = mixerReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                var readsAll = mixerReads.OrderBy(r => r.Id).ToList();
                decimal timeChange = 0;
                List<DateTime> dates = new List<DateTime>();
                List<DateTime> upTime = new List<DateTime>();

                for (int i = 1; i < reads.Count; i++)
                {
                    var count = reads[i].Product_Consumption - reads[i - 1].Product_Consumption;
                    if (count == 0)
                    {
                        dates.Add(reads[i].TimeStamp);
                    }
                }
                machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                var totalReads = mixerReads.Count;
                var stateOneReads = mixerReads.Where(r => r.State == 1).ToList().Count;
                var stateZeroReads = mixerReads.Where(r => r.State == 0).ToList().Count;
                var faultReadsCount = mixerReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                var faultReads = mixerReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                var Counter = 0;
                for (int i = 1; i < faultReads.Count; i++)
                {
                    if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                    {

                        Count++;
                        if (Count >= 2)
                        {
                            Count = 0;
                            Counter++;
                        }

                    }
                }
                faultReadsCount = faultReadsCount - Counter;
                if (faultReadsCount == 0)
                {
                    faultReadsCount = 1;
                }
                machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                var productionHours = mixerReads.FirstOrDefault().Production_Hours - mixerReads.LastOrDefault().Production_Hours;
                var producedUnits = mixerReads.FirstOrDefault().Product_Consumption - mixerReads.LastOrDefault().Product_Consumption;
                if (producedUnits == 0)
                {
                    producedUnits = 1;
                }
                machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                machine.ProductionHours = productionHours;
                machine.Production_OutPut = producedUnits;

                for (int i = 1; i < readsAll.Count; i++)
                {
                    StateTime state = new StateTime
                    {
                        State = readsAll[i].State,Fault = readsAll[i].Fault,
                        StartTime = readsAll[i-1].TimeStamp,
                        EndTime = readsAll[i ].TimeStamp,
                    };
                    if (readsAll[i].State != readsAll[i - 1].State)
                    {
                        upTime.Add(readsAll[i].TimeStamp);
                    }
                    machine.StateTimes.Add(state);
                }
                decimal value = 0;
                for (int i = 1; i < upTime.Count; i++)
                {

                    value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                }
                machine.UpTime = value;
                var upTimeReads = upTime.ToList();
                decimal maxSpeed = 0;
                var minuteCount = (mixerReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                for (int i = 0; i < minuteCount; i += 60)
                {
                    OEEDTO perValue = new OEEDTO { };
                    OEEDTO avaValue = new OEEDTO { };
                    var currentTimeFrom = mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    var currentTimeTo = mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                    if (currentTimeTo >= DateTime.Now)
                    {
                        currentTimeFrom = mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                        currentTimeTo = mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    }
                    var sC1 = mixerReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Product_Consumption;
                    var sC2 = mixerReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Product_Consumption;

                    var avaCount = mixerReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                    var avaCount2 = mixerReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                    var sC = sC1 - sC2;
                    machine.Throughput = sC;
                    if (sC > maxSpeed)
                    {
                        maxSpeed = (decimal)sC;
                        machine.Max_Production_Capacity = maxSpeed;
                    }
                    if (maxSpeed == 0)
                    {
                        maxSpeed = 1;
                    }
                    if (sC == 0)
                    {
                        sC = 1;
                    }
                    machine.Performance = (decimal)sC / (decimal)maxSpeed;


                }
                machine.Quality = 1;
                machine.Utiliztion = (decimal)712 / (decimal)720;
                machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                machine.TEEP = machine.Utiliztion * machine.OEE;
                //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                var time = (DateTime.Now - from).TotalHours;
                machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;


            }
            if (fillReads.Any())
            {
                /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                {
                    if(read.Pallet_No == 0 || read.Pallet_No )
                }*/
                machine.MachineType = "Filler";
                var reads = fillReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                var readsAll = fillReads.OrderBy(r => r.Id).ToList();
                decimal timeChange = 0;
                List<DateTime> dates = new List<DateTime>();
                List<DateTime> upTime = new List<DateTime>();

                for (int i = 1; i < reads.Count; i++)
                {
                    var count = reads[i].Count - reads[i - 1].Count;
                    if (count == 0)
                    {
                        dates.Add(reads[i].TimeStamp);
                    }
                }
                machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                var totalReads = fillReads.Count;
                var stateOneReads = fillReads.Where(r => r.State == 1).ToList().Count;
                var stateZeroReads = fillReads.Where(r => r.State == 0).ToList().Count;
                var faultReadsCount = fillReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                var faultReads = fillReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                var Counter = 0;
                for (int i = 1; i < faultReads.Count; i++)
                {
                    if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                    {

                        Count++;
                        if (Count >= 2)
                        {
                            Count = 0;
                            Counter++;
                        }

                    }
                }
                faultReadsCount = faultReadsCount - Counter;
                if (faultReadsCount == 0)
                {
                    faultReadsCount = 1;
                }
                machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                var productionHours = fillReads.FirstOrDefault().Production_Hours - fillReads.LastOrDefault().Production_Hours;
                var producedUnits = fillReads.FirstOrDefault().Count - fillReads.LastOrDefault().Count;
                machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                machine.ProductionHours = productionHours;
                machine.Production_OutPut = producedUnits;

                for (int i = 1; i < readsAll.Count; i++)
                {
                    StateTime state = new StateTime
                    {
                        State = readsAll[i].State,Fault = readsAll[i].Fault,
                        StartTime = readsAll[i-1].TimeStamp,
                        EndTime = readsAll[i ].TimeStamp,
                    };
                    if (readsAll[i].State != readsAll[i - 1].State)
                    {
                        upTime.Add(readsAll[i].TimeStamp);
                    }
                    machine.StateTimes.Add(state);
                }
                decimal value = 0;
                for (int i = 1; i < upTime.Count; i++)
                {

                    value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                }
                machine.UpTime = value;
                var upTimeReads = upTime.ToList();
                decimal maxSpeed = 0;
                var minuteCount = (fillReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                for (int i = 0; i < minuteCount; i += 60)
                {
                    OEEDTO perValue = new OEEDTO { };
                    OEEDTO avaValue = new OEEDTO { };
                    var currentTimeFrom = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    var currentTimeTo = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                    if (currentTimeTo >= DateTime.Now)
                    {
                        currentTimeFrom = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                        currentTimeTo = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    }
                    var sC1 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Count;
                    var sC2 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Count;
                    var pH1 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Production_Hours;
                    var pH2 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Production_Hours;

                    var pH = pH1 - pH2;
                    var avaCount = fillReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                    var avaCount2 = fillReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                    var sC = sC1 - sC2;
                    LineKPIData lineData = new LineKPIData { TimeStamp = currentTimeFrom };

                    machine.Throughput = sC;
                    if (sC > maxSpeed)
                    {
                        maxSpeed = (decimal)sC;
                        machine.Max_Production_Capacity = maxSpeed;
                    }
                    if (maxSpeed == 0)
                    {
                        maxSpeed = 1;
                    }
                    if (sC == 0)
                    {
                        sC = 1;
                    }
                    machine.Performance = (decimal)sC / (decimal)maxSpeed;
                    lineData.Throughput = sC;
                    lineData.ProductionOutPut = sC1;
                    lineData.CycleTime = (decimal)pH / (decimal)sC;
                    machine.LineData.Add(lineData);

                }
                machine.Quality = 1;
                machine.Utiliztion = (decimal)712 / (decimal)720;
                machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                machine.TEEP = machine.Utiliztion * machine.OEE;
                //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                var time = (DateTime.Now - from).TotalHours;
                machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;

                machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
            }
            if (dePallReads.Any())
            {
                /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                {
                    if(read.Pallet_No == 0 || read.Pallet_No )
                }*/
                machine.MachineType = "DPalletizer";
                var reads = dePallReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                var readsAll = dePallReads.OrderBy(r => r.Id).ToList();
                decimal timeChange = 0;
                List<DateTime> dates = new List<DateTime>();
                List<DateTime> upTime = new List<DateTime>();

                for (int i = 1; i < reads.Count; i++)
                {
                    var count = reads[i].Count - reads[i - 1].Count;
                    if (count == 0)
                    {
                        dates.Add(reads[i].TimeStamp);
                    }
                }
                machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                var totalReads = dePallReads.Count;
                var stateOneReads = dePallReads.Where(r => r.State == 1).ToList().Count;
                var stateZeroReads = dePallReads.Where(r => r.State == 0).ToList().Count;
                var faultReadsCount = dePallReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                var faultReads = dePallReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                var Counter = 0;
                for (int i = 1; i < faultReads.Count; i++)
                {
                    if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                    {

                        Count++;
                        if (Count >= 2)
                        {
                            Count = 0;
                            Counter++;
                        }

                    }
                }
                faultReadsCount = faultReadsCount - Counter;
                if (faultReadsCount == 0)
                {
                    faultReadsCount = 1;
                }
                machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                var productionHours = dePallReads.FirstOrDefault().Hours - dePallReads.LastOrDefault().Hours;
                var producedUnits = dePallReads.FirstOrDefault().Count - dePallReads.LastOrDefault().Count;
                machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                machine.ProductionHours = productionHours;
                machine.Production_OutPut = producedUnits;

                for (int i = 1; i < readsAll.Count; i++)
                {
                    StateTime state = new StateTime
                    {
                        State = readsAll[i].State,Fault = readsAll[i].Fault,
                        StartTime = readsAll[i-1].TimeStamp,
                        EndTime = readsAll[i ].TimeStamp,
                    };
                    if (readsAll[i].State != readsAll[i - 1].State)
                    {
                        upTime.Add(readsAll[i].TimeStamp);
                    }
                    else if(readsAll[i].State == 1)
                    {
                        upTime.Add(readsAll[i].TimeStamp);
                    }
                    machine.StateTimes.Add(state);
                }
                decimal value = 0;
                for (int i = 1; i < upTime.Count; i++)
                {

                    value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                }
                machine.UpTime = value;
                var upTimeReads = upTime.ToList();
                decimal maxSpeed = 0;
                var minuteCount = (dePallReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                for (int i = 0; i < minuteCount; i += 60)
                {
                    OEEDTO perValue = new OEEDTO { };
                    OEEDTO avaValue = new OEEDTO { };
                    var currentTimeFrom = dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    var currentTimeTo = dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                    if (currentTimeTo >= DateTime.Now)
                    {
                        currentTimeFrom = dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                        currentTimeTo = dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    }

                    var sC1 = dePallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Count;
                    var sC2 = dePallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Count;



                    var avaCount = dePallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                    var avaCount2 = dePallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                    var sC = sC1 - sC2;
                    machine.Throughput = sC;
                    if (sC > maxSpeed)
                    {
                        maxSpeed = (decimal)sC;
                        machine.Max_Production_Capacity = maxSpeed;
                    }
                    if (maxSpeed == 0)
                    {
                        maxSpeed = 1;
                    }
                    if (sC == 0)
                    {
                        sC = 1;
                    }
                    machine.Performance = (decimal)sC / (decimal)maxSpeed;


                }
                machine.Quality = 1;
                machine.Utiliztion = (decimal)712 / (decimal)720;
                machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                machine.TEEP = machine.Utiliztion * machine.OEE;
                //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                var time = (DateTime.Now - from).TotalHours;
                machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;

                machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
            }
            if (labelReads.Any())
            {
                /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                {
                    if(read.Pallet_No == 0 || read.Pallet_No )
                }*/
                machine.MachineType = "Label";
                var reads = labelReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                var readsAll = labelReads.OrderBy(r => r.Id).ToList();
                decimal timeChange = 0;
                List<DateTime> dates = new List<DateTime>();
                List<DateTime> upTime = new List<DateTime>();

                for (int i = 1; i < reads.Count; i++)
                {
                    var count = reads[i].Counts - reads[i - 1].Counts;
                    if (count == 0)
                    {
                        dates.Add(reads[i].TimeStamp);
                    }
                }
                machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                var totalReads = labelReads.Count;
                var stateOneReads = labelReads.Where(r => r.State == 1).ToList().Count;
                var stateZeroReads = labelReads.Where(r => r.State == 0).ToList().Count;
                var faultReadsCount = labelReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                var faultReads = labelReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                var Counter = 0;
                for (int i = 1; i < faultReads.Count; i++)
                {
                    if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                    {

                        Count++;
                        if (Count >= 2)
                        {
                            Count = 0;
                            Counter++;
                        }

                    }
                }
                faultReadsCount = faultReadsCount - Counter;
                if (faultReadsCount == 0)
                {
                    faultReadsCount = 1;
                }
                machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                var productionHours = labelReads.FirstOrDefault().Hours - labelReads.LastOrDefault().Hours;
                var producedUnits = labelReads.FirstOrDefault().Counts - labelReads.LastOrDefault().Counts;
                if (producedUnits == 0)
                {
                    producedUnits = 1;
                }
                machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                machine.ProductionHours = productionHours;
                machine.Production_OutPut = producedUnits;

                for (int i = 1; i < readsAll.Count; i++)
                {
                    StateTime state = new StateTime
                    {
                        State = readsAll[i].State,Fault = readsAll[i].Fault,
                        StartTime = readsAll[i-1].TimeStamp,
                        EndTime = readsAll[i ].TimeStamp,
                    };
                    if (readsAll[i].State != readsAll[i - 1].State)
                    {
                        upTime.Add(readsAll[i].TimeStamp);
                    }
                    machine.StateTimes.Add(state);
                }
                decimal value = 0;
                for (int i = 1; i < upTime.Count; i++)
                {

                    value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                }
                machine.UpTime = value;
                var upTimeReads = upTime.ToList();
                decimal maxSpeed = 0;
                var minuteCount = (labelReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                for (int i = 0; i < minuteCount; i += 60)
                {
                    OEEDTO perValue = new OEEDTO { };
                    OEEDTO avaValue = new OEEDTO { };
                    var currentTimeFrom = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    var currentTimeTo = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                    if (currentTimeTo >= DateTime.Now)
                    {
                        currentTimeFrom = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                        currentTimeTo = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    }
                    var sC1 = labelReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Counts;
                    var sC2 = labelReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Counts;

                    var avaCount = labelReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                    var avaCount2 = labelReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                    var sC = sC1 - sC2;
                    machine.Throughput = sC;
                    if (sC > maxSpeed)
                    {
                        maxSpeed = (decimal)sC;
                        machine.Max_Production_Capacity = maxSpeed;
                    }
                    if (maxSpeed == 0)
                    {
                        maxSpeed = 1;
                    }
                    machine.Performance = (decimal)sC / (decimal)maxSpeed;


                }
                machine.Quality = 1;
                machine.Utiliztion = (decimal)712 / (decimal)720;
                machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                machine.TEEP = machine.Utiliztion * machine.OEE;
                //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                var time = (DateTime.Now - from).TotalHours;
                machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
            }
            if (cartReads.Any())
            {
                /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                {
                    if(read.Pallet_No == 0 || read.Pallet_No )
                }*/
                machine.MachineType = "Cart";
                var reads = cartReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                var readsAll = cartReads.OrderBy(r => r.Id).ToList();
                decimal timeChange = 0;
                List<DateTime> dates = new List<DateTime>();
                List<DateTime> upTime = new List<DateTime>();

                for (int i = 1; i < reads.Count; i++)
                {
                    var count = reads[i].Counts - reads[i - 1].Counts;
                    if (count == 0)
                    {
                        dates.Add(reads[i].TimeStamp);
                    }
                }
                machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                var totalReads = cartReads.Count;
                var stateOneReads = cartReads.Where(r => r.State == 1).ToList().Count;
                var stateZeroReads = cartReads.Where(r => r.State == 0).ToList().Count;
                var faultReadsCount = cartReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                var faultReads = cartReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                var Counter = 0;
                for (int i = 1; i < faultReads.Count; i++)
                {
                    if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                    {

                        Count++;
                        if (Count >= 2)
                        {
                            Count = 0;
                            Counter++;
                        }

                    }
                }
                faultReadsCount = faultReadsCount - Counter;
                if (faultReadsCount == 0)
                {
                    faultReadsCount = 1;
                }
                machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                var productionHours = cartReads.FirstOrDefault().Hours - cartReads.LastOrDefault().Hours;
                var producedUnits = cartReads.FirstOrDefault().Counts - cartReads.LastOrDefault().Counts;
                if (producedUnits == 0)
                {
                    producedUnits = 1;
                }
                machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                machine.ProductionHours = productionHours;
                machine.Production_OutPut = producedUnits;

                for (int i = 1; i < readsAll.Count; i++)
                {
                    StateTime state = new StateTime
                    {
                        State = readsAll[i].State,Fault = readsAll[i].Fault,
                        StartTime = readsAll[i-1].TimeStamp,
                        EndTime = readsAll[i ].TimeStamp,
                    };
                    if (readsAll[i].State != readsAll[i - 1].State)
                    {
                        upTime.Add(readsAll[i].TimeStamp);
                    }
                    machine.StateTimes.Add(state);
                }
                decimal value = 0;
                for (int i = 1; i < upTime.Count; i++)
                {

                    value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                }
                machine.UpTime = value;
                var upTimeReads = upTime.ToList();
                decimal maxSpeed = 0;
                var minuteCount = (cartReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                for (int i = 0; i < minuteCount; i += 60)
                {
                    OEEDTO perValue = new OEEDTO { };
                    OEEDTO avaValue = new OEEDTO { };
                    var currentTimeFrom = cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    var currentTimeTo = cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                    if (currentTimeTo >= DateTime.Now)
                    {
                        currentTimeFrom = cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                        currentTimeTo = cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    }
                    var sC1 = cartReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Counts;
                    var sC2 = cartReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Counts;

                    var avaCount = cartReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                    var avaCount2 = cartReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                    var sC = sC1 - sC2;
                    machine.Throughput = sC;
                    if (sC > maxSpeed)
                    {
                        maxSpeed = (decimal)sC;
                        machine.Max_Production_Capacity = maxSpeed;
                    }
                    if (maxSpeed == 0)
                    {
                        maxSpeed = 1;
                    }
                    machine.Performance = (decimal)sC / (decimal)maxSpeed;


                }
                machine.Quality = 1;
                machine.Utiliztion = (decimal)712 / (decimal)720;
                machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                machine.TEEP = machine.Utiliztion * machine.OEE;
                //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                var time = (DateTime.Now - from).TotalHours;
                machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;

            }
            if (blowReads.Any())
            {
                /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                {
                    if(read.Pallet_No == 0 || read.Pallet_No )
                }*/
                machine.MachineType = "Blow";
                var reads = blowReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                var readsAll = blowReads.OrderBy(r => r.Id).ToList();
                decimal timeChange = 0;
                List<DateTime> dates = new List<DateTime>();
                List<DateTime> upTime = new List<DateTime>();

                for (int i = 1; i < reads.Count; i++)
                {
                    var count = reads[i].Count_Out - reads[i - 1].Count_Out;
                    if (count == 0)
                    {
                        dates.Add(reads[i].TimeStamp);
                    }
                }
                machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                var totalReads = blowReads.Count;
                var stateOneReads = blowReads.Where(r => r.State == 1).ToList().Count;
                var stateZeroReads = blowReads.Where(r => r.State == 0).ToList().Count;
                var faultReadsCount = blowReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                var faultReads = blowReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                var Counter = 0;
                for (int i = 1; i < faultReads.Count; i++)
                {
                    if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                    {

                        Count++;
                        if (Count >= 2)
                        {
                            Count = 0;
                            Counter++;
                        }

                    }
                }
                faultReadsCount = faultReadsCount - Counter;
                if (faultReadsCount == 0)
                {
                    faultReadsCount = 1;
                }
                machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                var productionHours = blowReads.FirstOrDefault().Production_Hours - blowReads.LastOrDefault().Production_Hours;
                var producedUnits = blowReads.FirstOrDefault().Count_Out - blowReads.LastOrDefault().Count_Out;
                if (producedUnits == 0)
                {
                    producedUnits = 1;
                }
                machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                machine.ProductionHours = productionHours;
                machine.Production_OutPut = producedUnits;

                for (int i = 1; i < readsAll.Count; i++)
                {
                    StateTime state = new StateTime
                    {
                        State = readsAll[i].State,Fault = readsAll[i].Fault,
                        StartTime = readsAll[i-1].TimeStamp,
                        EndTime = readsAll[i ].TimeStamp,
                    };
                    if (readsAll[i].State != readsAll[i - 1].State)
                    {
                        upTime.Add(readsAll[i].TimeStamp);
                    }
                    machine.StateTimes.Add(state);
                }
                decimal value = 0;
                for (int i = 1; i < upTime.Count; i++)
                {

                    value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                }
                machine.UpTime = value;
                var upTimeReads = upTime.ToList();
                decimal maxSpeed = 0;
                var minuteCount = (blowReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                for (int i = 0; i < minuteCount; i += 60)
                {
                    OEEDTO perValue = new OEEDTO { };
                    OEEDTO avaValue = new OEEDTO { };
                    var currentTimeFrom = blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    var currentTimeTo = blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                    if (currentTimeTo >= DateTime.Now)
                    {
                        currentTimeFrom = blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                        currentTimeTo = blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                    }
                    var sC1 = blowReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Count_Out;
                    var sC2 = blowReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Count_Out;

                    var avaCount = blowReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                    var avaCount2 = blowReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                    var sC = sC1 - sC2;
                    machine.Throughput = sC;
                    if (sC > maxSpeed)
                    {
                        maxSpeed = (decimal)sC;
                        machine.Max_Production_Capacity = maxSpeed;
                    }
                    if (maxSpeed == 0)
                    {
                        maxSpeed = 1;
                    }
                    machine.Performance = (decimal)sC / (decimal)maxSpeed;


                }
                machine.Quality = 1;
                machine.Utiliztion = (decimal)712 / (decimal)720;
                machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                machine.TEEP = machine.Utiliztion * machine.OEE;
                //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                var time = (DateTime.Now - from).TotalHours;
                machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;

            }
            return Ok(machine);
        }

        [HttpGet("GetLineKPIs/{id}")]
        public ActionResult GetLineKPIs(int id)
        {
            var From = (DateTime.Today.AddHours(8));
            var To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8));
                To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(20) && DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(8));
                To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4));
                To = (DateTime.Today.AddHours(7)).AddMinutes(45);
            }
            var from = From;
            var to = To;
            int Count = 0;
            List<MachineKPIs> machines = new List<MachineKPIs>();
            var loads = _mContext.Loads.Where(r => r.ProductionLineId == id && r.PlcCode != null).ToList();
            foreach (var MachineId in loads)
            {
                MachineKPIs machine = new MachineKPIs { from = from, to = to, MachineId = MachineId.PlcCode, MachineName = MachineId.Name };
                var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Co2_Consumption >= 0 && r.Co2_Consumption < 100 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);

                var mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (mixerReads2.Any())
                {
                    from = mixerReads2.Select(r => r.TimeStamp).LastOrDefault();
                    mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= mixerReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                }
                var fillReads2 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count == 0 && r.Count <= 1000 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count >= 0 && r.Speed >= 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (fillReads2.Any())
                {
                    from = fillReads2.Select(r => r.TimeStamp).LastOrDefault();
                    fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count >= 0 && r.TimeStamp >= fillReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();

                }

                var dePallReads2 = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (dePallReads2.Any())
                {
                    from = dePallReads2.Select(r => r.TimeStamp).LastOrDefault();
                    dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count >= 0 && r.TimeStamp >= dePallReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
                }

                var labelReads2 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (labelReads2.Any())
                {
                    from = labelReads2.Select(r => r.TimeStamp).LastOrDefault();
                    labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Counts >= 0 && r.TimeStamp >= labelReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
                }

                var cartReads2 = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (cartReads2.Any())
                {
                    from = cartReads2.Select(r => r.TimeStamp).LastOrDefault();
                    cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Counts >= 0 && r.TimeStamp >= cartReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
                }

                var blowReads2 = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count_In == 0 && r.Count_In <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count_In >= 0 && r.Count_Out > 0 && r.Production_Hours > 0 && r.Speed >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (blowReads2.Any())
                {
                    from = blowReads2.Select(r => r.TimeStamp).LastOrDefault();
                    blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Count_In >= 0 && r.TimeStamp >= blowReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp <= to).ToList();
                }
                var pallReads2 = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Pallet_No >= 0 && r.Pallet_No <= 200 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Pallet_No >= 0 && r.Packet_No > 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (pallReads2.Any())
                {
                    pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == MachineId.PlcCode && r.Pallet_No >= 0 && r.TimeStamp >= pallReads2.Select(r => r.TimeStamp).LastOrDefault() && r.TimeStamp<=to).ToList();
                    from = pallReads2.Select(r => r.TimeStamp).LastOrDefault();
                }
                if (pallReads.Any())
                {
                    /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                    {
                        if(read.Pallet_No == 0 || read.Pallet_No )
                    }*/
                    machine.MachineType = "Palletizer";
                    var reads = pallReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                    var readsAll = pallReads.OrderBy(r => r.Id).ToList();
                    decimal timeChange = 0;
                    List<DateTime> dates = new List<DateTime>();
                    List<DateTime> upTime = new List<DateTime>();

                    for (int i = 1; i < reads.Count; i++)
                    {
                        var count = reads[i].Pallet_No - reads[i - 1].Pallet_No;
                        if (count == 0)
                        {
                            dates.Add(reads[i].TimeStamp);
                        }
                    }
                    machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                    var totalReads = pallReads.Count;
                    var stateOneReads = pallReads.Where(r => r.State == 1).ToList().Count;
                    var stateZeroReads = pallReads.Where(r => r.State == 0).ToList().Count;
                    var faultReadsCount = pallReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                    var faultReads = pallReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                    var Counter = 0;
                    for (int i = 1; i < faultReads.Count; i++)
                    {
                        if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                        {

                            Count++;
                            if (Count >= 2)
                            {
                                Count = 0;
                                Counter++;
                            }

                        }
                    }
                    faultReadsCount = faultReadsCount - Counter;
                    if (faultReadsCount == 0)
                    {
                        faultReadsCount = 1;
                    }
                    machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                    var productionHours = pallReads.FirstOrDefault().Production_Hours - pallReads.LastOrDefault().Production_Hours;
                    var producedUnits = pallReads.FirstOrDefault().Pallet_No - pallReads.LastOrDefault().Pallet_No;
                    if(producedUnits == 0)
                    {
                        producedUnits = 1;
                    }
                    machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                    machine.ProductionHours = productionHours;
                    machine.Production_OutPut = producedUnits;
                    for (int i = 1; i < readsAll.Count; i++)
                    {

                        StateTime state = new StateTime
                        {
                            State = readsAll[i].State,Fault = readsAll[i].Fault,
                            StartTime = readsAll[i-1].TimeStamp,
                            EndTime = readsAll[i ].TimeStamp,
                        };
                        if (readsAll[i].State != readsAll[i - 1].State)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }
                        machine.StateTimes.Add(state);

                    }
                    decimal value = 0;
                    for (int i = 1; i < upTime.Count; i++)
                    {

                        value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                    }
                    machine.UpTime = value;
                    var upTimeReads = upTime.ToList();
                    var maxSpeed = 0;
                    var minuteCount = (pallReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = pallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }
                        var sC1 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Pallet_No;
                        var sC2 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Pallet_No;

                        var avaCount = pallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = pallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                        var sC = sC1 - sC2;
                        machine.Throughput = sC;
                        if (sC > maxSpeed)
                        {
                            maxSpeed = sC;
                            machine.Max_Production_Capacity = maxSpeed;
                        }
                        if (maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        machine.Performance = (decimal)sC / (decimal)maxSpeed;


                    }
                    machine.Quality = 1;
                    machine.Utiliztion = (decimal)712 / (decimal)720;
                    machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                    machine.TEEP = machine.Utiliztion * machine.OEE;
                    //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                    var time = (DateTime.Now - from).TotalHours;
                    machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                    machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                    machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;

                    
                    machines.Add(machine);


                }
                if (mixerReads.Any())
                {
                    /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                    {
                        if(read.Pallet_No == 0 || read.Pallet_No )
                    }*/
                    machine.MachineType = "Mixer";
                    var reads = mixerReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                    var readsAll = mixerReads.OrderBy(r => r.Id).ToList();
                    decimal timeChange = 0;
                    List<DateTime> dates = new List<DateTime>();
                    List<DateTime> upTime = new List<DateTime>();

                    for (int i = 1; i < reads.Count; i++)
                    {
                        var count = reads[i].Product_Consumption - reads[i - 1].Product_Consumption;
                        if (count == 0)
                        {
                            dates.Add(reads[i].TimeStamp);
                        }
                    }
                    machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                    var totalReads = mixerReads.Count;
                    var stateOneReads = mixerReads.Where(r => r.State == 1).ToList().Count;
                    var stateZeroReads = mixerReads.Where(r => r.State == 0).ToList().Count;
                    var faultReadsCount = mixerReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                    var faultReads = mixerReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                    var Counter = 0;
                    for (int i = 1; i < faultReads.Count; i++)
                    {
                        if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                        {

                            Count++;
                            if (Count >= 2)
                            {
                                Count = 0;
                                Counter++;
                            }

                        }
                    }
                    faultReadsCount = faultReadsCount - Counter;
                    if (faultReadsCount == 0)
                    {
                        faultReadsCount = 1;
                    }
                    machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                    var productionHours = mixerReads.FirstOrDefault().Production_Hours - mixerReads.LastOrDefault().Production_Hours;
                    var producedUnits = mixerReads.FirstOrDefault().Product_Consumption - mixerReads.LastOrDefault().Product_Consumption;
                    if (producedUnits == 0)
                    {
                        producedUnits = 1;
                    }
                    machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                    machine.ProductionHours = productionHours;
                    machine.Production_OutPut = producedUnits;

                    for (int i = 1; i < readsAll.Count; i++)
                    {
                        StateTime state = new StateTime
                        {
                            State = readsAll[i].State,Fault = readsAll[i].Fault,
                            StartTime = readsAll[i-1].TimeStamp,
                            EndTime = readsAll[i ].TimeStamp,
                        };
                        if (readsAll[i].State != readsAll[i - 1].State)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }

                        else if (readsAll[i].State == 1)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }
                        machine.StateTimes.Add(state);
                    }
                    decimal value = 0;
                    for (int i = 1; i < upTime.Count; i++)
                    {

                        value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                    }
                    machine.UpTime = value;
                    var upTimeReads = upTime.ToList();
                    decimal maxSpeed = 0;
                    var minuteCount = (mixerReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = mixerReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }
                        var sC1 = mixerReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Product_Consumption;
                        var sC2 = mixerReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Product_Consumption;

                        var avaCount = mixerReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = mixerReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                        var sC = sC1 - sC2;
                        machine.Throughput = sC;
                        if (sC > maxSpeed)
                        {
                            maxSpeed = (decimal)sC;
                            machine.Max_Production_Capacity = maxSpeed;
                        }
                        if (maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        machine.Performance = (decimal)sC / (decimal)maxSpeed;


                    }
                    machine.Quality = 1;
                    machine.Utiliztion = (decimal)712 / (decimal)720;
                    machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                    machine.TEEP = machine.Utiliztion * machine.OEE;
                    //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                    var time = (DateTime.Now - from).TotalHours;
                    machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                    machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                    machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
                    machines.Add(machine);


                }
                if (fillReads.Any())
                {
                    /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                    {
                        if(read.Pallet_No == 0 || read.Pallet_No )
                    }*/
                    machine.MachineType = "Filler";
                    var reads = fillReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                    var readsAll = fillReads.OrderBy(r => r.Id).ToList();
                    decimal timeChange = 0;
                    List<DateTime> dates = new List<DateTime>();
                    List<DateTime> upTime = new List<DateTime>();

                    for (int i = 1; i < reads.Count; i++)
                    {
                        var count = reads[i].Count - reads[i - 1].Count;
                        if (count == 0)
                        {
                            dates.Add(reads[i].TimeStamp);
                        }
                    }
                    machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                    var totalReads = fillReads.Count;
                    var stateOneReads = fillReads.Where(r => r.State == 1).ToList().Count;
                    var stateZeroReads = fillReads.Where(r => r.State == 0).ToList().Count;
                    var faultReadsCount = fillReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                    var faultReads = fillReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                    var Counter = 0;
                    for (int i = 1; i < faultReads.Count; i++)
                    {
                        if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                        {

                            Count++;
                            if (Count >= 2)
                            {
                                Count = 0;
                                Counter++;
                            }

                        }
                    }
                    faultReadsCount = faultReadsCount - Counter;
                    if (faultReadsCount == 0)
                    {
                        faultReadsCount = 1;
                    }
                    machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                    var productionHours = fillReads.FirstOrDefault().Production_Hours - fillReads.LastOrDefault().Production_Hours;
                    var producedUnits = fillReads.FirstOrDefault().Count - fillReads.LastOrDefault().Count;
                    machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                    machine.ProductionHours = productionHours;
                    machine.Production_OutPut = producedUnits;

                    for (int i = 1; i < readsAll.Count; i++)
                    {
                        StateTime state = new StateTime
                        {
                            State = readsAll[i].State,Fault = readsAll[i].Fault,
                            StartTime = readsAll[i-1].TimeStamp,
                            EndTime = readsAll[i ].TimeStamp,
                        };
                        if (readsAll[i].State != readsAll[i - 1].State)
                        {
                            
                            upTime.Add(readsAll[i].TimeStamp);
                        }
                        else if (readsAll[i].State == 1 && readsAll[i-1].State ==0)
                        {
                            
                            upTime.Add(readsAll[i].TimeStamp);
                        }
                        else if (readsAll[i].State == 1 && readsAll[i - 1].State == 1)
                        {

                            upTime.Add(readsAll[i].TimeStamp);
                        }


                        machine.StateTimes.Add(state);
                    }
                    decimal value = 0;
                    for (int i = 1; i < upTime.Count; i++)
                    {

                        value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                    }
                    machine.UpTime = value;
                    var upTimeReads = upTime.ToList();
                    decimal maxSpeed = 0;
                    var minuteCount = (fillReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = fillReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }
                        var sC1 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Count;
                        var sC2 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Count;
                        var pH1 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Production_Hours;
                        var pH2 = fillReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Production_Hours;

                        var pH = pH1 - pH2;
                        var avaCount = fillReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = fillReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                        var sC = sC1-sC2;
                        LineKPIData lineData = new LineKPIData { TimeStamp = currentTimeFrom };

                        machine.Throughput = sC;
                        if (sC > maxSpeed)
                        {
                            maxSpeed = (decimal)sC;
                            machine.Max_Production_Capacity = maxSpeed;
                        }
                        if (maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        if (sC == 0)
                        {
                            sC = 1;
                        }
                        machine.Performance = (decimal)sC / (decimal)maxSpeed;
                        lineData.Throughput = sC;
                        lineData.ProductionOutPut = sC1;
                        lineData.CycleTime = (decimal)pH / (decimal)sC;
                        machine.LineData.Add(lineData);

                    }
                    machine.Quality = 1;
                    machine.Utiliztion = (decimal)712 / (decimal)720;
                    machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                    machine.TEEP = machine.Utiliztion * machine.OEE;
                    //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                    var time = (DateTime.Now - from).TotalHours;
                    machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                    machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                    machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
                    machines.Add(machine);
                    
                }
                if (dePallReads.Any())
                {
                    /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                    {
                        if(read.Pallet_No == 0 || read.Pallet_No )
                    }*/
                    machine.MachineType = "DPalletizer";
                    var reads = dePallReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                    var readsAll = dePallReads.OrderBy(r => r.Id).ToList();
                    decimal timeChange = 0;
                    List<DateTime> dates = new List<DateTime>();
                    List<DateTime> upTime = new List<DateTime>();

                    for (int i = 1; i < reads.Count; i++)
                    {
                        var count = reads[i].Count - reads[i - 1].Count;
                        if (count == 0)
                        {
                            dates.Add(reads[i].TimeStamp);
                        }
                    }
                    machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                    var totalReads = dePallReads.Count;
                    var stateOneReads = dePallReads.Where(r => r.State == 1).ToList().Count;
                    var stateZeroReads = dePallReads.Where(r => r.State == 0).ToList().Count;
                    var faultReadsCount = dePallReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                    var faultReads = dePallReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                    var Counter = 0;
                    for (int i = 1; i < faultReads.Count; i++)
                    {
                        if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                        {

                            Count++;
                            if (Count >= 2)
                            {
                                Count = 0;
                                Counter++;
                            }

                        }
                    }
                    faultReadsCount = faultReadsCount - Counter;
                    if (faultReadsCount == 0)
                    {
                        faultReadsCount = 1;
                    }
                    machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                    var productionHours = dePallReads.FirstOrDefault().Hours - dePallReads.LastOrDefault().Hours;
                    var producedUnits = dePallReads.FirstOrDefault().Count - dePallReads.LastOrDefault().Count;
                    machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                    machine.ProductionHours = productionHours;
                    machine.Production_OutPut = producedUnits;

                    for (int i = 1; i < readsAll.Count; i++)
                    {
                        StateTime state = new StateTime
                        {
                            State = readsAll[i].State,Fault = readsAll[i].Fault,
                            StartTime = readsAll[i-1].TimeStamp,
                            EndTime = readsAll[i ].TimeStamp,
                        };
                        if (readsAll[i].State != readsAll[i - 1].State)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }

                        else if (readsAll[i].State == 1)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }
                        machine.StateTimes.Add(state);
                    }
                    decimal value = 0;
                    for (int i = 1; i < upTime.Count; i++)
                    {

                        value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                    }
                    machine.UpTime = value;
                    var upTimeReads = upTime.ToList();
                    decimal maxSpeed = 0;
                    var minuteCount = (dePallReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        LineKPIData data = new LineKPIData { };
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = dePallReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }

                        var sC1 = dePallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Count;
                        var sC2 = dePallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Count;

                        

                        var avaCount = dePallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = dePallReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                        var sC = sC1-sC2;
                        machine.Throughput = sC;
                        if (sC > maxSpeed)
                        {
                            maxSpeed = (decimal)sC;
                            machine.Max_Production_Capacity = maxSpeed;
                        }
                        if (maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        data.Performance = (decimal)sC / (decimal)maxSpeed;
                        data.Availability = (decimal)avaCount / (decimal)avaCount2;
                        data.Quality = 1;
                        data.OEE = data.Performance * data.Availability * data.Quality;
                        machine.LineData.Add(data);


                    }
                    var lineCount = machine.LineData.Count;
                    machine.LineData = machine.LineData.ToList().Take(lineCount - 1).ToList();
                    machine.Performance = (decimal)machine.LineData.Select(r => r.Performance).Average();
                    machine.Availability = (decimal)machine.LineData.Select(r => r.Availability).Average();
                    
                    machine.Quality = 1;
                    machine.Utiliztion = (decimal)712 / (decimal)720;
                    machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                    machine.TEEP = machine.Utiliztion * machine.OEE;
                    //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                    var time = (DateTime.Now - from).TotalHours;
                    machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                    machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;

                    machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
                    machines.Add(machine);
                }
                if (labelReads.Any())
                {
                    /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                    {
                        if(read.Pallet_No == 0 || read.Pallet_No )
                    }*/
                    machine.MachineType = "Label";
                    var reads = labelReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                    var readsAll = labelReads.OrderBy(r => r.Id).ToList();
                    decimal timeChange = 0;
                    List<DateTime> dates = new List<DateTime>();
                    List<DateTime> upTime = new List<DateTime>();

                    for (int i = 1; i < reads.Count; i++)
                    {
                        var count = reads[i].Counts - reads[i - 1].Counts;
                        if (count == 0)
                        {
                            dates.Add(reads[i].TimeStamp);
                        }
                    }
                    machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                    var totalReads = labelReads.Count;
                    var stateOneReads = labelReads.Where(r => r.State == 1).ToList().Count;
                    var stateZeroReads = labelReads.Where(r => r.State == 0).ToList().Count;
                    var faultReadsCount = labelReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                    var faultReads = labelReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                    var Counter = 0;
                    for (int i = 1; i < faultReads.Count; i++)
                    {
                        if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                        {

                            Count++;
                            if (Count >= 2)
                            {
                                Count = 0;
                                Counter++;
                            }

                        }
                    }
                    faultReadsCount = faultReadsCount - Counter;
                    if (faultReadsCount == 0)
                    {
                        faultReadsCount = 1;
                    }
                    machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                    var productionHours = labelReads.FirstOrDefault().Hours - labelReads.LastOrDefault().Hours;
                    var producedUnits = labelReads.FirstOrDefault().Counts - labelReads.LastOrDefault().Counts;
                    if(producedUnits == 0)
                    {
                        producedUnits = 1;
                    }
                    machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                    machine.ProductionHours = productionHours;
                    machine.Production_OutPut = producedUnits;

                    for (int i = 1; i < readsAll.Count; i++)
                    {
                        StateTime state = new StateTime
                        {
                            State = readsAll[i].State,Fault = readsAll[i].Fault,
                            StartTime = readsAll[i-1].TimeStamp,
                            EndTime = readsAll[i ].TimeStamp,
                        };
                        if (readsAll[i].State != readsAll[i - 1].State)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }

                        else if (readsAll[i].State == 1)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }
                        machine.StateTimes.Add(state);
                    }
                    decimal value = 0;
                    for (int i = 1; i < upTime.Count; i++)
                    {

                        value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                    }
                    machine.UpTime = value;
                    var upTimeReads = upTime.ToList();
                    decimal maxSpeed = 0;
                    var minuteCount = (labelReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        LineKPIData data = new LineKPIData { };
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = labelReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }
                        var sC1 = labelReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Counts;
                        var sC2 = labelReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Counts;

                        var avaCount = labelReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = labelReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                        var sC = sC1 - sC2;
                        machine.Throughput = sC;
                        if (sC > maxSpeed)
                        {
                            maxSpeed = (decimal)sC;
                            machine.Max_Production_Capacity = maxSpeed;
                        }
                        if (maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        data.Performance = (decimal)sC / (decimal)maxSpeed;
                        data.Availability = (decimal)avaCount / (decimal)avaCount2;
                        data.Quality = 1;
                        data.OEE = data.Performance * data.Availability * data.Quality;
                        machine.LineData.Add(data);

                    }
                    var lineCount = machine.LineData.Count;
                    machine.LineData = machine.LineData.ToList().Take(lineCount - 1).ToList();
                    machine.Performance = (decimal)machine.LineData.Select(r => r.Performance).Average();
                    machine.Availability = (decimal)machine.LineData.Select(r => r.Availability).Average();
                    machine.Quality = 1;
                    machine.Utiliztion = (decimal)712 / (decimal)720;
                    machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                    machine.TEEP = machine.Utiliztion * machine.OEE;
                    //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                    var time = (DateTime.Now - from).TotalHours;
                    machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                    machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                    machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
                    machines.Add(machine);
                }
                if (cartReads.Any())
                {
                    /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                    {
                        if(read.Pallet_No == 0 || read.Pallet_No )
                    }*/
                    machine.MachineType = "Cart";
                    var reads = cartReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                    var readsAll = cartReads.OrderBy(r => r.Id).ToList();
                    decimal timeChange = 0;
                    List<DateTime> dates = new List<DateTime>();
                    List<DateTime> upTime = new List<DateTime>();

                    for (int i = 1; i < reads.Count; i++)
                    {
                        var count = reads[i].Counts - reads[i - 1].Counts;
                        if (count == 0)
                        {
                            dates.Add(reads[i].TimeStamp);
                        }
                    }
                    machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                    var totalReads = cartReads.Count;
                    var stateOneReads = cartReads.Where(r => r.State == 1).ToList().Count;
                    var stateZeroReads = cartReads.Where(r => r.State == 0).ToList().Count;
                    var faultReadsCount = cartReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                    var faultReads = cartReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                    var Counter = 0;
                    for (int i = 1; i < faultReads.Count; i++)
                    {
                        if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                        {

                            Count++;
                            if (Count >= 2)
                            {
                                Count = 0;
                                Counter++;
                            }

                        }
                    }
                    faultReadsCount = faultReadsCount - Counter;
                    if (faultReadsCount == 0)
                    {
                        faultReadsCount = 1;
                    }
                    machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                    var productionHours = cartReads.FirstOrDefault().Hours - cartReads.LastOrDefault().Hours;
                    var producedUnits = cartReads.FirstOrDefault().Counts - cartReads.LastOrDefault().Counts;
                    if (producedUnits == 0)
                    {
                        producedUnits = 1;
                    }
                    machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                    machine.ProductionHours = productionHours;
                    machine.Production_OutPut = producedUnits;

                    for (int i = 1; i < readsAll.Count; i++)
                    {
                        StateTime state = new StateTime
                        {
                            State = readsAll[i].State,Fault = readsAll[i].Fault,
                            StartTime = readsAll[i-1].TimeStamp,
                            EndTime = readsAll[i ].TimeStamp,
                        };
                        if (readsAll[i].State != readsAll[i - 1].State)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }

                        else if (readsAll[i].State == 1)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }
                        machine.StateTimes.Add(state);
                    }
                    decimal value = 0;
                    for (int i = 1; i < upTime.Count; i++)
                    {

                        value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                    }
                    machine.UpTime = value;
                    var upTimeReads = upTime.ToList();
                    decimal maxSpeed = 0;
                    var minuteCount = (cartReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = cartReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }
                        var sC1 = cartReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Counts;
                        var sC2 = cartReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Counts;

                        var avaCount = cartReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = cartReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                        var sC = sC1-sC2;
                        machine.Throughput = sC;
                        if (sC > maxSpeed)
                        {
                            maxSpeed = (decimal)sC;
                            machine.Max_Production_Capacity = maxSpeed;
                        }
                        if (maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        machine.Performance = (decimal)sC / (decimal)maxSpeed;


                    }
                    machine.Quality = 1;
                    machine.Utiliztion = (decimal)712 / (decimal)720;
                    machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                    machine.TEEP = machine.Utiliztion * machine.OEE;
                    //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                    var time = (DateTime.Now - from).TotalHours;
                    machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                    machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                    machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
                    machines.Add(machine);

                }
                if (blowReads.Any())
                {
                    /*foreach (var read in pallReads.OrderBy(r=>r.Id))
                    {
                        if(read.Pallet_No == 0 || read.Pallet_No )
                    }*/
                    machine.MachineType = "Blow";
                    var reads = blowReads.OrderBy(r => r.Id).Where(r => r.TimeStamp >= from && r.TimeStamp < from.AddMinutes(10)).ToList();
                    var readsAll = blowReads.OrderBy(r => r.Id).ToList();
                    decimal timeChange = 0;
                    List<DateTime> dates = new List<DateTime>();
                    List<DateTime> upTime = new List<DateTime>();

                    for (int i = 1; i < reads.Count; i++)
                    {
                        var count = reads[i].Count_Out - reads[i - 1].Count_Out;
                        if (count == 0)
                        {
                            dates.Add(reads[i].TimeStamp);
                        }
                    }
                    machine.ChangeOverTime = (decimal)(dates.LastOrDefault() - dates.FirstOrDefault()).TotalMinutes;
                    var totalReads = blowReads.Count;
                    var stateOneReads = blowReads.Where(r => r.State == 1).ToList().Count;
                    var stateZeroReads = blowReads.Where(r => r.State == 0).ToList().Count;
                    var faultReadsCount = blowReads.Where(r => r.Fault == 1 && r.State == 0).ToList().Count;
                    var faultReads = blowReads.Where(r => r.Fault == 1 && r.State == 0).ToList();
                    var Counter = 0;
                    for (int i = 1; i < faultReads.Count; i++)
                    {
                        if ((faultReads[i - 1].TimeStamp - faultReads[i].TimeStamp).TotalSeconds < 30)
                        {

                            Count++;
                            if (Count >= 2)
                            {
                                Count = 0;
                                Counter++;
                            }

                        }
                    }
                    faultReadsCount = faultReadsCount - Counter;
                    if (faultReadsCount == 0)
                    {
                        faultReadsCount = 1;
                    }
                    machine.Availability = (decimal)stateOneReads / (decimal)totalReads;

                    var productionHours = blowReads.FirstOrDefault().Production_Hours - blowReads.LastOrDefault().Production_Hours;
                    var producedUnits = blowReads.FirstOrDefault().Count_Out - blowReads.LastOrDefault().Count_Out;
                    if (producedUnits == 0)
                    {
                        producedUnits = 1;
                    }
                    machine.CycleTime = (decimal)productionHours / (decimal)producedUnits;
                    machine.ProductionHours = productionHours;
                    machine.Production_OutPut = producedUnits;

                    for (int i = 1; i < readsAll.Count; i++)
                    {
                        StateTime state = new StateTime
                        {
                            State = readsAll[i].State,Fault = readsAll[i].Fault,
                            StartTime = readsAll[i-1].TimeStamp,
                            EndTime = readsAll[i ].TimeStamp,
                        };
                        if (readsAll[i].State != readsAll[i - 1].State)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }

                        else if (readsAll[i].State == 1)
                        {
                            upTime.Add(readsAll[i].TimeStamp);
                        }
                        machine.StateTimes.Add(state);
                    }
                    decimal value = 0;
                    for (int i = 1; i < upTime.Count; i++)
                    {

                        value = (decimal)(value + (decimal)(upTime[i] - upTime[i - 1]).TotalHours);
                    }
                    machine.UpTime = value;
                    var upTimeReads = upTime.ToList();
                    decimal maxSpeed = 0;
                    var minuteCount = (blowReads.OrderByDescending(r => r.Id).FirstOrDefault().TimeStamp - blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        OEEDTO perValue = new OEEDTO { };
                        OEEDTO avaValue = new OEEDTO { };
                        var currentTimeFrom = blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        var currentTimeTo = blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i - 60);
                            currentTimeTo = blowReads.OrderByDescending(r => r.Id).LastOrDefault().TimeStamp.AddMinutes(i);
                        }
                        var sC1 = blowReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Count_Out;
                        var sC2 = blowReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Count_Out;

                        var avaCount = blowReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo && e.State == 1).ToList().Count;
                        var avaCount2 = blowReads.Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).ToList().Count;
                        var sC = sC1-sC2;
                        machine.Throughput = sC;
                        if (sC > maxSpeed)
                        {
                            maxSpeed = (decimal)sC;
                            machine.Max_Production_Capacity = maxSpeed;
                        }
                        if (maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        machine.Performance = (decimal)sC / (decimal)maxSpeed;


                    }
                    machine.Quality = 1;
                    machine.Utiliztion = (decimal)712 / (decimal)720;
                    machine.OEE = machine.Availability * machine.Performance * machine.Quality;

                    machine.TEEP = machine.Utiliztion * machine.OEE;
                    //machine.UpTime = (decimal)(stateOneReads * 20)/(decimal)3600;
                    var time = (DateTime.Now - from).TotalHours;
                    machine.TotalDownTime = (decimal)time - (decimal)machine.UpTime;

                    machine.MTBF = (decimal)machine.UpTime / (decimal)faultReadsCount;
                    machine.OverAllUpTime = (decimal)machine.UpTime / (decimal)time;
                    machines.Add(machine);

                }
            }
            var avgOEE = machines.Select(r => r.OEE).Average();
            var avgMTBF = machines.Select(r => r.MTBF).Average();
            var avgUpTime = machines.Select(r => r.Availability).Average();
            var oee = machines.Where(r=>r.MachineType == "Filler").Select(r=>r.OEE).FirstOrDefault();
            var ava = machines.Where(r=>r.MachineType == "Filler").Select(r=>r.Availability).FirstOrDefault();
            var per = machines.Where(r=>r.MachineType == "Filler").Select(r=>r.Performance).FirstOrDefault();
            var qua = machines.Where(r=>r.MachineType == "Filler").Select(r=>r.Quality).FirstOrDefault();
            var teep = machines.Where(r => r.MachineType == "Filler").Select(r => r.TEEP).FirstOrDefault();
            var throughPut = machines.Where(r => r.MachineType == "Filler").Select(r => r.Throughput).FirstOrDefault();
            return Ok(new { machines, avgOEE, avgMTBF, avgUpTime, oee, ava, per, qua, teep,throughPut});
                                                                 
        }                                                        
                                                                
        [HttpGet("LinesDetails/{time}")]
        public ActionResult LinesDetails(int time)
        {
            var From = (DateTime.Today.AddHours(8)).AddMinutes(20);
            var To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8)).AddMinutes(20);
                To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(20) && DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(20)).AddMinutes(10);
                To = ((DateTime.Today.AddDays(1)).AddHours(7)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4)).AddMinutes(10);
                To = (DateTime.Today.AddHours(7)).AddMinutes(50);
            }
            if (time == 1)
            {
                var from =From;
                var to = To;
                var lines = _mContext.ProductionLines.Take(5).ToList();
                
                List<LineDetailsDTO> linesDetaila = new List<LineDetailsDTO>();
                foreach (var line in lines)
                {
                    decimal mixAva = 0;
                    decimal pallAva = 0;
                    decimal fillAva = 0;
                    decimal lablAva = 0;

                    LineDetailsDTO lineDetails = new LineDetailsDTO
                    {
                        LineId = line.Id,
                        From = from,
                        To = to,
                    };
                    var energyLoads = _mContext.Loads.Where(r => r.EnergyCode != null && r.ProductionLineId == line.Id).Select(r => new { r.Id, r.EnergyCode, r.ProductionLineId, r.FactoryId, r.Name }).ToList();
                    var energyLoadsCodes = _mContext.Loads.Where(r => r.EnergyCode != null && r.ProductionLineId == line.Id).Select(r => r.EnergyCode).ToList();

                    var energyReads = _eContext.IotTransactions.OrderByDescending(r => r.Id).Where(r => energyLoadsCodes.Contains(r.SourceId) && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    foreach (var energyRead in energyLoads)
                    {
                        var energySource1 = energyReads.Where(r => r.SourceId == energyRead.EnergyCode).FirstOrDefault();
                        var energySource2 = energyReads.Where(r => r.SourceId == energyRead.EnergyCode).LastOrDefault();
                        var totalEnergy = (energySource1.Energy1 + energySource1.Energy2 + energySource1.Energy3) - (energySource2.Energy1 + energySource2.Energy2 + energySource2.Energy3);
                        lineDetails.EnergyConsumption = totalEnergy;
                    }
                    lineDetails.PF = energyReads.Select(r => (r.PF1 + r.PF2 + r.PF3) / 3).Average();

                    var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Co2_Consumption >= 0 && r.Co2_Consumption < 100 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);

                    var mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (mixerReads2.Any())
                    {
                        mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= mixerReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }


                    var pallReads2 = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Pallet_No >= 0 && r.Pallet_No <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Pallet_No >= 0 && r.Packet_No > 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (pallReads2.Any())
                    {
                        pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Pallet_No >= 0 && r.TimeStamp >= pallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var fillReads2 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count >= 0 && r.Speed >= 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (fillReads2.Any())
                    {
                        fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count >= 0 && r.TimeStamp >= fillReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();

                    }

                    var dePallReads2 = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (dePallReads2.Any())
                    {
                        dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count >= 0 && r.TimeStamp >= dePallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var labelReads2 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (labelReads2.Any())
                    {
                        labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Counts >= 0 && r.TimeStamp >= labelReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var blowReads2 = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count_In == 0 && r.Count_In <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count_In >= 0 && r.Count_Out > 0 && r.Production_Hours > 0 && r.Speed >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (blowReads2.Any())
                    {
                        blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count_In >= 0 && r.TimeStamp >= blowReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }


                    if (mixerReads.Any())
                    {
                        var co2C1 = mixerReads.Select(r => r.Co2_Consumption).FirstOrDefault();
                        var co2C2 = mixerReads.Select(r => r.Co2_Consumption).LastOrDefault();

                        var sC1 = mixerReads.Select(r => r.Syrup_Consumption).FirstOrDefault();
                        var sC2 = mixerReads.Select(r => r.Syrup_Consumption).LastOrDefault();

                        var wC1 = mixerReads.Select(r => r.Water_Consumption).FirstOrDefault();
                        var wC2 = mixerReads.Select(r => r.Water_Consumption).LastOrDefault();

                        lineDetails.CO2 = (decimal)co2C1 - (decimal)co2C2;
                        lineDetails.WC = (decimal)wC1 - (decimal)wC2;
                        lineDetails.SC = (decimal)sC1 - (decimal)sC2;

                        var stateReadsCount = mixerReads.Select(r => r.State).ToList().Count;
                        var onReads = mixerReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        mixAva = (decimal)onReads / (decimal)stateReadsCount;

                    }
                    else
                    {
                        lineDetails.CO2 = 0;
                        lineDetails.WC = 0;
                        lineDetails.SC = 0;
                    }
                    if (pallReads.Any())
                    {
                        var pallC1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                        var pallC2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();

                        var packC1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                        var packC2 = pallReads.Select(r => r.Packet_No).LastOrDefault();



                        lineDetails.PackConsumption = (decimal)pallC1 - (decimal)pallC2;
                        lineDetails.PalletConsumption = (decimal)packC1 - (decimal)packC2;
                        var maxSpeed = 0;

                        var minuteCount = (DateTime.Now - from).TotalMinutes;
                        for (int i = 0; i < minuteCount; i += 60)
                        {
                            var currentTimeFrom = from.AddMinutes(i);
                            var currentTimeTo = from.AddMinutes(i + 60);
                            if (currentTimeTo >= DateTime.Now)
                            {
                                currentTimeFrom = from.AddMinutes(i - 60);
                                currentTimeTo = from.AddMinutes(i);
                            }
                            var sC1 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Pallet_No;
                            var sC2 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Pallet_No;
                            var sC = sC1 - sC2;
                            if (sC > maxSpeed)
                            {
                                maxSpeed = sC;
                            }
                            lineDetails.Speed = sC;
                            if (maxSpeed == 0)
                            {
                                maxSpeed = 1;
                            }
                            lineDetails.Performance = (decimal)sC / (decimal)maxSpeed;

                        }

                        var stateReadsCount = pallReads.Select(r => r.State).ToList().Count;
                        var onReads = pallReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        pallAva = (decimal)onReads / (decimal)stateReadsCount;

                        var lastFault = pallReads.OrderByDescending(r=>r.Id).Where(r=>r.Fault == 1).Select(r => new { r.Fault, r.TimeStamp }).FirstOrDefault();

                        var faultReadsCount = pallReads.Select(r => r.Fault).ToList().Count;
                        var faultReads = pallReads.Where(r => r.Fault == 1).Select(r => r.Fault).ToList().Count;
                        var faultPercen = (decimal)faultReads / (decimal)faultReadsCount;
                        lineDetails.FaultPerc = faultPercen;
                        if(lastFault != null)
                        {
                            lineDetails.Fault = lastFault.Fault;
                            lineDetails.TimeStamp = lastFault.TimeStamp;
                        }
                        else
                        {
                            lineDetails.Fault = 0;
                            lineDetails.TimeStamp = DateTime.Now;
                        }
                        

                    }
                    else
                    {
                        lineDetails.PackConsumption = 0;
                        lineDetails.PalletConsumption = 0;
                    }
                    if (fillReads.Any())
                    {
                        var bottleC1 = fillReads.Select(r => r.Count).FirstOrDefault();
                        var bottleC2 = fillReads.Select(r => r.Count).LastOrDefault();

                        var pHC1 = fillReads.Select(r => r.Production_Hours).FirstOrDefault();
                        var pHC2 = fillReads.Select(r => r.Production_Hours).LastOrDefault();

                        var sC1 = fillReads.Select(r => r.Speed).Average();
                        var msC1 = fillReads.Select(r => r.Speed).Max();


                        lineDetails.BottleConsumption = (decimal)bottleC1 - (decimal)bottleC2;
                        lineDetails.ProductionTime = ((decimal)pHC1 - (decimal)pHC2) / (decimal)12;
                        lineDetails.ProductionHours = ((decimal)pHC1 - (decimal)pHC2);
                        //lineDetails.Performance = sC1 / msC1;
                        var stateReadsCount = fillReads.Select(r => r.State).ToList().Count;
                        var onReads = fillReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        fillAva = (decimal)onReads / (decimal)stateReadsCount;

                        lineDetails.Rinse = fillReads.Select(r => r.Rinse).FirstOrDefault();

                    }
                    else
                    {
                        lineDetails.BottleConsumption = 0;
                        lineDetails.ProductionTime = 0;
                        lineDetails.Speed = 0;
                    }
                    if (labelReads.Any())
                    {
                        var bottleC1 = labelReads.Select(r => r.Counts).FirstOrDefault();
                        var bottleC2 = labelReads.Select(r => r.Counts).LastOrDefault();
                        var diff = (decimal)bottleC1 - (decimal)bottleC2;
                        lineDetails.Quality = 1;
                        if (lineDetails.Quality == 0)
                        {
                            lineDetails.Quality = 1;
                        }

                        var stateReadsCount = labelReads.Select(r => r.State).ToList().Count;
                        var onReads = labelReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                        lablAva = (decimal)onReads / (decimal)stateReadsCount;
                    }
                    else if (line.Id == 2)
                    {
                        var signalReads = _sContext.SignalBrokerTypeThree.Where(r => r.TimeStamp >= from && r.TimeStamp <= to && r.In_Count > 0 && r.BrokerId == "L_Conv_02").ToList().Select(r => r.In_Count).Sum();
                        lineDetails.Quality = 1;
                        if (lineDetails.Quality == 0)
                        {
                            lineDetails.Quality = 1;
                        }
                    }
                    else if (line.Id == 5)
                    {
                        var signalReads = _sContext.SignalBrokerTypeThree.Where(r => r.TimeStamp >= from && r.TimeStamp <= to && r.In_Count > 0 && r.BrokerId == "L_Labl_05").ToList().Select(r => r.In_Count).Sum();
                        lineDetails.Quality = 1;
                        if (lineDetails.Quality == 0)
                        {
                            lineDetails.Quality = 1;
                        }
                    }


                    if (line.Id == 1)
                    {
                        lineDetails.Avalability = (pallAva + fillAva + lablAva) / (decimal)3;
                    }
                    else if (line.Id == 2)
                    {
                        lineDetails.Avalability = (pallAva + fillAva) / (decimal)2;
                    }
                    else if (line.Id == 3)
                    {
                        lineDetails.Avalability = (pallAva + fillAva + lablAva + mixAva) / (decimal)4;
                    }
                    else if (line.Id == 4)
                    {
                        lineDetails.Avalability = (pallAva + fillAva + lablAva) / (decimal)3;
                    }
                    else if (line.Id == 5)
                    {
                        lineDetails.Avalability = (pallAva + fillAva + mixAva) / (decimal)3;
                    }
                    lineDetails.OEE = lineDetails.Avalability * lineDetails.Performance * lineDetails.Quality;
                    linesDetaila.Add(lineDetails);


                }
                FactoryDetailsDTO factoryDetails = new FactoryDetailsDTO
                {
                    LineId = 1,
                    From = from,
                    To = to,
                    FactoryName = "Alex (ABI)",
                    EnergyConsumption = linesDetaila.Select(r => r.EnergyConsumption).Sum(),
                    BottleConsumption = linesDetaila.Select(r => r.BottleConsumption).Sum(),
                    CO2 = linesDetaila.Select(r => r.CO2).Sum(),
                    EnergyConsumptionUseIndex = linesDetaila.Select(r => r.EnergyConsumptionUseIndex).Sum(),
                    PackConsumption = linesDetaila.Select(r => r.PackConsumption).Sum(),
                    PalletConsumption = linesDetaila.Select(r => r.PalletConsumption).Sum(),
                    SC = linesDetaila.Select(r => r.SC).Sum(),
                    WC = linesDetaila.Select(r => r.WC).Sum(),
                    Speed = linesDetaila.Select(r => r.Speed).Max(),
                    ProductionTime = linesDetaila.Select(r => r.ProductionTime).Max(),
                    PF = linesDetaila.Select(r => r.PF).Average(),
                    ProductionHours = linesDetaila.Select(r => r.ProductionHours).Max()
                };
                return Ok(new { linesDetaila, factoryDetails });

            }
            return Ok();
        }
        [HttpGet("LineDetails/{id}")]
        public ActionResult LineDetails(int id)
        {
            /*var From = (DateTime.Today.AddHours(8)).AddMinutes(20);
            var To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8)).AddMinutes(20);
                To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(20) && DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(20)).AddMinutes(10);
                To = ((DateTime.Today.AddDays(1)).AddHours(7)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4)).AddMinutes(10);
                To = (DateTime.Today.AddHours(7)).AddMinutes(50);
            }*/
            var From = (DateTime.Today.AddHours(8));
            var To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8));
                To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(20) && DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(8));
                To = (DateTime.Today.AddHours(19)).AddMinutes(45);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4));
                To = (DateTime.Today.AddHours(7)).AddMinutes(45);
            }
            var from = From;
                var to = To;
                var lines = _mContext.ProductionLines.Where(r=>r.Id == id).ToList();
                List<LineDetailsDTO> linesDetaila = new List<LineDetailsDTO>();
            foreach (var line in lines)
            {
                decimal mixAva = 0;
                decimal pallAva = 0;
                decimal fillAva = 0;
                decimal lablAva = 0;

                LineDetailsDTO lineDetails = new LineDetailsDTO
                {
                    LineId = line.Id,
                    From = from,
                    To = to,
                };
                var energyLoads = _mContext.Loads.Where(r => r.EnergyCode != null && r.ProductionLineId == line.Id).Select(r => new { r.Id, r.EnergyCode, r.ProductionLineId, r.FactoryId, r.Name }).ToList();
                var energyLoadsCodes = _mContext.Loads.Where(r => r.EnergyCode != null && r.ProductionLineId == line.Id).Select(r => r.EnergyCode).ToList();

                var energyReads = _eContext.IotTransactions.OrderByDescending(r => r.Id).Where(r => energyLoadsCodes.Contains(r.SourceId) && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                foreach (var energyRead in energyLoads)
                {
                    var energySource1 = energyReads.Where(r => r.SourceId == energyRead.EnergyCode).FirstOrDefault();
                    var energySource2 = energyReads.Where(r => r.SourceId == energyRead.EnergyCode).LastOrDefault();
                    var totalEnergy = (energySource1.Energy1 + energySource1.Energy2 + energySource1.Energy3) - (energySource2.Energy1 + energySource2.Energy2 + energySource2.Energy3);
                    lineDetails.EnergyConsumption = totalEnergy;
                }
                lineDetails.PF = energyReads.Select(r => (r.PF1 + r.PF2 + r.PF3) / 3).Average();

                var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Co2_Consumption >= 0 && r.Co2_Consumption < 100 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);

                var mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (mixerReads2.Any())
                {
                    mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= mixerReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                }


                var pallReads2 = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Pallet_No >= 0 && r.Pallet_No <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Pallet_No >= 0 && r.Packet_No > 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (pallReads2.Any())
                {
                    pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Pallet_No >= 0 && r.TimeStamp >= pallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                }

                var fillReads2 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count >= 0 && r.Speed >= 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (fillReads2.Any())
                {
                    fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count >= 0 && r.TimeStamp >= fillReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();

                }

                var dePallReads2 = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (dePallReads2.Any())
                {
                    dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count >= 0 && r.TimeStamp >= dePallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                }

                var labelReads2 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (labelReads2.Any())
                {
                    labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Counts >= 0 && r.TimeStamp >= labelReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                }

                var blowReads2 = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count_In == 0 && r.Count_In <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                var blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count_In >= 0 && r.Count_Out > 0 && r.Production_Hours > 0 && r.Speed >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                if (blowReads2.Any())
                {
                    blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.Line == line.Id && r.Count_In >= 0 && r.TimeStamp >= blowReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                }


                if (mixerReads.Any())
                {
                    var co2C1 = mixerReads.Select(r => r.Co2_Consumption).FirstOrDefault();
                    var co2C2 = mixerReads.Select(r => r.Co2_Consumption).LastOrDefault();

                    var sC1 = mixerReads.Select(r => r.Syrup_Consumption).FirstOrDefault();
                    var sC2 = mixerReads.Select(r => r.Syrup_Consumption).LastOrDefault();

                    var wC1 = mixerReads.Select(r => r.Water_Consumption).FirstOrDefault();
                    var wC2 = mixerReads.Select(r => r.Water_Consumption).LastOrDefault();

                    lineDetails.CO2 = (decimal)co2C1 - (decimal)co2C2;
                    lineDetails.WC = (decimal)wC1 - (decimal)wC2;
                    lineDetails.SC = (decimal)sC1 - (decimal)sC2;

                    var stateReadsCount = mixerReads.Select(r => r.State).ToList().Count;
                    var onReads = mixerReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                    mixAva = (decimal)onReads / (decimal)stateReadsCount;

                }
                else
                {
                    lineDetails.CO2 = 0;
                    lineDetails.WC = 0;
                    lineDetails.SC = 0;
                }
                if (pallReads.Any())
                {
                    var pallC1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                    var pallC2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();

                    var packC1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                    var packC2 = pallReads.Select(r => r.Packet_No).LastOrDefault();



                    lineDetails.PackConsumption = (decimal)pallC1 - (decimal)pallC2;
                    lineDetails.PalletConsumption = (decimal)packC1 - (decimal)packC2;
                    var maxSpeed = 0;

                    var minuteCount = (DateTime.Now - from).TotalMinutes;
                    for (int i = 0; i < minuteCount; i += 60)
                    {
                        var currentTimeFrom = from.AddMinutes(i);
                        var currentTimeTo = from.AddMinutes(i + 60);
                        if (currentTimeTo >= DateTime.Now)
                        {
                            currentTimeFrom = from.AddMinutes(i - 60);
                            currentTimeTo = from.AddMinutes(i);
                        }
                        var sC1 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).FirstOrDefault().Pallet_No;
                        var sC2 = pallReads.OrderByDescending(r => r.Id).Where(e => e.TimeStamp >= currentTimeFrom && e.TimeStamp <= currentTimeTo).LastOrDefault().Pallet_No;
                        var sC = sC1 - sC2;
                        if(sC > maxSpeed)
                        {
                            maxSpeed = sC;
                        }
                        lineDetails.Speed = sC;
                        if(maxSpeed == 0)
                        {
                            maxSpeed = 1;
                        }
                        lineDetails.Performance = (decimal)sC / (decimal)maxSpeed;

                    }

                    var stateReadsCount = pallReads.Select(r => r.State).ToList().Count;
                    var onReads = pallReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                    pallAva = (decimal)onReads / (decimal)stateReadsCount;

                }
                else
                {
                    lineDetails.PackConsumption = 0;
                    lineDetails.PalletConsumption = 0;
                }
                if (fillReads.Any())
                {
                    var bottleC1 = fillReads.Select(r => r.Count).FirstOrDefault();
                    var bottleC2 = fillReads.Select(r => r.Count).LastOrDefault();

                    var pHC1 = fillReads.Select(r => r.Production_Hours).FirstOrDefault();
                    var pHC2 = fillReads.Select(r => r.Production_Hours).LastOrDefault();

                    var sC1 = fillReads.Select(r => r.Speed).Average();
                    var msC1 = fillReads.Select(r => r.Speed).Max();


                    lineDetails.BottleConsumption = (decimal)bottleC1 - (decimal)bottleC2;
                    lineDetails.ProductionTime = ((decimal)pHC1 - (decimal)pHC2) / (decimal)12;
                    lineDetails.ProductionHours = ((decimal)pHC1 - (decimal)pHC2);
                    //lineDetails.Performance = sC1 / msC1;
                    var stateReadsCount = fillReads.Select(r => r.State).ToList().Count;
                    var onReads = fillReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                    fillAva = (decimal)onReads / (decimal)stateReadsCount;

                }
                else
                {
                    lineDetails.BottleConsumption = 0;
                    lineDetails.ProductionTime = 0;
                    lineDetails.Speed = 0;
                }
                if (labelReads.Any())
                {
                    var bottleC1 = labelReads.Select(r => r.Counts).FirstOrDefault();
                    var bottleC2 = labelReads.Select(r => r.Counts).LastOrDefault();
                    var diff = (decimal)bottleC1 - (decimal)bottleC2;
                    lineDetails.Quality = 1;
                    if (lineDetails.Quality == 0)
                    {
                        lineDetails.Quality = 1;
                    }

                    var stateReadsCount = labelReads.Select(r => r.State).ToList().Count;
                    var onReads = labelReads.Where(r => r.State == 1).Select(r => r.State).ToList().Count;
                    lablAva = (decimal)onReads / (decimal)stateReadsCount;
                }
                else if (line.Id == 2)
                {
                    var signalReads = _sContext.SignalBrokerTypeThree.Where(r => r.TimeStamp >= from && r.TimeStamp <= to && r.In_Count > 0 && r.BrokerId == "L_Conv_02").ToList().Select(r => r.In_Count).Sum();
                    lineDetails.Quality = 1;
                    if (lineDetails.Quality == 0)
                    {
                        lineDetails.Quality = 1;
                    }
                }
                else if (line.Id == 5)
                {
                    var signalReads = _sContext.SignalBrokerTypeThree.Where(r => r.TimeStamp >= from && r.TimeStamp <= to && r.In_Count > 0 && r.BrokerId == "L_Labl_05").ToList().Select(r => r.In_Count).Sum();
                    lineDetails.Quality = 1;
                    if (lineDetails.Quality == 0)
                    {
                        lineDetails.Quality = 1;
                    }
                }


                if (line.Id == 1)
                {
                    lineDetails.Avalability = (pallAva + fillAva + lablAva) / (decimal)3;
                }
                else if (line.Id == 2)
                {
                    lineDetails.Avalability = (pallAva + fillAva) / (decimal)2;
                }
                else if (line.Id == 3)
                {
                    lineDetails.Avalability = (pallAva + fillAva + lablAva + mixAva) / (decimal)4;
                }
                else if (line.Id == 4)
                {
                    lineDetails.Avalability = (pallAva + fillAva + lablAva) / (decimal)3;
                }
                else if (line.Id == 5)
                {
                    lineDetails.Avalability = (pallAva + fillAva + mixAva) / (decimal)3;
                }
                lineDetails.OEE = lineDetails.Avalability * lineDetails.Performance * lineDetails.Quality;
                linesDetaila.Add(lineDetails);


            }

            return Ok(linesDetaila);
        }

        [HttpGet("RouteRoot")]
        public ActionResult RouteRoot()
        {
            var From = (DateTime.Today.AddHours(8)).AddMinutes(20);
            var To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            if (DateTime.Now > DateTime.Today.AddHours(8) && DateTime.Now < DateTime.Today.AddHours(20))
            {
                From = (DateTime.Today.AddHours(8)).AddMinutes(20);
                To = (DateTime.Today.AddHours(19)).AddMinutes(50);
            }
            else if ( DateTime.Now > DateTime.Today.AddHours(20) &&  DateTime.Now < (DateTime.Today.AddDays(1)).AddHours(8))
            {
                From = (DateTime.Today.AddHours(20)).AddMinutes(10);
                To = ((DateTime.Today.AddDays(1)).AddHours(7)).AddMinutes(50);
            }
            else if (DateTime.Now > DateTime.Today.AddHours(-4) && DateTime.Now < (DateTime.Today.AddHours(8)))
            {
                From = (DateTime.Today.AddHours(-4)).AddMinutes(10);
                To = (DateTime.Today.AddHours(7)).AddMinutes(50);
            }
            var from = From;
                var to = To;
                
                  
                    List<RouteRootDTO> routeRootDTOs = new List<RouteRootDTO>();
            var recipes = _mContext.ProductionLines.Take(5).ToList();
            foreach (var recipe in recipes)
            {
                var actualProcess = _mContext.Loads.Where(r => r.ProductionLineId == recipe.Id && r.PlcCode != null).ToList();
                RouteRootDTO routeRootDTO = new RouteRootDTO
                {
                    name = recipe.Name,

                };
                ProcessMaterialDTO processMaterialDTO = new ProcessMaterialDTO
                {
                    name = "",
                };
                ProcessTreeDTO processTreeDTO = new ProcessTreeDTO
                {
                    name = "",
                };
                MaterialNameDTO materialNameDTO = new MaterialNameDTO
                {
                    name = "",
                };
                MaterialNameDTO materialNameDTO2 = new MaterialNameDTO
                {
                    name = "",
                };
                MaterialNameDTO materialNameDTO3 = new MaterialNameDTO
                {
                    name = "",
                };
                foreach (var process in actualProcess)
                {
                    
                    var mixerReads2 = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Co2_Consumption >= 0 && r.Co2_Consumption < 100 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to);

                    var mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (mixerReads2.Any())
                    {
                        mixerReads = _context.Mixers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Co2_Consumption >= 0 && r.Syrup_Consumption > 0 && r.Water_Consumption > 0 && r.TimeStamp >= mixerReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }


                    var pallReads2 = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Pallet_No == 0 && r.Pallet_No <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Pallet_No >= 0 && r.Packet_No > 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (pallReads2.Any())
                    {
                        pallReads = _context.Palletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Pallet_No >= 0 && r.TimeStamp >= pallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var fillReads2 = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count >= 0 && r.Speed >= 0 && r.Production_Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (fillReads2.Any())
                    {
                        fillReads = _context.Fillers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count >= 0 && r.TimeStamp >= fillReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();

                    }

                    var dePallReads2 = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count == 0 && r.Count <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (dePallReads2.Any())
                    {
                        dePallReads = _context.DPalletizers.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count >= 0 && r.TimeStamp >= dePallReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var labelReads2 = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Counts >= 0 && r.Speed >= 0 && r.Hours > 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (labelReads2.Any())
                    {
                        labelReads = _context.Labels.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Counts >= 0 && r.TimeStamp >= labelReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var blowReads2 = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count_In == 0 && r.Count_In <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count_In >= 0 && r.Count_Out > 0 && r.Production_Hours > 0 && r.Speed >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (blowReads2.Any())
                    {
                        blowReads = _context.Blow_Moulders.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Count_In >= 0 && r.TimeStamp >= blowReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }

                    var cartReads2 = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Counts == 0 && r.Counts <= 100 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    var cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Counts >= 0  && r.Hours > 0 && r.Speed >= 0 && r.TimeStamp >= from && r.TimeStamp <= to).ToList();
                    if (cartReads2.Any())
                    {
                        cartReads = _context.Cartonizers_Shrinks.OrderByDescending(r => r.Id).Where(r => r.MachineId == process.PlcCode && r.Counts >= 0 && r.TimeStamp >= cartReads2.Select(r => r.TimeStamp).LastOrDefault()).ToList();
                    }


                    

                    
                    
                    
                    
                    
                    if (recipe.Id == 1)
                    {
                        
                        
                        if (pallReads.Any())
                        {
                            
                            var pallC1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                            var pallC2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();

                            var packC1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                            var packC2 = pallReads.Select(r => r.Packet_No).LastOrDefault();

                            var pallets = pallC1 - pallC2;
                            var pack = packC1 - packC2;

                            
                            
                            routeRootDTO.name = process.Name + ": " + pallets + " Pallet";
                        }
                        if (labelReads.Any())
                        {
                           
                            var bottleC1 = labelReads.Select(r => r.Counts).FirstOrDefault();
                            var bottleC2 = labelReads.Select(r => r.Counts).LastOrDefault();
                            var diff = (decimal)bottleC1 - (decimal)bottleC2;

                            processTreeDTO.name = process.Name + ": " + diff + " Bottle";
                            routeRootDTO.children.Add(processTreeDTO);
                            
                        }
                        if (fillReads.Any())
                        {
                            
                            var bottleC1 = fillReads.Select(r => r.Count).FirstOrDefault();
                            var bottleC2 = fillReads.Select(r => r.Count).LastOrDefault();

                            var bottle = bottleC1 - bottleC2;

                            processMaterialDTO.name = process.Name + ": " + bottle + " Bottle";

                            processTreeDTO.children.Add(processMaterialDTO);
                        }
                        if (dePallReads.Any())
                        {
                           
                            var bottleC1 = dePallReads.Select(r => r.Count).FirstOrDefault();
                            var bottleC2 = dePallReads.Select(r => r.Count).LastOrDefault();
                            var diff = (decimal)bottleC1 - (decimal)bottleC2;
                            materialNameDTO.name = process.Name + ": " + diff + " Bottle";
                            
                            processMaterialDTO.children.Add(materialNameDTO);
                        }
                        
                    }
                    else if(recipe.Id == 2)
                    {
                        if (cartReads.Any())
                        {
                            var bottleC1 = cartReads.Select(r => r.Counts).FirstOrDefault();
                            var bottleC2 = cartReads.Select(r => r.Counts).LastOrDefault();
                            var diff = (decimal)bottleC1 - (decimal)bottleC2;

                            routeRootDTO.name = process.Name + ": " + diff + " Bottle";
                        }
                        if (pallReads.Any())
                        {

                            var pallC1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                            var pallC2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();

                            var packC1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                            var packC2 = pallReads.Select(r => r.Packet_No).LastOrDefault();

                            var pallets = pallC1 - pallC2;
                            var pack = packC1 - packC2;



                            processTreeDTO.name = process.Name + ": " + pallets + " Pallet";
                            routeRootDTO.children.Add(processTreeDTO);
                        }
                        if (fillReads.Any())
                        {

                            var bottleC1 = fillReads.Select(r => r.Count).FirstOrDefault();
                            var bottleC2 = fillReads.Select(r => r.Count).LastOrDefault();

                            var bottle = bottleC1 - bottleC2;

                            processMaterialDTO.name = process.Name + ": " + bottle + " Bottle";

                            processTreeDTO.children.Add(processMaterialDTO);
                        }
                    }
                    else if(recipe.Id == 3)
                    {
                        if (cartReads.Any())
                        {
                            var bottleC1 = cartReads.Select(r => r.Counts).FirstOrDefault();
                            var bottleC2 = cartReads.Select(r => r.Counts).LastOrDefault();
                            var diff = (decimal)bottleC1 - (decimal)bottleC2;

                            routeRootDTO.name = process.Name + ": " + diff + " Bottle";
                        }
                        if (pallReads.Any())
                        {

                            var pallC1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                            var pallC2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();

                            var packC1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                            var packC2 = pallReads.Select(r => r.Packet_No).LastOrDefault();

                            var pallets = pallC1 - pallC2;
                            var pack = packC1 - packC2;



                            processTreeDTO.name = process.Name + ": " + pallets + " Pallet";
                            routeRootDTO.children.Add(processTreeDTO);
                        }
                        if (labelReads.Any())
                        {

                            var bottleC1 = labelReads.Select(r => r.Counts).FirstOrDefault();
                            var bottleC2 = labelReads.Select(r => r.Counts).LastOrDefault();
                            var diff = (decimal)bottleC1 - (decimal)bottleC2;

                            processMaterialDTO.name = process.Name + ": " + diff + " Bottle";
                            processTreeDTO.children.Add(processMaterialDTO);

                        }
                        if (fillReads.Any())
                        {

                            var bottleC1 = fillReads.Select(r => r.Count).FirstOrDefault();
                            var bottleC2 = fillReads.Select(r => r.Count).LastOrDefault();

                            var bottle = bottleC1 - bottleC2;

                            materialNameDTO.name = process.Name + ": " + bottle + " Bottle";

                            processMaterialDTO.children.Add(materialNameDTO);
                        }
                        if (mixerReads.Any())
                        {

                            var co2C1 = mixerReads.Select(r => r.Co2_Consumption).FirstOrDefault();
                            var co2C2 = mixerReads.Select(r => r.Co2_Consumption).LastOrDefault();

                            var sC1 = mixerReads.Select(r => r.Syrup_Consumption).FirstOrDefault();
                            var sC2 = mixerReads.Select(r => r.Syrup_Consumption).LastOrDefault();

                            var wC1 = mixerReads.Select(r => r.Water_Consumption).FirstOrDefault();
                            var wC2 = mixerReads.Select(r => r.Water_Consumption).LastOrDefault();

                            var cO2 = (co2C1 - co2C2).ToString();
                            var sC = (sC1 - sC2).ToString();
                            var wC = (wC1 - wC2).ToString();

                            materialNameDTO2.name = process.Name + ": Syrup " + (sC) + " L" + ": Syrup " + (wC) + " L" + ": Syrup " + (cO2) + " KG";
                            materialNameDTO.children.Add(materialNameDTO2);
                        }
                        if (blowReads.Any())
                        {
                            var bottleC1 = blowReads.Select(r => r.Count_Out).FirstOrDefault();
                            var bottleC2 = blowReads.Select(r => r.Count_Out).LastOrDefault();
                            var diff = (decimal)bottleC1 - (decimal)bottleC2;

                            materialNameDTO3.name = process.Name + " : " + diff + " Bottle";

                            materialNameDTO2.children.Add(materialNameDTO3);
                        }
                    }
                    else if (recipe.Id == 4)
                    {
                        if (pallReads.Any())
                        {

                            var pallC1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                            var pallC2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();

                            var packC1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                            var packC2 = pallReads.Select(r => r.Packet_No).LastOrDefault();

                            var pallets = pallC1 - pallC2;
                            var pack = packC1 - packC2;



                            routeRootDTO.name = process.Name + ": " + pallets + " Pallet";

                        }
                        if (labelReads.Any())
                        {

                            var bottleC1 = labelReads.Select(r => r.Counts).FirstOrDefault();
                            var bottleC2 = labelReads.Select(r => r.Counts).LastOrDefault();
                            var diff = (decimal)bottleC1 - (decimal)bottleC2;

                            processTreeDTO.name = process.Name + ": " + diff + " Bottle";
                            routeRootDTO.children.Add(processTreeDTO);
                        }
                        if (fillReads.Any())
                        {

                            var bottleC1 = fillReads.Select(r => r.Count).FirstOrDefault();
                            var bottleC2 = fillReads.Select(r => r.Count).LastOrDefault();

                            var bottle = bottleC1 - bottleC2;

                            processMaterialDTO.name = process.Name + ": " + bottle + " Bottle";

                            processTreeDTO.children.Add(processMaterialDTO);
                        }
                    }
                    else if (recipe.Id == 5)
                    {
                        if (pallReads.Any())
                        {

                            var pallC1 = pallReads.Select(r => r.Pallet_No).FirstOrDefault();
                            var pallC2 = pallReads.Select(r => r.Pallet_No).LastOrDefault();

                            var packC1 = pallReads.Select(r => r.Packet_No).FirstOrDefault();
                            var packC2 = pallReads.Select(r => r.Packet_No).LastOrDefault();

                            var pallets = pallC1 - pallC2;
                            var pack = packC1 - packC2;

                            routeRootDTO.name = process.Name + ": " + pallets + " Pallet";

                        }
                        if (fillReads.Any())
                        {

                            var bottleC1 = fillReads.Select(r => r.Count).FirstOrDefault();
                            var bottleC2 = fillReads.Select(r => r.Count).LastOrDefault();

                            var bottle = bottleC1 - bottleC2;

                            processTreeDTO.name = process.Name + ": " + bottle + " Bottle";
                            routeRootDTO.children.Add(processTreeDTO);
                        }
                        if (mixerReads.Any())
                        {

                            var co2C1 = mixerReads.Select(r => r.Co2_Consumption).FirstOrDefault();
                            var co2C2 = mixerReads.Select(r => r.Co2_Consumption).LastOrDefault();

                            var sC1 = mixerReads.Select(r => r.Syrup_Consumption).FirstOrDefault();
                            var sC2 = mixerReads.Select(r => r.Syrup_Consumption).LastOrDefault();

                            var wC1 = mixerReads.Select(r => r.Water_Consumption).FirstOrDefault();
                            var wC2 = mixerReads.Select(r => r.Water_Consumption).LastOrDefault();

                            var cO2 = (co2C1 - co2C2).ToString();
                            var sC = (sC1 - sC2).ToString();
                            var wC = (wC1 - wC2).ToString();

                            processMaterialDTO.name = process.Name + ": Syrup " + (sC) + " L" + ": Syrup " + (wC) + " L" + ": Syrup " + (cO2) + " KG";
                            processTreeDTO.children.Add(processMaterialDTO);
                        }
                        if (blowReads.Any())
                        {
                            var bottleC1 = blowReads.Select(r => r.Count_Out).FirstOrDefault();
                            var bottleC2 = blowReads.Select(r => r.Count_Out).LastOrDefault();
                            var diff = (decimal)bottleC1 - (decimal)bottleC2;

                            materialNameDTO.name = process.Name + " : " + diff + " Bottle";

                            processMaterialDTO.children.Add(materialNameDTO);
                        }

                    }



                }
                routeRootDTOs.Add(routeRootDTO);
            }

            return Ok(routeRootDTOs);
        }

        
        /*[HttpGet("GetLinesProcess")]
        public ActionResult GetLinesProcess()
        {

        }*/

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
