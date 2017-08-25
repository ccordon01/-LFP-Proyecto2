using System;
using System.Collections;
using System.Collections.Generic;

namespace viboritas
{
    class Analisis_Sintactico
    {

        rall ral = new rall();
        Data d = new Data();
        ArrayList pila = new ArrayList();
        ArrayList lista = new ArrayList();
        ArrayList comandos = new ArrayList();
        ArrayList var = new ArrayList();
        ArrayList jugador = new ArrayList();
        ArrayList vpr = new ArrayList();
        ArrayList roca = new ArrayList();
        ArrayList general1 = new ArrayList();
        ArrayList generalmove = new ArrayList();
        ArrayList generalmoves = new ArrayList();
        ArrayList generalmovesx = new ArrayList();
        ArrayList generalmovesc = new ArrayList();
        ArrayList generalmovesw = new ArrayList();
        List<generalmove> generalmovesv = new List<generalmove>();
        string move = "";
        public ArrayList general2 = new ArrayList();
        String[] Palabras_Reservadas = new String[] { "variables","jugador","roca","llave","bono","salida","enemigo","movimiento"};
        String[] Palabras_Reservadas_Etiquetas = new String[] { "campo","tesoros" };
        bool pila_c = true;
        bool etiqueta = false;
        public void Analizar(List<string> lineas_sintacticas)
        {
            bool add_data = false;
            bool movv = false;
            ArrayList lista_aux = new ArrayList();
            foreach (string item in lineas_sintacticas)
            {
                //Console.WriteLine(item);
                if ("movimientos"==item) {
                    if (generalmovesc.Count != 0)
                    {
                        Console.WriteLine("entro");
                        movv = false;
                        generalmovesx.Add(generalmovesc);
                        generalmovesc = new ArrayList();
                    }
                    else {
                        movv = true;
                    }
                }
                if (movv) {
                    generalmovesc.Add(item);
                }
                if (pila_control(item))
                {
                    if (etiquetas_control(item)) {
                        if (etiqueta)
                        {
                            //Console.WriteLine("Termina: " + item);
                            etiqueta = false;
                        }
                        else
                        {
                            //Console.WriteLine("Inicia: " + item);
                            etiqueta = true;
                        }
                    }
                    pila_add(item);
                    pila_c = pila_b(item, false);
                    if (add_data)
                    {
                        if (lista_aux.Count != 0)
                        {
                            //Console.WriteLine("inserte1: "+item);
                            lista.Add(lista_aux);
                        }
                        lista_aux = new ArrayList();
                    }
                    if (!pila_c)
                    {
                        add_data = true;
                    }
                    else
                    {
                        add_data = false;
                        if (lista_aux.Count != 0)
                        {
                            //Console.WriteLine("inserte2: " + item);
                            lista.Add(lista_aux);
                        }
                    }
                }
                if (add_data)
                {
                    //Console.WriteLine("inserte3: " + item);
                    lista_aux.Add(item);
                }
                else
                {
                    lista_aux = new ArrayList();
                }
            }
            if (pila.Count == 0)
            {
                //Console.WriteLine("analisis perfecto");
                foreach (ArrayList var in lista)
                {
                    ArrayList lista_aux_data = new ArrayList();
                    //Console.WriteLine("esto encontro: " + var[0] + " - "+var.Count);
                    if (var.Count > 1)
                    {
                        //Console.WriteLine("muestraaaa   " + var[1]);
                    }
                    foreach (Data item in d.arreglo_Data)
                    {
                        if (item.nombre.Equals(var[0]))
                        {
                            int lad = 0;
                            lista_aux_data.Add(var[0]);
                            for (int i = 1; i < (var.Count - 1); i++)
                            {
                                foreach (string item_i in item.arreglo_de_secuencia)
                                {
                                    if (var[i].Equals(item_i))
                                    {
                                        if (var[i].Equals("global"))
                                        {
                                            lista_aux_data.Add(var[i]);
                                        }
                                        else
                                        {
                                            lad = i + 1;
                                            lista_aux_data.Add(var[i + 1]);
                                        }
                                    }
                                }
                            }
                            if (var.Count > 1 && (var.Count - 1) != lad)
                            {
                                lista_aux_data.Add(var[var.Count - 1]);
                            }
                            item.set_arreglo_de_datos(lista_aux_data);
                            comandos.Add(lista_aux_data);
                            lista_aux_data = new ArrayList();
                        }
                    }
                }
                foreach (ArrayList item in comandos)
                {
                    String show = "";
                    foreach (string item1 in item)
                    {
                        show = show + item1 + ",";
                    }
                    revision(show);
                    //Console.WriteLine(show);
                }
                foreach (rall item in roca)
                {
                    //Console.WriteLine("find this: "+item.get());
                }
                foreach (ArrayList item in generalmovesx)
                {
                    bool active = false;
                    int i = 0;
                    string wordaux = "";
                    generalmovesv = new List<generalmove>();
                    foreach (string item1 in item)
                    {

                        if (item1 != "movimiento")
                        {
                            active = true;
                            if (i == 0)
                            {
                                Console.WriteLine(item1);
                                wordaux = item1;
                            }
                            else {
                                generalmovesv.Add(new generalmove(wordaux,(i-1)));
                                Console.WriteLine(i);
                                i = 0;
                                Console.WriteLine(item1);
                                wordaux = item1;
                            }
                        }
                        else {
                            if (active) {
                                i++;
                                Console.WriteLine(i);
                            }
                        }
                    }
                    generalmovesv[generalmovesv.Count - 1].v = generalmovesv[generalmovesv.Count - 1].v + 1;
                    generalmovesw.Add(generalmovesv);
                }
                foreach (List<generalmove> item in generalmovesw)
                {
                    Console.WriteLine("--------");
                    foreach (generalmove ite in item)
                    {
                        for (int i = 0; i < ite.v; i++)
                        {
                            generalmove.Add(ite.wordaux);
                            Console.WriteLine(ite.wordaux);
                        }
                    }
                    Console.WriteLine("--------");

                    generalmoves.Add(generalmove);
                    generalmove = new ArrayList();
                }
                general2.Add(new send("roca",roca));
                general2.Add(new send("jugador",jugador));
                general2.Add(new send("enemigo", general1));
                general2.Add(new send("movimientos", generalmoves));
            }
            else
            {
                //Console.WriteLine("analisis erroneo " + pila.Count + " etiquetas incompletas");
                foreach (var item in pila)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void revision(string s) {
            string[] datos = s.Split(',');
            //Console.WriteLine(s);
            //Console.WriteLine("entra " + datos[0]);
            switch (datos[0]) {
                case "var":
                    bool g1 = false;
                    if (datos[1] == "global")
                    {
                        g1 = true;
                        var.Add(new vvar(g1, datos[1], datos[2], datos[3]));
                    }
                    else {
                        var.Add(new vvar(g1, datos[0], datos[1], datos[2]));
                    }
                    break;
                case "jugador":
                    jugador.Add(new jjugador(datos[1], datos[2]));
                    break;

                case "roca":
                    //Console.WriteLine(datos[0]+datos[1]+datos[2]+datos[3]);
                    ral= new rall(datos[0], datos[1], datos[2], datos[3], 0, 0);
                    break;
                case "llave":
                    ral = new rall(datos[0], datos[1], datos[2], datos[3], 0, 0);
                    break;
                case "salida":
                    ral = new rall(datos[0], datos[1], datos[2], datos[3], 0, 0);
                    break;
                case "bono":
                    ral = new rall(datos[0],datos[1], datos[2], datos[3], 0, 0);
                    break;
                case "X":
                    ral.v5 = int.Parse(datos[1]);
                    //roca.Add(ral);
                    break;
                case "Y":
                    ral.v6 = int.Parse(datos[1]);
                    roca.Add(ral);
                    ral = new rall();
                    break;
                case "enemigo":
                    general1.Add(new enemy(datos[1], datos[2], datos[3], datos[4]));
                    break;
                case "movimientos":
                    //Console.WriteLine("movimientos");
                    if (generalmove.Count!=0) {
                        //generalmoves.Add(generalmove);
                        //generalmove = new ArrayList();
                        move = "";
                    }
                    break;
                case "movimiento":
                    if (move == "")
                    {
                        if (datos[1] == "")
                        {

                        }
                        else
                        {
                            move = datos[1];
                            //generalmove.Add(move);
                            //Console.WriteLine("movimientos: " + move);
                        }
                    }
                    else {
                        if (datos[1] == "")
                        {
                            //generalmove.Add(move);
                            //Console.WriteLine("movimientos: " + move);
                        }
                        else
                        {
                            move = datos[1];
                            //generalmove.Add(move);
                            //Console.WriteLine("movimientos: " + move);
                        }
                    }
                    break;
            }
        }
        private void pila_add(string item)
        {
            if (pila.Count != 0)
            {
                pila_c = pila_b(item, true);
                if (pila_c)
                {
                    pila.Add(item);
                }
            }
            else
            {
                pila.Add(item);
            }
        }

        private bool pila_b(string item, bool c)
        {
            for (int i = 0; i < pila.Count; i++)
            {
                if (pila[i].Equals(item))
                {
                    if (c)
                    {
                        pila.RemoveAt(i);
                    }
                    return false;
                }
            }
            return true;
        }

        private bool pila_control(string item)
        {
            foreach (Data i in d.arreglo_Data)
            {
                if (i.nombre.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        private bool etiquetas_control(string item)
        {
            foreach (string case_w in Palabras_Reservadas)
            {
                if (case_w == item)
                {
                    return true;
                }
            }
            return false;
        }

    }

    internal class generalmove
    {
        public int v;
        public string wordaux;

        public generalmove(string wordaux, int v)
        {
            this.wordaux = wordaux;
            this.v = v;
        }
    }

    public class send
    {
        public ArrayList roca;
        public string v;

        public send(string v, ArrayList roca)
        {
            this.v = v;
            this.roca = roca;
        }
    }

    public class enemy
    {
        public string v1;
        public string v2;
        public string v3;
        public string v4;

        public enemy(string v1, string v2, string v3, string v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }
    }

    public class rall
    {
        public string v1;
        public string v2;
        public string v3;
        public int v4;
        public int v5;
        public string v;
        public int v6;

        public rall()
        {
        }

        public rall(string v1, string v2, string v3, int v4, int v5)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }

        public rall(string v1, string v2, string v3, string v, int v5, int v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v = v;
            this.v5 = v5;
            this.v6 = v6;
        }

        public string get()
        {
            return this.v3;
        }
    }

    public class jjugador
    {
        public string v1;
        public string v2;
        public string v3;

        public jjugador(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public jjugador(string v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }

    public class vvar
    {
        public bool g1;
        public string v1;
        public string v2;
        public string v3;

        public vvar(bool g1, string v1, string v2, string v3)
        {
            this.g1 = g1;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }
}