using CalculadoraNumerosPrimos_Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNumerosPrimos_Domain
{
    public class CalculoDomain
    {
        public static List<CalcularDTO> CalcularNumero(CalcularDTO calcularDTO)
        {   List<CalcularDTO> returnData = new List<CalcularDTO>();

            for (int i = calcularDTO.RangoMenor; i <= calcularDTO.RangoMayor; i++)
            {
                bool esPrimo = true;
                if (i < 2)
                {
                    esPrimo = false;
                }
                else
                {
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            esPrimo = false;
                            break;
                        }
                    }
                }

                if (esPrimo)
                {
                    returnData.Add(new CalcularDTO { numeroPrimo = i });
                }
            }
            return returnData;
        }

    }
}
