using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class Program
    {
        
        List<SeleccionPais> list1 = new List<SeleccionPais>()
            {
                t1,a1,c1
};
        //public ListaJugadores(string pais)
        //{
        //    List<SeleccionFutbol> SeleccionPais;

        //    Futbolista f1 = new Futbolista();
        //    f1.SetNombre("Pablito ");
        //    f1.SetApellidos(" Lopez");
        //    f1.SetDemarcacion("Delantero");
        //    f1.SetDorsal(9);
        //    f1.SetEdad(20);
        //    f1.SetId(350215);
        //    f1.SetViajando(true);

        //    Futbolista f2 = new Futbolista();
        //    f2.SetNombre("Lionel");
        //    f2.SetApellidos(" Messi");
        //    f2.SetDemarcacion("Delantero");
        //    f2.SetDorsal(10);
        //    f2.SetEdad(30);
        //    f2.SetId(350235);
        //    f2.SetViajando(true);

        //    Futbolista f3 = new Futbolista();
        //    f3.SetNombre("Jorge ");
        //    f3.SetApellidos("Campos");
        //    f3.SetDemarcacion("Portero");
        //    f3.SetDorsal(1);
        //    f3.SetEdad(40);
        //    f3.SetId(350455);
        //    f3.SetViajando(true);

        //    Entrenador e1 = new Entrenador();
        //    e1.SetNombre("Tuca");
        //    e1.SetApellidos("Ferreti");
        //    e1.SetEdad(55);
        //    e1.SetIdFederacion("a84748");
        //    e1.SetId(456);
        //    e1.SetViajando(true);

        //    Entrenador e2 = new Entrenador();
        //    e2.SetNombre("Parejita");
        //    e2.SetApellidos("Lopez");
        //    e2.SetEdad(55);
        //    e2.SetIdFederacion("a84748");
        //    e2.SetId(456);
        //    e2.SetViajando(true);

        //    Masajista m1 = new Masajista();
        //    m1.SetNombre("Manita");
        //    m1.SetApellidos("Santa");
        //    m1.SetEdad(45);
        //    m1.SetAniosExperiencia(15);
        //    m1.SetTitulacion("pro");
        //    m1.SetId(4562);
        //    m1.SetViajando(true);

        //    Masajista m2 = new Masajista();
        //    m2.SetNombre("Soba");
        //    m2.SetApellidos("Testa");
        //    m2.SetEdad(45);
        //    m2.SetAniosExperiencia(15);
        //    m2.SetTitulacion("la vida ");
        //    m2.SetId(4562);
        //    m2.SetViajando(false);

        //    SeleccionPais = new List<SeleccionFutbol> {
        //        f1,f2,f3,m1,m2,e1,e2
        //    };
        //}
        static void Main(string[] args)
        {

            List<SeleccionFutbol> SeleccionPais;

            Futbolista f1 = new Futbolista();
            f1.SetNombre("Pablito ");
            f1.SetApellidos(" Lopez");
            f1.SetDemarcacion("Delantero");
            f1.SetDorsal(9);
            f1.SetEdad(20);
            f1.SetId(350215);
            f1.SetViajando(true);

            Futbolista f2 = new Futbolista();
            f2.SetNombre("Lionel");
            f2.SetApellidos(" Messi");
            f2.SetDemarcacion("Delantero");
            f2.SetDorsal(10);
            f2.SetEdad(30);
            f2.SetId(350235);
            f2.SetViajando(true);

            Futbolista f3 = new Futbolista();
            f3.SetNombre("Jorge ");
            f3.SetApellidos("Campos");
            f3.SetDemarcacion("Portero");
            f3.SetDorsal(1);
            f3.SetEdad(40);
            f3.SetId(350455);
            f3.SetViajando(true);

            Entrenador e1 = new Entrenador();
            e1.SetNombre("Tuca");
            e1.SetApellidos("Ferreti");
            e1.SetEdad(55);
            e1.SetIdFederacion("a84748");
            e1.SetId(456);
            e1.SetViajando(true);

            Entrenador e2 = new Entrenador();
            e2.SetNombre("Parejita");
            e2.SetApellidos("Lopez");
            e2.SetEdad(55);
            e2.SetIdFederacion("a84748");
            e2.SetId(456);
            e2.SetViajando(true);

            Masajista m1 = new Masajista();
            m1.SetNombre("Manita");
            m1.SetApellidos("Santa");
            m1.SetEdad(45);
            m1.SetAniosExperiencia(15);
            m1.SetTitulacion("pro");
            m1.SetId(4562);
            m1.SetViajando(true);

            Masajista m2 = new Masajista();
            m2.SetNombre("Soba");
            m2.SetApellidos("Testa");
            m2.SetEdad(45);
            m2.SetAniosExperiencia(15);
            m2.SetTitulacion("la vida ");
            m2.SetId(4562);
            m2.SetViajando(false);

            SeleccionPais = new List<SeleccionFutbol> {
                f1,f2,f3,m1,m2,e1,e2
            };

            foreach (SeleccionFutbol integrante in SeleccionPais)
            {
                Console.WriteLine("****************");
                Console.WriteLine("\n" + integrante.ToString());
                integrante.Viajar();

                if (integrante.Concentrarse())
                {

                    if (integrante.GetType().Name.ToUpper() == "JUGADOR")
                    {
                        Console.WriteLine(" A jugar");
                    }
                    else if (integrante.GetType().Name.ToUpper() == "ENTRENADOR")
                    {
                        Console.WriteLine(" A dirigir");
                    }
                    else
                    {
                        Console.WriteLine(" A masajear");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("el contador es " + m2.GetContador());
            Console.ReadLine();
        }
    }
}
