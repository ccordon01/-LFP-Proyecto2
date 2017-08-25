using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viboritas
{
    class Comando : AbstractAutomata
    {
        public ArrayList words=new ArrayList();
        
        String palabra_concatenada="";
        int error = 0;
        int linea = 0;
        int columna = 0;
        bool conc = false;
        bool concom = false;
        bool Reconocedor_errores = true;
        bool Reconocedor_entrada_salida = true;
        public Comando(int[] F, int[,] stateTable) : base(F, stateTable)
        {
            ar_words = words;
        }

        public override int GetState(int s, char c,int col)
        {
            columna=col;
            if (col == 1) {
                words.Clear();
                error = 0;
                palabra_concatenada = "";
                Reconocedor_entrada_salida = true;
            }
            int n= Encoding.ASCII.GetBytes(c.ToString())[0];
            //Console.WriteLine(n);
            if ((n >= 65 && n <= 90) || (n >= 97 && n <= 122))
            {
                //Console.WriteLine(_stateTable[s, 2]);
                //Console.WriteLine("char: "+c+ " estado: "+ _stateTable[s, 2]);
                if (conc) {
                    Concatenar(c);
                }
                return _stateTable[s, 2];
            }
            else if (n == 60)
            {

                concom = false;
                //Console.WriteLine(_stateTable[s, 0]);
                //Console.WriteLine("char: " + c + " estado: " + _stateTable[s, 0]);
                if (_stateTable[s, 0]!= -1) {
                    conc = true;
                }
                if (conc && palabra_concatenada != "")
                {
                    //Console.WriteLine(palabra_concatenada);
                    //conc = false;
                    Concatenar(',');
                    //words.Add(palabra_concatenada);
                    //palabra_concatenada = "";
                    
                }
                else
                {
                    conc = true;
                }
                return _stateTable[s, 0];
            }
            else if (n == 37)
            {
                //Console.WriteLine(_stateTable[s, 1]);
                Reconocedor_entrada_salida = false;
                //Console.WriteLine("char: " + c + " estado: " + _stateTable[s, 1]);
                return _stateTable[s, 1];
            }
            else if (n == 62)
            {

                Concatenar(',');
                //Console.WriteLine(_stateTable[s, 6]);
                //Console.WriteLine("char: " + c + " estado: " + _stateTable[s, 6]);
                if (concom)
                {
                    concom = false;
                }
                else
                {
                    concom = true;
                }
                return _stateTable[s, 6];
            }
            else if (n == 34)
            {
                if (conc && palabra_concatenada != "")
                {
                    //Console.WriteLine(palabra_concatenada);
                    //conc = false;
                    Concatenar(',');
                    //words.Add(palabra_concatenada);
                    //palabra_concatenada = "";
                    if (concom)
                    {
                        concom = false;
                    }
                    else {
                        concom = true;
                    }
                }
                else
                {
                    conc = true;
                }
                //Console.WriteLine(_stateTable[s, 4]);
                //Console.WriteLine("char: " + c + " estado: " + _stateTable[s, 4]);
                return _stateTable[s, 4];
            }
            else if (n == 61)
            {
                //Console.WriteLine(_stateTable[s, 3]);
                //Console.WriteLine("char: " + c + " estado: " + _stateTable[s, 3]);
                return _stateTable[s, 3];
            }
            else if (n == 32 || n==9 || n==11)
            {
                //Console.WriteLine(_stateTable[s, 7]);
                //Console.WriteLine("char: " + c + " estado: " + _stateTable[s, 7]);
                if (conc && palabra_concatenada != "")
                {
                    //conc = false;
                    if (concom)
                    {
                        Concatenar(c);
                    }
                    else
                    {
                        //Console.WriteLine(palabra_concatenada);
                        Concatenar(',');
                        //words.Add(palabra_concatenada);
                        //palabra_concatenada = "";
                    }
                }
                else {
                    conc = true;
                }
                return _stateTable[s, 7];
            }
            else
            {
                if (conc)
                {
                    if (concom)
                    {
                        Concatenar(c);
                    }
                    else
                    {
                        //Console.WriteLine(palabra_concatenada);
                        Concatenar(',');
                        //words.Add(palabra_concatenada);
                        //palabra_concatenada = "";
                    }
                }
                //Console.WriteLine(-1);
                if (_stateTable[s, 5]==-1) {
                    error++;
                    //Console.WriteLine("Error Linea: " + linea + " Columna: " + columna + " Caracter: " + c);
                    columna = 0;
                }
                //Console.WriteLine("char: " + c + " estado: " + _stateTable[s, 5]);
                return _stateTable[s, 5];
            }

        }

        public void Concatenar(char c)
        {
            palabra_concatenada += c.ToString();
        }

        public override String Retornar_Palabra_Concatenada() {
            String temporal = palabra_concatenada;
            ///palabra_concatenada = "";
            columna = 0;
            return temporal;
        }

        public override bool RecognizeToken(string inputString, int line, bool erroes)
        {
            Reconocedor_errores = erroes;
            linea = line;
            return RecognizeBase(inputString);
        }

        public override int Retornar_Tipo_Etiqueta() {
            bool aux_reconocedor = Reconocedor_entrada_salida;
            ///Reconocedor_entrada_salida = true;
            if (aux_reconocedor){
                return 1;
            }
            else{
                return 0;
            }
            
        }
    }
}
