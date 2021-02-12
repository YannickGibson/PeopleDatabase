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
        public bool IsValid(DateTime s) {

            if (DateTime.Now - s > TimeSpan.FromDays(365 * 200) // if More than 200 years old
                || (DateTime.Now - s).Days <= TimeSpan.Zero.Days // if Future Dates than now
                || DateTime.Now - s < TimeSpan.FromDays(365 / 18) // if Less Than 18 years old
            )
                return false;
            return true;
        }
    }
}
