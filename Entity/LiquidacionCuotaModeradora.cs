using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class LiquidacionCuotaModeradora
    {
        public int NumeroLiquidacion { get; set; }
        public string IdPaciente { get; set; }
        public string TipoAfiliacion { get; set; } 
        public double ValorSericio { get; set; }
        public double CuotaModeradora { get; set; }
        public double SalarioDevengado { get; set; }
        public string TarifaAplicada { get; set; }
        public double ValorLiquidadoReal { get; set; }
        public string TopeMaximo { get; set; }
        public  double CalcularCuotaModeradoraRegimenContributivo()
        {
            double cuotaModeradora = 0;
            TipoAfiliacion = "regimen contributivo";
            if (SalarioDevengado < 1755606)
            {
                cuotaModeradora = ValorSericio * 0.15;
                ValorLiquidadoReal = cuotaModeradora;
                TarifaAplicada = "15%";
                if (cuotaModeradora >= 250000)
                {
                    cuotaModeradora = 250000;
                    TopeMaximo = "aplica";
                }
                else
                {
                    TopeMaximo = "no aplica";
                }
            }
            if ((SalarioDevengado >= 1755606) && (SalarioDevengado <= 4386015))
            {
                cuotaModeradora = ValorSericio * 0.20;
                ValorLiquidadoReal = cuotaModeradora;
                TarifaAplicada = "20%";
                if (cuotaModeradora >= 900000)
                {
                    cuotaModeradora = 900000;
                    TopeMaximo = "aplica";
                }
                else
                {
                    TopeMaximo = "no aplica";
                }
            }
            if (SalarioDevengado > 4386015)
            {
                cuotaModeradora = ValorSericio * 0.25;
                ValorLiquidadoReal = cuotaModeradora;
                TarifaAplicada = "25%";
                if (cuotaModeradora >= 1500000)
                {
                    cuotaModeradora = 1500000;
                    TopeMaximo = "aplica";
                }
                else
                {
                    TopeMaximo = "no aplica";
                }
            }
            return cuotaModeradora;
        }
        public double CalcularCuotaModeradoraRegimenSubsidiado()
        {
            double cuotaModeradora = 0;
            cuotaModeradora = ValorSericio * 0.05;
            ValorLiquidadoReal = cuotaModeradora;
            TarifaAplicada = "5%";
            TipoAfiliacion = "regimen subsidiado";
            if (cuotaModeradora >= 200000)
            {
                cuotaModeradora = 200000;
                TopeMaximo = "aplica";
            }
            else
            {
                TopeMaximo = "no aplica";
            }
            return cuotaModeradora;
        }
    }
}
