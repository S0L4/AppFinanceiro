using System;
using System.Collections.Generic;
using Trabalho_TiGIRay.Repositorio;
using Trabalho_TiGIRay.ViewModel;

namespace Trabalho_TiGIRay.ViewController {
    public class TransicaoViewController {
        public static void CadastrarTransicao () {
            string descricao, transacoes;
            float valor;

            do {
                System.Console.WriteLine ("Defina um tipo de Transação");
                transacoes = ExibirOpcoes ();

                if (string.IsNullOrEmpty(transacoes))
                {
                    System.Console.WriteLine("Tipo Inválido");
                }

            } while (string.IsNullOrEmpty(transacoes));

            do {
                System.Console.WriteLine ("Defina uma descrição");
                descricao = Console.ReadLine ();

                if (string.IsNullOrEmpty (descricao)) {
                    System.Console.WriteLine ("Descrição Inválida");
                }

            } while (string.IsNullOrEmpty (descricao));

            do {
                System.Console.WriteLine ("Digite o valor");
                valor = float.Parse (Console.ReadLine ());

                if (float.IsNegative (valor)) {
                    System.Console.WriteLine ("Valor Inválido");
                }

            } while (float.IsNegative (valor));

            TransicaoViewModel transacao = new TransicaoViewModel ();
            transacao.TiposDeTransacoes = transacoes;
            transacao.Descricao = descricao;
            transacao.Valor = valor;

            TransicaoRepositorio.Inserir (transacao);

            System.Console.WriteLine ("Cadastro Efetuado com sucesso");
            Console.ReadLine ();
        }
        public static void ListarTransacoes () {
            List<TransicaoViewModel> listaDeTransacao = TransicaoRepositorio.Listar();

            foreach (var item in listaDeTransacao)
            {
                if (item != null)
                {
                    System.Console.WriteLine ("================================");
                    System.Console.WriteLine($"TIPO: {item.TiposDeTransacoes}");
                    System.Console.WriteLine($"DESCRIÇÃO: {item.Descricao}");
                    System.Console.WriteLine($"VALOR: {item.Valor}");
                    System.Console.WriteLine($"DATA DE CRIAÇÃO: {item.DataCricao}");
                    System.Console.WriteLine ("================================");
                }

                System.Console.WriteLine("Aperte ENTER para voltar para o menu");
                Console.ReadLine();
                
            }
        }

        public static string ExibirOpcoes () {
            string opcao = "";
            bool opcaoNaoEscolhida = false;
            do {
                System.Console.WriteLine ("================================");
                System.Console.WriteLine ("||  (1) Despesa                ||");
                System.Console.WriteLine ("||  (2) Receita                ||");
                System.Console.WriteLine ("================================");
                System.Console.WriteLine ("Escolha uma opção:              ");

                int codigoOpcao = int.Parse (Console.ReadLine ());

                switch (codigoOpcao) {
                    case 1:
                        opcao = "Despesa";
                        opcaoNaoEscolhida = false;
                        break;

                    case 2:
                        opcao = "Receita";
                        opcaoNaoEscolhida = false;
                        break;

                    default:
                        System.Console.WriteLine ("Cógiogo Inválido");
                        break;
                }

            } while (opcaoNaoEscolhida);
            return opcao;
        }

    }
}