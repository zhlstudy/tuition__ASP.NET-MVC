using JXGL.OA.EFModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.EFDAL
{
    public class BaseDAL<T>where T:class,new()
    {

        //定义DbContextFactory工厂模式后，用以下的方式实现
        public DbContext dbContext { get { return DbContextFactory.GetCurrentDbContext(); } }

        //一.定义一个EF的实体模型对象
        //readonly JxglOADbEntities dbContext = new JxglOADbEntities();

        //二.对表的增删改查操作
        //1.问题：实现对那个表？？？？     这是不确定的
        // 2.解决方法：用泛型类下的泛型方法，实现返回值类型，并用这个类型的泛型类和这个泛型和它的方法，即：T，但怎么定义？？？？？？
        //3.定义一个泛型类，同时用where来约束这个类必须是一个class，且能new()一个对象，即T必须有一个无参构造函数
        //4.将下面所有的EntityInfo 替换为T
        //5.问题：dbContext.T 报错。用dbContext.Set<T>() 方法，把它转换为一个集合对象 DbSet()记录集合：

        #region 用泛型委托实现对表的高级查询，也是万能查询，Func<泛型约束>（参数...返回值类型）
        //1.用泛型委托实现查询 全部记录，调查方法必须传递一个：lambda表达式
        public IQueryable<T> Func_GetAllEntityList<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda)
        {
            IQueryable<T> userList = dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).AsQueryable();
            return userList;
        }
        //2.用泛型委托实现查询 全部记录，调查方法必须传递一个：lambda表达式
        public IQueryable<T> Func_GetPageEntityList<S>(int page, int rows, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda)
        {
            IQueryable<T> userList = dbContext.Set<T>().Where(whereLambda).OrderBy(orderLambda).Skip((page - 1) * rows).Take(rows).AsQueryable();
            return userList;
        }

        #endregion

        #region 添加记录：Create方法
        public bool Create(T entity)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        {
            dbContext.Set<T>().Add(entity);//告诉EF，我现在要添加一条记录到EF实体模型Student中           
            //////if (dbContext.SaveChanges() > 0) return true; else return false;

            //封装 DbSession 类后 用以下方法实现对实体数据的CRUD转交给BLL层
            return true;
        }

        #endregion

        #region 修改记录：Update方法
        public bool Update(T entity)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        {
            dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;//告诉EF，我现在要修改一条记录到EF实体模型Student中

            //dbContext.Savechanges();//将EF实体表的修改，保存到后台的表中；他返回一个整形的数值，
            //怎么使用返回的值
            //if (dbContext.SaveChanges() > 0) return true; else return false;
            //return dbContext.SaveChanges() > 0;

            //封装 DbSession 类后 用以下方法实现对实体数据的CRUD转交给BLL层
            return true;
        }

        #endregion

        #region 删除记录：Delete方法
        public bool Delete(int id)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        {
            //1.先查询指定的Id的记录是否存在！
            //方法1：
            //Student stu = dbContext.Student.Where(u => u.Id == id).FirstOrDefault();
            //方法2：
            T entity = dbContext.Set<T>().Find(id);
            dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;//告诉EF，我现在要删除一条记录到EF实体模型Student中
            //dbContext.Savechanges();//将EF实体表的修改，保存到后台的表中；他返回一个整形的数值，
            //if (dbContext.SaveChanges() > 0) return true; else return false;

               //封装 DbSession 类后 用以下方法实现对实体数据的CRUD转交给BLL层
            return true;

        }

        #endregion
    }
}
