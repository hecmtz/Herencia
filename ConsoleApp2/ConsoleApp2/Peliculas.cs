using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleApp2
{
    class Peliculas
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["blockbuster"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;

        private string movie, name, rentals;

        //GEt & SEt

        public string GetName()
        {
            return name;
        }

        public void ShowAllMovies(string usuario)
        {
            SqlDataReader age;
            int compareAge;
            string UserName;
            conexion.Open();
            UserName = usuario;


            cadena = "SELECT DATEDIFF(year,FechaNacimiento,GETDATE()) AS filter FROM USUARIO WHERE UserName LIKE '" + UserName + "'";
            comando = new SqlCommand(cadena, conexion);
            age = comando.ExecuteReader();
            age.Read();
            //extracting from the query array the result from the column filter
            compareAge = Convert.ToInt32(age["filter"].ToString());
            conexion.Close();
            SqlDataReader registros;
            Console.Clear();
            Console.WriteLine("\nPeliculas Disponibles : ");
            Console.WriteLine("---------------------------------------------------------");
            //Console.ReadLine();

            conexion.Open();

            cadena = "SELECT NombrePelicula AS MovieName FROM PELICULAS where ControlParental<= " + compareAge;
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();
            Console.WriteLine("\nCatalogo de peliculas ...");
            Console.WriteLine("---------------------------------------------------------");
            // to show the available rooms
            while (registros.Read())
            {
                Console.WriteLine(registros["MovieName"].ToString());
                Console.WriteLine();
            }
            Console.ReadLine();
            conexion.Close();
        }
        public void MisAlquileres(string usuario)
        {
            SqlDataReader misAlquileres;

            string UserName, EstadoAlquiler;
            string peliculaEntregada = "Entregada";
            bool enAlq = false;
            UserName = usuario;
            conexion.Open();

            cadena = "Select *  FROM ALQUILERES WHERE UserName LIKE '" + UserName + "'";
            comando = new SqlCommand(cadena, conexion);
            misAlquileres = comando.ExecuteReader();
         
            misAlquileres.Read();
            while (misAlquileres.Read())
            {
                EstadoAlquiler = misAlquileres["EstadoAlquiler"].ToString();
              

                if (EstadoAlquiler == "En Alquiler")
                {
                    enAlq = true;
                }

                else
                {
                   
                }
            }
            conexion.Close();
            if (enAlq)
            {
                Console.WriteLine("\n¿Quieres devolver alguna película?   s/n: ");
                if (Console.ReadLine() == "s" || Console.ReadLine() == "S")
                {

                    conexion.Open();
                    cadena = "Select * FROM ALQUILERES WHERE UserName like '" + UserName + "' AND EstadoAlquiler Like 'En Alquiler' ";
                    
                    comando = new SqlCommand(cadena, conexion);
                    misAlquileres = comando.ExecuteReader();
                    misAlquileres.Read();
                    Console.WriteLine("Id \t Fecha del Alquiler \t Fecha de Entrega  \t ID pelicula \t Nombre Pelicula ");
                    while (misAlquileres.Read())
                    {

                        Console.WriteLine(misAlquileres["AlquilerID"].ToString() + "\t" + misAlquileres["FechaAlquiler"].ToString() + "\t" + misAlquileres["FechaEntrega"].ToString() + "\t\t" + misAlquileres["PeliculasID"].ToString() + "\t" + misAlquileres["NombrePelicula"].ToString());

                    }
                    conexion.Close();

                    Console.WriteLine("¿Cuál es la película que quieres devolver?");
                    string IDAlquiler = Console.ReadLine();

                    conexion.Open();
                    cadena = " UPDATE ALQUILERES SET FechaEntrega = GETDATE()  WHERE PeliculasID LIKE '" + IDAlquiler + "'";
                    comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    conexion.Open();

                    cadena = " UPDATE PELICULAS SET Disponible = 'Disponible'  WHERE PeliculasID LIKE '" + IDAlquiler + "'";
                    comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    conexion.Open();
                    cadena = "Select EstadoAlquiler  FROM ALQUILERES  WHERE PeliculasID LIKE '" + IDAlquiler + "'";
                    comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    conexion.Open();
                    cadena = " UPDATE ALQUILERES SET EstadoAlquiler = '" + peliculaEntregada + "'  WHERE PeliculasID LIKE '" + IDAlquiler + "'";
                    comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();

                }
            }
            else
            {
                Console.WriteLine("No tiene peliculas alquiladas");
            }
            conexion.Close();
           



        }
        public void AlquilarPeliculas(string usuario)
        {
            SqlDataReader age;
            int compareAge, diasAlquiler;
            string UserName, nombrePelic;
            string enAlquiler = "En Alquiler";
            conexion.Open();
            UserName = usuario;

            cadena = "SELECT DATEDIFF(year,FechaNacimiento,GETDATE()) AS filter FROM USUARIO WHERE UserName LIKE '" + UserName + "'";
            comando = new SqlCommand(cadena, conexion);
            age = comando.ExecuteReader();
            age.Read();
            compareAge = Convert.ToInt32(age["filter"].ToString());
            conexion.Close();

            Console.Clear();
            Console.WriteLine("\nPeliculas Disponibles para alquilar : ");
            Console.WriteLine("---------------------------------------------------------");

            conexion.Open();

            cadena = "SELECT * FROM Peliculas WHERE Disponible LIKE 'Disponible' AND ControlParental <= '" + compareAge + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader avaibles = comando.ExecuteReader();
            while (avaibles.Read())
            {

                Console.WriteLine(avaibles["PeliculasID"].ToString() + "\t" + avaibles["NombrePelicula"].ToString() + "\t" + avaibles["Categoria"].ToString() + "\t" + avaibles["ControlParental"].ToString() + "+");

            }
            conexion.Close();

            Console.WriteLine("Elige una Pelicula ingresando el numero : ");
            int select = Convert.ToInt32(Console.ReadLine());
            conexion.Open();
            cadena = "SELECT * From PELICULAS Where PeliculasID LIKE '" + select + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader pelicR = comando.ExecuteReader();
            conexion.Close();

            conexion.Open();
            cadena = "UPDATE Peliculas SET Disponible = 'Alquilada' WHERE PeliculasID LIKE'" + select + "'";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

            conexion.Open();
            cadena = "SELECT NombrePelicula AS NombrePelicula From PELICULAS Where PeliculasID LIKE '" + select + "'";
            //select es la pelicula seleccionada (numero)
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader nombrePeli = comando.ExecuteReader();
            nombrePeli.Read();
            nombrePelic = nombrePeli["NombrePelicula"].ToString();

            conexion.Close();

            conexion.Open();

            cadena = "INSERT INTO ALQUILERES (FechaAlquiler, PeliculasID,UserName,NombrePelicula,EstadoAlquiler ) VALUES ( GETDATE( ),'" + select + "','" + UserName + "','" + nombrePelic + "','" + enAlquiler + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            Console.WriteLine("El alquiler de la pelicula elegida ha sido registrada");
            Console.WriteLine("¿Cuántos dias quieres alquilarla?\n");
            diasAlquiler = Convert.ToInt32(Console.ReadLine());
            conexion.Open();
            cadena = "UPDATE ALQUILERES SET FechaEntrega = DATEADD(day," + diasAlquiler + " ,GETDATE())";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

            Console.ReadLine();

            return;
        }
    }

}


//        //******************* GET y SET ************************
//        public int GetIDPeliculas()
//        {
//            return idMovie;
//        }
//        public string GetTitulo()
//        {
//            return titleMovie;
//        }
//        public string GetGenero()
//        {
//            return genreMovie;
//        }
//        public int GetClasificacion()
//        {
//            return parentControl;
//        }

//        public void SetIDPeliculas(int IDPeliculas)
//        {
//            this.idMovie = IDPeliculas;
//        }
//        public void SetTitulo(string Titulo)
//        {
//            this.titleMovie = Titulo;
//        }
//        public void SetGenero(string Genero)
//        {
//            this.genreMovie = Genero;
//        }
//        public void SetClasificación(int Clasificacion)
//        {
//            this.parentControl = Clasificacion;
//        }

//       //metodos



//        public void VerPeliculas()
//        {
//            conexion.Open();
//            cadena = "SELECT * FROM Peliculas";
//            comando = new SqlCommand(cadena, conexion);
//            SqlDataReader registros = comando.ExecuteReader();
//            while (registros.Read())
//            {
//                Console.WriteLine(registros["IDPeliculas"].ToString() + "\t" + registros["Titulo"].ToString());

//            }
//            conexion.Close();

//            Console.WriteLine("Eliga una Pelicula");
//            int elecPeli = Convert.ToInt32(Console.ReadLine());
//            conexion.Open();
//            cadena = "SELECT * From Peliculas Where IDPeliculas like '" + elecPeli + "'";
//            comando = new SqlCommand(cadena, conexion);
//            SqlDataReader movie = comando.ExecuteReader();
//            while (movie.Read())
//            {
//                Console.WriteLine(movie["IDPeliculas"].ToString() + "\t" + movie["Titulo"].ToString() + "\t" + movie["Genero"].ToString() + "\t" + movie["Clasificacion"].ToString() + "\t" + movie["Estado"].ToString());

//            }
//            conexion.Close();
//            return;
//        }





//    }
//}