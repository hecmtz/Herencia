using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class Entrenador : SeleccionFutbol
    {
        private string idFederacion;

        public Entrenador() : base()
        {

        }
        public Entrenador(string idFederacion , int id, int edad, string nombre, string apellidos): base(id, edad, nombre, apellidos)
        {
            this.idFederacion = idFederacion;
        }
        public string GetIdFederacion()
        {
            return idFederacion;
        }
        public void SetIdFederacion(string idFederacion)
        {
            this.idFederacion = idFederacion;
        }
        public override string ToString()
        {
            return base.ToString() + " El id :" + idFederacion;
        }
        public string ToStringEntrenador()
        {
            return base.ToStringSeleccion() + " El id :" + idFederacion ;
        }

    }
}
