using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viboritas
{
    class Data
    {
        public string nombre;
        public string[] arreglo_de_secuencia;
        public ArrayList arreglo_de_datos;
        public ArrayList arreglo_Data= new ArrayList();

        public Data() {
            info();
        }

        public Data(string nombre,ArrayList arreglo_de_datos)
        {
            this.nombre = nombre;
            this.arreglo_de_datos = arreglo_de_datos;
        }

        private void info()
        {
            ArrayList vacio_a = new ArrayList();
            string[] vacio_s = new string[] { };
            arreglo_Data.Add(new Data("variables",vacio_s,vacio_a));
            arreglo_Data.Add(new Data("var", new string[] { "global", "tipo", "valor","nombre" }));
            arreglo_Data.Add(new Data("jugador", new string[] {"color","traje"}));
            arreglo_Data.Add(new Data("vidas", new string[] { "nombre" }));
            arreglo_Data.Add(new Data("poder", new string[] { "nombre" }));
            arreglo_Data.Add(new Data("remoto", new string[] { "nombre" }));
            arreglo_Data.Add(new Data("fantasma", new string[] { "nombre" }));
            arreglo_Data.Add(new Data("campo", new string[] { "ancho","alto","color","textura" }));
            arreglo_Data.Add(new Data("rocas", vacio_s, vacio_a));
            arreglo_Data.Add(new Data("tesoros", vacio_s, vacio_a));
            arreglo_Data.Add(new Data("roca", new string[] { "color","textura","durable" }));
            arreglo_Data.Add(new Data("Y", new string[] { "nombre" }));
            arreglo_Data.Add(new Data("X", new string[] { "nombre" }));
            arreglo_Data.Add(new Data("llave", new string[] { "color", "textura", "accion" }));
            arreglo_Data.Add(new Data("bono", new string[] { "color", "textura", "accion" }));
            arreglo_Data.Add(new Data("salida", new string[] { "color", "textura", "accion" }));
            arreglo_Data.Add(new Data("enemigo", new string[] { "color", "textura", "x" ,"y"}));
            arreglo_Data.Add(new Data("movimiento", new string[] { "mov"}));
            arreglo_Data.Add(new Data("movimientos", vacio_s, vacio_a));
            //< enemigo color = "verde" textura = "C:\lfyp2016\img\enemigo1.png" X = "0" Y = "9" >

            //     < movimientos >

            //         < movimiento > arriba <% movimiento >
        }

        public Data(string nombre,string[] arreglo_de_secuencia,ArrayList arreglo_de_datos) {
            this.nombre = nombre;
            this.arreglo_de_secuencia = arreglo_de_secuencia;
            this.arreglo_de_datos = arreglo_de_datos;
        }
        public Data(string nombre, string[] arreglo_de_secuencia)
        {
            this.nombre = nombre;
            this.arreglo_de_secuencia = arreglo_de_secuencia;
            this.arreglo_de_datos = new ArrayList();
        }
        public void set_arreglo_de_datos(ArrayList arreglo_de_datos)
        {
            this.arreglo_de_datos = arreglo_de_datos;
        }
    }
}
