function solve(input){
    let towns = {};

    input.forEach(town => {
        town = town.split(' <-> ');
        
        let city = town[0];
        let population = Number(town[1]);

        if ([city] in towns === false) {
            towns[city] = 0;
        }

        towns[city] += population;
    });

    Object.keys(towns).forEach(k=> console.log(k + ' : ' + towns[k]));
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
)