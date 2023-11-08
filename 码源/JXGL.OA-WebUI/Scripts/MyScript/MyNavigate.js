function AddccordionNode() {
    //1.获取导航栏中Accordion面板的导航Json格式的数据
    $.ajax({
        url: '/Home/GetMainMenuList/?id=0', method: 'get', dataType: 'json',
        success: function (data) {
            //2.动态添加导航数据到Accordion面板中
            $.each(data, function (k,v) {
                $('#LeftAccordion').accordion('add', {
                    title: v.text, iconCls: v.iconCls, selected: false, animate: true,
                    content: "<ul id='tree" + v.Id + "'></ul>"
                });
                //3.给一步中创建treeX模型结构树添加子菜单节点，并将链接指向url定向的网页文件，给每个子菜单添加一个onclick事件
                $('#tree' + v.Id).tree({
                    url: '/Home/GetSubMenuList/?id=' + v.Id, method: 'get', lines: true, animate: true,
                    onClick: function (node) {
                        if ($('#myTabs').tabs('exists', node.text)) { $('#myTabs').tabs('select', node.text); return }
                        else {
                            $('#myTabs').tabs('add', {
                                title: node.text, closable: true, icon: node.iconCls,
                                content: addFrame(node.url)
                            });
                        }
                    }
                })
            })

        }
    })
}
function addFrame(url) {
    var f = '<iframe frameborder="0" src="' + url + '" scrolling="auto" style="width:100%;height:100%;"><iframe>';
    return f;
}