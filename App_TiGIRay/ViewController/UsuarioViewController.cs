using System;
using Trabalho_TiGIRay.Repositorio;
using Trabalho_TiGIRay.Utils;
using Trabalho_TiGIRay.ViewModel;

namespace Trabalho_TiGIRay.ViewController {
    public class UsuarioViewController {
        public static void CadastrarUsuario () {

            string nome, email, senha, confirmarSenha;
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

            } while (dataNascimento.Equals (""));

            do {
                System.Console.WriteLine ("Digite o E-mail do usuário");
                email = Console.ReadLine ();

                if (!ValidacaoUtil.ValidacaoEmail (email)) {
                    System.Console.WriteLine ("E-mail inválido");
                }

            } while (!ValidacaoUtil.ValidacaoEmail (email));

            do {
                System.Console.WriteLine ("Digite a sua senha");
                senha = Console.ReadLine ();

                System.Console.WriteLine ("Confirme a sua senha");
                confirmarSenha = Console.ReadLine ();

                if (!ValidacaoUtil.ValidacaoSenha (senha, confirmarSenha)) {
                    System.Console.WriteLine ("Senha inválida");
                }

            } while (!ValidacaoUtil.ValidacaoSenha (senha, confirmarSenha));

            UsuarioViewModel usuario = new UsuarioViewModel ();
            usuario.Nome = nome;
            usuario.DataNascimento = dataNascimento;
            usuario.Email = email;
            usuario.Senha = senha;

            UsuarioRepositorio.Inserir (usuario);

            System.Console.WriteLine ("Cadastro Efetuado com sucesso");
            Console.ReadLine ();

        }

        public static UsuarioViewModel EfetuarLogin () {
            string email, senha;

            System.Console.WriteLine ("Digite seu e-mail");
            email = Console.ReadLine ();

            System.Console.WriteLine ("Digite sua senha");
            senha = Console.ReadLine ();

            UsuarioViewModel usuarioRecuperado = UsuarioRepositorio.Buscar (email, senha);

            if (usuarioRecuperado != null) {
                return usuarioRecuperado;
            }
            System.Console.WriteLine("Usuário não encontrado");
            return null;
        }
    }
}