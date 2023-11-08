using JXGL.OA.BLL;
using JXGL.OA.EFDAL;
using System.Linq;
using System.Web.Mvc;

namespace JXGL.OA_WebUI.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Default()
        {
            return View();
        }
        #region 不可取
        ////1.定义EF实体数据模型 dbContext 对象
        ////以下不符合C#的三层设计要求
        //readonly JxglOADbEntities dbContext = new JxglOADbEntities();
        ////2.获取 系统导航的菜单数据
        //#region A 获取系统导航主菜单
        //public JsonResult GetMainMenuList()
        //{
        //    var menuList = dbContext.SysMenu.Where(m => m.ParentId == 0).OrderBy(m => m.Id).ToList();
        //    return Json(menuList, JsonRequestBehavior.AllowGet);

        //}
        //#endregion
        //#region B 获取系统导航子菜单
        //public JsonResult GetSubMenuList(int id)
        //{
        //    var menuList = dbContext.SysMenu.Where(m => m.ParentId == id).OrderBy(m => m.Id).ToList();
        //    return Json(menuList, JsonRequestBehavior.AllowGet);

        //}
        //#endregion
        #endregion

            //1.获取  系统导航的菜单数据，定义一个SysMenuDAL 对象
        //readonly SysMenuDAL menuDAL = new SysMenuDAL();
        //2.调用业务逻辑  BLL 层实现

            public SysMenuBLL menuBLL { get { return new SysMenuBLL(); } }
        #region  查询
        public JsonResult GetMainMenuList()
        {
            var menuList = menuBLL.GetMainMenuList().ToList();
            return Json(menuList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetSubMenuList(int id)
        {
            var menuList = menuBLL.GetSubMenuList(id).ToList();
            return Json(menuList, JsonRequestBehavior.AllowGet);

        }
        #endregion

    }
}