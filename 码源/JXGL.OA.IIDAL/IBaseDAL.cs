using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.IIDAL
{
    public interface IBaseDAL<T>where T:class,new()
    {
        
   

    #region 用泛型委托实现对表的高级查询，也是万能查询，Func<泛型约束>（参数...返回值类型）
    //1.用泛型委托实现查询 全部记录，调查方法必须传递一个：lambda表达式
        IQueryable<T> Func_GetAllEntityList<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda);
        //2.用泛型委托实现查询 全部记录，调查方法必须传递一个：lambda表达式
        IQueryable<T> Func_GetPageEntityList<S>(int page, int rows, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda);
        #endregion

        #region 添加记录：Create方法
        bool Create(T entity);//参数：调用该方法，必须传递一个Student实体对象 无需指定Id    
        #endregion

        #region 修改记录：Update方法
        bool Update(T entity);//参数：调用该方法，必须传递一个Student实体对象 必需指定Id    
        #endregion

        #region 删除记录：Delete方法
        bool Delete(int id);//参数：调用该方法，必须传递一个Student实体对象 无需指定Id    
        #endregion
    

    }
}
