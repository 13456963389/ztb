//============================================================
//author:于永博
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace ZtbSoft.Models
{
    /// <summary>
    /// 员工信息
    /// </summary>
    [Serializable()]
    public class Employee
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember(IsRequired = false)]
        public int EmployeeId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? EmployeeSex { get; set; }
        /// <summary>
        /// 职别Id
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? JobLevelId { get; set; }
        /// <summary>
        /// 职别（岗位）
        /// </summary>
        [DataMember(IsRequired = false)]
        public string JobLevel { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeePhone { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? EmployeeBirthday { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? EmployeeEntryDate { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeEmail { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeQQ { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeWeixin { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeAddress { get; set; }
        /// <summary>
        /// 最高学历
        /// </summary>
        [DataMember(IsRequired = false)]
        public byte? EmployeeEducation { get; set; }
        /// <summary>
        /// 毕业院校
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeSchool { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeIDCode { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeUsername { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DataMember(IsRequired = false)]
        public string EmployeeUserpass { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? RoleId { get; set; }
        /// <summary>
        /// 基本工资
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal? EmployeeWages { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember(IsRequired = false)]
        public byte? State { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        [DataMember(IsRequired = false)]
        public string Bank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        [DataMember(IsRequired = false)]
        public string BankCard { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 员工信息
        /// </summary>
        public Employee() { }


        /// <summary>
        /// 员工信息
        /// </summary>
        public Employee(DataRow dr)
        {
            if (dr.Table.Columns.Contains("EmployeeId") && !dr.IsNull("EmployeeId"))
            {
                EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
            }
            if (dr.Table.Columns.Contains("EmployeeCode") && !dr.IsNull("EmployeeCode"))
            {
                EmployeeCode = dr["EmployeeCode"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeName") && !dr.IsNull("EmployeeName"))
            {
                EmployeeName = dr["EmployeeName"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeSex") && !dr.IsNull("EmployeeSex"))
            {
                EmployeeSex = Convert.ToInt32(dr["EmployeeSex"]);
            }
            if (dr.Table.Columns.Contains("JobLevelId") && !dr.IsNull("JobLevelId"))
            {
                JobLevelId = Convert.ToInt32(dr["JobLevelId"]);
            }
            if (dr.Table.Columns.Contains("JobLevel") && !dr.IsNull("JobLevel"))
            {
                JobLevel = dr["JobLevel"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeePhone") && !dr.IsNull("EmployeePhone"))
            {
                EmployeePhone = dr["EmployeePhone"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeBirthday") && !dr.IsNull("EmployeeBirthday"))
            {
                EmployeeBirthday = Convert.ToDateTime(dr["EmployeeBirthday"]);
            }
            if (dr.Table.Columns.Contains("EmployeeEntryDate") && !dr.IsNull("EmployeeEntryDate"))
            {
                EmployeeEntryDate = Convert.ToDateTime(dr["EmployeeEntryDate"]);
            }
            if (dr.Table.Columns.Contains("EmployeeEmail") && !dr.IsNull("EmployeeEmail"))
            {
                EmployeeEmail = dr["EmployeeEmail"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeQQ") && !dr.IsNull("EmployeeQQ"))
            {
                EmployeeQQ = dr["EmployeeQQ"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeWeixin") && !dr.IsNull("EmployeeWeixin"))
            {
                EmployeeWeixin = dr["EmployeeWeixin"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeAddress") && !dr.IsNull("EmployeeAddress"))
            {
                EmployeeAddress = dr["EmployeeAddress"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeEducation") && !dr.IsNull("EmployeeEducation"))
            {
                EmployeeEducation = Convert.ToByte(dr["EmployeeEducation"]);
            }
            if (dr.Table.Columns.Contains("EmployeeSchool") && !dr.IsNull("EmployeeSchool"))
            {
                EmployeeSchool = dr["EmployeeSchool"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeIDCode") && !dr.IsNull("EmployeeIDCode"))
            {
                EmployeeIDCode = dr["EmployeeIDCode"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeUsername") && !dr.IsNull("EmployeeUsername"))
            {
                EmployeeUsername = dr["EmployeeUsername"].ToString();
            }
            if (dr.Table.Columns.Contains("EmployeeUserpass") && !dr.IsNull("EmployeeUserpass"))
            {
                EmployeeUserpass = dr["EmployeeUserpass"].ToString();
            }
            if (dr.Table.Columns.Contains("RoleId") && !dr.IsNull("RoleId"))
            {
                RoleId = Convert.ToInt32(dr["RoleId"]);
            }
            if (dr.Table.Columns.Contains("EmployeeWages") && !dr.IsNull("EmployeeWages"))
            {
                EmployeeWages = Convert.ToDecimal(dr["EmployeeWages"]);
            }
            if (dr.Table.Columns.Contains("Remark") && !dr.IsNull("Remark"))
            {
                Remark = dr["Remark"].ToString();
            }
            if (dr.Table.Columns.Contains("State") && !dr.IsNull("State"))
            {
                State = Convert.ToByte(dr["State"]);
            }
            if (dr.Table.Columns.Contains("Bank") && !dr.IsNull("Bank"))
            {
                Bank = dr["Bank"].ToString();
            }
            if (dr.Table.Columns.Contains("BankCard") && !dr.IsNull("BankCard"))
            {
                BankCard = dr["BankCard"].ToString();
            }
            if (dr.Table.Columns.Contains("CreateTime") && !dr.IsNull("CreateTime"))
            {
                CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            }
            if (dr.Table.Columns.Contains("ModifyTime") && !dr.IsNull("ModifyTime"))
            {
                ModifyTime = Convert.ToDateTime(dr["ModifyTime"]);
            }
        }
    }
}