using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL
{
    public class VacationPlanBLL : IVacationPlanBLL
    {
        private readonly IVacationPlanData _vacationPlan;
        private readonly IMapper _mapper;
        public VacationPlanBLL(IVacationPlanData vacationPlanData, IMapper mapper)
        {
            _mapper = mapper;
            _vacationPlan = vacationPlanData;
        }
        public IEnumerable<VacationPlanDTO> GetVacationPlanByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Insert(InsertVacationPlanDTO plan)
        {
            var dataDTO = _mapper.Map<VacationPlan>(plan);
            await _vacationPlan.TransactionInsert(dataDTO);
            return Task.CompletedTask;  
        }

        public async Task<Task> Update(VacationPlanDTO plan)
        {
            var data = _mapper.Map<VacationPlan>(plan);
            await _vacationPlan.Update(data);
            return Task.CompletedTask;
        }
    }
}
