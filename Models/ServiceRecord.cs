using System;

namespace LifeManager_BlazorServerUI.Models
{
    public class ServiceRecord
    {
        public int Id { get; set; }
        public DateTime ServiceTimeStamp { get; set; }
        public string ServiceLocation { get; set; }
        public decimal Cost { get; set; }
        public string ServiceNotes { get; set; }
    }
}
