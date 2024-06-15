﻿using GeradorDeTestes.WinForm.Compartilhado;
using GeradorDeTestes2024.ModuloMateria;
using GeradorDeTestes2024.ModuloTeste;

namespace GeradorDeTestes2024.ModuloQuestao
{
    internal class RepositorioQuestao : RepositorioBaseEmArquivo<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestao(ContextoDados contexto) : base(contexto)
        {
            if (contexto.Questoes.Any())
                contadorId = contexto.Questoes.Max(i => i.Id) + 1;
        }

        public void AdicionarDependencia(Teste novoTeste)
        {
            List<Questao> questoes = contexto.Questoes.FindAll(q => novoTeste.Questoes.Contains(q));

            foreach (Questao q in questoes)
            {
                q.Testes.Add(novoTeste);
                Editar(q.Id, q);
            }
        }

        public void AtualizarDependencia(Teste testeSelecionado, Teste testeEditado)
        {
            Questao questao = null;
            List<Teste> testes = new List<Teste>();

            foreach (Questao quest in contexto.Questoes)
            {
                if (quest.Testes.Find(q => q.Materia.Id == testeSelecionado.Materia.Id) != null)
                    questao = quest;

            }
            foreach (Teste t in questao.Testes)
            {
                if (t.Id != testeSelecionado.Id)
                {
                    testes.Add(t);
                }
            }
            questao.Testes.Clear();
            questao.Testes = testes;

            List<Questao> questoes = contexto.Questoes.FindAll(q => testeEditado.Questoes.Contains(q));

            foreach (Questao q in questoes)
            {
                q.Testes.Add(testeEditado);
            }
        }

        public override bool Excluir(int id)
        {
            Questao questao = SelecionarPorId(id);

            List<Questao> questoes = new List<Questao>();
            Materia materia = contexto.Materias.Find(m => m.Id == questao.Materia.Id);
            foreach (Questao q in materia.Questoes)
            {
                if (q.Id != questao.Id)
                    questoes.Add(q);
            }
            materia.Questoes.Clear();
            materia.Questoes = questoes;

            return base.Excluir(id);
        }
        protected override List<Questao> ObterRegistros()
        {
            return contexto.Questoes;
        }

    }
}
