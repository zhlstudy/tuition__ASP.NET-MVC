
using JXGL.OA.IIDAL;

namespace JXGL.OA.EFDAL
{
      public partial interface _IDbSession
	  {
	         
 
	          IRoleInfoDAL GetRoleInfoDAL { get; }
 
	          ISysMenuDAL GetSysMenuDAL { get; }
 
	          IUserInfoDAL GetUserInfoDAL { get; }
              int SaveChanges();

	}
}