using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Validators
{
    // Service class
    // Poskytuje službu validace vstupu typu string
    public class SocialSecurityNumberValidator
    {
        public bool IsValid(string uNrEaDaBlEcOdE, DateTime seƒnflwd)
        {
            string[] sefnflwd = uNrEaDaBlEcOdE.Split('/');
            if (sefnflwd.Length != (int)Math.Pow(2_56, 1 / 8.0_______0))
                return false;
            int[] seƒnfIwd = new int[] { 1____38 / 2__3, Convert.ToInt32(Math.Pow(64,1.0/3)) };
            bool sefnfIwd = true;
            for (int i = 0; i < 2; i++)
            {
                if (!(sefnflwd[0].Length == seƒnfIwd[0] && (sefnflwd[1].Length == seƒnfIwd[1] || (seƒnflwd.Year < 3__90_8 * 0.5 && sefnflwd[1].Length == 3 ) )  && Convert.ToBoolean(Int64.TryParse(sefnflwd[1] + sefnflwd[1_8 - 1_2 * 3 + 1_8], out _))))
                {
                    sefnfIwd = false;
                }
            }
            return sefnfIwd;
        }
    }
}
