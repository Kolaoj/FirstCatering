using AutoMapper;
using FirstCatering.API.Entities;
using FirstCatering.API.Models;
using FirstCatering.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FirstCatering.API.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    public class EmployeeDataController : ControllerBase
    {
        private readonly IEmployeeDataRepository _employeeDataRepository;
        private readonly IMapper _mapper;

        public EmployeeDataController(IEmployeeDataRepository employeeDataRepository, IMapper mapper)
        {
            _employeeDataRepository = employeeDataRepository ??
                throw new ArgumentNullException(nameof(employeeDataRepository));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost ]
        public IActionResult GetUserData([FromBody]EmployeeDataForRetrievalDto employeeDataForRetrieval)
        {
            if (_employeeDataRepository.CheckCardRegistration(employeeDataForRetrieval.CardId) == false)
            {
                return NotFound("This card is not registered");
            }

            if (_employeeDataRepository.CheckPin(employeeDataForRetrieval.CardId, employeeDataForRetrieval.Pin) == false)
            {
                return BadRequest("Incorrect pin");
            }

            var employeeDetails = _employeeDataRepository.GetEmployeeData(employeeDataForRetrieval.CardId, employeeDataForRetrieval.Pin);

            return Ok(employeeDetails);
        }

        [HttpPost("Register")]
        public IActionResult CreateNewEmployee([FromBody]EmployeeData employeeData)
        {
            if (_employeeDataRepository.CheckCardRegistration(employeeData.CardId) == true)
            {
                return BadRequest("This card is already registered to someone else");
            }

            if (_employeeDataRepository.CheckEmployeeRegistration(employeeData.EmployeeId) == true)
            {
                return BadRequest("This employee already exists");
            }

            _employeeDataRepository.CreateNewEmployee(employeeData);
           
            _employeeDataRepository.Save();

            return Created("http://localhost:50295/api/Employee/", employeeData);
        }

        [HttpPatch("ChangeBalance/TopUp")]
        public IActionResult ChangeBalanceTopUp([FromBody]JsonPatchDocument<EmployeeDataForBalanceChangeDto> patchDoc, [FromHeader] string cardId, [FromHeader] string pin)
        {
            if (_employeeDataRepository.CheckCardRegistration(cardId) == false)
            {
                return NotFound("This card is not registered");
            }

            if (_employeeDataRepository.CheckPin(cardId, pin) == false)
            {
                return BadRequest("Incorrect pin");
            }

            var employeeDataEntity = _employeeDataRepository.GetEmployeeEntity(cardId, pin);

            var employeeDataToPatch = _mapper.Map<EmployeeDataForBalanceChangeDto>(employeeDataEntity);

            patchDoc.ApplyTo(employeeDataToPatch, ModelState);

            if (!TryValidateModel(employeeDataToPatch))
            {
                return BadRequest(ModelState);
            }

            _employeeDataRepository.ChangeBalance(employeeDataToPatch, employeeDataEntity);

            _employeeDataRepository.Save();

            return NoContent();
        }

        [HttpPatch("ChangeBalance/MakePayment")]
        public IActionResult ChangeBalanceMakePayment([FromBody]JsonPatchDocument<EmployeeDataForBalanceChangeDto> patchDoc, [FromHeader] string cardId, [FromHeader] string pin)
        {
            if (_employeeDataRepository.CheckCardRegistration(cardId) == false)
            {
                return NotFound("This card is not registered");
            }

            if (_employeeDataRepository.CheckPin(cardId, pin) == false)
            {
                return BadRequest("Incorrect pin");
            }

            var employeeDataEntity = _employeeDataRepository.GetEmployeeEntity(cardId, pin);
           
            if (employeeDataEntity.Balance < 1)
            {
                return BadRequest("Not enough money to make a purchase, top up necessary");
            }

            var employeeDataToPatch = _mapper.Map<EmployeeDataForBalanceChangeDto>(employeeDataEntity);

            patchDoc.ApplyTo(employeeDataToPatch, ModelState);

            if (!TryValidateModel(employeeDataToPatch))
            {
                return BadRequest(ModelState);
            }

            _employeeDataRepository.ChangeBalance(employeeDataToPatch, employeeDataEntity);

            _employeeDataRepository.Save();

            return NoContent();
        }
    }
}
