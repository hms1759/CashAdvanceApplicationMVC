using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyApplication.Models
{
    public class MMvcCashAdvance
    {
        public int Id { get; set; }
        public string requestBy { get; set; }
        public string requestDate { get; set; }
        public string approvedDate { get; set; }
        public string approvedBY { get; set; }
        public string requestStatus { get; set; }
        public int Employee_Id { get; set; }
        public string amount { get; set; }
        public string department { get; set; }

        public string LOginErrorMessage { get; set; }
    }
}
