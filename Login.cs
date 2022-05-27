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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Se valida que el usuario haya agregado bien los datos
            //y lo deja entrar al sistema, de lo contrario no lo hace. 
            if (txtUsuario.Text == "admin" && txtContraseña.Text == "admin1452")
                this.DialogResult = DialogResult.OK;
            else
            {
                lblError.Visible = true;
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Esto es para darle al boton salir y que cierre el formulario desde el login
            Close();
        }
    }
}
