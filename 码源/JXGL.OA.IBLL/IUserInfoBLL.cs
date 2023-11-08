using JXGL.OA.EFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXGL.OA.IBLL
{
    public partial interface IUserInfoBLL:IBaseBLL<UserInfo>
    {
        //是UserInfoBLL继承了他  实现了这个接口
        bool IsUserExist(UserInfo user);
    }
}
