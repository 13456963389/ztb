using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class PowerDetailBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            PowerDetail powerDetail = JsonHelper.JsonToObject<PowerDetail>(json);
            return new PowerDetailDAL().INSERT(powerDetail);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByPowerDetailId(int powerDetailId)
        {
            return new PowerDetailDAL().DeleteByPowerDetailId(powerDetailId);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int Update(string json)
        {
            PowerDetail powerDetail = JsonHelper.JsonToObject<PowerDetail>(json);
            return new PowerDetailDAL().Update_V(powerDetail);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int Update_V(PowerDetail powerDetail)
        {
            return new PowerDetailDAL().Update_V(powerDetail);
        }


        /// <summary>
        /// 得到实体
        /// </summary>
        public PowerDetail GetByPowerDetailId(int powerDetailId)
        {
            return new PowerDetailDAL().GetByPowerDetailId(powerDetailId);
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new PowerDetailDAL().GetAll("*", whe, "");
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
            count = new PowerDetailDAL().GetCount(sel_whe);
            DataTable dt = new PowerDetailDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }


        public DataTable GetAll(string sel_col, string sel_whe, string sel_ord)
        {
            return new PowerDetailDAL().GetAll(sel_col, sel_whe, sel_ord);
        }
    }
}