using System;
using Trabalho_TiGIRay.Repositorio;
using Trabalho_TiGIRay.Utils;
using Trabalho_TiGIRay.ViewController;

namespace Trabalho_TiGIRay {
    class Program {
        static void Main (string[] args) {
            int resposta = 0;
            int opcaoLogado = 0;

            do {
                MenuUtils.MenuDeslogado ();
                resposta = int.Parse (Console.ReadLine ());

                switch (resposta) {
                    case 1:
                        // Cadatrar usuario
                        UsuarioViewController.CadastrarUsuario ();
                        break;

                    case 2:
                        // Efetuar login
                        var usuarioLogado = UsuarioViewController.EfetuarLogin ();
                        do {
                            MenuUtils.MenuLogado ();
                            opcaoLogado = int.Parse (Console.ReadLine ());

                            switch (opcaoLogado) {

                                case 1:
                                    // Cadastrar Transiçoes
                                    TransicaoViewController.CadastrarTransicao ();
                                    break;

                                case 2:
                                    // Listar
                                    TransicaoViewController.ListarTransacoes ();
                                    break;

                                case 3:
                                    // Exibir saldo
                                    TransicaoViewController.ExibirSaldo (usuarioLogado);
                                    break;

                                case 4:
                                    // Exibir relatório no world
                                    TransicaoRepositorio.CriarArquivo();
                                    break;

                                case 0:
                                    // Sair
                                    break;
                                default:
                                    System.Console.WriteLine ("Valor inválido!");
                                    break;
                            }
                        } while (opcaoLogado != 0);

                        // Opções de transações

                        break;

                    default:
                        System.Console.WriteLine ("Valor inválido!");
                        break;
                }
            } while (resposta != 0);
        }
    }
}