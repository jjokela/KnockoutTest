using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutTest.Models
{
    public class TrapViewModel : Trap
    {
        public bool Selected { get; set; }

        public TrapViewModel()
        {

        }

        public TrapViewModel(Trap trap)
        {
            TrapId = trap.TrapId;
            Name = trap.Name;
            Selected = false;
            Details = trap.Details;
        }
    }
}