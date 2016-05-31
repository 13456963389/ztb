using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ZtbSoft.Components
{
    public class Trans_Model
    {
        public string SQL { get; set; }
        public SqlParameter[] Paras { get; set; }



    }

    public class Trans_SQL
    {
        public static bool ExecuteSqlTran(List<Trans_Model> SQLStringList)
        {

            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnSting()))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {

                    try
                    {
                        //循环  
                        foreach (Trans_Model Mysql in SQLStringList)
                        {

                            SqlCommand cmd = new SqlCommand(Mysql.SQL, conn);
                            cmd.Transaction = trans;
                            cmd.Parameters.AddRange(Mysql.Paras);
                            int result = cmd.ExecuteNonQuery();     //这里可以记录该事务的执行结果  
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

    }
}
