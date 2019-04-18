using System;
using System.Collections.Generic;
using System.Text;
using App_PCC.Models;
using SQLite;

namespace App_PCC.Services
{
    public class ServiceCadUser
    {
        SQLiteConnection conn;
        public string Mensagem { get; set; }

        public ServiceCadUser(string Caminho)
        {
            if (Caminho == "")
                Caminho = App.Caminho;

            conn = new SQLiteConnection(Caminho);
            conn.CreateTable<cad_tb_user>();
        }


        public void Inserir(cad_tb_user user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.user_st_nome))
                    throw new Exception("Nome não infomado");
                if (string.IsNullOrEmpty(user.user_st_login))
                    throw new Exception("Login não informado");
                if (string.IsNullOrEmpty(user.user_st_senha))
                    throw new Exception("Senha não informada");
                if (string.IsNullOrEmpty(user.user_st_email))
                    throw new Exception("E-mail não informado");

                int result = conn.Insert(user);
                if(result != 0)
                {
                    this.Mensagem = string.Format("Usuário cadasrado - Nome: {0}", user.user_st_nome);
                }
                else
                {
                    this.Mensagem = string.Format("Nenhum cadastro inserido");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean verifUsuario(string login, string senha)
        {
            try
            { 
                var consult = conn.Query<cad_tb_user>("SELECT * FROM cad_tb_user WHERE user_st_login='" + login + "' AND user_st_senha='" + senha + "'");

                Boolean verif = consult.Count > 0 ? true : false;

                return verif;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int idUser(string login, string senha)
        {
            string user_in_id= "";
            var table = conn.Query<cad_tb_user>("SELECT user_in_id FROM cad_tb_user WHERE user_st_login='"+login+"' AND user_st_senha='"+senha+"'");
            foreach (var s in table)
            {
                user_in_id = s.user_in_id.ToString();
            }

            return Convert.ToInt32(user_in_id);
        }
    }
}
