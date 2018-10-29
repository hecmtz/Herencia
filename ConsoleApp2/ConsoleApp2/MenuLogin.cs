using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{


    class MenuLogin
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["blockbuster"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;


        RegistrarUsuario regUser = new RegistrarUsuario();

        ////set & get
        //public void SetUsuario(string usuario)
        //{
        //    this.usuario = usuario;
        //}
        //public string GetUsuario()
        //{
        //    return this.usuario;
        //}
        //public void SetPassw(string passw)
        //{
        //    this.passw = passw;

        //}
        //public void SetLogin(bool loginComplete)
        //{
        //    this.loginComplete = loginComplete;
        //}
        //public bool GetLogin()
        //{
        //    return this.loginComplete;
        //}
        //public string GetPassw()
        //{
        //    return this.passw;
        //}

        //starts log id


    }
}
