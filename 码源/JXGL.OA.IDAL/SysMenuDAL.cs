using JXGL.OA.EFModel;
using JXGL.OA.IIDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.EFDAL
{
    public partial class SysMenuDAL:BaseDAL<SysMenu>,ISysMenuDAL
    {

        #region A 获取系统导航主菜单
 //       readonly JxglOADbEntities dbContext = new JxglOADbEntities();

        public IQueryable<SysMenu> GetMainMenuList()
        {
            IQueryable<SysMenu> menuList = dbContext.Set<SysMenu>().Where(m => m.ParentId == 0).OrderBy(m => m.Id).AsQueryable();
            return menuList;

        }
        #endregion
        #region B 获取系统导航子菜单
        public IQueryable<SysMenu> GetSubMenuList(int id)
        {
            IQueryable<SysMenu> subList = dbContext.Set<SysMenu>().Where(m => m.ParentId == id).OrderBy(m => m.Id).AsQueryable();
            return subList;

        }
        #endregion



        //#region 没有继承 方法一

        //readonly JxglOADbEntities dbContext = new JxglOADbEntities();

        //#region A 获取系统导航主菜单
        //public IQueryable<SysMenu> GetMainMenuList()
        //{
        //    IQueryable<SysMenu> menuList = dbContext.SysMenu.Where(m => m.ParentId == 0).OrderBy(m => m.Id).AsQueryable();
        //    return menuList;

        //}
        //#endregion
        //#region B 获取系统导航子菜单
        //public IQueryable<SysMenu> GetSubMenuList(int id)
        //{
        //    IQueryable<SysMenu> subList = dbContext.SysMenu.Where(m => m.ParentId == id).OrderBy(m => m.Id).AsQueryable();
        //    return subList;

        //}
        //#endregion

        //#region 查询记录 Read  方法
        ////1.查询 全部表的记录 ，用Lambada表达式
        //public IQueryable<SysMenu> GetAllMenuList()
        //{
        //    IQueryable<SysMenu> menuList = dbContext.SysMenu.Where(u => u.Id > 0).OrderBy(u => u.Id).AsQueryable();
        //    return menuList;
        //}

        ////2.分页查询
        //public IQueryable<SysMenu> GetPageMenuList(int page, int rows)
        //{
        //    IQueryable<SysMenu> menuList = dbContext.SysMenu.Where(u => u.Id > 0).OrderBy(u => u.Id).Skip((page - 1)
        //        * rows).Take(rows).AsQueryable();
        //    return menuList;
        //}
        //#endregion

        //#region 添加记录：Create方法
        //public bool Create(SysMenu menu)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        //{
        //    dbContext.SysMenu.Add(menu);//告诉EF，我现在要添加一条记录到EF实体模型Student中           
        //    if (dbContext.SaveChanges() > 0) return true; else return false;
        //}

        //#endregion

        //#region 修改记录：Update方法
        //public bool Update(SysMenu menu)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        //{
        //    dbContext.Entry(menu).State = System.Data.Entity.EntityState.Modified;//告诉EF，我现在要修改一条记录到EF实体模型Student中

        //    //dbContext.Savechanges();//将EF实体表的修改，保存到后台的表中；他返回一个整形的数值，
        //    //怎么使用返回的值
        //    //if (dbContext.SaveChanges() > 0) return true; else return false;
        //    return dbContext.SaveChanges() > 0;
        //}

        //#endregion

        //#region 删除记录：Delete方法
        //public bool Delete(int id)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        //{
        //    //1.先查询指定的Id的记录是否存在！
        //    //方法1：
        //    //Student stu = dbContext.Student.Where(u => u.Id == id).FirstOrDefault();
        //    //方法2：
        //    SysMenu menu = dbContext.SysMenu.Find(id);
        //    dbContext.Entry(menu).State = System.Data.Entity.EntityState.Deleted;//告诉EF，我现在要删除一条记录到EF实体模型Student中
        //    //dbContext.Savechanges();//将EF实体表的修改，保存到后台的表中；他返回一个整形的数值，
        //    if (dbContext.SaveChanges() > 0) return true; else return false;
        //}

        //#endregion

        //#endregion


    }
}
