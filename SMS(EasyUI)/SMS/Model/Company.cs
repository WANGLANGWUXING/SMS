using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //公司信息实体类
    public class Company
    {
        //公司编号
        public int id { set; get; }
        //公司名称
        public string CompanyName { set; get; }
        //公司类型
        public string CompanyType { set; get; }
        //公司简称
        public string CompanyShort { set; get; }
        //公司地址
        public string CompanyAddress { set; get; }
        //邮编
        public string Postalcode { set; get; }
        //公司电话
        public string Tel { set; get; }
        //联系人
        public string Linkman { set; get; }
        //邮箱
        public string Email { set; get; }
        //开户银行
        public string Bank { set; get; }
        //银行账号
        public string BandAccounts { set; get; }
        //管理员
        public string Username { set; get; }
        //添加时间
        public string AddTime { set; get; }
    }
}
