using JXGL.OA.IDAL;
using JXGL.OA.IIDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.EFDAL
{
    //DbSession还能够确保事务的一致性和有效性，避免各种数据并发问题。
    public class DbSession : IDbSession
    {
        //此类实现BLL层(业务逻辑与DAL层的一次会话，Session，让它拥有DAL所有DAL对象，并把它们设置为类的属性)
        //1.获取DAL层所有对象，并把他们的

        public IUserInfoDAL GetUserInfoDAL { get { return DALFactory.GetUserInfoDAL(); } }

        public ISysMenuDAL GetSysMenuDAL { get { return DALFactory.GetSysMenuDAL(); } }

        public IRoleInfoDAL GetRoleInfoDAL { get { return DALFactory.GetRoleInfoDAL(); } }

        //2.这个方法是把后台数据实体表的修改保存权限有基类移交给业务逻辑层
        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
