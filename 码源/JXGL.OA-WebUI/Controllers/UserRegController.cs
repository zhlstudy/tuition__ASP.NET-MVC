using JXGL.OA.BLL;
using JXGL.OA.Common;
using JXGL.OA.EFModel;
using JXGL.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXGL.OA_WebUI.Controllers
{
    public class UserRegController : Controller
    {
        // GET: UserReg
        public ActionResult Index()
        {
            return View();
        }
        //1.定义一个IUserInfoBLL接口对象，用UserInfoBLL中add方法实现
        IUserInfoBLL userBLL = new UserInfoBLL();

        public JsonResult CreateUser(UserInfo user)
        {
            JsonMessager result = new JsonMessager();
            //2.首先判断当前这个注册用户UserGH是否已经存在，如果存在，不能实现注册了
            if (!userBLL.IsUserExist(user))
            {
                user.DelFlag = false; user.ModfiedOn = DateTime.Now; user.SubTime = DateTime.Now;
                if (userBLL.Add(user)) { result.Type = 1; result.Message = "用户注册成功！！"; }
                else { result.Type = 2; result.Message = "用户注册失败！！"; }
            }
            else { result.Type = 3; result.Message = "用户已经存在，注册失败！！"; }
            return Json(result);
        }
    }
}