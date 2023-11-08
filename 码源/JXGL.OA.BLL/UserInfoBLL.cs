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
    //在高深学习：用T4模板实现代码的重复，即：Don't Repeat Yourself!!!
    public partial class UserInfoBLL : BaseBLL<UserInfo>,IUserInfoBLL
    {
        public override void SetCurrentDAL()
        {
            this.CurrentDAL = mySession.GetUserInfoDAL;
        }


        //定义一个方法 判断用（UserGH）是否存在，这个方法是UserInfoBLL特有的   不是公共的

        public bool IsUserExist(UserInfo user)
        {
            UserInfo userInfo = CurrentDAL.Func_GetAllEntityList(u => u.UserGH == user.UserGH, u => u.Id).FirstOrDefault();
            if (userInfo != null) return true; else return false;
        }

        //#region 用DbSession会话模式 ，实现对DAL层的访问
        ////4.使用会话模式 ，实现对DAL层的访问
        ////private IDbSession mySession = new DbSession();
        ////4.1使用会话工厂模式 ，实现对DAL层的访问
        //private IDbSession mySession {get { return DbSessionFactory.GetCurrentDbSession(); } }

        //#region  查询记录
        //public IQueryable<UserInfo> GetAllUserList<S>(Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderLambda)
        //{
        //    IQueryable<UserInfo> userList = mySession.GetUserInfoDAL.Func_GetAllEntityList(whereLambda, orderLambda).AsQueryable();
        //    return userList;
        //}

        ////2.分页查询
        //public IQueryable<UserInfo> GetPageAllUserList<S>(int page, int rows, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderLambda)
        //{
        //    IQueryable<UserInfo> userList = mySession.GetUserInfoDAL.Func_GetPageEntityList(page, rows, whereLambda, orderLambda).AsQueryable();
        //    return userList;
        //}
        //#endregion

        //#region 添加记录：Create方法
        //public bool Add(UserInfo user)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        //{
        //    //return mySession.GetUserInfoDAL.Create(user);
        //    //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //    mySession.GetUserInfoDAL.Create(user);
        //    return mySession.SaveChanges() > 0;
        //}
        //#endregion

        //#region 修改记录：Update方法
        //public bool Edit(UserInfo user)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        //{
        //    //return mySession.GetUserInfoDAL.Update(user);
        //    //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //    mySession.GetUserInfoDAL.Update(user);
        //    return mySession.SaveChanges() > 0;
        //}
        //#endregion

        //#region 删除记录：Delete方法
        //public bool Delete(int id)
        //{
        //    //return mySession.GetUserInfoDAL.Delete(id);
        //    //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //    mySession.GetUserInfoDAL.Delete(id);
        //    return mySession.SaveChanges() > 0;
        //}
        //#endregion
        //#endregion

        //#region 方法一
        ////3.更高级的编程：把new（）去掉，取代它的是反射实现，Assmblly，把它定义到DALFactory()工厂模式中：       
        //////private readonly IUserInfoDAL userDal = DALFactory.GetUserInfoDAL();  //类的成员变量，这种方式不能实现一次访问共享上下文
        ////换成属性
        ////////private IUserInfoDAL userDal { get { return DALFactory.GetUserInfoDAL(); } }

        ////2.高级编程：接口实现抽象编程，由菜鸟=>高级
        ////private readonly IUserInfoDAL userDal = new UserInfoDAL();//父类指向子类去实现 实现了抽象编程  类的多态


        //////1.定义一个 UserInfo 对象，并调用其中的方法实现对User Info表的增删改查操作
        ////readonly UserInfoDAL userDal = new UserInfoDAL();
        ////2.查询记录
        //#region  查询记录
        ////public IQueryable<UserInfo> GetAllUserList<S>(Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderLambda)
        ////{
        ////    IQueryable<UserInfo> userList = userDal.Func_GetAllEntityList(whereLambda, orderLambda).AsQueryable();
        ////    return userList;
        ////}

        //////2.分页查询
        ////public IQueryable<UserInfo> GetPageAllUserList<S>(int page, int rows, Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderLambda)
        ////{
        ////    IQueryable<UserInfo> userList = userDal.Func_GetPageEntityList(page, rows, whereLambda, orderLambda).AsQueryable();
        ////    return userList;
        ////}
        //#endregion

        //#region 添加记录：Create方法
        ////public bool Add(UserInfo user)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        ////{
        ////    return userDal.Create(user);

        ////}
        //#endregion

        //#region 修改记录：Update方法
        ////public bool Edit(UserInfo user)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        ////{
        ////    return userDal.Update(user);

        ////}
        //#endregion

        //#region 删除记录：Delete方法
        ////public bool Delete(int id)
        ////{
        ////    return userDal.Delete(id);

        ////}
        //#endregion
        //#endregion

    }
}
