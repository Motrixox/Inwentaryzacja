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
    [Route("api/DeviceTypes")]
    public class DeviceTypesController : ControllerBase
    {
        private readonly IRepositoryService<DeviceType> _repository;
        private readonly IMapper _mapper;

        public DeviceTypesController(IRepositoryService<DeviceType> deviceTypesRepository, IMapper mapper)
        {
            _repository = deviceTypesRepository;
            _mapper = mapper;
        }

        // POST api/DeviceTypes
        [HttpPost]
        public ActionResult<DeviceType> AddDeviceType([FromBody] DeviceTypeDTO deviceTypeDTO)
        {
            var result = _repository.Add(_mapper.Map<DeviceType>(deviceTypeDTO));

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return CreatedAtAction(nameof(AddDeviceType), new { id = deviceTypeDTO.Id }, deviceTypeDTO);
        }

        // GET api/DeviceTypes
        [HttpGet]
        public ActionResult<List<DeviceType>> GetAllDeviceTypes()
        {
            var result = _repository.GetAllRecords().Include(x => x.Devices).ToList();

            if (result.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/DeviceTypes/1
        [HttpGet("{id}")]
        public ActionResult<DeviceType> GetDeviceTypeById(Guid id)
        {
            var result = _repository.FindBy(x => x.Id == id).Include(x => x.Devices).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/DeviceTypes/1
        [HttpDelete("{id}")]
        public ActionResult<DeviceType> DeleteDeviceTypeById(Guid id)
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

        // PUT api/Devices
        [HttpPut]
        public ActionResult<DeviceType> EditDevice(DeviceTypeDTO deviceTypeDTO)
        {
            var result = _repository.Edit(_mapper.Map<DeviceType>(deviceTypeDTO));

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }
    }
}
