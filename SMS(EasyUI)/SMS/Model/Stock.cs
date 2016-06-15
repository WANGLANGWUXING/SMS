using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //库存表实体类
    public class Stock
    {
        //库存编号
        public int id { set; get; }
        //商品编号
        public int CommodityId { set; get; }
        //公司编号
        public int CompanyId { set; get; }
        //商品数量
        public int Number { set; get; }
        //商品单价
        public int Pirce { set; get; }
        //销售日期
        public string StockDate { set; get; }
        //结算方式
        public string SettlementType { set; get; }
        //应收金额
        public int Payment { set; get; }
        //实收金额
        public int FactPayment { set; get; }
        //未收金额
        public int NotPayment { set; get; }
        //经手人
        public string ManageMan { set; get; }
        //管理员名称
        public string Username { set; get; }
        //添加时间
        public string AddTime { set; get; }
        //客户端编号
        public int ClientId { set; get; }
        //信息类型
        public string Type { set; get; }
    }
}
