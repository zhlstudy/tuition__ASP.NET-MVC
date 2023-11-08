using JXGL.OA.EFModel;
using JXGL.OA.IIDAL;
using System.Linq;

namespace JXGL.OA.EFDAL
{
    public partial class UserInfoDAL:BaseDAL<UserInfo>,IUserInfoDAL
    {
        //#region 没有继承 纯打 此方法较麻烦
        //readonly JxglOADbEntities dbContext = new JxglOADbEntities();

        //#region 查询记录 Read  方法1 ：普通的查询
        ////1.查询 全部表的记录 ，用Lambada表达式
        //public IQueryable<UserInfo> GetAllUserList()
        //{
        //    IQueryable<UserInfo> userList = dbContext.UserInfo.Where(u => u.Id > 0).OrderBy(u => u.Id).AsQueryable();
        //    return userList;
        //}

        ////2.分页查询
        //public IQueryable<UserInfo> GetPageUserList(int page, int rows)
        //{
        //    IQueryable<UserInfo> userList = dbContext.UserInfo.Where(u => u.Id > 0).OrderBy(u => u.Id).Skip((page - 1)
        //        * rows).Take(rows).AsQueryable();
        //    return userList;
        //}

        ////3按Id查询
        //public UserInfo GetUserById(int id)
        //{
        //    UserInfo user = dbContext.UserInfo.Where(u => u.Id == id).OrderBy(u => u.Id).FirstOrDefault();
        //    return user;
        //}
        ////4按name查询
        //public UserInfo GetUserByUserName(string name)
        //{
        //    //UserInfo user = dbContext.UserInfo.Where(u =>  u.UserName == name).OrderBy(u => u.Id).FirstOrDefault();
        //    UserInfo user = dbContext.UserInfo.Where(u => u.UserName.Contains("name")).OrderBy(u => u.Id).FirstOrDefault();
        //    return user;
        //}
        ////5按 性别 查询
        //public IQueryable<UserInfo> GetUserByUserSex(string sex)
        //{
        //    IQueryable<UserInfo> userList = dbContext.UserInfo.Where(u => u.UserSex.Contains("sex")).AsQueryable();
        //    return userList;
        //}
        ////6按 部门 查询
        //public IQueryable<UserInfo> GetUserByUserBm(string bm)
        //{
        //    IQueryable<UserInfo> userList = dbContext.UserInfo.Where(u => u.UserBM.Contains("bm")).AsQueryable();
        //    return userList;
        //}
        //#endregion

        //#region 方法二：用泛型委托实现对表的高级查询，也是万能查询，Func<泛型约束>（参数...返回值类型）
        ////1.用泛型委托实现查询 全部记录，调查方法必须传递一个：lambda表达式
        //public IQueryable<UserInfo> Func_GetAllUserList<S>(Expression<Func<UserInfo, bool>> whereLambda,Expression<Func<UserInfo, S>> orderLambda)
        //{
        //    IQueryable<UserInfo> userList = dbContext.UserInfo.Where(whereLambda).OrderBy(orderLambda).AsQueryable();
        //    return userList;
        //}
        ////2.用泛型委托实现查询 全部记录，调查方法必须传递一个：lambda表达式
        //public IQueryable<UserInfo> Func_GetPageUserList<S>(int page,int rows , Expression<Func<UserInfo, bool>> whereLambda, Expression<Func<UserInfo, S>> orderLambda)
        //{
        //    IQueryable<UserInfo> userList = dbContext.UserInfo.Where(whereLambda).OrderBy(orderLambda).Skip((page-1)*rows).Take(rows).AsQueryable();
        //    return userList;
        //}

        //#endregion

        //#region 添加记录：Create方法
        //public bool Create(UserInfo user)//参数：调用该方法，必须传递一个Student实体对象 无需指定Id
        //{
        //    dbContext.UserInfo.Add(user);//告诉EF，我现在要添加一条记录到EF实体模型Student中           
        //    if (dbContext.SaveChanges() > 0) return true; else return false;
        //}

        //#endregion

        //#region 修改记录：Update方法
        //public bool Update(UserInfo user)//参数：调用该方法，必须传递一个Student实体对象 必需指定Id
        //{
        //    dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;//告诉EF，我现在要修改一条记录到EF实体模型Student中

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
        //    UserInfo user = dbContext.UserInfo.Find(id);
        //    dbContext.Entry(user).State = System.Data.Entity.EntityState.Deleted;//告诉EF，我现在要删除一条记录到EF实体模型Student中
        //    //dbContext.Savechanges();//将EF实体表的修改，保存到后台的表中；他返回一个整形的数值，
        //    if (dbContext.SaveChanges() > 0) return true; else return false;
        //}

        //#endregion
        //#endregion


       // readonly JxglOADbEntities dbContext = new JxglOADbEntities();

        public int GetBySexCountNum(string xb)
        {
            //return dbContext.UserInfo.Where(u => u.UserSex == xb).Count();
            return dbContext.Set<UserInfo>().Where(u => u.UserSex == xb).Count();
        }
    }
}
