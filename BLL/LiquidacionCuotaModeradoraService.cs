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
            List<LiquidacionCuotaModeradora> liquidaciones = new List<LiquidacionCuotaModeradora>();
            liquidaciones = repository.Consultar();

            foreach (LiquidacionCuotaModeradora liquidacion in liquidaciones)
            {
                if (numeroLiquidacion==liquidacion.NumeroLiquidacion)
                {
                    liquidaciones.Remove(liquidacion);
                    repository.Modificar(liquidaciones);
                }
            }
            
        }

        public void ActualizarLiquidacion(int numeroLiquidacion, double valorServicio)
        {
            List<LiquidacionCuotaModeradora> liquidaciones = new List<LiquidacionCuotaModeradora>();
            LiquidacionCuotaModeradora liquidacion1 = new LiquidacionCuotaModeradora();
            liquidaciones = repository.Consultar();
            foreach (LiquidacionCuotaModeradora liquidacion in liquidaciones)
            {
                if ((numeroLiquidacion==liquidacion.NumeroLiquidacion)&&(liquidacion.TipoAfiliacion== "regimen contributivo"))
                {
                    liquidacion1.ValorSericio = valorServicio;
                    liquidacion1.SalarioDevengado = liquidacion.SalarioDevengado;
                    liquidacion.CuotaModeradora = liquidacion1.CalcularCuotaModeradoraRegimenContributivo();
                    liquidacion.ValorLiquidadoReal = liquidacion1.ValorLiquidadoReal;
                    liquidacion.TopeMaximo = liquidacion1.TopeMaximo;

                    repository.Modificar(liquidaciones);
                }
                if ((numeroLiquidacion == liquidacion.NumeroLiquidacion) && (liquidacion.TipoAfiliacion == "regimen subsidiado"))
                {
                    liquidacion1.ValorSericio = valorServicio;
                    liquidacion1.SalarioDevengado = liquidacion.SalarioDevengado;
                    liquidacion.CuotaModeradora = liquidacion1.CalcularCuotaModeradoraRegimenSubsidiado();
                    liquidacion.ValorLiquidadoReal = liquidacion1.ValorLiquidadoReal;
                    liquidacion.TopeMaximo = liquidacion1.TopeMaximo;

                    repository.Modificar(liquidaciones);
                }
            }
        }
    }
}
