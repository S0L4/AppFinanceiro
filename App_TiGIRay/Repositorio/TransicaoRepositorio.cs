using System;
using System.Collections.Generic;
using System.IO;
using Ionic.Zip;
using Spire.Doc;
using Spire.Doc.Documents;
using Trabalho_TiGIRay.ViewModel;

namespace Trabalho_TiGIRay.Repositorio {
    public class TransicaoRepositorio {
        public static TransicaoViewModel Inserir (TransicaoViewModel transacao) {
            List<TransicaoViewModel> listaDeTransacoes = Listar ();
            int contador = 0;

            if (listaDeTransacoes != null) {
                contador = listaDeTransacoes.Count;
            }

            transacao.DataCricao = DateTime.Now;

            StreamWriter sw = new StreamWriter ("transacoes.csv", true);

            sw.WriteLine ($"{transacao.IdUsuario};{transacao.TiposDeTransacoes};{transacao.Descricao};{transacao.Valor};{transacao.DataCricao}");

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
                    transacao.IdUsuario = int.Parse (dadosDaTransacao[0]);
                    transacao.TiposDeTransacoes = dadosDaTransacao[1];
                    transacao.Descricao = dadosDaTransacao[2];
                    transacao.Valor = float.Parse (dadosDaTransacao[3]);
                    transacao.DataCricao = DateTime.Parse (dadosDaTransacao[4]);

                    listaDeTransacoes.Add (transacao);
                }
            }
            return listaDeTransacoes;
        }

        public static void CriarArquivo () {
            float receita = 0, despesas = 0;
            Document documento = new Document ();
            Paragraph paragrafo = documento.AddSection ().AddParagraph ();
            var listaDeTransacoes = new List<TransicaoViewModel> ();
            var listaDeUsuarios = new List<UsuarioViewModel> ();

            foreach (var item in listaDeTransacoes) {
                if (item.TiposDeTransacoes.Equals ("Receita")) {
                    receita += item.Valor;
                } else {
                    despesas += item.Valor;
                }

                float saldo = receita - despesas;

            }
            foreach (var item in listaDeUsuarios) {
                if ((item != null) && item.Id.Equals(true)) {
                    System.Console.WriteLine("CHEGOOOU!");
                    paragrafo.AppendText("================================");
                    paragrafo.AppendText($"ID: {item.Id}");
                    paragrafo.AppendText($"Usuario: {item.Nome}");
                    paragrafo.AppendText($"E-Mail: {item.Email}");
                    paragrafo.AppendText($"Senha: {item.Senha}");
                    paragrafo.AppendText($"Data de Nascimento: {item.DataNascimento}");
                    paragrafo.AppendText("================================");

                }

            }

            documento.SaveToFile ("Transacoes.docx");

            ZipFile zip = new ZipFile ();
            zip.AddFile ("Transacoes.docx");
            zip.Save ("Transacoes.zip");
        }

    }

}