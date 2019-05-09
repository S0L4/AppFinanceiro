using System.Collections.Generic;
using System.IO;
using Trabalho_TiGIRay.ViewModel;
using System;

namespace Trabalho_TiGIRay.Repositorio
{
    public class UsuarioRepositorio
    {
        public List<UsuarioViewModel> Listar () {
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
                    usuario.Nome = dadosDoUsuario[1];
                    usuario.Email = dadosDoUsuario[2];
                    usuario.Senha = dadosDoUsuario[3];
                    usuario.DataNascimento = DateTime.Parse (dadosDoUsuario[4]);

                    listaDeUsuarios.Add (usuario);
                }
            }
            return listaDeUsuarios;
        }
        
        public UsuarioViewModel Inserir (UsuarioViewModel usuario) {
            List<UsuarioViewModel> listaDeUsuarios = Listar ();
            int contador = 0;

            if (listaDeUsuarios != null) {
                contador = listaDeUsuarios.Count;
            }

            StreamWriter sw = new StreamWriter ("usuarios.csv", true);

            sw.WriteLine ($"{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento}");

            sw.Close ();

            return usuario;
        }
    }
}