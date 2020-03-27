using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionCuotaModeradora
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
        public abstract double CalcularCuotaModeradora();
       
    }
}
