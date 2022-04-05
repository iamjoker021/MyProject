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

        /* Working
        [HttpGet("{adhaarNumber:int}")]
        public async Task<IActionResult> GetPensionerDetails(int adhaarNumber)
        {
            ProcessPension processPension = new ProcessPension();

            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync( StaticDetails.PensionDetailURL + StaticDetails.PensionDetialPath + adhaarNumber);

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
        */

        private readonly IProcessPensionRepository _processPensionRepo;

        public ProcessPensionController(IProcessPensionRepository processPensionRepo)
        {
            _processPensionRepo = processPensionRepo;
        }

        [HttpGet("{adhaarNumber:int}")]
        public async Task<IActionResult> GetPensionerDetails(int adhaarNumber)
        {

            var processPension = await _processPensionRepo.GetAsync(StaticDetails.PensionDetailURL + StaticDetails.PensionDetialPath, adhaarNumber);

            var obj = new { PensionAmount = processPension.GetPensionAmount(), BankServiceCharge = processPension.GetBankServiceCharge() };

            return Ok(obj);
        }
    }
}
