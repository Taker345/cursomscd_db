using System;
using System.Collections.Generic;

namespace DataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectando a la base de datos");
            Db database = new Db();
            database.Connect();

            if (database.EstaLaConexionAbierta())
            {
                Usuario newUser = new Usuario()
                {
                    //hiddenId = 0,
                    //id = "",
                    firstName = "",
                    lastName = "",
                    email = "",
                    password = "",
                    photoUrl = "",
                    searchPreferences = "",
                    status = false,
                    deleted = false,
                    isAdmin = false,


                };
                database.InsertUser(newUser)

                ;

                List<Usuario> listaUsuarios = database.DameLosUsuarios();

                listaUsuarios.ForEach(usuario =>
                {
                    Console.WriteLine(

                        "\n"
                        + "\n"
                        + "hiddenId : "
                        + usuario.hiddenId
                        + "\nId : "
                        + usuario.id
                        + "\nEmail : "
                        + usuario.email
                        + "\nContraseña : "
                        + usuario.password
                        + "\nNombre : " 
                        + usuario.firstName 
                        + "\nApellido : " 
                        + usuario.lastName 
                        + "\nFoto de URL : "
                        + usuario.photoUrl
                        + "\nBuscar Preferencia : "
                        + usuario.searchPreferences
                        + "\nEs admin : "
                        + usuario.isAdmin
                        );
                });
            }

            database.Desconectar();
            database = null;
            


            Console.ReadKey();
        }



    }
}
