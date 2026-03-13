using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Transreceptor_v1
{
    internal class Convertir
    {
        public static void ConvertirNumero(int leido, StringBuilder resultadoConChequeo)
        {
            

                if (leido >= 0 && leido <= 127)
                {
                    // Paso 1: Convertir a binario (7 bits)
                    string binario = Convert.ToString(leido, 2).PadLeft(7, '0');

                    // Paso 2: Invertir el orden de los bits (MSB ↔ LSB)
                    string binarioInvertido = InvertirBits(binario);

                    // Paso 3: Contar ceros en la secuencia invertida
                    int cantidadCeros = ContarCeros(binarioInvertido);

                    // Paso 4: Convertir cantidad de ceros a binario de 3 bits
                    string bitsChequeo = Convert.ToString(cantidadCeros, 2).PadLeft(3, '0');

                    // Paso 5: Agregar bits de chequeo al final (nuevo LSB)
                    string binarioFinal = binarioInvertido + bitsChequeo;


                    //resultadoConChequeo.Append(binarioFinal + " "); // Agregar espacio después de cada número convertido me mueve los indices
                    resultadoConChequeo.Append(binarioFinal);

            }
                else
                {
                    Console.WriteLine($"✗ Advertencia: {leido} está fuera del rango (0-127)");
                }
            
            

            // Función para invertir los bits
            static string InvertirBits(string binario)
            {
                return new string(binario.Reverse().ToArray());
            }

            // Función para contar los ceros en una cadena binaria
            static int ContarCeros(string binario)
            {
                return binario.Count(c => c == '0');
            }

        }
    }
}
