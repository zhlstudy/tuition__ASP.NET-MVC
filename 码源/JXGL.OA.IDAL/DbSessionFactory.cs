using JXGL.OA.IIDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.EFDAL
{
    public class DbSessionFactory
    {
        public static IDbSession GetCurrentDbSession()
        {
            IDbSession Db = CallContext.GetData("MyDbSession") as IDbSession;
            if (Db == null)
            {
                //理解：   CallContext静态类下是一组键值数据，["MyDbSession"，""],当第一次时，xxx一定为空， 
                Db = new DbSession();
                CallContext.SetData("MyDbSession", Db);//等价于：[key="MyDbSession",value="JxglOADbEntities"]
            }
            return Db;
        }
    }
}
