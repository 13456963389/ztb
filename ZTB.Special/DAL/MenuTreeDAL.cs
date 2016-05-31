using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft;

namespace ZTB.Special.DAL
{
    public class MenuTreeDAL
    {
        /// <summary>
        /// 获取树数据
        /// </summary>
        /// <param name="treeType"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetList(string treeType, string pid)
        {
            DataTable dt = new DataTable();
            if (pid != "0")
            {
                switch (treeType)
                {
                    case "dict":
                        GetDictTreeData(Int32.Parse(pid), out dt);
                        break;
                    case "sysConfig":
                        GetSysConfigTreeData(out dt);
                        break;
                }
            }
            if (dt.Rows.Count < 1)
                LoadTreeData(dt);
            return dt;
        }

        /// <summary>
        /// 数据字典
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pid"></param>
        private void GetDictTreeData(int pid, out DataTable dt)
        {
            string sql = @"
SELECT DictId AS id,DictName AS [name],Pid AS pid 
FROM dbo.Dict 
WHERE PId=@pid
            ";
            SqlParameter[] pars = { 
                                  new SqlParameter("@pid",pid)
                                  };
            dt = SqlHelper.ExecuteDataTable(CommandType.Text, sql, pars);
        }

        /// <summary>
        /// 系统配置
        /// </summary>
        /// <param name="dt"></param>
        private void GetSysConfigTreeData(out DataTable dt)
        {
            string sql = @"
SELECT ConfigId AS id,ConfigName AS [name],0 AS pid FROM dbo.SysConfig
            ";
            dt = SqlHelper.ExecuteDataTable(CommandType.Text, sql);
        }

        /// <summary>
        /// 初始化根节点
        /// </summary>
        /// <param name="dt"></param>
        private void LoadTreeData(DataTable dt)
        {
            dt.Columns.Add(new DataColumn("id", typeof(int)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("pid", typeof(int)));
            dt.Columns.Add(new DataColumn("url", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["id"] = 0;
            dr["name"] = "基础节点";
            dr["pid"] = -1;
            dr["url"] = "#";
            dt.Rows.Add(dr);
        }
    }
}
