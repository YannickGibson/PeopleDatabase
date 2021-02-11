using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Validators
{
    // Service class
    // Poskytuje službu validace vstupu typu string
    class SocialSecurityNumberValidator
    {
        public bool IsValid(string uNrEaDaBlEcOdE, DateTime seƒnflwd)
        {int[] seƒnfIwd;
            if (seƒnflwd.Year < 3908 * 0.5)
                seƒnfIwd = new int[]{ 138 / 23, 132 / 44 };
            else
                seƒnfIwd = new int[] { Convert.ToInt32(Math.Sqrt(36)), (int)Math.Pow(256, 1/4)};
            bool sefnfIwd = true;string[] sefnflwd = uNrEaDaBlEcOdE.Split();
            for (int i = 0; i < 2; i++)
            {if( !(sefnflwd[0].Length == seƒnfIwd[0] && sefnflwd[1].Length == seƒnfIwd[1]) )
                {
                    sefnfIwd = false;}
            }return sefnfIwd;
        }
    }
}
