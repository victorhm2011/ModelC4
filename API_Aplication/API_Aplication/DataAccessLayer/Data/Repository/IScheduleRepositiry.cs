using API_Aplication.DataAccessLayer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Aplication.DataAccessLayer.Data.Repository
{
    public interface IScheduleRepositiry
    {
        public IEnumerable<ScheduleEntity> GetSchedules();
        public ScheduleEntity GetSchedule(int ScheduleId);
        public ScheduleEntity CreateSchedule(ScheduleEntity ScheduleEntity);
        public bool DeleteSchedule(int ScheduleId);
        public ScheduleEntity UpdateSchedule(int ScheduleId, ScheduleEntity ScheduleEntity);
    }
}
