using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Domain;


namespace BlusukYogya.Data.Interface
{
    public interface IVacationPlanData : ICrudData<VacationPlan>
    {
        Task TransactionInsert(VacationPlan entity);
        IEnumerable<VacationPlan> GetVacationPlanByUserID(int userID);
        VacationPlan GetVacationPlanAndPlanItemByPlanID(int planID);
    }
}
