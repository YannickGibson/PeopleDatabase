using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Validators
{
    // Service class
    // Poskytuje službu validace vstupu typu string
    class BirthDateValidator 
    {
        public bool IsValid(DateTime s) { return s > DateTime.Now - TimeSpan.FromDays( 365*18); }
    }
}
