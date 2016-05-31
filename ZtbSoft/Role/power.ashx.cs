using ZtbSoft.BLL;
using ZtbSoft.Models;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace ZtbSoft.Web.ajax.New
{
    /// <summary>
    /// power 的摘要说明
    /// </summary>
    public class power : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            int roleId = Convert.ToInt32(context.Request["roleId"]);

            //DataTable dtDetail = new PowerDetailBLL().GetAll("", "", "");   //得到权限具体项目

            //DataTable dtObject = new PowerObjectBLL().GetAll("", "", "ord asc"); //得到所有权限

            //DataTable dtPower = new RolePowerBLL().GetAll("roleid=" + roleId);  //得到当前角色权限




            //ArrayList list = new ArrayList();

            ////组装json
            //foreach (DataRow item in dtObject.Rows)
            //{
            //    Hashtable curH = new Hashtable();

            //    //组装权限json
            //    PowerObject obj = new PowerObject(item);
            //    curH.Add("Id", obj.Id);
            //    curH.Add("Name", obj.Name);
            //    curH.Add("ParentId", obj.ParentId);

            //    //如果有具体的权限项目
            //    if (!string.IsNullOrWhiteSpace(obj.Detail))
            //    {
            //        //得到具体项目
            //        string[] arr = obj.Detail.Split(',');
            //        string whe = "PowerDetailCode in(";
            //        foreach (string str in arr)
            //        {
            //            whe += "'" + str + "',";
            //        }
            //        whe = whe.TrimEnd(',') + ")";
            //        DataRow[] drs = dtDetail.Select(whe, "PowerDetailId asc");

            //        //现在角色具有的权限
            //        DataRow[] drpower = dtPower.Select("powerid=" + obj.Id);
            //        string powerDetail = string.Empty;
            //        if (drpower != null && drpower.Length > 0)
            //            powerDetail = drpower[0]["PowerDetail"].ToString();

            //        //组装权限项目json
            //        ArrayList detailList = new ArrayList();
            //        foreach (DataRow drDetail in drs)
            //        {
            //            PowerDetail pd = new PowerDetail(drDetail);
            //            Hashtable curHtDe = new Hashtable();
            //            curHtDe.Add("PowerDetailName", pd.PowerDetailName);
            //            curHtDe.Add("PowerDetailCode", pd.PowerDetailCode);

            //            if (!string.IsNullOrWhiteSpace(powerDetail) &&
            //                powerDetail.IndexOf(pd.PowerDetailCode, StringComparison.CurrentCultureIgnoreCase) > -1)
            //                curHtDe.Add("checked", true);
            //            else
            //                curHtDe.Add("checked", false);
            //            detailList.Add(curHtDe);
            //        }
            //        curH.Add("functions", detailList);
            //    }
            //    list.Add(curH);
            //}
            ArrayList list = new ArrayList();

            DataTable dt = new RolePowerBLL().GetPowerTreeByRoleId(roleId);
            DataTable dtDetail = new PowerDetailBLL().GetAll("", "", "");   //得到权限具体项目

            foreach (DataRow item in dt.Rows)
            {
                string Id = item["Id"].ToString();
                string ParentId = item["ParentId"].ToString();
                string Name = item["Name"].ToString();
                string Detail = item["Detail"].ToString();
                string RolePowerId = item["RolePowerId"].ToString();
                string PowerDetail = item["PowerDetail"].ToString();

                Hashtable curH = new Hashtable();
                curH.Add("Id", Id);
                curH.Add("Name", Name);
                curH.Add("ParentId", ParentId);



                if (!string.IsNullOrWhiteSpace(RolePowerId))
                {
                    curH.Add("checked", "true");
                }

                //如果有具体的权限项目
                if (!string.IsNullOrWhiteSpace(Detail))
                {
                    //得到具体项目
                    string[] arr = Detail.Split(',');
                    string whe = "PowerDetailCode in(";
                    foreach (string str in arr)
                    {
                        whe += "'" + str + "',";
                    }
                    whe = whe.TrimEnd(',') + ")";
                    DataRow[] drs = dtDetail.Select(whe, "PowerDetailId asc");

                    //组装权限项目json
                    ArrayList detailList = new ArrayList();
                    foreach (DataRow drDetail in drs)
                    {
                        PowerDetail pd = new PowerDetail(drDetail);
                        Hashtable curHtDe = new Hashtable();
                        curHtDe.Add("PowerDetailName", pd.PowerDetailName);
                        curHtDe.Add("PowerDetailCode", pd.PowerDetailCode);

                        if (!string.IsNullOrWhiteSpace(PowerDetail) &&
                            PowerDetail.IndexOf(pd.PowerDetailCode, StringComparison.CurrentCultureIgnoreCase) > -1)
                            curHtDe.Add("checked", true);
                        else
                            curHtDe.Add("checked", false);
                        detailList.Add(curHtDe);
                    }
                    curH.Add("functions", detailList);
                }
                list.Add(curH);
            }

            string json = JsonHelper.Encode(list);

            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}