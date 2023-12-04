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
    [Route("api/IssuedDevices")]
    public class IssuedDevicesController : ControllerBase
    {
        private readonly IRepositoryService<IssuedDevice> _issuedDevicesRepository;
        private readonly IRepositoryService<Device> _deviceRepository;
        private readonly IMapper _mapper;

        public IssuedDevicesController(IRepositoryService<IssuedDevice> issuedDevicesRepository,
            IRepositoryService<Device> deviceRepository,
            IMapper mapper)
        {
            _issuedDevicesRepository = issuedDevicesRepository;
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        // POST api/issueddevices
        [HttpPost]
        public ActionResult<IssuedDevice> AddIssue([FromBody] IssuedDeviceDTO issueDTO)
        {
            issueDTO.DateOfIssue = issueDTO.DateOfIssue.ToUniversalTime();

            var deviceIssues = _issuedDevicesRepository.FindBy(x => x.DeviceId == issueDTO.DeviceId).ToList();

            if (deviceIssues.FirstOrDefault() != null)
            {
                foreach (var deviceIssue in deviceIssues)
                {
                    if (deviceIssue.DateOfReturn == null)
                    {
                        return BadRequest("Device has not been returned. Cannot issue this device.");
                    }
                }
            }

            var result = _issuedDevicesRepository.Add(_mapper.Map<IssuedDevice>(issueDTO));

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            var device = _deviceRepository.GetSingle(issueDTO.DeviceId);
            device.EmployeeId = issueDTO.EmployeeId;
            device.Place = issueDTO.Place;
            device.Status = (Status)2;
            result = _deviceRepository.Edit(device);

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return CreatedAtAction(nameof(AddIssue), new { id = issueDTO.Id }, issueDTO);
        }

        // GET api/issueddevices
        [HttpGet]
        public ActionResult<List<IssuedDevice>> GetAllIssues()
        {
            var result = _issuedDevicesRepository.GetAllRecords().ToList();

            if (result.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/issueddevices/1
        [HttpGet("{id}")]
        public ActionResult<List<IssuedDevice>> GetIssuesByDeviceId(Guid id)
        {
            var result = _issuedDevicesRepository.FindBy(x => x.DeviceId == id).ToList();

            if (result.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/issueddevices/last/1
        [HttpGet("last/{id}")]
        public ActionResult<IssuedDevice> GetLastIssueByDeviceId(Guid id)
        {
            var result = _issuedDevicesRepository.FindBy(x => x.DeviceId == id).Include(x => x.Employee).Include(x => x.Device);

            if (result.FirstOrDefault() == null)
            {
                return NotFound();
            }

            IssuedDevice lastDevice = result.FirstOrDefault();

            foreach (var issue in result)
            {
                if (issue.DateOfReturn == null)
                {
                    return Ok(issue);
                }

                if (issue.DateOfIssue > lastDevice.DateOfIssue)
                {
                    lastDevice = issue;
                }
            }

            return Ok(lastDevice);
        }

        // DELETE api/issueddevices/1
        [HttpDelete("{id}")]
        public ActionResult<IssuedDevice> DeleteIssueById(Guid id)
        {
            var emp = _issuedDevicesRepository.GetSingle(id);

            if (emp == null)
            {
                return BadRequest("Attempted to update or delete an entity that does not exist in the store.");
            }

            var result = _issuedDevicesRepository.Delete(emp);

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }

        // PUT api/issueddevices
        [HttpPut]
        public ActionResult<IssuedDevice> EditIssue(IssuedDeviceDTO issueDTO)
        {
            var result = _issuedDevicesRepository.Edit(_mapper.Map<IssuedDevice>(issueDTO));

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }

        // PUT api/issueddevices/return
        [HttpPut("return")]
        public ActionResult<IssuedDevice> ReturnDevice(IssuedDeviceDTO issueDTO)
        {
            var result = _issuedDevicesRepository.Edit(_mapper.Map<IssuedDevice>(issueDTO));

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            var device = _deviceRepository.GetSingle(issueDTO.DeviceId);
            device.Status = (Status)1; // niewydany
            device.Place = issueDTO.Place;

            result = _deviceRepository.Edit(device);

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }

        // PUT api/issueddevices/1
        [HttpPut("{id}")]
        public ActionResult<IssuedDevice> AddReturnDate(Guid id, [FromBody] DateTime returnDate)
        {
            var newIssue = _issuedDevicesRepository.GetSingle(id);

            if (newIssue == null)
            {
                return NotFound();
            }

            newIssue.DateOfReturn = returnDate;

            var result = _issuedDevicesRepository.Edit(newIssue);

            if (result.Result == ServiceResultStatus.Error)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }
    }
}
