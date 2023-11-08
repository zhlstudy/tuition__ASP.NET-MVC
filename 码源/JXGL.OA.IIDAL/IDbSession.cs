using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.IIDAL
{
    public interface IDbSession
    {
        IUserInfoDAL GetUserInfoDAL { get; }

        ISysMenuDAL GetSysMenuDAL { get; }

        IRoleInfoDAL GetRoleInfoDAL { get; }

        int SaveChanges();
    }
}
