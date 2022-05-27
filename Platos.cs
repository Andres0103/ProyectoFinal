using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Platos
    {
        //Declaramos las propiedades y las encapsulo 
        private int precio;
        private int preciobebida;
        private string comida;
        private string bebidas;

        //Creamos constructor por defecto sin parametros
        public Platos()
        {

        }

        //Creamos un segundo constructor con 2 parametros de las variables declaradas
        public Platos( int precio, int preciobebida, string comida, string bebidas)
        {
            this.comida = comida;
            this.comida = bebidas;
            this.precio = precio;
            this.Preciobebida = preciobebida;
        }

        //Creamos los metodos de acceso y modificacion de las propiedades
        public string Comida { get => comida; set => comida = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Bebidas { get => bebidas; set => bebidas = value; }
        public int Preciobebida { get => preciobebida; set => preciobebida = value; }


        //Se crea la propiedad estatica
        public static int CantidadDeElemento = 0;


    }
}
