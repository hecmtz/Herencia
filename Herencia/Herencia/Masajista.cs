using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class Masajista : SeleccionFutbol
    {
        private string titulacion;
        private int aniosExperiencia;
        public Masajista() : base()
        {

        }
        public Masajista(string titulacion, int aniosExperiencia, int id, int edad, string nombre, string apellidos) : base(id, edad, nombre, apellidos)
        {
            this.titulacion = titulacion;
            this.aniosExperiencia = aniosExperiencia;
        }
        public string GetTitulacion()
        {
            return titulacion;
        }
        public void SetTitulacion(string titulacion)
        {
            this.titulacion = titulacion;
        }
        public int GetAniosExperiencia()
        {
            return aniosExperiencia;
        }
        public void SetAniosExperiencia(int aniosExperiencia)
        {
            this.aniosExperiencia = aniosExperiencia;
        }


        public override string ToString()
        {
            return base.ToString() + "Titulo : " + titulacion + "\n Años de exp " + aniosExperiencia;

        }

        public string ToStringMasajista()
        {
            return base.ToStringSeleccion() + "Titulo : " + titulacion + "\n Años de exp " + aniosExperiencia;
          
        }

    }
}
