using JXGL.OA.EFModel;
using JXGL.OA.IBLL;

namespace JXGL.OA.IBLL
{
      public partial interface _IRoleInfoBLL : IBaseBLL<RoleInfo>
	  {
	      //说明:
		  //    1.请将对本实体表所需要的扩展方法添加在RoleInfoDAL，类中;
		  //    2.RoleInfoDAL 和 _RoleInfoDAL 都要添加 partial 修饰符;
		  
		  void SetCurrentDAL();
	  }
}

