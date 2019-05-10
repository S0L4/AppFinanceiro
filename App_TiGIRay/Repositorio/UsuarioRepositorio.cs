using System;
using System.Collections.Generic;
using System.IO;
using Trabalho_TiGIRay.ViewModel;

namespace Trabalho_TiGIRay.Repositorio {
    public class UsuarioRepositorio {
        public static UsuarioViewModel Inserir (UsuarioViewModel usuario) {
            List<UsuarioViewModel> listaDeUsuarios = Listar ();
            int contador = 0;

            if (listaDeUsuarios != null) {
                contador = listaDeUsuarios.Count;
            }

            StreamWriter sw = new StreamWriter ("usuarios.csv", true);

            sw.WriteLine ($"{usuario.Nome};{usuario.DataNascimento};{usuario.Email};{usuario.Senha}");

            sw.Close ();

            return usuario;
        }

        public static List<UsuarioViewModel> Listar () {
            List<UsuarioViewModel> listaDeUsuarios = new List<UsuarioViewModel> ();
            UsuarioViewModel usuario;

            if (!File.Exists ("usuarios.csv")) {
                return null;
            }

            string[] usuarios = File.ReadAllLines ("usuarios.csv");

            foreach (var item in usuarios) {

                if (item != null) {
                    string[] dadosDoUsuario = item.Split (";");
                    usuario = new UsuarioViewModel ();
                    usuario.Nome = dadosDoUsuario[0];
                    usuario.Email = dadosDoUsuario[1];
                    usuario.Senha = dadosDoUsuario[2];
                    usuario.DataNascimento = DateTime.Parse (dadosDoUsuario[3]);

                    listaDeUsuarios.Add (usuario);
                }
            }
            return listaDeUsuarios;
        }

        public static UsuarioViewModel Buscar (string email, string senha) {
            List<UsuarioViewModel> listaDeUsuarios = Listar ();

            foreach (var item in listaDeUsuarios) {
                if (item != null && email.Equals (item.Email) && senha.Equals (item.Senha)) {
                    return item;
                }
            }
            return null;
        }
    }
}