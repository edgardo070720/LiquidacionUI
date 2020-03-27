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
        private List<LiquidacionCuotaModeradora> listaLiquidacion;


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
        public List<LiquidacionCuotaModeradora> Consultar()
        {
            listaLiquidacion = new List<LiquidacionCuotaModeradora>();
            string line = string.Empty;
            FileStream file = new FileStream(nameFile, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while ((line=reader.ReadLine())!=null)
            {
                LiquidacionCuotaModeradora liquidacion = new RegimenContributivo();
                char separador = ';';
                string[] matrizLiquidacion = line.Split(separador);
                liquidacion.NumeroLiquidacion =Convert.ToInt32( matrizLiquidacion[0]);
                liquidacion.IdPaciente = matrizLiquidacion[1];
                liquidacion.TipoAfiliacion = matrizLiquidacion[2];
                liquidacion.SalarioDevengado =Convert.ToDouble( matrizLiquidacion[3]);
                liquidacion.ValorSericio = Convert.ToDouble(matrizLiquidacion[4]);
                liquidacion.TarifaAplicada = matrizLiquidacion[5];
                liquidacion.ValorLiquidadoReal = Convert.ToDouble(matrizLiquidacion[6]);
                liquidacion.TopeMaximo = matrizLiquidacion[7];
                liquidacion.CuotaModeradora = Convert.ToDouble(matrizLiquidacion[8]);
                listaLiquidacion.Add(liquidacion);
            }
            reader.Close();
            file.Close();
            return listaLiquidacion;
        }
    }
}
