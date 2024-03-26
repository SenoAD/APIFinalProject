using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.BLL.DTO;
using BlusukYogya.Data;

namespace BlusukYogya.BLL.Interface
{
    public interface IVacationPlanBLL
    {
        Task<Task> Insert(InsertVacationPlanDTO plan);
        IEnumerable<VacationPlanDTO> GetVacationPlanByUserID(int userID);
        Task<Task> Update(VacationPlanDTO plan);
        //GetEditVacationPlanDTO GetVacationPlanAndPlanItemByPlanID(int planID);
    }
}
