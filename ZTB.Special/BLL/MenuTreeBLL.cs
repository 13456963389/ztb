using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTB.Special.DAL;

namespace ZTB.Special.BLL
{
    public class MenuTreeBLL
    {
        /// <summary>
        /// 获取树数据
        /// </summary>
        /// <param name="treeType"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetList(string treeType, string pid)
        {
            return new MenuTreeDAL().GetList(treeType, pid);
        }
    }
}
