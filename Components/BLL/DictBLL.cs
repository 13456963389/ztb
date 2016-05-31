using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ZtbSoft.DAL;
using ZtbSoft.Models;

namespace ZtbSoft.BLL
{

    public partial class DictBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        public int Insert(string json)
        {
            Dict dict = JsonHelper.JsonToObject<Dict>(json);
            return new DictDAL().INSERT(dict);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteByDictId(int dictId)
        {
            return new DictDAL().DeleteByDictId(dictId);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public int Update(string json)
        {
            Dict dict = JsonHelper.JsonToObject<Dict>(json);
            return new DictDAL().Update_V(dict);
        }
        /// <summary>
        /// 修改
        /// </summary>
        public int Update_V(Dict dict)
        {
            return new DictDAL().Update_V(dict);
        }


        /// <summary>
        /// 得到实体
        /// </summary>
        public Dict GetByDictId(int dictId)
        {
            return new DictDAL().GetByDictId(dictId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns></returns>
        public DataTable GetModelByDictId(int dictId)
        {
            var dt = new DictDAL().GetModelByDictId(dictId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["PId"].ToString() == "0")
                    dt.Rows[i]["PName"] = "基础节点";
            }
            return dt;
        }
        /// <summary>
        /// 得到所有
        /// </summary>
        /// <param name="whe">条件</param>
        /// <returns></returns>
        public ArrayList GetAll(string whe)
        {
            DataTable dt = new DictDAL().GetAll("*", whe, "");
            return JsonHelper.DataTableToArrayList(dt);
        }

        /// <summary>
        /// 获取数据字典下拉列表
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        public ArrayList GetDictDrop(string dictCode)
        {
            return JsonHelper.DataTableToArrayList(new DictDAL().GetDictDrop(dictCode));
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
            count = new DictDAL().GetCount(sel_whe);
            DataTable dt = new DictDAL().GetPage(sel_col, sel_whe, sel_ord, page_size, page);
            return JsonHelper.DataTableToArrayList(dt);
        }

    }
}
