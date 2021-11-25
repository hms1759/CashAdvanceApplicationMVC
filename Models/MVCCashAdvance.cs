using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyApplication.Models
{
    public class MVCCashAdvance
    {
        public int Id { get; set; }
        public string requestBy { get; set; }
        public string requestDate { get; set; }
        public string approvedDate { get; set; }
        public string approvedBY { get; set; }
        public string requestStatus { get; set; }
        public int Employee_Id { get; set; }
        public decimal amount { get; set; }
        public string department { get; set; }
    }
}
