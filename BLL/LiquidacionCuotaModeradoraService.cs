﻿using System;
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
        private List<RegimenContributivo> liquidaciones;
        LiquidacionCuotaModeradoraRepository repository;
        public void RegistarLiquidacion(LiquidacionCuotaModeradora liquidacion)
        {
            repository = new LiquidacionCuotaModeradoraRepository();
            repository.Registrar(liquidacion);
        }
        
    }
}
