using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ZtbSoft.Components
{
    public enum enum_PowerType
    {
        view = 1, //查看
        add = 2,  //添加
        edit = 3, //修改
        delete = 4   //删除
    }
    public class PowerHelper
    {

        /// <summary>
        /// 是否具有 查看 权限
        /// </summary>
        /// <param name="code">权限Code</param>
        /// <param name="dt">具有的权限</param>
        /// <returns></returns>
        public static string isView(string code, DataTable dt)
        {
            if (!isPower(enum_PowerType.view, code, dt))
            {
                Hashtable result = new Hashtable();
                result["error"] = -3;
                result["message"] = "没有查看权限";
                return JsonHelper.Encode(result);
            }
            return string.Empty;
        }
        /// <summary>
        /// 是否具有 新增 权限
        /// </summary>
        /// <param name="code">权限Code</param>
        /// <param name="dt">具有的权限</param>
        /// <returns></returns>
        public static string isAdd(string code, DataTable dt)
        {
            if (!isPower(enum_PowerType.add, code, dt))
            {
                Hashtable result = new Hashtable();
                result["error"] = -3;
                result["message"] = "没有新增权限";
                return JsonHelper.Encode(result);
            }
            return string.Empty;
        }

        /// <summary>
        /// 是否具有 修改 权限
        /// </summary>
        /// <param name="code">权限Code</param>
        /// <param name="dt">具有的权限</param>
        /// <returns></returns>
        public static string isEdit(string code, DataTable dt)
        {
            if (!isPower(enum_PowerType.edit, code, dt))
            {
                Hashtable result = new Hashtable();
                result["error"] = -3;
                result["message"] = "没有修改权限";
                return JsonHelper.Encode(result);
            }
            return string.Empty;
        }

        /// <summary>
        /// 是否具有 删除 权限
        /// </summary>
        /// <param name="code">权限Code</param>
        /// <param name="dt">具有的权限</param>
        /// <returns></returns>
        public static string isDelete(string code, DataTable dt)
        {
            if (!isPower(enum_PowerType.delete, code, dt))
            {
                Hashtable result = new Hashtable();
                result["error"] = -3;
                result["message"] = "没有删除权限";
                return JsonHelper.Encode(result);
            }
            return string.Empty;
        }

        /// <summary>
        /// 判断是否具有权限
        /// </summary>
        /// <param name="pt">枚举类型 与数据库表  PowerDetail 中Code 一致</param>
        /// <param name="code">权限Code</param>
        /// <param name="dt">具有的权限</param>
        /// <returns></returns>
        private static bool isPower(enum_PowerType pt, string code, DataTable dt)
        {
            string pType = pt.ToString();

            DataRow[] drs = dt.Select("Code='" + code + "'");

            if (drs != null && drs.Length == 1)
            {
                string pDetial = drs[0]["PowerDetail"].ToString();

                if (pDetial.IndexOf(pType) > -1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
