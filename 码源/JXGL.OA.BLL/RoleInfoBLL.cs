using JXGL.OA.EFDAL;
using JXGL.OA.EFModel;
using JXGL.OA.IBLL;
using JXGL.OA.IDAL;
using JXGL.OA.IIDAL;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JXGL.OA.BLL
{
    public partial class RoleInfoBLL : BaseBLL<RoleInfo>,IRoleInfoBLL
    {
        public override void SetCurrentDAL()
        {
            this.CurrentDAL = mySession.GetRoleInfoDAL;
        }

        //      //4.使用会话模式 ，实现对DAL层的访问
        //      //private IDbSession mySession = new DbSession();
        //      //4.1使用会话工厂模式 ，实现对DAL层的访问
        //      private IDbSession mySession { get { return DbSessionFactory.GetCurrentDbSession(); } }


        //      //2.查询记录
        //      #region  查询记录
        //      public IQueryable<RoleInfo> GetAllRoleList<S>(Expression<Func<RoleInfo, bool>> whereLambda, Expression<Func<RoleInfo, S>> orderLambda)
        //      {
        //          IQueryable<RoleInfo> roleList = mySession.GetRoleInfoDAL.Func_GetAllEntityList(whereLambda, orderLambda).AsQueryable();
        //          return roleList;
        //      }

        //      //2.分页查询
        //      public IQueryable<RoleInfo> GetPageAllRoleList<S>(int page, int rows, Expression<Func<RoleInfo, bool>> whereLambda, Expression<Func<RoleInfo, S>> orderLambda)
        //      {
        //          IQueryable<RoleInfo> roleList = mySession.GetRoleInfoDAL.Func_GetPageEntityList(page, rows, whereLambda, orderLambda).AsQueryable();
        //          return roleList;
        //      }
        //      #endregion

        //      #region 添加记录：Create方法
        //      public bool Add(RoleInfo role)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        //      {
        //          //return mySession.GetRoleInfoDAL.Create(role);
        //          //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //          mySession.GetRoleInfoDAL.Create(role);
        //          return mySession.SaveChanges() > 0;
        //      }
        //      #endregion

        //      #region 修改记录：Update方法
        //      public bool Edit(RoleInfo role)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        //      {
        //          //return mySession.GetRoleInfoDAL.Update(role);
        //          //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //          mySession.GetRoleInfoDAL.Update(role);
        //          return mySession.SaveChanges() > 0;
        //      }
        //      #endregion

        //      #region 删除记录：Delete方法
        //      public bool Delete(int id)
        //      {
        //          //return mySession.GetRoleInfoDAL.Delete(id);
        //          //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //          mySession.GetRoleInfoDAL.Delete(id);
        //          return mySession.SaveChanges() > 0;
        //      }
        //      #endregion


        ////      #region 普通
        ////      //3.更高级的编程：把new（）去掉，取代它的是反射实现，Assmblly，把它定义到DALFactory()工厂模式中：       
        ////      //private readonly IRoleInfoDAL roleDal = DALFactory.GetRoleInfoDAL();
        ////      //换成属性
        ////      private IRoleInfoDAL roleDal { get{ return DALFactory.GetRoleInfoDAL(); } }

        ////      //2.高级编程：接口实现抽象编程，由菜鸟=>高级
        //////      private readonly IRoleInfoDAL roleDal = new RoleInfoDAL();//父类指向子类去实现 实现了抽象编程

        ////      ////1.定义一个 RoleInfo 对象，并调用其中的方法实现对Role Info表的增删改查操作
        ////      //RoleInfoDAL roleDal = new RoleInfoDAL();

        ////      //2.查询记录
        ////      #region  查询记录
        ////      public IQueryable<RoleInfo> GetAllRoleList<S>(Expression<Func<RoleInfo, bool>> whereLambda, Expression<Func<RoleInfo, S>> orderLambda)
        ////      {
        ////          IQueryable<RoleInfo> roleList = roleDal.Func_GetAllEntityList(whereLambda, orderLambda).AsQueryable();
        ////          return roleList;
        ////      }

        ////      //2.分页查询
        ////      public IQueryable<RoleInfo> GetPageAllRoleList<S>(int page, int rows, Expression<Func<RoleInfo, bool>> whereLambda, Expression<Func<RoleInfo, S>> orderLambda)
        ////      {
        ////          IQueryable<RoleInfo> roleList = roleDal.Func_GetPageEntityList(page, rows, whereLambda, orderLambda).AsQueryable();
        ////          return roleList;
        ////      }
        ////      #endregion

        ////      #region 添加记录：Create方法
        ////      public bool Add(RoleInfo role)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        ////      {
        ////          return roleDal.Create(role);
        ////      }
        ////      #endregion

        ////      #region 修改记录：Update方法
        ////      public bool Edit(RoleInfo role)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        ////      {
        ////          return roleDal.Update(role);
        ////      }
        ////      #endregion

        ////      #region 删除记录：Delete方法
        ////      public bool Delete(int id)
        ////      {
        ////          return roleDal.Delete(id);
        ////      }
        ////      #endregion
        ////      #endregion

    }
}
