function solve(input){
    objects = JSON.parse(input);

    let result = ['<table>'];

    let headers = 
    '   <tr>' +
        Object.keys(objects[0]).map(th => '<th>' + th + '</th>').join('') + 
    '</tr>'

    result.push(headers)

    let tableDatas = [];
    objects.forEach(obj => {
        let tableData = '   <tr>';

        Object.values(obj).forEach(td => tableData += '<td>' + escapeHtml(td.toString()) + '</td>');

        tableData += '</tr>';
        result.push(tableData);
    });

    result.push('</table>')
    console.log(result.join('\n'));

    function escapeHtml(unsafe)
    {
        return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#39;");
    }

}

solve('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');