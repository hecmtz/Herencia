using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class SeleccionFutbol
    {
        static int contador;
        private int id, edad;
        private string nombre, apellidos;
        private bool viajando;
        private bool concentrar;

        public SeleccionFutbol(int id, int edad, string nombre, string apellidos)
        {
            this.id = id;
            this.edad = edad;
            this.nombre = nombre;
            this.apellidos = apellidos;
            contador++;
        }
        public SeleccionFutbol()
        {
            contador++;
        }
        public int GetId()
        {
            return id;
        }
        public int GetEdad()
        {
            return edad;
        }
        public int GetContador()
        {
            return contador;
        }

        public string GetNombre()
        {
            return nombre;
        }
        public string GetApellidos()
        {
            return apellidos;
        }
        public void SetId(int id)
        {
            this.id = id;
        }
        public void SetEdad(int edad)
        {
            this.edad = edad;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void SetApellidos(string apellidos)
        {
            this.apellidos = apellidos;
        }
        public void Setconcentrarse(bool concentrar)
        {
            this.concentrar = concentrar;
        }
        public void SetViajando(bool viajando)
        {
            this.viajando = viajando;
        }
        public override string ToString()
        {
            return " Nombre : " + nombre + "\n Apellidos : " + apellidos + "\n ID: " + id + "\n Edad :" + edad;
        }

        public string ToStringSeleccion()
        {
            return " Nombre : " + nombre + "\n Apellidos : " + apellidos + "\n ID;: " + id + "\n Edad :" + edad;

        }

        public void Viajar()
        {
            if (viajando)
            {
                Console.WriteLine(" Esta viajando ");
                viajando = true;
            }
            else
            {
                Console.WriteLine(" No esta viajando ");
                viajando = false;
            }
        }
        public bool Concentrarse()
        {
            if (viajando)
            {
                Console.WriteLine(" No puede concentrarse ");

            }
            else
            {
                Console.WriteLine(" Concentrandose. ");
                concentrar = true;
            }
            return concentrar;
        }
       
    }


}

