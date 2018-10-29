using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["blockbuster"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;



        static void Main(string[] args)
        {

            //menu Login
            MenuLog();

            MainMenu mainMen = new MainMenu();
            RegistrarUsuario regUser = new RegistrarUsuario();
     

        }



        static void RegisterUser()
        {
            string nombre, apellido, correo, usuario, passw, fechaNacimiento;
            bool userLibre = false;
            bool mailLibre = false;

            Console.WriteLine("Ingresa tu nombre");
            nombre = Console.ReadLine();

            Console.WriteLine("Ingresa tu apellido");
            apellido = Console.ReadLine();

            Console.WriteLine("Ingresa tu correo");
            correo = Console.ReadLine();

            Console.WriteLine("Ingresa tu nombre de usuario");
            usuario = Console.ReadLine();

            Console.WriteLine("Ingresa el password ");
            passw = Console.ReadLine();

            Console.WriteLine("Ingresa fecha de nacimiento como Mes/Dia/Año  ");
            fechaNacimiento = Console.ReadLine();

            //comprobar

            //comprueba si existe 
            conexion.Open();
            cadena = "SELECT UserName From USUARIO WHERE UserName like '" + usuario + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader comparar = comando.ExecuteReader();


            if (comparar.Read())
            {

                userLibre = false;
            }
            else
            {

                userLibre = true;
            }

            conexion.Close();
            conexion.Open();
            cadena = "SELECT Email From USUARIO WHERE Email like '" + correo + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader compararmail = comando.ExecuteReader();


            if (compararmail.Read())
            {

                mailLibre = false;
            }
            else
            {

                mailLibre = true;
            }

            conexion.Close();
            Console.ReadLine();
            // se crea 
            if (mailLibre && userLibre)
            {
                conexion.Open();
                cadena = "INSERT INTO USUARIO  VALUES ('" + usuario + "','" + nombre + "','" + apellido + "','" + correo + "','" + passw + "','" + fechaNacimiento + "')";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                Console.WriteLine("Usuario creado");


            }
            else
            {
                Console.WriteLine("Error usuario ya registrado");
            }

        }
        static void LoginLog()
        {

            string usuario, password;
            string cSalida;
            bool salida = false;
            bool registrado = false;

            Console.WriteLine("\n============================================= LOG IN =============================================");
            do
            {
                Console.WriteLine("Ingresa el Usuario: ");
                usuario = Console.ReadLine();

                Console.WriteLine("Ingresa el Password: ");
                password = Console.ReadLine();

                //TODO: add condition if password==pasword and Usuario==Usuario -> user menu
                conexion.Open();
                cadena = "SELECT Passw from USUARIO where UserName LIKE '" + usuario + "'";
                comando = new SqlCommand(cadena, conexion);
                SqlDataReader compara = comando.ExecuteReader();
                registrado = compara.Read();
                if (!registrado)
                {
                    Console.WriteLine("Datos incorrectos , intenta de nuevo.");
                    Console.WriteLine("¿Deseas salir?   s/n");
                    cSalida = Console.ReadLine();
                    if (cSalida == "S" || cSalida == "s")
                    {
                        salida = true;
                    }
                    else if (cSalida == "N" || cSalida == "n")
                    {
                        salida = false;
                    }
                    else
                    {
                        Console.WriteLine("Error, presiona S / N");
                    }
                }
                else
                {
                    Console.WriteLine("You are successfully logged in!");
                    MenuMain(usuario);

                }


                //        User u1 = new User();
                //        u1.SetName(compara["Usuario"].ToString());
                //        //all the attributes
                //        u1.SetName

                conexion.Close();
                compara.Close();
                //        //check the boolean below
            } while (!registrado && salida == false);


        }

        //Menu del Login

        static void MenuLog()
        {
            int menu;
            bool salida = false;
            const int REGISTERUSER=1 , LOGIN=2, SALIR=3;
            do
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bienvenido a BlockBuster ...");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("Ingresa: \n 1) Registrarse \n 2)Login \n 3) Salir ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case REGISTERUSER:
                        RegisterUser();
                        break;
                    case LOGIN:
                        LoginLog();
                        break;
                    case SALIR:
                        Console.WriteLine("Adios");
                        salida = true;
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("error numero erroneo ");
                        break;
                }
            } while (salida==false);
        }

        //Menu principal en el que se muestra el Catalogo, alquilan peliculas y se ven los alquileres.

        static void MenuMain(string usuario)
        {
            Peliculas p = new Peliculas();
            int menuAlque;
            bool salir=false;
            const int VERPELICULAS = 1, ALQUILAR = 2, MISALQUILERES = 3, SALIR = 4;
            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("\n -------------------------------------------------");
                Console.WriteLine("Bienvenido " + usuario + " :");
                Console.WriteLine("Ingresa: \n 1) Ver Catalogo  \n 2)Alquilar pelicula  \n 3) Mis alquileres \n 4) Salir  ");
                menuAlque = Convert.ToInt32(Console.ReadLine());
                switch (menuAlque)
                {
                    case VERPELICULAS:
                        Console.Clear();
                        p.ShowAllMovies(usuario);
                        break;

                    case ALQUILAR:
                        Console.Clear();
                        p.AlquilarPeliculas(usuario);
                        break;

                    case MISALQUILERES:
                        Console.Clear();
                        p.MisAlquileres(usuario);

                        break;
                    case SALIR:
                        Console.WriteLine("Adios");
                        menuAlque = 8;
                        salir = true;
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("error numero erroneo ");
                        break;
                }
            } while (salir==false);


        }
    }
}