using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
        private string nameFile = @"lista de liquidacion.txt";
        private List<RegimenContributivo> listaLiquidacion;


        public void Registrar(LiquidacionCuotaModeradora liquidacion)
        {

            FileStream file = new FileStream(nameFile, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{liquidacion.NumeroLiquidacion};{liquidacion.IdPaciente};{liquidacion.TipoAfiliacion};" +
                $"{liquidacion.SalarioDevengado};{liquidacion.ValorSericio};{liquidacion.TarifaAplicada};" +
                $"{liquidacion.ValorLiquidadoReal};" +
                $"{liquidacion.TopeMaximo};{liquidacion.CuotaModeradora}");
            writer.Close();
            file.Close();
        }
      
       
    }
}
