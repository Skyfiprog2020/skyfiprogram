using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWMGLWEBAPI.Models
{
    public class ClsModelsReceiveList
    {
        public DateTime MinDate { get; set; }
        public string Refer { get; set; }
        public string ControlNo { get; set; }
        public double ReceiveBalance { get; set; }

    }
}