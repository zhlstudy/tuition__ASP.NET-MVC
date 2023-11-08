using JXGL.OA.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.IBLL
{
    public partial interface ISysMenuBLL:IBaseBLL<SysMenu>
    {
        // A 获取系统导航主菜单
        IQueryable<SysMenu> GetMainMenuList();

        // B 获取系统导航子菜单
        IQueryable<SysMenu> GetSubMenuList(int id);
    }
}
