using System;
using System.Collections.Generic;
using System.Text;

namespace Transreceptor_v1
{
    internal class Socorro
    {
        static public void MMSI(StringBuilder resultadoConChequeo, List<int> ECC, string numero)
        {
            List<int> mmsi = new List<int>();

            // Agrupar de 2 en 2
            List<string> grupos = AgruparDeDosEnDos(numero);
            foreach (string grupo in grupos)
            {
                int value = Convert.ToInt32(grupo, 10);
                mmsi.Add(value);
            }

            foreach (int mm in mmsi)
            {
                ECC.Add(mm);
                Convertir.ConvertirNumero(mm, resultadoConChequeo);
            }

        }

        static List<string> AgruparDeDosEnDos(string numero)
        {
            List<string> grupos = new List<string>();

            // Si es impar, agregar '0' al final
            if (numero.Length % 2 != 0)
            {
                numero += "0"; // se le agrega un 0 al final para completar el ultimo grupo de 2 (NORMA)
            }

            // Agrupar de 2 en 2
            for (int i = 0; i < numero.Length; i += 2)
            {
                string grupo = numero.Substring(i, 2);
                grupos.Add(grupo);
            }

            return grupos;
        }

        public static void NatureofDistress(StringBuilder resultadoConChequeo, List<int> ECC, int op)
        { 
            switch (op)
            {
                case 0:
                     Convertir.ConvertirNumero(100, resultadoConChequeo); ECC.Add(100);
                   break;
                case 1:
                    Convertir.ConvertirNumero(101, resultadoConChequeo); ECC.Add(101);
                   break;
                 case 2:
                     Convertir.ConvertirNumero(102, resultadoConChequeo); ECC.Add(102);
                    break;
                 case 3:
                      Convertir.ConvertirNumero(103, resultadoConChequeo); ECC.Add(103);
                    break;
                 case 4:
                      Convertir.ConvertirNumero(104, resultadoConChequeo); ECC.Add(104);
                    break;
                 case 5:
                     Convertir.ConvertirNumero(105, resultadoConChequeo); ECC.Add(105);
                    break;
                 case 6:
                      Convertir.ConvertirNumero(106, resultadoConChequeo); ECC.Add(106);
                    break;
                 case 7:
                     Convertir.ConvertirNumero(107, resultadoConChequeo); ECC.Add(107);
                    break;
                 case 8:
                     Convertir.ConvertirNumero(108, resultadoConChequeo); ECC.Add(108);
                    break;
                 case 9:
                     Convertir.ConvertirNumero(109, resultadoConChequeo); ECC.Add(109);
                    break;
                 case 10:
                    Convertir.ConvertirNumero(110, resultadoConChequeo); ECC.Add(110);
                    break;
                 default:
                    break;
            }
        }

        public static void Comunicacionsig(StringBuilder resultadoConChequeo, List<int> ECC, int op2)
        {

            switch (op2)
            {
                case 0:
                    Convertir.ConvertirNumero(100, resultadoConChequeo); ECC.Add(100);
                    break;
                case 1:
                    Convertir.ConvertirNumero(101, resultadoConChequeo); ECC.Add(101);
                    break;
                case 2:
                    Convertir.ConvertirNumero(109, resultadoConChequeo); ECC.Add(109);
                    break;
                case 3:
                    Convertir.ConvertirNumero(113, resultadoConChequeo); ECC.Add(113);
                    break;
                case 4:
                    Convertir.ConvertirNumero(115, resultadoConChequeo); ECC.Add(115);
                    break;
                case 5:
                    Convertir.ConvertirNumero(126, resultadoConChequeo); ECC.Add(126);
                    break;
                default:
                    break;
            }
            
        }

        public static void Posicion(StringBuilder resultadoConChequeo, List<int> ECC)
        { 
            // -38.04248790955501, -57.545178158600976  MDP
            Convertir.ConvertirNumero(33, resultadoConChequeo); ECC.Add(33);
            Convertir.ConvertirNumero(80, resultadoConChequeo); ECC.Add(80);
            Convertir.ConvertirNumero(40, resultadoConChequeo); ECC.Add(40);
            Convertir.ConvertirNumero(57, resultadoConChequeo); ECC.Add(57);
            Convertir.ConvertirNumero(54, resultadoConChequeo); ECC.Add(54);

            // Obtener zona horaria de Argentina
            TimeZoneInfo argentinaZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");

            // Convertir hora UTC a hora Argentina
            DateTime argentinaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, argentinaZone);

            int hora = argentinaTime.Hour;
            int minutos = argentinaTime.Minute;
            Convertir.ConvertirNumero(hora, resultadoConChequeo); ECC.Add(hora);
            Convertir.ConvertirNumero(minutos, resultadoConChequeo); ECC.Add(minutos);
        }
        static void SubCom()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║             ¿ Como sigue la comunicación ?            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

            Console.WriteLine("1. F3E/G3E ALL MODES TP");
            Console.WriteLine("2. F3E/G3E DUPLEX TP");
            Console.WriteLine("3. J3E TP");
            Console.WriteLine("4. F1B/J2B TTY-FEC");
            Console.WriteLine("5. F1B/J2B TTY-ARQ");
            Console.WriteLine("6. Sin información");

        }
    }
}