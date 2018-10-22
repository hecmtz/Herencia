using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class Futbolista : SeleccionFutbol
    {
        private int dorsal;
        private string demarcacion;

        public Futbolista(int id, int edad, string nombre, string apellidos, int dorsal, string demarcacion) : base(id, edad, nombre, apellidos)
        {
            this.dorsal = dorsal;
            this.demarcacion = demarcacion;

        }

        public Futbolista():base()
        {

        }
        public int GetDorsal()
        {
            return dorsal;
        }
        public void SetDorsal(int dorsal)
        {
            this.dorsal = dorsal;
        }
        public string GetDemarcacion()
        {
            return demarcacion;
        }
        public void SetDemarcacion(string demarcacion)
        {
            this.demarcacion = demarcacion;
        }
        public override string ToString()
        {
            return base.ToString() + " \n Dorsal numero :  " + dorsal + "\n  demarcacion : " + demarcacion;
        }
        public string ToStringFutbolista()
        {
            return base.ToStringSeleccion() + " \n Dorsal numero :  " + dorsal + "\n  demarcacion : " + demarcacion;
        }
    }

}
