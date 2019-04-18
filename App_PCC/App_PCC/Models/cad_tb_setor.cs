using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App_PCC.Models
{
    [Table("cad_tb_setor")]
    class cad_tb_setor
    {
        [PrimaryKey, AutoIncrement]
        public int set_in_id { get; set; }
        [NotNull]
        public string set_st_desc { get; set; }
        public int set_in_status { get; set; }
        public int user_in_cad { get; set; }
        public DateTime set_dt_cad { get; set; }
        public int user_in_edit { get; set; }
        public DateTime set_in_edit { get; set; }
        public int user_in_aprov { get; set; }
        public DateTime set_dt_aprov { get; set; }
        public int user_in_delete { get; set; }
        public DateTime set_dt_delete { get; set; }
        public string D_E_L_E_T_E { get; set; }
    }
}
