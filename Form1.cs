using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Se crean las variables que usaremos de precios y la lista
        int PrecioCorregido = 0;
        int PrecioCorregido2 = 0;
        List<Platos> ListPlatos = new List<Platos>();
        Platos NuevoPlatos;

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            //cierra el programa
            Close();
        }

        private bool validarPrecio()
        {
            // Validar que el precio que haya entrado sea numerco
            if (!int.TryParse(TxtPrecio.Text, out PrecioCorregido) || TxtPrecio.Text == "")
            {
                errorProvider1.SetError(TxtPrecio, "Debe de ingresar un numero");
                TxtPrecio.Focus();
                return false;
            }

            else if (!int.TryParse(txtPrecioBebida.Text, out PrecioCorregido2) || txtPrecioBebida.Text == "")
            {
                errorProvider1.SetError(TxtPrecio, "Debe de ingresar un numero");
                txtPrecioBebida.Focus();
                return false;
            }
            else
            {
                //Si no se digita valores en el campo que no sea numericos, sale error
                //y no deja continuar
                errorProvider1.SetError(TxtPrecio, "");
                return true;

                errorProvider2.SetError(txtPrecioBebida, "");
                return true;
            }
        }
        private void BtnAgregarCarrito_Click(object sender, EventArgs e)
        {
            //Este boton agregar al carrito los platos y bebidas, con su respectivos valores
            string Comida = CbPlato.Text;
            string bebidas = cbBebidas.Text;
            int precio = PrecioCorregido;
            int preciobebida = PrecioCorregido2;
            


            if (validarPrecio() == false)
            {
                return;
            }

            NuevoPlatos = new Platos (precio, preciobebida, Comida, bebidas);

            NuevoPlatos.Comida = CbPlato.Text;
            NuevoPlatos.Bebidas = cbBebidas.Text;
            NuevoPlatos.Precio = PrecioCorregido;
            NuevoPlatos.Preciobebida = PrecioCorregido2;

            //Agregamos los productos a la lista
            ListPlatos.Add(NuevoPlatos);

            MessageBox.Show("Se agregó los items al carrito");

            //Muestro los productos en el data grid
            DgvFactura.DataSource = null;
            DgvFactura.DataSource = ListPlatos;

            /*utilizamos la variable estatica y lo acumulamos de uno en uno para saber la
             cantidad de elementos*/
            Platos.CantidadDeElemento += 1;
            TxtNumeroElemntos.Text = Convert.ToString(Platos.CantidadDeElemento);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un random para mostar el numero de la factura al azar 
            Random r = new Random();
            TxtNumeroDefactura.Text = Convert.ToString(r.Next(10, 101));

            //Creamos un foreach para recorres la lista y sumar el precio de cada producto
            decimal suma = 0;
            foreach (var item in ListPlatos)
            {
                suma += item.Precio;
                suma += item.Preciobebida;
                
            }
            TxtTotal.Text = Convert.ToString(suma);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Aqui carga el form del login
            Login obj = new Login();

            if (obj.ShowDialog() != DialogResult.OK)
                this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //este boton limpia los datos
            DgvFactura.DataSource = null;
            DgvFactura.Rows.Clear();
            TxtNumeroElemntos.Clear();
            TxtNumeroDefactura.Clear();
            TxtTotal.Clear();
            TxtPrecio.Clear();
            txtPrecioBebida.Clear();


        }
    }
}
