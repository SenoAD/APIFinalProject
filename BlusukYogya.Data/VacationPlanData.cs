using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlusukYogya.Data
{
    public class VacationPlanData : IVacationPlanData
    {
        private readonly YogyaBlusukContext _context;
        public VacationPlanData(YogyaBlusukContext yogyaBlusukContext)
        {
            _context = yogyaBlusukContext;
        }
        public Task Create(VacationPlan entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VacationPlan> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VacationPlan>> GetAll()
        {
            throw new NotImplementedException();
        }

        public VacationPlan GetVacationPlanAndPlanItemByPlanID(int planID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VacationPlan> GetVacationPlanByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task TransactionInsert(VacationPlan entity)
        {
                    _context.VacationPlans.Add(entity);
                    await _context.SaveChangesAsync();
        }


        public async Task Update(VacationPlan entity)
        {
            var data = await _context.VacationPlans.Include(c => c.PlanItems).Where(c=> c.PlanId == entity.PlanId).SingleOrDefaultAsync();
            
            data.Name = entity.Name;
            data.Description = entity.Description;
            data.IsPublic = entity.IsPublic;
            data.PlanItems = entity.PlanItems;
            await _context.SaveChangesAsync();
        }
    }
}
