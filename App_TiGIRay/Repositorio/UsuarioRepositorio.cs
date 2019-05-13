using System;
using System.Collections.Generic;
using System.IO;
using Trabalho_TiGIRay.ViewModel;

namespace Trabalho_TiGIRay.Repositorio {
    public class UsuarioRepositorio {
        public static UsuarioViewModel Inserir (UsuarioViewModel usuario) {
            List<UsuarioViewModel> listaDeUsuarios = Listar ();

            if (listaDeUsuarios != null) {
                usuario.Id = listaDeUsuarios.Count;
            }

            StreamWriter sw = new StreamWriter ("usuarios.csv", true);

            sw.WriteLine ($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento};");

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
                    usuario.Id = int.Parse(dadosDoUsuario[0]);
                    usuario.Nome = dadosDoUsuario[1];
                    usuario.Email = dadosDoUsuario[2];
                    usuario.Senha = dadosDoUsuario[3];
                    usuario.DataNascimento = DateTime.Parse (dadosDoUsuario[4]);

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