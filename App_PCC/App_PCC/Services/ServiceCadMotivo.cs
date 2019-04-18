using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App_PCC.Models;


namespace App_PCC.Services
{
    class ServiceCadMotivo
    {
        SQLiteConnection conn;
        public string Mensagem { get; set; }

        public ServiceCadMotivo(string Caminho)
        {
            if (Caminho == "")
                Caminho = App.Caminho;

            conn = new SQLiteConnection(Caminho);
            conn.CreateTable<cad_tb_motivo>();
        }

        public void Inserir(cad_tb_motivo motivo)
        {
            try
            {
                int result = conn.Insert(motivo);
                if (result != 0)
                {
                    this.Mensagem = string.Format("Setor cadastrado - Nome: {0}", motivo.mot_st_desc);
                }
                else
                {
                    this.Mensagem = string.Format("Nenhum cadastro inserido");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<cad_tb_motivo> Listar(int set_in_id)
        {
            List<cad_tb_motivo> lista = new List<cad_tb_motivo>();
            try
            {
                //lista = conn.Table<cad_tb_motivo>().ToList();
                lista = conn.Query<cad_tb_motivo>("SELECT mot_st_desc FROM cad_tb_motivo WHERE set_in_id =" + set_in_id);
                this.Mensagem = "Listagem dos Motivos";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }
    }
}
