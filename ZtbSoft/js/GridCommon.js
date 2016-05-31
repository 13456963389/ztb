//合计行算法
function onDrawSummaryCell(e) {
    var result = e.result;
    if (e.result && e.result.sum) {
        //服务端汇总计算
        if (result.sum[e.field] != "null" && result.sum[e.field] != undefined) {
            var s = "<div style='color:Brown;width:100%;border:1px;' align='right'>" + result.sum[e.field] + "</div>";
            e.cellHtml = s;
        }        
    }
}
//导出EXCEL
function ExportExcel() {
    var columns = grid.getBottomColumns();

    function getColumns(columns) {
        columns = columns.clone();
        for (var i = columns.length - 1; i >= 0; i--) {
            var column = columns[i];
            if (!column.field) {
                columns.removeAt(i);
            } else {
                var c = { header: column.header, field: column.field };
                columns[i] = c;
            }
        }
        return columns;
    }

    var columns = getColumns(columns);
    var json = mini.encode(columns);
    document.getElementById("excelColumns").value = json;
    document.getElementById("excelData").value = mini.encode(grid.data);
    var excelForm = document.getElementById("excelForm");
    excelForm.submit();

}