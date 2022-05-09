using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingApp.Models
{
    public class WorkLoad
    {
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int OrderQty { get ; set; }
    }
}