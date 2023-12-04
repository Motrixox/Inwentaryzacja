using AutoMapper;
using Inwentaryzacja.DataTransferObjects;
using Inwentaryzacja.Extensions;
using Inwentaryzacja.Interfaces;
using Inwentaryzacja.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inwentaryzacja.Controlers
{
    [ApiController]
    [Route("api/Devices")]
    public class DevicesController : ControllerBase
    {
        private readonly IRepositoryService<Device> _repository;
        private readonly IMapper _mapper;

        public DevicesController(IRepositoryService<Device> devicesRepository, IMapper mapper)
        {
            _repository = devicesRepository;
            _mapper = mapper;
        }


        // POST api/devices
        [HttpPost]
        public ActionResult<Device> AddDevice([FromBody] DeviceDTO deviceDTO)
        {
            var device = _mapper.Map<Device>(deviceDTO);
            device.Id = Guid.NewGuid();
            device.Status = (Status)1;
            if (device.Code==null)
            {
                device.Code = device.Id.ToString();
            }
            device.IsConfirmed = false;
            var result = _repository.Add(device);

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return CreatedAtAction(nameof(AddDevice), new { id = deviceDTO.Id }, deviceDTO);
        }

        // GET api/devices
        [HttpGet]
        public ActionResult<List<Device>> GetAllDevices()
        {
            var result = _repository.GetAllRecords().Include(x => x.Employee).Include(x => x.DeviceType).ToList();

            if (result.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/devices/1
        [HttpGet("{id}")]
        public ActionResult<Device> GetDeviceById(Guid id)
        {
            var result = _repository.FindBy(x => x.Id == id).Include(x => x.Employee).Include(x => x.DeviceType).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/devices/code/ABC123
        [HttpGet("code/{code}")]
        public ActionResult<Device> GetDeviceByCode(string code)
        {
            var result = _repository.FindBy(x => x.Code == code).Include(x => x.Employee).Include(x => x.DeviceType).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/devices/1
        [HttpDelete("{id}")]
        public ActionResult<Device> DeleteDeviceById(Guid id)
        {
            var emp = _repository.GetSingle(id);

            if (emp == null)
            {
                return BadRequest("Attempted to update or delete an entity that does not exist in the store.");
            }

            var result = _repository.Delete(emp);

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }

        // PUT api/devices
        [HttpPut]
        public ActionResult<Device> EditDevice(DeviceDTO deviceDTO)
        {
            var device = _repository.GetSingle((Guid)deviceDTO.Id);
            device.Id = (Guid)deviceDTO.Id;
            device.Code = deviceDTO.Code;
            device.SerialNumber = deviceDTO.SerialNumber;
            device.Description = deviceDTO.Description;
            device.DeviceTypeId = deviceDTO.DeviceTypeId;
            device.EmployeeId = deviceDTO.EmployeeId;
            device.Status = deviceDTO.Status;
            device.Place = deviceDTO.Place;
            var result = _repository.Edit(device);

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }

        //GET api/devices/Status/1
        //Gets the current value of IsConfirmed
        [HttpGet("Status/{id}")]
        public ActionResult<Device> GetStatus(Guid id)
        {
            var result = _repository.GetSingle(id).IsConfirmed;

            return Ok(result);
        }

        //PUT api/devices/Status/1
        //Changes the current value of IsConfirmed to the opposite
        [HttpPut("Status/{id}")]
        public ActionResult<Device> ChangeStatus(Guid id)
        {
            var result = _repository.GetSingle(id);

            if (result.IsConfirmed == false)
            {
                result.IsConfirmed = true;
            }
            else
            {
                result.IsConfirmed = false;
            }
            _repository.Edit(result);
            return Ok();
        }

        //PUT api/devices/Status
        //Body: [1,2,4,6]
        //Changes the current value of IsConfirmed of all given devices to the opposite
        [HttpPut("Status")]
        public ActionResult<Device> ChangeGroupStatus([FromBody] Guid[] ids)
        {
            foreach (var id in ids)
            {
                var result = _repository.GetSingle(id);

                if (result.IsConfirmed == false)
                {
                    result.IsConfirmed = true;
                }
                else
                {
                    result.IsConfirmed = false;
                }
                _repository.Edit(result);
            }

            return Ok();
        }

        //PUT api/devices/ResetInventory
        //Sets IsConfirmed flag of all devices to false
        [HttpPut("ResetInventory")]
        public ActionResult<Device> ResetInventory()
        {
            var devices = _repository.GetAllRecords().ToList();
            foreach (var device in devices)
            {
                device.IsConfirmed = false;
                var result = _repository.Edit(device);

                if (result.Result == ServiceResultStatus.Error)
                {
                    return BadRequest(result.Messages);
                }
            }
            return Ok();
        }

        //PUT api/devices/TurnOff/1
        //Changes the current value of Status to 3 (turned off)
        [HttpPut("TurnOff/{id}")]
        public ActionResult<Device> TurnOff(Guid id)
        {
            var result = _repository.GetSingle(id);

            result.Status = (Status)3;
            
            _repository.Edit(result);
            return Ok();
        }
    }
}
