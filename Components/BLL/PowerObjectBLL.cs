using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class PowerObjectBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            PowerObject powerObject = JsonHelper.JsonToObject<PowerObject>(json);
            return new PowerObjectDAL().INSERT(powerObject);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteById(int id)
        {
            return new PowerObjectDAL().DeleteById(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int Update(string json)
        {
            PowerObject powerObject = JsonHelper.JsonToObject<PowerObject>(json);
            return new PowerObjectDAL().Update_V(powerObject);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int Update_V(PowerObject powerObject)
        {
            return new PowerObjectDAL().Update_V(powerObject);
        }


        /// <summary>
        /// 得到实体
        /// </summary>
        public PowerObject GetById(int id)
        {
            return new PowerObjectDAL().GetById(id);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new PowerObjectDAL().GetAll("*", whe, "");
            return JsonHelper.DataTableToArrayList(dt);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="sel_col">查询列</param>
        /// <param name="sel_whe">条件</param>
        /// <param name="sel_ord">排序</param>
        /// <param name="page_size">页大小</param>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public ArrayList GetPage(string sel_col, string sel_whe, string sel_ord, int page_size, int page, out int count)
        {
            count = new PowerObjectDAL().GetCount(sel_whe);
            DataTable dt = new PowerObjectDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }


        public DataTable GetAll(string sel_col, string sel_whe, string sel_ord)
        {
            return new PowerObjectDAL().GetAll(sel_col, sel_whe, sel_ord);
        }
    }
}