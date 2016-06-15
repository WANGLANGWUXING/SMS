using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //管理员实体类
    public class User
    {
        //管理员编号
        public int id { set; get; }
        //管理员姓名
        public string username { set; get; }
        //密码
        public string userpwd { set; get; }
        //添加时间
        public string AddTime { set; get; }
    }
}
