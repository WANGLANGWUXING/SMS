<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SMS.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="UI/themes/black/easyui.css" rel="stylesheet" />
    <link href="UI/themes/icon.css" rel="stylesheet" />
    <script src="Script/jquery-1.8.2.min.js"></script>
    <script src="UI/jquery.easyui.min.js"></script>
    <script src="UI/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript">
        $(function () {
            var dataNew = [{
                "id": 1,
                "text": "基本信息",
                "children": [{
                    "text": "公司信息管理",
                    "checked": true,
                }, {
                    "text": "商品信息管理",
                    "checked": true,
                }]

            },
             {
                 "text": "进货信息管理",
                 "checked": true,
                 "children": [{
                     "text": "商品进货信息",
                     "checked": true
                 },
                 {
                     "text": "商品退货信息",
                     "checked": true
                 }]
             },
                    {
                        "text": "销售管理",
                        "checked": true,
                        "children": [{
                            "text": "销售信息管理",
                            "checked": true,
                            "attributes": { "url": "Sale/SaleManage.aspx" }
                        },
                        {
                            "text": "销售退货管理",
                            "checked": true,
                            "attributes": { "url": "Sale/ReturnManage.aspx" }
                        }]
                    },
                    {
                        "text": "盘点管理",
                        "checked": true,
                        "children": [{
                            "text": "商品结算管理",
                            "checked": true
                        },
                        {
                            "text": "商品库存查询",
                            "checked": true
                        },
                        {
                            "text": "商品销售排行",
                            "checked": true
                        },
                        {
                            "text": "日销售额结算",
                            "checked": true
                        }]
                    },
              {
                  "text": "系统设置",
                  "checked": true,
                  "children": [{
                      "text": "管理员信息管理",
                      "checked": true
                  },
                  {
                      "text": "退出登录",
                      "checked": true
                  }]
              }, ]

            $('#tree').tree({
                url: "",
                data: dataNew,
                onClick: function (node) {
                    if ($("#table").tabs("exists", node.text)) {
                        $("#table").tabs("select", node.text)
                    }
                    else {
                        var tab = $("#table").tabs("tabs");
                        $("#table").tabs("add", {
                            title: node.text,
                            closable: true,
                            content: "<iframe src='" + node.attributes.url + "' height=100% width=100% scrolling='no' frameborder='0' ></iframe>",
                        })
                    }
                }

            })
        })
    </script>
</head>
<body>
    <div id="cc" class="easyui-layout" data-options="fit:true">
        <div data-options="region:'north',split:true" style="height: 100px;"></div>
        <%--        <div data-options="region:'south',title:'South Title',split:true" style="height: 100px;"></div>
        <div data-options="region:'east',iconCls:'icon-reload',title:'East',split:true" style="width: 100px;"></div>--%>
        <div data-options="region:'west',title:'销售信息管理',split:true" style="width: 200px; padding: 10px;">
            <ul id="tree"></ul>
        </div>
        <div data-options="region:'center',title:'center title'" style="padding: 5px; background: #808080;">
            <div id="table" class="easyui-tabs" data-options="fit:true">
                <div title="首页" data-options="fit:true" style="padding: 10px;">
                    <p style="font-size:30px;">欢迎来到每天惠</p>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
