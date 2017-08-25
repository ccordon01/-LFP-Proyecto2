using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace viboritas
{
    public partial class Form1 : Form
    {
        Panel dynamicPanelMove = new Panel();
        List<enemigos_p> enemigos = new List<enemigos_p>();
        public Form1()
        {
            Analisis_Lexico l = new Analisis_Lexico();
            foreach (send item in l.prueba_d)
            {
                switch (item.v) {
                    case "roca":
                        foreach (rall item1 in item.roca)
                        {
                            Panel dynamicPanel11 = new Panel();
                            dynamicPanel11.Location = new System.Drawing.Point((45 * item1.v5), (45 * item1.v6));
                            dynamicPanel11.Name = "Panel1";
                            dynamicPanel11.Size = new System.Drawing.Size(45, 45);
                            Image img11 = Image.FromFile(item1.v3);
                            dynamicPanel11.BackgroundImage = (Image)(new Bitmap(img11, new Size(45, 45)));//img; //Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+ @"C:\lfyp2016\img\roca2.png");
                            Controls.Add(dynamicPanel11);
                        }
                        break;
                    case "enemigo":
                        foreach (enemy item1 in item.roca)
                        {
                            Panel dynamicPanel11 = new Panel();
                            dynamicPanel11.Location = new System.Drawing.Point((45 * int.Parse(item1.v3)), (45 * int.Parse(item1.v4)));
                            dynamicPanel11.Name = "Panel1";
                            dynamicPanel11.Size = new System.Drawing.Size(45, 45);
                            Image img11 = Image.FromFile(item1.v2);
                            dynamicPanel11.BackgroundImage = (Image)(new Bitmap(img11, new Size(45, 45)));//img; //Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+ @"C:\lfyp2016\img\roca2.png");
                            enemigos.Add(new enemigos_p(dynamicPanel11,new List<string>(),0));
                            Controls.Add(dynamicPanel11);
                        }
                        break;
                    case "movimientos":
                        int i = 0;
                        foreach (ArrayList item1 in item.roca)
                        {
                            enemigos_p aux_p = enemigos[i];
                            foreach (string iteml in item1)
                            {
                                Console.WriteLine("enemigo "+i+" mueve "+iteml);
                                aux_p.list.Add(iteml);
                            }
                            i++;
                        }
                        break;
                }
            }
            InitializeComponent();
            //Panel dynamicPanel1 = new Panel();
            //dynamicPanel1.Location = new System.Drawing.Point((45 * 1), (45 * 1));
            //dynamicPanel1.Name = "Panel1";
            //dynamicPanel1.Size = new System.Drawing.Size(45, 45);
            //Image img = Image.FromFile(@"C:\lfyp2016\img\roca2.png");
            //dynamicPanel1.BackgroundImage = (Image)(new Bitmap(img, new Size(45, 45)));//img; //Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+ @"C:\lfyp2016\img\roca2.png");
            //Controls.Add(dynamicPanel1);
            dynamicPanelMove.Location = new System.Drawing.Point((45 * 0), (45 * 0));
            dynamicPanelMove.Name = "Panel1";
            dynamicPanelMove.Size = new System.Drawing.Size(45, 45);
            Image img1 = Image.FromFile(@"C:\lfyp2016\img\heroe.png");
            dynamicPanelMove.BackgroundImage = (Image)(new Bitmap(img1, new Size(45, 45)));//img; //Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+ @"C:\lfyp2016\img\roca2.png");
            Controls.Add(dynamicPanelMove);
            for (int i  = 0; i  < 10; i ++)
            {
                for (int k = 0; k < 10; k++)
                {
                    Panel dynamicPanel = new Panel();
                    dynamicPanel.Location = new System.Drawing.Point((45*i), (45*k));
                    dynamicPanel.Name = "Panel1";
                    dynamicPanel.Size = new System.Drawing.Size(45, 45);
                    dynamicPanel.BackColor = Color.LightGreen;
                    Controls.Add(dynamicPanel);
                }
            }
            
        }
        private bool move = false;
        private int posicion=-1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            switch (posicion)
            {
                case 0:
                    if (move)
                    {
                        dynamicPanelMove.Location = new Point(this.dynamicPanelMove.Location.X, this.dynamicPanelMove.Location.Y - 45);
                        label1.Location = new Point(this.label1.Location.X, this.label1.Location.Y - 10);
                        move = false;
                    }
                    //posicion = 0;
                    break;

                case 1:
                    if (move)
                    {
                        dynamicPanelMove.Location = new Point(this.dynamicPanelMove.Location.X, this.dynamicPanelMove.Location.Y + 45);
                    label1.Location = new Point(this.label1.Location.X, this.label1.Location.Y + 10);
                        move = false;
                    }
                    //posicion = 1;
                    break;

                case 2:
                    if (move)
                    {
                        dynamicPanelMove.Location = new Point(this.dynamicPanelMove.Location.X - 45, this.dynamicPanelMove.Location.Y);
                    label1.Location = new Point(this.label1.Location.X - 10, this.label1.Location.Y);
                        move = false;
                    }
                    //posicion = 2;
                    break;

                case 3:
                    if (move)
                    {
                        dynamicPanelMove.Location = new Point(this.dynamicPanelMove.Location.X + 45, this.dynamicPanelMove.Location.Y);
                    label1.Location = new Point(this.label1.Location.X + 10, this.label1.Location.Y);
                        move = false;
                    }
                    //posicion = 3;
                    break;

            }
            foreach (enemigos_p item in enemigos)
            {
                Console.WriteLine(item.v);
                int tmp = 0;
                foreach (string itemn in item.list)
                {
                    if (tmp == item.v) {
                        switch (itemn)
                        {
                            case "izquierda":
                                item.dynamicPanel11.Location = new Point(item.dynamicPanel11.Location.X - 45, item.dynamicPanel11.Location.Y);
                                break;
                            case "derecha":
                                item.dynamicPanel11.Location = new Point(item.dynamicPanel11.Location.X + 45, item.dynamicPanel11.Location.Y);
                                break;
                            case "arriba":
                                item.dynamicPanel11.Location = new Point(item.dynamicPanel11.Location.X, item.dynamicPanel11.Location.Y - 45);
                                break;
                            case "abajo":
                                item.dynamicPanel11.Location = new Point(item.dynamicPanel11.Location.X, item.dynamicPanel11.Location.Y + 45);
                                break;
                        }
                        item.v = item.v + 1;
                        //Console.WriteLine(item.v);
                        //Console.WriteLine(item.list.Count);
                        if (item.v == (item.list.Count))
                        {
                            item.v = 0;
                        }
                        Console.WriteLine("nuevo " + item.v);
                        break;
                    }
                    tmp++;
                }
                
            }


        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 400;
            foreach (enemigos_p item in enemigos)
            {
                switch (item.list[item.v])
                {
                    case "izquierda":
                        item.dynamicPanel11.Location= new Point(item.dynamicPanel11.Location.X-45, item.dynamicPanel11.Location.Y);
                        break;
                    case "derecha":
                        item.dynamicPanel11.Location = new Point(item.dynamicPanel11.Location.X+45, item.dynamicPanel11.Location.Y);
                        break;
                    case "arriba":
                        item.dynamicPanel11.Location = new Point(item.dynamicPanel11.Location.X, item.dynamicPanel11.Location.Y-45);
                        break;
                    case "abajo":
                        item.dynamicPanel11.Location = new Point(item.dynamicPanel11.Location.X, item.dynamicPanel11.Location.Y+45);
                        break;
                }
                item.v = item.v++;
                if (item.v==(item.list.Count-1)) {
                    item.v = 0;
                }
            }
            //switch (posicion)
            //{
            //    case 0:
            //        if (move)
            //        {
            //            dynamicPanelMove.Location = new Point(this.dynamicPanelMove.Location.X, this.dynamicPanelMove.Location.Y - 45);
            //            label1.Location = new Point(this.label1.Location.X, this.label1.Location.Y - 10);
            //            move = false;
            //        }
            //        //posicion = 0;
            //        break;

            //    case 1:
            //        if (move)
            //        {
            //            dynamicPanelMove.Location = new Point(this.dynamicPanelMove.Location.X, this.dynamicPanelMove.Location.Y + 45);
            //            label1.Location = new Point(this.label1.Location.X, this.label1.Location.Y + 10);
            //            move = false;
            //        }
            //        //posicion = 1;
            //        break;

            //    case 2:
            //        if (move)
            //        {
            //            dynamicPanelMove.Location = new Point(this.dynamicPanelMove.Location.X - 45, this.dynamicPanelMove.Location.Y);
            //            label1.Location = new Point(this.label1.Location.X - 10, this.label1.Location.Y);
            //            move = false;
            //        }
            //        //posicion = 2;
            //        break;

            //    case 3:
            //        if (move)
            //        {
            //            dynamicPanelMove.Location = new Point(this.dynamicPanelMove.Location.X + 45, this.dynamicPanelMove.Location.Y);
            //            label1.Location = new Point(this.label1.Location.X + 10, this.label1.Location.Y);
            //            move = false;
            //        }
            //        //posicion = 3;
            //        break;

            //}


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //timer2.Start();
        }

 

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    posicion = 0;
                    move = true;
                    break;
                case Keys.Down:
                    posicion = 1;
                    move = true;
                    break;
                case Keys.Left:
                    posicion = 2;
                    move = true;
                    break;
                case Keys.Right:
                    posicion = 3;
                    move = true;
                    break;

            }

        }

        public class TransparentPanel : Panel //<==change to Button for instance, and works
        {
            Timer Wriggler = new Timer();
            public TransparentPanel()
            {
                Wriggler.Tick += new EventHandler(TickHandler);
                this.Wriggler.Interval = 500;
                this.Wriggler.Enabled = true;
            }
            protected void TickHandler(object sender, EventArgs e)
            {
                this.InvalidateEx();
            }
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
                    return cp;
                }
            }
            protected void InvalidateEx()
            {
                if (Parent == null)
                {
                    return;
                }
                Rectangle rc = new Rectangle(this.Location, this.Size);
                Parent.Invalidate(rc, true);
            }
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                // Do not allow the background to be painted  
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {



        }
    }

    internal class enemigos_p
    {
        public ArrayList arrayList;
        public Panel dynamicPanel11;
        public List<string> list;
        public int v;

        public enemigos_p(Panel dynamicPanel11, ArrayList arrayList)
        {
            this.dynamicPanel11 = dynamicPanel11;
            this.arrayList = arrayList;
        }

        public enemigos_p(Panel dynamicPanel11, List<string> list, int v)
        {
            this.dynamicPanel11 = dynamicPanel11;
            this.list = list;
            this.v = v;
        }

        public enemigos_p(Panel dynamicPanel11, ArrayList arrayList, int v) : this(dynamicPanel11, arrayList)
        {
            this.v = v;
        }
    }
}
