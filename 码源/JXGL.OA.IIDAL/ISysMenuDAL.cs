using JXGL.OA.EFModel;
using System.Linq;

namespace JXGL.OA.IIDAL
{
    public interface ISysMenuDAL:IBaseDAL<SysMenu>
    {
       // A 获取系统导航主菜单
        IQueryable<SysMenu> GetMainMenuList();
        // B 获取系统导航子菜单
        IQueryable<SysMenu> GetSubMenuList(int id);
    }
}
