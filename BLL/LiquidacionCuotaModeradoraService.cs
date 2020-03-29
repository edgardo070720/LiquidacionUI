using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    
    public class LiquidacionCuotaModeradoraService
    {
        List<LiquidacionCuotaModeradora> liquidaciones;
        LiquidacionCuotaModeradoraRepository repository = new LiquidacionCuotaModeradoraRepository();
        public void RegistarLiquidacion(LiquidacionCuotaModeradora liquidacion)
        {
            
            repository.Registrar(liquidacion);
        }
        public List<LiquidacionCuotaModeradora> ConsultarLiquidacion()
        {
           
            return repository.Consultar();
        }
        public void EliminarLiquidacion(int numeroLiquidacion)
        {
            int control = 0;
             liquidaciones = new List<LiquidacionCuotaModeradora>();
            liquidaciones = repository.Consultar();

            foreach (LiquidacionCuotaModeradora liquidacion in liquidaciones)
            {
                if (numeroLiquidacion==liquidacion.NumeroLiquidacion)
                {
                    liquidaciones.Remove(liquidacion);
                    repository.Modificar(liquidaciones);
                    control =1;
                    Console.WriteLine("SE ELIMINO CORRECTAMENTE");
                }
            }
            if (control==0)
            {
                Console.WriteLine("NO SE ENCONTRO LIQUIDACION SON ESE NUMERO");
            }
        }

        public void ActualizarLiquidacion(int numeroLiquidacion, double valorServicio)
        {
            
            List<LiquidacionCuotaModeradora> liquidaciones = new List<LiquidacionCuotaModeradora>();
            LiquidacionCuotaModeradora liquidacion1 = new LiquidacionCuotaModeradora();
            liquidaciones = repository.Consultar();
            foreach (LiquidacionCuotaModeradora liquidacion in liquidaciones)
            {
                if ((numeroLiquidacion==liquidacion.NumeroLiquidacion))
                {
                   
                    if (liquidacion.TipoAfiliacion == "regimen contributivo")
                    {
                        liquidacion1.ValorSericio = valorServicio;
                        liquidacion1.SalarioDevengado = liquidacion.SalarioDevengado;
                        liquidacion.CuotaModeradora = liquidacion1.CalcularCuotaModeradoraRegimenContributivo();
                        liquidacion.ValorLiquidadoReal = liquidacion1.ValorLiquidadoReal;
                        liquidacion.TopeMaximo = liquidacion1.TopeMaximo;
                        Console.WriteLine("SE MODIFICO EL VALOR CORECTAMENTE");
                        repository.Modificar(liquidaciones);
                        
                    }
                }
                if ((numeroLiquidacion == liquidacion.NumeroLiquidacion)  )
                {
                  
                    if (liquidacion.TipoAfiliacion == "regimen subsidiado")
                    {
                        liquidacion1.ValorSericio = valorServicio;
                        liquidacion1.SalarioDevengado = liquidacion.SalarioDevengado;
                        liquidacion.CuotaModeradora = liquidacion1.CalcularCuotaModeradoraRegimenSubsidiado();
                        liquidacion.ValorLiquidadoReal = liquidacion1.ValorLiquidadoReal;
                        liquidacion.TopeMaximo = liquidacion1.TopeMaximo;
                        Console.WriteLine("SE MODIFICO EL VALOR CORECTAMENTE");
                        repository.Modificar(liquidaciones);
                        
                    }
                }
            }

        }

        public int Validar(int numeroLiquidacion)
        {
            int control = 0;
            List<LiquidacionCuotaModeradora> liquidaciones = new List<LiquidacionCuotaModeradora>();
            liquidaciones = repository.Consultar();
            foreach (LiquidacionCuotaModeradora liquidacion in liquidaciones)
            {
                if ((numeroLiquidacion == liquidacion.NumeroLiquidacion))
                {
                    control = 1;
                }
                if ((numeroLiquidacion == liquidacion.NumeroLiquidacion))
                {
                    control = 1;
                }
            }
            if (control == 0)
            {
                Console.WriteLine("NO SE ENCONTRO LIQUIDACION CON ESE NUMERO");
            }
            return control;
        }
    }
}
