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
            int controlador=0;
            while (controlador==0)
            {
                switch (MostrarMenu())
                {
                    case 1: service.RegistarLiquidacion(RecibirDatos()); break;
                    case 2:
                        Console.WriteLine("------------CONSULTAR---------------------");
                        Console.WriteLine("NUMERO LIQUIDACION-ID PACIENTE-TIPO DE AFILIACION-SALARIO DEVENGADO-" +
                        "VALOR DEL SERVICIO-TARIFA APLICADA-VALOR DE LIQUIDACION REAL-TOPE MAXIMO-CUOTA MODERADORA");
                        foreach (LiquidacionCuotaModeradora liquidacion in service.ConsultarLiquidacion()) 
                        {
                            Console.WriteLine($"{liquidacion.NumeroLiquidacion}--{liquidacion.IdPaciente}--{liquidacion.TipoAfiliacion}--" +
                                $"{liquidacion.SalarioDevengado}--{liquidacion.ValorSericio}--{liquidacion.TipoAfiliacion}--{liquidacion.ValorLiquidadoReal}--" +
                                $"{liquidacion.TopeMaximo}--{liquidacion.CuotaModeradora}");
                        }  ; Console.ReadKey(); break;
                    case 3: Console.WriteLine("-------------ELIMINAR--------------");
                        Console.WriteLine("NUMERO DE LIQUIDACION: "); int numeroLiquidacion = Convert.ToInt32(Console.ReadLine());
                        service.EliminarLiquidacion(numeroLiquidacion);break;
                    case 4: Console.WriteLine("---------MODIFICAR VALOR DE SERVICIO---------");
                        Console.WriteLine("NUMERO DE LIQUIDACION: "); int numeroLiquidacion1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("VALOR DEL SERVICIO: "); int valorServicio = Convert.ToInt32(Console.ReadLine());
                        service.ActualizarLiquidacion(numeroLiquidacion1, valorServicio);break;
                    case 5: controlador = 1;break;
                    default:Console.WriteLine("ERROR AL DIGITAR LA OPCION");break;

                }
            }
        }

        public static int MostrarMenu()
        {
            int opcion;
            Console.WriteLine("---------------menu------------");
            Console.WriteLine("1. REGISTRAR LIQUIDACION");
            Console.WriteLine("2. CONSULTAR LISTA DE LIQUIDACION");
            Console.WriteLine("3. ELIMINAR LIQUIDACION");
            Console.WriteLine("4. MODIFICAR VALOR DEL SERVICIO");
            Console.WriteLine("5. SALIR");
            Console.WriteLine("DIGITE LA OPCION: ");
            opcion = Convert.ToInt32(Console.ReadLine());
            return opcion;
        }
        public static LiquidacionCuotaModeradora RecibirDatos()
        {
            LiquidacionCuotaModeradora liquidacion = new LiquidacionCuotaModeradora();
            Console.WriteLine("----------REGISTRAR-----------");
            Console.WriteLine("NUMERO DE LIQUIDACION: ");
            liquidacion.NumeroLiquidacion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("IDENTIFICACION DEL PACIENTE: ");
            liquidacion.IdPaciente = Console.ReadLine();
            Console.WriteLine("SALARIO DEVENGADO: ");
            liquidacion.SalarioDevengado = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("VALOR DEL SERVICIO: ");
            liquidacion.ValorSericio = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("1- regimen subsidiado");
            Console.WriteLine("2- regimen comtributivo");
            Console.WriteLine("DIGITE UNO DE LOS DOS TIPOS DE REGIMEN: ");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1: liquidacion.CuotaModeradora = liquidacion.CalcularCuotaModeradoraRegimenSubsidiado();break;
                case 2: liquidacion.CuotaModeradora = liquidacion.CalcularCuotaModeradoraRegimenContributivo();break;
                default:
                    Console.WriteLine("ERROR AL DIGITAR UNA DE LAS OPCIONES");
                    break;
            }
            return liquidacion;
        }

    }
}
