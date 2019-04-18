using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App_PCC.Models
{
    [Table("glo_tb_atendimento")]
    class glo_tb_atendimento
    {
        [PrimaryKey, AutoIncrement]
        public int at_in_id { get; set; }
        public int at_in_aluno { get; set; }
        public int at_in_atendente {get; set; }
        public int cur_in_id { get; set; }
        public string at_st_desc { get; set; }
        public string at_st_obs { get; set; }
        public DateTime at_dt_cad { get; set; }
        public DateTime at_dt_fin { get; set; }
        public int user_in_fin { get; set; }
        public DateTime at_dt_delete { get; set; }
        public int at_in_tentativas { get; set; }
        public int at_in_status { get; set; }
        public int set_in_id { get; set; }
        public int mot_in_id { get; set; }
        public string D_E_L_E_T_E { get; set; }


    }
}
