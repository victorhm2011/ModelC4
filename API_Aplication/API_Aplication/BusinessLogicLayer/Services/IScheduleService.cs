using API_Aplication.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Aplication.BusinessLogicLayer.Services
{
    public interface IScheduleService
    {
        public IEnumerable<ScheduleModel> GetSchedules();
        public ScheduleModel GetSchedule(int ScheduleId);
        public ScheduleModel CreateSchedule(ScheduleModel ScheduleModel);
        public bool DeleteSchedule(int ScheduleId);
        public ScheduleModel UpdateSchedule(int ScheduleId, ScheduleModel ScheduleModel);
    }
}
