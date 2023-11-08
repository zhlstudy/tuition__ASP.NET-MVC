using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.IBLL
{
    public partial interface IBaseBLL<T> where T : class, new()
    {
        IQueryable<T> GetAllEntityList<S>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda);

        IQueryable<T> GetPageAllEntityList<S>(int page, int rows, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda);

         bool Add(T entity);

         bool Edit(T entity);
      
         bool Delete(int id);
       
     
     
    }
}
