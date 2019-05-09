using System;
using Trabalho_TiGIRay.Repositorio;
using Trabalho_TiGIRay.ViewModel;

namespace Trabalho_TiGIRay.ViewController {
    public class UsuarioViewController {
        public static void CadastrarUsuario () {

            string nome, email, senha;
            DateTime dataNascimento;

            do {
                System.Console.WriteLine ("Digite seu nome completo");
                nome = Console.ReadLine ();

                if (string.IsNullOrEmpty (nome)) {
                    System.Console.WriteLine ("Nome inválido!");
                }

            } while (string.IsNullOrEmpty (nome));

            do {
                System.Console.WriteLine ("Digite a sua data de nascimento");
                dataNascimento = DateTime.Parse (Console.ReadLine ());

            } while (dataNascimento != null);

            do {
                System.Console.WriteLine ("Digite seu e-mail");
                email = Console.ReadLine ();

                if (email.Contains ("@") && email.Contains (".com") && string.IsNullOrEmpty (email)) {
                    System.Console.WriteLine ("E-mail inválido!");
                }

            } while (email.Contains ("@") && email.Contains (".com") && string.IsNullOrEmpty (email));

            do {
                System.Console.WriteLine ("Digite uma senha com no mínimo 6 caracteres");
                senha = Console.ReadLine ();

                if (senha.Length < 5) {
                    System.Console.WriteLine ("Senha inválida!");
                }

            } while (senha.Length < 5);

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel ();
            usuarioViewModel.Nome = nome;
            usuarioViewModel.DataNascimento = dataNascimento;
            usuarioViewModel.Email = email;
            usuarioViewModel.Senha = senha;

            UsuarioRepositorio.Inserir (usuario);

            System.Console.WriteLine ("Cadastro Efetuado com sucesso");
            System.Console.WriteLine ("");
        }
    }
}