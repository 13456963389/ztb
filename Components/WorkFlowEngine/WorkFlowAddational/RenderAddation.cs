using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtbSoft;
using ZtbSoft.Models;

namespace Components.WorkFlowEngine.WorkFlowAddational
{
    public class RenderAddation
    {
        internal List<WorkFlow> GetMainWorkFlowList(int businessId)
        {
            string sqlCmd = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId=@BusinessId AND NodeType NOT IN ('" + Convert.ToInt32(NodeTypeStatus.START) + "','" + Convert.ToInt32(NodeTypeStatus.END) + "','" + Convert.ToInt32(NodeTypeStatus.NAMEDES) + "')";
            DataTable dt = SqlHelper.ExecuteDataTable(sqlCmd,
                new SqlParameter("@BusinessId", businessId));
            List<WorkFlow> lists = new List<WorkFlow>();
            if (dt == null || dt.Rows.Count <= 0)
            {
                throw new Exception("该业务流程无任何节点!");
            }
            foreach (DataRow item in dt.Rows)
            {
                lists.Add(new WorkFlow(item));
            }
            return lists;
        }

        internal List<WorkFlow> GetWorkFlowInfo(int businessId, int parentNodeCode)
        {
            string sqlCmd = @"SELECT * FROM dbo.WorkFlow
                WHERE BusinessId=@BusinessId AND PCode=@PCode AND NodeType NOT IN ('" + Convert.ToInt32(NodeTypeStatus.START) + "','" + Convert.ToInt32(NodeTypeStatus.END) + "','" + Convert.ToInt32(NodeTypeStatus.NAMEDES) + "')";
            DataTable dt = SqlHelper.ExecuteDataTable(sqlCmd,
                new SqlParameter("@BusinessId", businessId),
                new SqlParameter("@PCode", parentNodeCode));
            List<WorkFlow> lists = new List<WorkFlow>();
            if (dt == null || dt.Rows.Count <= 0)
            {
                throw new Exception("该业务流程无任何节点!");
            }
            foreach (DataRow item in dt.Rows)
            {
                lists.Add(new WorkFlow(item));
            }
            return lists;
        }

        internal WorkFlow GetIngMainNode(int businessId)
        {
            string sqlCmd = @"SELECT TOP 1 * FROM dbo.WorkFlow
                WHERE BusinessId=@BusinessId AND NodeStatu=@NodeStatu AND PCode IN (SELECT NodeCode FROM dbo.WorkFlow WHERE BusinessId=@BusinessId AND NodeType=" + Convert.ToInt32(NodeTypeStatus.NAMEDES) + ")";
            DataTable dt = SqlHelper.ExecuteDataTable(sqlCmd,
                new SqlParameter("@BusinessId", businessId),
                new SqlParameter("@NodeStatu", Convert.ToInt32(NodeActionStatus.DOING)));
            if (dt == null || dt.Rows.Count <= 0)
            {
                throw new Exception("该业务流程无任何正在进行的节点!");
            }
            return new WorkFlow(dt.Rows[0]);
        }

        internal List<WorkFlow> GetAllIngMainNode(List<int> businessIdList)
        {
            List<WorkFlow> lists = new List<WorkFlow>();
            businessIdList.ForEach(item =>
            {
                string sqlCmd = @"SELECT TOP 1 * FROM dbo.WorkFlow
                WHERE BusinessId=@BusinessId AND NodeStatu=@NodeStatu AND PCode IN (SELECT NodeCode FROM dbo.WorkFlow WHERE BusinessId=@BusinessId AND NodeType=" + Convert.ToInt32(NodeTypeStatus.NAMEDES) + ")";
                DataTable dt = SqlHelper.ExecuteDataTable(sqlCmd,
                    new SqlParameter("@BusinessId", item),
                    new SqlParameter("@NodeStatu", Convert.ToInt32(NodeActionStatus.DOING)));
                if (dt == null || dt.Rows.Count <= 0)
                {
                    throw new Exception("该业务流程无任何正在进行的节点!");
                }
                lists.Add(new WorkFlow(dt.Rows[0]));
            });
            return lists;
        }
    }
}
