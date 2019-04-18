using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App_PCC.Models;

namespace App_PCC.Services
{
    class ServiceCadSetor
    {
        SQLiteConnection conn;
        public string Mensagem { get; set; }

        public ServiceCadSetor(string Caminho)
        {
            if (Caminho == "")
                Caminho = App.Caminho;

            conn = new SQLiteConnection(Caminho);
            conn.CreateTable<cad_tb_setor>();
        }


        public void Inserir(cad_tb_setor setor)
        {
            try
            {

                int result = conn.Insert(setor);
                if (result != 0)
                {
                    this.Mensagem = string.Format("Setor cadastrado - Nome: {0}", setor.set_st_desc);
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

        public string idSetor(string set_st_desc)
        {
            string id = "";
            var table = conn.Query<cad_tb_setor>("SELECT set_in_id FROM cad_tb_setor WHERE set_st_desc='"+set_st_desc+"'");
            foreach(var s in table)
            {
                id = s.set_in_id.ToString();
            }

            return id;
        }

        public List<cad_tb_setor> Listar()
        {
            List<cad_tb_setor> lista = new List<cad_tb_setor>();
            try
            {
                lista = conn.Table<cad_tb_setor>().ToList();
                this.Mensagem = "Listagem dos Setores";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }

    }
}
