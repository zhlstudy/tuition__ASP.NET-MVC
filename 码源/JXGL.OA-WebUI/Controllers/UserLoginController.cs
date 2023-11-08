using JXGL.OA.BLL;
using JXGL.OA.Common;
using JXGL.OA.EFModel;
using JXGL.OA.IBLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace JXGL.OA_WebUI.Controllers
{
    public class UserLoginController : Controller
    {
        //定义一个UserInfoBLL成员属性
        public IUserInfoBLL userBLL { get { return new UserInfoBLL(); } }


        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 提供验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowVerifyCode()
        {
            string verifyCode = string.Empty;
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out verifyCode);
            #region 缓存Key 
            Cache cache = new Cache();
            // 先用当前类的全名称拼接上字符串 “verifyCode” 作为缓存的key
            var verifyCodeKey = $"{this.GetType().FullName}_verifyCode";
            cache.Remove(verifyCodeKey);
            cache.Insert(verifyCodeKey, verifyCode);
            #endregion
            MemoryStream memory = new MemoryStream();
            bitmap.Save(memory, ImageFormat.Gif);
            return File(memory.ToArray(), "image/gif");
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password, string Code)
        {
            JsonMessager result = new JsonMessager();
            // 第一步检验验证码
            // 从缓存获取验证码作为校验基准  
            // 先用当前类的全名称拼接上字符串 “verifyCode” 作为缓存的key
            Cache cache = new Cache();
            var verifyCodeKey = $"{this.GetType().FullName}_verifyCode";
            object cacheobj = cache.Get(verifyCodeKey);//验证码的值
            if (UserName == "" && Password == "" && Code == "")
            {
                result.Type = 0; result.Message = "请输入完整信息！！！！"; return Json(result);
            }
            if (!(cacheobj.ToString().Equals(Code, StringComparison.CurrentCultureIgnoreCase))) { result.Type = 1; result.Message = "验证码错误！"; return Json(result); }
            UserInfo user = userBLL.GetAllEntityList(u => u.UserGH == UserName && u.UserPWD == Password && u.DelFlag == false, u => u.Id).FirstOrDefault();
          
            //else if (cacheobj != null)
            //{
            //    result.Type = 1; result.Message = "请输入验证码或者刷新验证码！";
            //}//不区分大小写比较验证码是否正确           
            if (user == null) { result.Type = 2; result.Message = "用户名或密码错误错误！"; return Json(result); }
            Session["LoginUser"] = user;        
            result.Type = 3; result.Message = "用户登录成功！"; return Json(result);
            
          



        }




    }
}
