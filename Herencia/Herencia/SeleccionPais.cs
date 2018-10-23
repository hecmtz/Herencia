using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class SeleccionPais
    {
     
        private string nombre;
        private List<SeleccionPais> pais;
        private int numeroTParticipantes, numeroTPaises;
        private int nFutbolista , nEntrenador, nMasajista;


        public SeleccionPais(string nombre)
        {
            this.nombre = nombre;
            pais = new List<SeleccionPais>();
        }
          public SeleccionPais (string nombre, List<SeleccionPais> pais)
        {
            this.nombre = nombre;
            this.pais = pais;
        }

         public void AddSeleccion(SeleccionPais s)
        {
            //Si el método MeterVehiculo nos devuelve true, añadiremos el vehículo
            if (MeterJugador(s))
            {
                //Si el objeto que queremos meter es un Taxi, le añadimos uno al contador de taxis.
                if (s.GetType().Name == "Futbolista")
                {
                    nFutbolista++;
                }
                //Si el objeto que queremos meter es un Autobus, le añadimos uno al contador de autobuses.
                else if (s.GetType().Name == "Masajista")
                {
                    nMasajista++;
                }
                else if (s.GetType().Name == "Entrenador")
                {
                    nEntrenador++;
                }

                //Como hemos verificado que se puede meter, lo metemos
                Console.WriteLine("se ha añadido al" + s.GetType().Name + " .");
                pais.Add(s);
            }
        }
         public List<SeleccionPais> GetSeleccionPais()
        {
            return pais;
        }


        
        public bool MeterJugador (SeleccionPais s)
        {
           
            if (pais.Count < 6)
            {
                if (s.GetType().Name == "Masajista" && nMasajista < 1)
                {
                    return true;
                }
                else if (s.GetType().Name == "Taxi" && nEntrenador < 1)
                {
                    return true;
                }
                else if (s.GetType().Name == "Futbolista")
                {
                    return true;
                }
                  Console.WriteLine("No caben más " + s.GetType().Name + "s en el equipos");
                Console.ReadLine();
                return false;
            }
            Console.WriteLine("No caben más " + s.GetType().Name + "s en el equipos");
            Console.ReadLine();
            return false;
}


    }
}
