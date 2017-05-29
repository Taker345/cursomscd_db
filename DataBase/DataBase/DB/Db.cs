using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class Db
    {
        private SqlConnection conexion = null;
        public void Connect()
        {
            try
            {
                //PREPARO LA CADENA DE CONEXION A LA BASE DE 
                string cadenaConexion = @"Server=.\sqlexpress;Database=testdb;User Id=testuser;Password=!Curso@2017; ";

                //CREO LA CONEXION
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;
                //TRATO DE ABRIR LA CONEXION
                conexion.Open();
                // PREGUNTO POR EL ESTADO DE LA CONEXION
                //if (conexion.State == ConnectionState.Open)
                //{
                //    Console.WriteLine("Conexion establecida con exito");
                //}

            }
            //USAMOS EL CATCH EN CASO DE ERROR CON LO QUE CERRAMOS Y DESTRUIMOS LA CONEXCION

            catch (Exception)
            {
                Console.WriteLine("Lo siento mijo, pero la base de datos esta en la mierda");
                if (conexion != null)
                {
                    //CIERRO LA CONEXION
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                        Console.WriteLine("Conexion cerrada con exito");
                    }
                    //DSTRUYO LA CONEXION
                    conexion.Dispose();
                    conexion = null;
                    Console.WriteLine("Conxion DESTRUIDA con Exito");
                }
            }
            finally
            {
                

            }


        }


        public bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public void Desconectar()
        {
            if (conexion != null)
            {
                //CIERRO LA CONEXION
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }

            }
        }
        public List<Usuario> DameLosUsuarios()
        {
            List<Usuario> usuarios = null;
            //Usuario[] usuarios = null;
            //PREPARO LA CONSULTA SQL PARA OBTENER USUARIO
            string consultaSQL = "SELECT * FROM Users";
            //PREPARO UN COMLANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, this.conexion);
            //RECOJO LOS DATOS
            SqlDataReader reader = comando.ExecuteReader();
            usuarios = new List<Usuario>();
            //int numeroDeUsuarios = 0;
            while (reader.Read())
            {

                usuarios.Add(new Usuario()
                {
                    hiddenId = int.Parse(reader["hiddenId"].ToString()),
                    id = reader["id"].ToString(),
                    password = reader["password"].ToString(),
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    photoUrl = reader["photoUrl"].ToString(),
                    searchPreferences = reader["searchPreferences"].ToString(),
                    status = bool.Parse(reader["status"].ToString()),
                    deleted = (bool)reader["deleted"],
                    isAdmin = Convert.ToBoolean(reader["isAdmin"]),

                });
            //numeroDeUsuarios++;
                //Console.WriteLine("Nombre : " + reader["firstName"]);
            }


            // DEVUELVO LOS DATOS
            return usuarios;
        }

        public void InsertUser(Usuario usuario)
        {
            //PREPARO LA CONSULTA SQL PARA INSERTAR AL NUEVO USUARIO
            string consultaSQL = @"INSERT INTO Users (
                                                email
                                               ,password
                                               ,firstName
                                               ,lastName
                                               ,photoUrl
                                               ,searchPreferences
                                               ,status
                                               ,deleted
                                               ,isAdmin
                                               )
                                         VALUES (";
            consultaSQL += "'" + usuario.email + "'";
            consultaSQL += ",'" + usuario.password + "'";
            consultaSQL += ",'" + usuario.firstName + "'";
            consultaSQL += ",'" + usuario.lastName + "'";
            consultaSQL += ",'" + usuario.photoUrl + "'";
            consultaSQL += "," + usuario.searchPreferences + "";
            consultaSQL += "," + (usuario.status ? "1" : "0");
            consultaSQL += "," + (usuario.deleted? "1":"0");
            consultaSQL += "," + (usuario.isAdmin ? "1" : "0");
            consultaSQL += ");";
            //PREPARO UN COMLANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, this.conexion);
            //RECOJO LOS DATOS
            comando.ExecuteNonQuery();
           
        

        }
    }
}
