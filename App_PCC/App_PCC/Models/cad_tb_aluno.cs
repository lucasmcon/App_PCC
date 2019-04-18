using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App_PCC.Models

{
    [Table("car_tb_aluno")]
    class cad_tb_aluno
    {
        [PrimaryKey, AutoIncrement]
        public int alu_in_id { get; set; }
        [NotNull]
        public int user_in_id { get; set; }
        [NotNull]
        public int cur_in_id { get; set; }
        public string alu_st_nome { get; set; }
        public  int alu_in_ra { get; set; }
        public string alu_st_email { get; set; }
        public string alu_st_cpf { get; set; }
        public DateTime alu_dt_nasc { get; set; }
        public int alu_in_cep { get; set; }
        public string alu_st_end { get; set; }
        public int alu_in_numero { get; set; }
        public string alu_st_complemento { get; set; }
        public string alu_st_bairro { get; set; }
        public string alu_st_cidade { get; set; }
        public string alu_st_uf { get; set; }
        public DateTime alu_dt_cad { get; set; }
        public DateTime alu_dt_edit { get; set; }
        public int alu_in_status { get; set; }
        public int alu_in_edit { get; set; }
        public int alu_in_cad { get; set; }

    }
}
