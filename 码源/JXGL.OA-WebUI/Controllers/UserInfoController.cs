using JXGL.OA.BLL;
using JXGL.OA.EFDAL;
using JXGL.OA.EFModel;
using JXGL.OA.IBLL;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JXGL.OA_WebUI.Controllers
{
    public class UserInfoController : BaseController
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        //#region 方法一 没有写数据逻辑层BLL的时候   直接用DAL
        //readonly UserInfoDAL UserDAL = new UserInfoDAL();
        ////1.定义对UserInfo 表的增删改查
        //#region  查询 记录
        ////public JsonResult GetAllUserList()
        ////{
        ////    var menuList = UserDAL.GetAllUserList().ToList();
        ////    return Json(menuList, JsonRequestBehavior.AllowGet);

        ////}
        ////public JsonResult GetPageUserInfoList(int page, int rows)
        ////{

        ////    var listData = new { total = UserDAL.GetAllUserList().ToList().Count(), rows = UserDAL.GetPageUserList(page, rows).ToList() };

        ////    return Json(listData, JsonRequestBehavior.AllowGet);

        ////}
        ////#endregion

        ////2.调用DAL的泛型委托方法查询
        //#region  调用泛型委托 查询 记录
        //public JsonResult Func_GetAllUserList()
        //{
        //    var menuList = UserDAL.Func_GetAllEntityList(u=>u.Id>0&&u.UserSex=="男",u=>new { u.UserName,u.Id}).ToList();
        //    return Json(menuList, JsonRequestBehavior.AllowGet);

        //}
        //public JsonResult Func_GetPageUserList(int page, int rows)
        //{

        //    var listData = new { total = UserDAL.Func_GetAllEntityList(u=>u.Id>0,u=>u.Id).ToList().Count(), rows = UserDAL.Func_GetPageEntityList(page, rows, u => u.Id > 0, u => u.Id).ToList() };

        //    return Json(listData, JsonRequestBehavior.AllowGet);

        //}
        //#endregion


        //#region 添加记录 Add的方法
        //public JsonResult Add(UserInfo user)
        //{
        //    user.ModfiedOn = DateTime.Now;
        //    user.SubTime = DateTime.Now;
        //    user.DelFlag = false;
        //    //当前的stu实体中，无需指定 Id 可以没有值
        //    if (UserDAL.Create(user)) return Json("Ok"); else return Json("Error");

        //}
        //#endregion

        //#region 修改记录 Edit
        //public JsonResult Edit(UserInfo user)
        //{
        //    //当前的stu实体中，需指定 Id 必须指定值
        //    if (UserDAL.Update(user)) return Json("Ok"); else return Json("Error");
        //}
        //#endregion

        //#region 删除记录 Delete 方法
        //public JsonResult Delete(int id)
        //{
        //    //当前的stu实体中，需指定 Id 必须指定值
        //    if (UserDAL.Delete(id)) return Json("Ok"); else return Json("Error");
        //}
        //#endregion
        //#endregion

        //#endregion

        #region 方法2 有

        //public UserInfoBLL UserBLL = new UserInfoBLL();
        //3.1封装 IBaseBLL基类后 用抽象 （高级）以下方法来实现
        public IUserInfoBLL UserBLL { get { return new UserInfoBLL(); } }
        
        #region  调用泛型委托 查询 记录
        public JsonResult Func_GetAllUserList()
        {
            var menuList = UserBLL.GetAllEntityList(u => u.Id > 0 && u.UserSex == "男", u => new { u.UserName, u.Id }).ToList();
            return Json(menuList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Func_GetPageUserList(int page, int rows)
        {

            var listData = new { total = UserBLL.GetAllEntityList(u => u.Id > 0, u => u.Id).ToList().Count(), rows = UserBLL.GetPageAllEntityList(page, rows, u => u.Id > 0, u => u.Id).ToList() };

            return Json(listData, JsonRequestBehavior.AllowGet);

        }
        #endregion


        #region 添加记录 Add的方法
        public JsonResult Add(UserInfo user)
        {
            user.ModfiedOn = DateTime.Now;
            user.SubTime = DateTime.Now;
            user.DelFlag = false;
            //当前的stu实体中，无需指定 Id 可以没有值
            if (UserBLL.Add(user)) return Json("Ok"); else return Json("Error");

        }
        #endregion

        #region 修改记录 Edit
        public JsonResult Edit(UserInfo user)
        {
            //当前的stu实体中，需指定 Id 必须指定值
            if (UserBLL.Edit(user)) return Json("Ok"); else return Json("Error");
        }
        #endregion

        #region 删除记录 Delete 方法
        public JsonResult Delete(int id)
        {
            //当前的stu实体中，需指定 Id 必须指定值
            if (UserBLL.Delete(id)) return Json("Ok"); else return Json("Error");
        }
        #endregion
        #endregion


    }
}