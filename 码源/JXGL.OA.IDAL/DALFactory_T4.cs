
using JXGL.OA.IIDAL;
using System.Configuration;
using System.Reflection;

namespace JXGL.OA.EFDAL
{
      public partial class _DALFactory
	  {
	         public static string name = ConfigurationManager.AppSettings["DALssemblyName"];

	         public static IRoleInfoDAL GetRoleInfoDAL()
	         {
	               return Assembly.Load(name).CreateInstance(name + ".RoleInfoDAL") as IRoleInfoDAL;
	         }
	         public static ISysMenuDAL GetSysMenuDAL()
	         {
	               return Assembly.Load(name).CreateInstance(name + ".SysMenuDAL") as ISysMenuDAL;
	         }
	         public static IUserInfoDAL GetUserInfoDAL()
	         {
	               return Assembly.Load(name).CreateInstance(name + ".UserInfoDAL") as IUserInfoDAL;
	         }
    }
}
