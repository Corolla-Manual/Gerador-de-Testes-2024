﻿using GeradorDeTestes.WinForm.Compartilhado;

namespace GeradorDeTestes2024.ModuloQuestao
{
    internal class ControladorQuestao : ControladorBase
    {
        private IRepositorioQuestao repositorioQuestao;
        private TabelaQuestaoControl tabelaQuestao;

        public ControladorQuestao(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao;
        }

        public override string TipoCadastro => "Questões";

        public override string ToolTipAdicionar => "Cadastrar uma nova questão";

        public override string ToolTipEditar => "Editar uma questão já existente";

        public override string ToolTipExcluir => "Excluir uma questão já existente";

        public override void Adicionar()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterListagem()
        {
            if (tabelaQuestao == null)
                tabelaQuestao = new tabelaQuestaoControl();

            List<Questao> questoes = repositorioQuestao.SelecionarTodos();

            tabelaQuestao.AtualizarRegistros(questoes);

            return tabelaQuestao;
        }
    }
}
