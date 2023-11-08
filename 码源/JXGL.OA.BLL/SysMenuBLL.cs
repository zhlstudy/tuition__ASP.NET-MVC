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
    public partial class SysMenuBLL : BaseBLL<SysMenu>,ISysMenuBLL
    {
        public override void SetCurrentDAL()
        {
            this.CurrentDAL = mySession.GetSysMenuDAL;
        }
        // A 获取系统导航主菜单
        public IQueryable<SysMenu> GetMainMenuList()
        {
            return  mySession.GetSysMenuDAL.GetMainMenuList();
        }
        // B 获取系统导航子菜单
        public IQueryable<SysMenu> GetSubMenuList(int id)
        {
            return mySession.GetSysMenuDAL.GetSubMenuList(id);
        }

        ////4.使用会话模式 ，实现对DAL层的访问
        ////private IDbSession mySession = new DbSession();
        ////4.1使用会话工厂模式 ，实现对DAL层的访问
        //private IDbSession mySession { get { return DbSessionFactory.GetCurrentDbSession(); } }

        //#region  查询记录
        //public IQueryable<SysMenu> GetAllUserList<S>(Expression<Func<SysMenu, bool>> whereLambda, Expression<Func<SysMenu, S>> orderLambda)
        //{
        //    IQueryable<SysMenu> menuList = mySession.GetSysMenuDAL.Func_GetAllEntityList(whereLambda, orderLambda).AsQueryable();
        //    return menuList;
        //}
        //#endregion
        //#region
        ////2.分页查询
        //public IQueryable<SysMenu> GetPageAllUserList<S>(int page, int rows, Expression<Func<SysMenu, bool>> whereLambda, Expression<Func<SysMenu, S>> orderLambda)
        //{
        //    IQueryable<SysMenu> menuList = mySession.GetSysMenuDAL.Func_GetPageEntityList(page, rows, whereLambda, orderLambda).AsQueryable();
        //    return menuList;
        //}
        //#endregion

        //#region 添加记录：Create方法
        //public bool Add(SysMenu menu)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        //{
        //    //return mySession.GetSysMenuDAL.Create(menu);
        //    //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //    mySession.GetSysMenuDAL.Create(menu);
        //    return mySession.SaveChanges() > 0;
        //}
        //#endregion

        //#region 修改记录：Update方法
        //public bool Edit(SysMenu menu)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        //{
        //    //return mySession.GetSysMenuDAL.Update(menu);
        //    //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //    mySession.GetSysMenuDAL.Update(menu);
        //    return mySession.SaveChanges() > 0;
        //}
        //#endregion

        //#region 删除记录：Delete方法
        //public bool Delete(int id)
        //{
        //    //return mySession.GetSysMenuDAL.Delete(id);
        //    //封装 DbSession 类后 用以下方法完成对实体表的操作的保存工作
        //    mySession.GetSysMenuDAL.Delete(id);
        //    return mySession.SaveChanges() > 0;
        //}
        //#endregion


        ////#region 普通
        //////3.更高级的编程：把new（）去掉，取代它的是反射实现，Assmblly，把它定义到DALFactory()工厂模式中：       
        ////////private readonly ISysMenuDAL menuDal = DALFactory.GetSysMenuoDAL();
        //////换成属性
        ////private ISysMenuDAL menuDal { get { return DALFactory.GetSysMenuoDAL(); } }

        //////2.高级编程：接口实现抽象编程，由菜鸟=>高级
        //////     private readonly ISysMenuDAL menuDal = new SysMenuDAL();//父类指向子类去实现 实现了抽象编程

        ////#region 方法一
        ////////1.定义一个 SysMenu 对象，并调用其中的方法实现对User Info表的增删改查操作
        //////readonly SysMenuDAL menuDal = new SysMenuDAL();
        //////2.查询记录
        ////#region  查询记录
        ////public IQueryable<SysMenu> GetAllUserList<S>(Expression<Func<SysMenu, bool>> whereLambda, Expression<Func<SysMenu, S>> orderLambda)
        ////{
        ////    IQueryable<SysMenu> menuList = menuDal.Func_GetAllEntityList(whereLambda, orderLambda).AsQueryable();
        ////    return menuList;
        ////}

        //////2.分页查询
        ////public IQueryable<SysMenu> GetPageAllUserList<S>(int page, int rows, Expression<Func<SysMenu, bool>> whereLambda, Expression<Func<SysMenu, S>> orderLambda)
        ////{
        ////    IQueryable<SysMenu> menuList = menuDal.Func_GetPageEntityList(page, rows, whereLambda, orderLambda).AsQueryable();
        ////    return menuList;
        ////}
        ////#endregion

        ////#region 添加记录：Create方法
        ////public bool Add(SysMenu menu)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        ////{
        ////    return menuDal.Create(menu);
        ////}
        ////#endregion

        ////#region 修改记录：Update方法
        ////public bool Edit(SysMenu menu)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        ////{
        ////    return menuDal.Update(menu);
        ////}
        ////#endregion

        ////#region 删除记录：Delete方法
        ////public bool Delete(int id)
        ////{
        ////    return menuDal.Delete(id);
        ////}
        ////#endregion
        ////#endregion
        ////#endregion

    }
}
