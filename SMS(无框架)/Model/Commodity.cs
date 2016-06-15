using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //商品表实体类
    public class Commodity
    {
        //商品编号
        public int id { set; get; }
        //商品名称
        public string CommodityName { set; get; }
        //商品简称
        public string ShortName { set; get; }
        //产地
        public string ProducePlace { set; get; }
        //单位
        public string Unit { set; get; }
        //规格
        public string Specs { set; get; }
        //批号
        public string PassNumber { set; get; }
        //批准文号
        public string PassList { set; get; }
        //公司编号
        public int CompanyId { set; get; }
        //备注
        public string Remark { set; get; }
        //管理员名称
        public string UserName { set; get; }
        //添加时间
        public string AddTime { set; get; }
        //总计
        public string total { set; get; }
    }
}
