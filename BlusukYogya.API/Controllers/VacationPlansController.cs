using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationPlansController : ControllerBase
    {
        private readonly IVacationPlanBLL _vacationPlan;
        public VacationPlansController(IVacationPlanBLL vacationPlanBLL)
        {
            _vacationPlan = vacationPlanBLL;
        }

        [HttpPost("InsertNew")]
        public async Task<IActionResult> InsertNewVacationPlan(InsertVacationPlanDTO insertVacationPlanDTO)
        {
            {
                var result = await _vacationPlan.Insert(insertVacationPlanDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(VacationPlanDTO vacationPlanDTO)
        {
            {
                var result = await _vacationPlan.Update(vacationPlanDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
