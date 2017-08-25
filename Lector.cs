using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace viboritas
{
    class Lector
    {

        public ArrayList Arreglo_de_archivo(String InputString) {
            StreamReader objReader = new StreamReader(InputString);
            string sLine = "";
            ArrayList arrText = new ArrayList();
            sLine = objReader.ReadLine();
            while (sLine != null)
            {
                List<string> listaTextoP = sLine.Split(new[] { "\n" },
            StringSplitOptions.RemoveEmptyEntries).ToList();
                //Console.WriteLine(sLine+" - "+listaTextoP.Count());
                ///Console.WriteLine(Encoding.ASCII.GetBytes(sLine)[0]);
                if (sLine != null || sLine!= Convert.ToChar(11).ToString() ) {
                    if (sLine.Count() > 0 && listaTextoP.Count() > 0)
                    {
                        arrText.Add(sLine);
                    }
                }
                sLine = objReader.ReadLine();
                ///Console.WriteLine(sLine + " tamaño: " + sLine.Length);
            }
            objReader.Close();
            return arrText;
        }
    }
}
