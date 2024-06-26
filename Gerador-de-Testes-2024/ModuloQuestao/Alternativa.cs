﻿namespace GeradorDeTestes2024.ModuloQuestao
{
    public class Alternativa
    {
        public string Descricao { get; set; }
        public bool Correta { get; set; }

        public Alternativa(string descricao)
        {
            Descricao = descricao;
            Correta = false;
        }

        public void MarcarCorreta()
        {
            Correta = true;
        }
        public override string ToString()
        {
            return $"{Descricao}";
        }

        public void LimparRespostaCorreta()
        {
            Correta = false;
        }

        internal void RefatorarModeloAlternativa(int count)
        {
            if (Descricao.Contains("->"))
                Descricao = Descricao.Split(" ")[2];
            Descricao = $"({(char)(65 + count)}) -> {Descricao}";
        }
    }
}