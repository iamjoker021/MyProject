using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models.Dtos;
using MyProject.Repository;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionDetailController : ControllerBase
    {
        private readonly IPensionDetailRepository _pensionDetailRepo;
        private readonly IMapper _mapper;

        public PensionDetailController(IPensionDetailRepository pensionDetailRepo, IMapper mapper)
        {
            _pensionDetailRepo = pensionDetailRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPensionerDetails()
        {
            var objList = _pensionDetailRepo.GetPensionDetails();

            if (objList == null)
            {
                return NotFound("The Adhhar Numer does not exist in Database");
            }

            var objListDto = new List<PensionerDetailDto>();

            foreach (var obj in objList) {
                objListDto.Add(_mapper.Map<PensionerDetailDto>(obj));
            }

            return Ok(objListDto);
        }

        [HttpGet("{adhaarNumber:int}")]
        public IActionResult GetPensionerDetailByAdhaar(int adhaarNumber)
        {
            var obj = _pensionDetailRepo.GetPensionerDetailByAdhaar(adhaarNumber);

            if (obj == null)
            {
                return NotFound("The Adhhar Numer does not exist in Database");
            }

            var objDto = _mapper.Map<PensionerDetailDto>(obj);

            return Ok(objDto);
        }
    }
}
