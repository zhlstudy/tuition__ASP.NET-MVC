using JXGL.OA.BLL;
using JXGL.OA.EFDAL;
using JXGL.OA.EFModel;
using JXGL.OA.IBLL;
using System.Linq;
using System.Web.Mvc;

namespace JXGL.OA_WebUI.Controllers
{
    public class SysMenuController : BaseController
    {
        // GET: SysMenu
        public ActionResult Index()
        {
            return View();
        }
        #region 方法一
        //1.从 SysMenuDAL 层获取SysMenu表的信息
        //readonly SysMenuDAL menuDAL = new SysMenuDAL();
        //2.业务逻辑层定义完成后。使用以下方法
        // readonly SysMenuBLL menuBLL = new SysMenuBLL(); 学：注入->Ioc,spring.net

        //3.封装 baseBLL基类后 用以下方法来实现
        //public SysMenuBLL menuBLL { get { return new SysMenuBLL(); } }

        //3.1封装 IBaseBLL基类后 用抽象 （高级）以下方法来实现
        public ISysMenuBLL menuBLL { get { return new SysMenuBLL(); } }

        #region  查询
        public JsonResult GetAllMenuList()
        {
            var menuList = menuBLL.GetAllEntityList(u=>u.Id>0&&u.text=="考试",u=>new { u.Id,u.ParentId}).ToList();
            return Json(menuList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetPageSysMenuList(int page, int rows)
        {

            var listData = new { total = menuBLL.GetAllEntityList(u => u.Id > 0,u=>u.Id).Count(), rows = menuBLL.GetPageAllEntityList(page, rows, u => u.Id > 0, u => u.Id).ToList() };

            return Json(listData, JsonRequestBehavior.AllowGet);

        }
        #endregion
        #region 添加记录 Add的方法
        public JsonResult Add(SysMenu Menu)
        {
            //当前的stu实体中，无需指定 Id 可以没有值
            if (menuBLL.Add(Menu)) return Json("Ok"); else return Json("Error");

        }
        #endregion

        #region 修改记录 Edit
        public JsonResult Edit(SysMenu Menu)
        {
            //当前的stu实体中，需指定 Id 必须指定值
            if (menuBLL.Edit(Menu)) return Json("Ok"); else return Json("Error");
        }
        #endregion

        #region 删除记录 Delete 方法
        public JsonResult Delete(int id)
        {
            //当前的stu实体中，需指定 Id 必须指定值
            if (menuBLL.Delete(id)) return Json("Ok"); else return Json("Error");
        }
        #endregion
        #endregion


    }
}