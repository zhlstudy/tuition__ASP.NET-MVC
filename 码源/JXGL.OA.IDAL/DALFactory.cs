using JXGL.OA.EFDAL;
using JXGL.OA.IIDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.IDAL
{
    public partial class DALFactory
    {
        //1.更高级的编程：把new（）去掉，取代它的是反射实现，Assmblly，把它定义到DALFactory()工厂模式中：
        #region 一简单工厂模式
        //2.从类功能：能给BLL层生产所需要DAL对象
        //3.用静态方法实现
        //public static IUserInfoDAL GetUserInfoDAL() { return new UserInfoDAL();}
        //public static IRoleInfoDAL GetRoleInfoDAL() {return new RoleInfoDAL(); }
        //public static ISysMenuDAL GetSysMenuoDAL(){return new SysMenuDAL(); }
        #endregion
        #region 二抽象工厂模式
        //更高级的编程方式：用抽象 工厂模式实现，把new去掉 ，使用C#的反射机制
        public static string name = ConfigurationManager.AppSettings["DALAssemblyName"];
        public static IUserInfoDAL GetUserInfoDAL() { return Assembly.Load(name).CreateInstance(name + ".UserInfoDAL") as IUserInfoDAL; }
        public static IRoleInfoDAL GetRoleInfoDAL() { return Assembly.Load(name).CreateInstance(name + ".RoleInfoDAL") as IRoleInfoDAL; }
        public static ISysMenuDAL GetSysMenuDAL() { return Assembly.Load(name).CreateInstance(name + ".SysMenuDAL") as ISysMenuDAL; }
        #endregion
    }
}
