
using JXGL.OA.IDAL;
using JXGL.OA.IIDAL;

namespace JXGL.OA.EFDAL
{
      public partial class _DbSession:IDbSession
	  {
	         
 
	         public  IRoleInfoDAL GetRoleInfoDAL { get { return DALFactory.GetRoleInfoDAL(); } }
 
	         public  ISysMenuDAL GetSysMenuDAL { get { return DALFactory.GetSysMenuDAL(); } }
 
	         public  IUserInfoDAL GetUserInfoDAL { get { return DALFactory.GetUserInfoDAL(); } }
             public int SaveChanges() { return DbContextFactory.GetCurrentDbContext().SaveChanges(); }

	}
}