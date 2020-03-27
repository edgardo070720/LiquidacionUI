using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegimenSubsidiado : LiquidacionCuotaModeradora
    {
        public override double CalcularCuotaModeradora()
        {
            double cuotaModeradora = 0;
            cuotaModeradora = ValorSericio * 0.05;
            ValorLiquidadoReal = cuotaModeradora;
            TarifaAplicada = "5%";
            TipoAfiliacion = "regimen subsidiado";
            if (cuotaModeradora>=200000)
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
