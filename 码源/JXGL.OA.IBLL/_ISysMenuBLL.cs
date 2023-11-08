using JXGL.OA.EFModel;
using JXGL.OA.IBLL;

namespace JXGL.OA.IBLL
{
      public partial interface _ISysMenuBLL : IBaseBLL<SysMenu>
	  {
	      //说明:
		  //    1.请将对本实体表所需要的扩展方法添加在SysMenuDAL，类中;
		  //    2.SysMenuDAL 和 _SysMenuDAL 都要添加 partial 修饰符;
		  
		  void SetCurrentDAL();
	  }
}

