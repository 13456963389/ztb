/*
 * creater:张成仪|成意
 * createtime:2016年2月23日
 * remark:表单页面数据处理
 * *****************************************************
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZtbSoft.Components
{
    /// <summary>
    /// 表单页面数据处理
    /// </summary>
    public class PageDataHelper
    {
        /// <summary>
        /// 根据JSON获取实体
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="pageJsonData">Json数据</param>
        /// <param name="paramName">参数名菜（formData：页面表单实体，gridModel:页面表格数据实体）</param>
        /// <returns>实体对象</returns>
        public static T GetModelToJoson<T>(string pageJsonData, string paramName)
        {
            var rtnObj = default(T);
            ArrayList rows = (ArrayList)JsonHelper.Decode(pageJsonData);
            if (rows.Count > 0)
            {
                //采购申请单数据
                Hashtable formJson = (Hashtable)rows[0];
                rtnObj = JsonHelper.JsonToObject<T>(formJson[paramName].ToString());
            }
            return rtnObj;
        }
    }
}
