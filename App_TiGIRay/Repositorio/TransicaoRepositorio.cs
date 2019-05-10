using System;
using System.Collections.Generic;
using System.IO;
using Trabalho_TiGIRay.ViewModel;

namespace Trabalho_TiGIRay.Repositorio
{
    public class TransicaoRepositorio
    {
        public static TransicaoViewModel Inserir (TransicaoViewModel transacao) {
            List<TransicaoViewModel> listaDeTransacoes = Listar ();
            int contador = 0;

            if (listaDeTransacoes != null) {
                contador = listaDeTransacoes.Count;
            }

            transacao.DataCricao = DateTime.Now;

            StreamWriter sw = new StreamWriter ("transacoes.csv", true);

            sw.WriteLine ($"{transacao.TiposDeTransacoes};{transacao.Descricao};{transacao.Valor};{transacao.DataCricao}");

            sw.Close ();

            return transacao;
        }

         public static List<TransicaoViewModel> Listar () {
            List<TransicaoViewModel> listaDeTransacoes = new List<TransicaoViewModel> ();
            TransicaoViewModel transacao;

            if (!File.Exists ("transacoes.csv")) {
                return null;
            }

            string[] transacoes = File.ReadAllLines ("transacoes.csv");

            foreach (var item in transacoes) {

                if (item != null) {
                    string[] dadosDaTransacao = item.Split (";");
                    transacao = new TransicaoViewModel ();
                    transacao.TiposDeTransacoes = dadosDaTransacao[0];
                    transacao.Descricao = dadosDaTransacao[1];
                    transacao.Valor = float.Parse (dadosDaTransacao[2]);
                    transacao.DataCricao = DateTime.Parse (dadosDaTransacao[3]);

                    listaDeTransacoes.Add (transacao);
                }
            }
            return listaDeTransacoes;
        }
    }
}