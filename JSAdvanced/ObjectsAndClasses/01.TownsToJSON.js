function solve(input){
    input = input.map(row => 
         row.split('|')
            .map(word=> word.trim())
            .filter(word => word != ''));
        
    let headers = input.shift();
            
    let result = [];   

    input.forEach(row => {
        let currentObject = {
           [headers[0]]: row[0],
           [headers[1]]: Number(Number(row[1]).toFixed(2)),
           [headers[2]]: Number(Number(row[2]).toFixed(2)),
        }

        result.push(currentObject);
    });

    console.log(JSON.stringify(result));
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);