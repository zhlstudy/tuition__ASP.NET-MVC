using JXGL.OA.EFDAL;
using JXGL.OA.IIDAL;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JXGL.OA.BLL
{
    public abstract class BaseBLL<T> where T : class, new()
    {

        //Don't Repeat yourself!!!!!
        //Base基类：用泛型约束类《T》实现，把EntityInfoBLL中的代码复制

        #region 用会话模式 ，实现对DAL层的访问
        //.1使用会话工厂模式 ，实现对DAL层的访问
        //定义一个DbSession会话对象，它实现BLL层和DAL层的会话，用接口实现，并把它定义为类的一个属性
        public IDbSession mySession { get { return DbSessionFactory.GetCurrentDbSession(); } }
        //2.问题：在EntityinfoBll中调用了EntityinfoDAL,在RoleinfoBll中调用了RoleinfoDAL,......在这里该调用那个DAl?  不确定怎么办？mySession.Get XXX DAL,xxx 是什么 不能确定
        //3.假设：mySession.Get XXX DAL  xxx 是:CurrentDAL, 它的类型是？在当前的设计中，我们设计父类接口DAL。IBaseDAL(),他能代表所有的DAL类型，  并把它设置为类的一个属性
        public IBaseDAL<T> CurrentDAL { get; set; }
        //4.问题又来了：这个CurrentDAL 应该是谁，还不能确定，如何确定它的具体的Dal是哪一个？子类继承父类时，父类可以强迫子类给父类传递一个参数，
        //5.解决方法：让子类给父类传递一个DAL，即谁继承这个类，就谁给它传递一个DAL，并把这个参数赋值给CurrentDAL，
        //6.怎么能给它赋值？给这个基类添加一个方法来实现：SetCurrentDAL();用这个方法给CurrentDAL赋值，
        public abstract void SetCurrentDAL();
        //7.这个方法必须在以下的所有方法执行前，它先被执行调用 ，怎么实现？
        //8.关于类的构造，在无参构造函数中调用SetCurrentDAL()这个方法即可实现！！！！！
        public BaseBLL()
        {
            SetCurrentDAL();
        }
        //9.上面的构造函数保证了，类的其他方法在被执行前 ，拿到了CurrentDAL()的值

        #region  查询记录
        public IQueryable<T> GetAllEntityList<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda)
        {
            IQueryable<T> userList = CurrentDAL.Func_GetAllEntityList(whereLambda, orderLambda).AsQueryable();
            return userList;
        }

        //2.分页查询
        public IQueryable<T> GetPageAllEntityList<S>(int page, int rows, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda)
        {
            IQueryable<T> userList = CurrentDAL.Func_GetPageEntityList(page, rows, whereLambda, orderLambda).AsQueryable();
            return userList;
        }
        #endregion

        #region 添加记录：Create方法
        public bool Add(T entity)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        {
            //return mySession.GetEntityInfoDAL.Create(entity);
            //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
           CurrentDAL.Create(entity);
            return mySession.SaveChanges() > 0;
        }
        #endregion

        #region 修改记录：Update方法
        public bool Edit(T entity)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        {
            //return mySession.GetEntityInfoDAL.Update(entity);
            //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
            CurrentDAL.Update(entity);
            return mySession.SaveChanges() > 0;
        }
        #endregion

        #region 删除记录：Delete方法
        public bool Delete(int id)
        {
            //return mySession.GetEntityInfoDAL.Delete(id);
            //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
            CurrentDAL.Delete(id);
            return mySession.SaveChanges() > 0;
        }
        #endregion
        #endregion
    }
}
