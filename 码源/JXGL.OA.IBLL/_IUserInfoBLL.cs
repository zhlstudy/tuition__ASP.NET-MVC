using JXGL.OA.EFModel;
using JXGL.OA.IBLL;

namespace JXGL.OA.IBLL
{
      public partial interface _IUserInfoBLL : IBaseBLL<UserInfo>
	  {
	      //说明:
		  //    1.请将对本实体表所需要的扩展方法添加在UserInfoDAL，类中;
		  //    2.UserInfoDAL 和 _UserInfoDAL 都要添加 partial 修饰符;
		  
		  void SetCurrentDAL();
	  }
}

