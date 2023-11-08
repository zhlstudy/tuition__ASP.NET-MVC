using JXGL.OA.EFModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.EFDAL
{
    public class DbContextFactory
    {
        //1.方法一：该静态返回值类型为 EF 实体数据框的JxglOADbEntities
        //public JxglOADbEntities GetCurrentDbContext() { return new JxglOADbEntities(); }
        //2.方法二：用抽象编程=》高级编程，用接口实现，返回值为该类的父类：DbContext
        //public DbContext GetCurrentDbContext() { return new JxglOADbEntities(); }
        //3.方法三：用CallContext 静态类中GetData()和SetData()方法实现，它类似一个键值对数据
        //一次访问共享一个EF  Context 上下文
        public static DbContext GetCurrentDbContext()
        {
            DbContext Db = CallContext.GetData("MyDbContext") as DbContext;
            if (Db == null)
            {
                //理解：   CallContext静态类下是一组键值数据，["MyDbContext"，""],当第一次时，xxx一定为空， 
                Db = new JxglOADbEntities();
                CallContext.SetData("MyDbContext",Db );//等价于：[key="MyDbContext",value="JxglOADbEntities"]
            }
            return Db;
        }
    }
}
