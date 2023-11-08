using JXGL.OA.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JXGL.OA_WebUI.Controllers
{
    public class BaseController : Controller
    {
        // 1.定义一个类的成员变量
        public bool isChecked = true;
       //2.添加一个用户属性，它存放用户登录成功后的用户信息
        public UserInfo LoginUser { get; set; }

        public BaseController() { }
        //3.重写方法 ，在控制器的Action方法被执行前，首先要执行如下代码
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //Session["LoginUser"] , xxx)键K "LoginUser" ，值value "xxx"; xxx 它必须是一个UserInfo对象
            if (filterContext.HttpContext.Session["LoginUser"] == null)
                // 响应到这个地址
                filterContext.HttpContext.Response.Redirect("/UserLogin/Index");

            else LoginUser = filterContext.HttpContext.Session["LoginUser"] as UserInfo;
        }

    }
}