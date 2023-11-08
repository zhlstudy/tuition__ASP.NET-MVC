using JXGL.OA.BLL;
using JXGL.OA.EFDAL;
using JXGL.OA.EFModel;
using JXGL.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXGL.OA_WebUI.Controllers
{
    public class RoleInfoController : BaseController
    {
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }
        //1.从 RoleInfoDAL 层获取RoleInfo表的信息
        //readonly RoleInfoDAL roleDal = new RoleInfoDAL();
        //2.业务逻辑层定义完成后。使用以下方法
        //readonly RoleInfoBLL roleBLL = new RoleInfoBLL(); 学：注入->Ioc,spring.net

        //3.封装 BaseBLL基类后 用以下方法来实现
        //public RoleInfoBLL roleBLL { get { return new RoleInfoBLL(); } }

        //3.1封装 IBaseBLL基类后 用抽象 （高级）以下方法来实现
        public IRoleInfoBLL roleBLL { get { return new RoleInfoBLL(); } }


        //2.调用DAL的泛型委托方法查询
        #region  调用泛型委托 查询 记录
        public JsonResult Func_GetAllRoleList()
        {
            var menuList = roleBLL.GetAllEntityList(u => u.Id > 0, u => new { u.RoleName, u.Id }).ToList();
            return Json(menuList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Func_GetPageRoleList(int page, int rows)
        {

            var listData = new { total = roleBLL.GetAllEntityList(u => u.Id > 0, u => u.Id).ToList().Count(), rows = roleBLL.GetPageAllEntityList(page, rows, u => u.Id > 0, u => u.Id).ToList() };

            return Json(listData, JsonRequestBehavior.AllowGet);

        }
        #endregion


        #region 添加记录 Add的方法
        public JsonResult Add(RoleInfo role)
        {
            role.ModfiedOn = DateTime.Now;
            role.SubTime = DateTime.Now;
            role.DelFlag = false;
            //当前的stu实体中，无需指定 Id 可以没有值
            if (roleBLL.Add(role)) return Json("Ok"); else return Json("Error");

        }
        #endregion

        #region 修改记录 Edit
        public JsonResult Edit(RoleInfo role)
        {
            //当前的stu实体中，需指定 Id 必须指定值
            if (roleBLL.Edit(role)) return Json("Ok"); else return Json("Error");
        }
        #endregion

        #region 删除记录 Delete 方法
        public JsonResult Delete(int id)
        {
            //当前的stu实体中，需指定 Id 必须指定值
            if (roleBLL.Delete(id)) return Json("Ok"); else return Json("Error");
        }
        #endregion

    }
}