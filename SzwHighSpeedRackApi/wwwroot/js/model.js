var MyModel = {
    getTables: (db) => {
        $.ajax({
            url: "/api/model/GetTableList",
            data: { dbName: db },
            success: (data) => {
                $("#tableList").html("");
                var optionStr = "";
                for (var i = 0; i < data.length; i++) {
                    optionStr += "  <option>"+data[i]+"</option>";
                }
                $("#tableList").html(optionStr);
            }
        });
    },
    generateModel: (db, table) => {
        $.ajax({
            url: "/api/model/GenerateCode",
            data: { dbName: db, tableName: table },
            success: (data) => {
                $("#codeResult").val(data);
            }
        });
    }
}

$(document).ready(() => {

    //绑定数据库改变事件
    $('#dbList').change(() => {
        var db = $('#dbList').val();
        MyModel.getTables(db);
    });

    //绑定点击生成事件
    $("#modelGenerate").click(() => {
        var db = $('#dbList').val();
        var table = $('#tableList').val();
        MyModel.generateModel(db, table);
    });
   
})