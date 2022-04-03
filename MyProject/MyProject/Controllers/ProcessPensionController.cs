using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Repository.IRepository;
using Newtonsoft.Json;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPensionController : Controller
    {
        private readonly IProcessPensionRepository _pensionProcessRepo;

        public ProcessPensionController(IProcessPensionRepository pensionProcessRepo, IMapper mapper)
        {
            _pensionProcessRepo = pensionProcessRepo;
        }
        /*
        // [HttpPost("{adhaarNumber:int}")]
        [HttpGet("{adhaarNumber:int}")]
        public IActionResult GetPensionerDetailr(int adhaarNumber)
        {
            var obj = GetPensionDetailByAdhaar(adhaarNumber);

            if (obj == null)
            {
                return NotFound("The Adhhar Numer does not exist in Database");
            }

            return Ok(obj);
        }

        public ProcessPension GetPensionDetailByAdhaar(int adhaarNumber)
        {
            var obj = _pensionProcessRepo.GetAsync("https://localhost:44364/api/PensionDetail/", adhaarNumber);
            
            return obj;
        }
        */

        [HttpGet("{adhaarNumber:int}")]
        public async Task<IActionResult> GetPensionerDetails(int adhaarNumber)
        {
            ProcessPension processPension = new ProcessPension();

            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://localhost:44364/api/PensionDetail/" + adhaarNumber);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                processPension = JsonConvert.DeserializeObject<ProcessPension>(jsonString);
            }

            if (processPension == null)
            {
                return NotFound("The Adhhar Numer does not exist in Database");
            }

            var obj = new { PensionAmount = processPension.GetPensionAmount(), BankServiceCharge = processPension.GetBankServiceCharge() };

            return Ok(obj);
        }
    }
}
