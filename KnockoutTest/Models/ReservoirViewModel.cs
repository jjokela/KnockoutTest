using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutTest.Models
{
    public class ReservoirViewModel : Reservoir
    {
        public List<TrapViewModel> TrapViewModels { get; set; }
        public ReservoirViewModel()
        {
            TrapViewModels = new List<TrapViewModel>();
        }

        public ReservoirViewModel(Reservoir reservoir)
        {
            TrapViewModels = new List<TrapViewModel>();
            ReservoirId = reservoir.ReservoirId;
            Name = reservoir.Name;

            foreach (var trap in reservoir.Traps)
            {
                TrapViewModels.Add(new TrapViewModel(trap));
            }
        }

    }
}