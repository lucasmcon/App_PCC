using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App_PCC.Models
{
    [Table("cad_tb_user")]
    public class cad_tb_user
    {
        [PrimaryKey, AutoIncrement]
        public int user_in_id { get; set; }
        [NotNull]
        public string user_st_nome { get; set; }
        [NotNull]
        public string user_st_login { get; set; }
        [NotNull]
        public string user_st_senha { get; set; }
        [NotNull]
        public string user_st_email { get; set; }
        [NotNull]
        public DateTime user_dt_cad { get; set; }
        public int user_in_cad { get; set; }
        public DateTime user_dt_edit { get; set; }
        public int user_in_edit { get; set; }
        [NotNull]
        public int user_in_status { get; set; }
        public string user_st_tipo { get; set; }

    }
}
