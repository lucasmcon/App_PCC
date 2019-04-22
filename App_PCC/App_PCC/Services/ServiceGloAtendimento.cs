using System;
using System.Collections.Generic;
using System.Text;
using App_PCC.Models;
using SQLite;

namespace App_PCC.Services
{
    class ServiceGloAtendimento
    {
        SQLiteConnection conn;
        public string Mensagem { get; set; }

        public ServiceGloAtendimento(string Caminho)
        {
            if (Caminho == "")
                Caminho = App.Caminho;

            conn = new SQLiteConnection(Caminho);
            conn.CreateTable<glo_tb_atendimento>();
        }

        public void Inserir(glo_tb_atendimento atendimento)
        {
            try
            {
                int result = conn.Insert(atendimento);
                if (result != 0)
                {
                    this.Mensagem = string.Format("Senha gerada");
                }
                else
                {
                    this.Mensagem = string.Format("Nenhuma senha gerada");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
