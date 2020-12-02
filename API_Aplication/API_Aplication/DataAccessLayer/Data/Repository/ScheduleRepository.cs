using API_Aplication.DataAccessLayer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Aplication.DataAccessLayer.Data.Repository
{
    public class ScheduleRepository : IScheduleRepositiry
    {
        private List<ScheduleEntity> Schedules = new List<ScheduleEntity>(){
            new ScheduleEntity(){Id=1,Departure=new DateTime(2020,12,01),Arrival=new DateTime(2020,12,02),Origin= "Cochabamba", Destiny= "Santiago"},
            new ScheduleEntity(){Id=2,Departure=new DateTime(2020,12,06),Arrival=new DateTime(2020,12,10),Origin= "Cochabamba", Destiny= "Moscu"},
            new ScheduleEntity(){Id=3,Departure=new DateTime(2020,12,10),Arrival=new DateTime(2020,12,11),Origin= "Cochabamba", Destiny= "Beijing"},
            new ScheduleEntity(){Id=4,Departure=new DateTime(2020,12,22),Arrival=new DateTime(2020,12,24),Origin= "Cochabamba", Destiny= "Roma"}
        };
        public ScheduleEntity CreateSchedule(ScheduleEntity ScheduleEntity)
        {
            int ScheduleId;
            if (Schedules.Count() == 0)
            {
                ScheduleId = 1;
            }
            else
            {
                ScheduleId = Schedules.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }
            ScheduleEntity.Id = ScheduleId;
            Schedules.Add(ScheduleEntity);
            return ScheduleEntity;
        }

        public bool DeleteSchedule(int ScheduleId)
        {
            var ScheduleToDelete = GetSchedule(ScheduleId);
            Schedules.Remove(ScheduleToDelete);
            return true;
        }

        public ScheduleEntity GetSchedule(int ScheduleId)
        {
            return Schedules.FirstOrDefault(c => c.Id == ScheduleId);
        }

        public IEnumerable<ScheduleEntity> GetSchedules()
        {
            return Schedules;
        }

        public ScheduleEntity UpdateSchedule(int ScheduleId, ScheduleEntity ScheduleEntity)
        {
            var ScheduletoUpdate = GetSchedule(ScheduleEntity.Id);
            ScheduletoUpdate.Departure = ScheduleEntity.Departure ?? ScheduletoUpdate.Departure;
            ScheduletoUpdate.Arrival = ScheduleEntity.Arrival ?? ScheduletoUpdate.Arrival;
            ScheduletoUpdate.Origin = ScheduleEntity.Origin ?? ScheduletoUpdate.Origin;
            ScheduletoUpdate.Destiny = ScheduleEntity.Destiny ?? ScheduletoUpdate.Destiny;
            return ScheduletoUpdate;
        }
    }
}
