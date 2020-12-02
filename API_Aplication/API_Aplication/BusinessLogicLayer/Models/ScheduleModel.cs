using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Aplication.BusinessLogicLayer.Models
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public String Origin { get; set; }
        public String Destiny { get; set; }
    }
}
