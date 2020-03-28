using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace LiquidacionUI
{
    class Program
    {
        static void Main(string[] args)
        {
            LiquidacionCuotaModeradoraService service = new LiquidacionCuotaModeradoraService();

            int numeroLiquidacion = Convert.ToInt32(Console.ReadLine());
            double valorServicio = Convert.ToDouble(Console.ReadLine());
            service.ActualizarLiquidacion(numeroLiquidacion, valorServicio);


            Console.ReadKey();
        }
    }
}
