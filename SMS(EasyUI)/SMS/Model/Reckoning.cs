using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //结算表实体类
    public class Reckoning
    {
        //结算编号
        public int id { set; get; }
        //商品编号
        public int CommodityId { set; get; }
        //结款
        public int Settlement { set; get; }
        //经手人
        public string ManageMan { set; get; }
        //结账日期
        public string datetime { set; get; }
        //管理员名称
        public string username { set; get; }
        //添加时间
        public string Addtime { set; get; }
    }
}
