using API_Aplication.BusinessLogicLayer.Models;
using API_Aplication.DataAccessLayer.Data.Entities;
using API_Aplication.DataAccessLayer.Data.Repository;
using API_Aplication.REST_Layer.Exceptions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Aplication.BusinessLogicLayer.Services
{
    public class ScheduleService : IScheduleService
    {
        
        private IScheduleRepositiry _scheduleRepository;
        private IMapper _mapper;
        public ScheduleModel CreateSchedule(ScheduleModel ScheduleModel)
        {
            var entityreturned = _scheduleRepository.CreateSchedule(_mapper.Map<ScheduleEntity>(ScheduleModel));

            return _mapper.Map<ScheduleModel>(entityreturned);
        }

        public bool DeleteSchedule(int ScheduleId)
        {
            var ScheduleToDelete = GetSchedule(ScheduleId);
            return _scheduleRepository.DeleteSchedule(ScheduleId);
        }

        public ScheduleModel GetSchedule(int ScheduleId)
        {
            var Schedule = _scheduleRepository.GetSchedule(ScheduleId);

            if (Schedule == null)
            {
                throw new NotFoundException($"The Schedule {ScheduleId} doesnt exists, try it with a new id");
            }

            return _mapper.Map<ScheduleModel>(Schedule);
        }

        public IEnumerable<ScheduleModel> GetSchedules()
        {
            var entityList = _scheduleRepository.GetSchedules();
            var modelList = _mapper.Map<IEnumerable<ScheduleModel>>(entityList);
            return modelList;
        }

        public ScheduleModel UpdateSchedule(int ScheduleId, ScheduleModel ScheduleModel)
        {
            var ScheduleToUpdate = _scheduleRepository.UpdateSchedule(ScheduleId,_mapper.Map<ScheduleEntity>(ScheduleModel));

            return _mapper.Map<ScheduleModel>(ScheduleToUpdate);
        }
    }
}
