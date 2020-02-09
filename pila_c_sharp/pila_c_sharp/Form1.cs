using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pila_c_sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //VARIABLES GLOBALES PARA QUE ESTEN DISPONIBLES EN TODAS LAS CLASES
        public static class glo
        {
            public static int cont = 0;
            public static Stack<int> aux = new Stack<int>();
        }
        //FUNCIONA PARA CONTROLAR SI LA PILA ESTA VACIA
        public bool  pila_vacia() 
        {
            if (glo.aux.Count <= 0)
            {
                return true;
            }
            else return false;
        }


        private void button1_Click(object sender, EventArgs e)//BOTON PARA HACER PUSH
        {
            glo.aux.Push(glo.cont); //PUSH A LA PILA GLOBAL UN VALOR CUALQUIERA, PODRIA SER UN RANDOM
                                    //PERO ME ERA MAS FACIL CONTROLAR CON NUMEROS CONSECUTIVOS.


            int i = new int(); //DECLARO i PARA USAR EN EL FOR QUE ME RENDERIZA LA LISTA AL REVEZ

            listBox1.Items.Clear(); //LIMPIO LA LISTA

            for (i = 0; i < glo.aux.Count(); i++)
            {
                listBox1.Items.Add(Convert.ToString(glo.aux.ElementAt(i)));
            }
           
            //EL CONTADOR SOLO LO USO PARA CARGAR UN VALOR COMO PRUEBA
            glo.cont = glo.cont + 1;
            //ACTUALIZO SIEMPRE EL TOP DE LA PILA EN UN LABEL
            lbl_top.Text = (Convert.ToString(glo.aux.Peek()));
            //actualizo el label para el tamaño de la pila
            lbl_tamaño.Text = Convert.ToString(glo.aux.Count());

        }

        private void button2_Click(object sender, EventArgs e) //BOTON PARA HACER POP
        {
            //SI LA PILA ESTA VACIA ENTONCES MUESTRA MENSAJE 
            if (pila_vacia())
            {
                MessageBox.Show("Pila vacia");
            }
            else //SINO HACE EL POP A LA PILA
            {
                glo.aux.Pop();


                //AHORA RENDERIZO DE NUEVO LA LISTA PARA QUE SE MUESTRE AL REVEZ
                int i = new int();

                listBox1.Items.Clear();

                for (i = 0; i < glo.aux.Count(); i++)
                {
                    listBox1.Items.Add(glo.aux.ElementAt(i));
                }
                if (pila_vacia())
                {
                    lbl_top.Text = "vacia";
                }
                else
                {
                    lbl_top.Text = (Convert.ToString(glo.aux.Peek()));
                }
                //actualizo el label para el tamaño de la pila
                lbl_tamaño.Text=Convert.ToString(glo.aux.Count());
            }
        }

        private void button3_Click(object sender, EventArgs e)// BOTON PARA HACER PEEK
        {
            if (pila_vacia())
            {
                MessageBox.Show("Pila vacia");
            }
            else
            {
                MessageBox.Show(Convert.ToString(glo.aux.Peek()));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

