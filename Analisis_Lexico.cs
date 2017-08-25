using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace viboritas
{
    class Analisis_Lexico
    {

        Analisis_Sintactico sintactico = new Analisis_Sintactico();
        public ArrayList prueba_d=new ArrayList();
        static ArrayList prueba;
        static int[] F_Comando = new int[] { 9 };
        static int[,] Tabla_Comando = new int[,] { { 1, -1, -1, -1, -1, -1, -1, 0 }, { -1, 2, 3, -1, -1, -1, -1, 1 }, { -1, -1, 3, -1, -1, -1, -1, 2 }, { -1, -1, 4, 5, -1, -1, 9, 3 }, { -1, -1, 4, 5, -1, -1, 9, 4 }, { -1, -1, -1, -1, 6, -1, -1, 5 }, { -1, -1, 6, -1, 8, 7, -1, 6 }, { -1, -1, 6, -1, 8, 7, -1, 7 }, { -1, -1, 4, -1, -1, -1, 9, 8 }, { -1, -1, -1, -1, -1, -1, -1, 9 } };
        static int[,] Tabla_Linea = new int[,] { { 1, -1, -1, -1, -1, -1, -1, 0 }, { -1, 2, 3, -1, -1, -1, -1, 1 }, { -1, -1, 3, -1, -1, -1, -1, 2 }, { -1, -1, 4, 5, -1, -1, 9, 3 }, { -1, -1, 4, 5, -1, -1, 9, 4 }, { -1, -1, -1, -1, 6, -1, -1, 5 }, { -1, -1, 6, -1, 8, 7, -1, 6 }, { -1, -1, 6, -1, 8, 7, -1, 7 }, { -1, -1, 4, -1, -1, -1, 9, 8 }, { 1, -1, 9, -1, -1, 9, -1, 9 } };
        public Analisis_Lexico()
        {
            AbstractAutomata automata1 = new Comando(F_Comando, Tabla_Comando);
            AbstractAutomata automata2 = new Comando(F_Comando, Tabla_Linea);
            Lector arreglo = new Lector();
            int line = 0;
            bool if_check = false;
            string linea = "<var global tipo = \"Entero\" valor = \"320\">numero_E<%var>";
            prueba = arreglo.Arreglo_de_archivo("mapa1.xml");
            int errores = 0;
            List<string> lineas_sintacticas = new List<string>();
            List<string> ver = new List<string>();
            foreach (string sOutput in prueba)
            {
                line++;
                bool valida1_comando = automata1.RecognizeToken(sOutput, line, true);
                bool valida1_linea = automata2.RecognizeToken(sOutput, line, true);
                if (valida1_comando)
                {
                    ver = automata1.Retornar_Palabra_Concatenada().Split(new[] { "," },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (ver[0] == "accion" && !if_check)
                    {
                        if_check = true;
                    }
                    else
                    {
                        if_check = false;
                    }
                }
                else if (valida1_linea)
                {
                    ver = automata2.Retornar_Palabra_Concatenada().Split(new[] { "," },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else if (if_check)
                {

                }
                else
                {
                    Console.WriteLine("linea: " + line + "Error: " + sOutput);
                    errores++;
                }
                ////Console.WriteLine("linea: "+line);
                foreach (string item in ver)
                {
                    lineas_sintacticas.Add(item);
                    //Console.WriteLine(item);
                }
                //Console.WriteLine(" ");
            }
            Console.WriteLine("Cantidad de errores encontrados: " + errores);
            if (errores == 0)
            {
                Console.WriteLine("Archivo sin errores Lexicos ");
                sintactico.Analizar(lineas_sintacticas);
                prueba_d = sintactico.general2;
            }
            else
            {
                Console.WriteLine("Archivo contiene errores Lexicos ");
            }

        }
    }
}
