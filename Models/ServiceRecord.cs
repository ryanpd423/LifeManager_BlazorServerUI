using System;

namespace LifeManager_BlazorServerUI.Services
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
