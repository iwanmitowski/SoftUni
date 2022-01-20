function solve(input){
    let keys = input.shift().split(' ').filter(k => k != '|');
    
    let result = [];

    input.forEach(town => {
       let townValues = town.split('|').map(x=>x.trim()).filter(k => k != '');

       let currentTown = {
           [keys[0]]: townValues[0],
           [keys[1]]: Number(Number(townValues[1]).toFixed(2)),
           [keys[2]]: Number(Number(townValues[2]).toFixed(2))
       }

       result.push(currentTown);
    });

    console.log(JSON.stringify(result));
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);