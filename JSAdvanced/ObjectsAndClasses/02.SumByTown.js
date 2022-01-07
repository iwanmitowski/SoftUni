function solve(input){
    let towns = {};

    for (let index = 0; index < input.length - 1; index+=2) {
        let key = input[index];
        let value = Number(input[index + 1]);

        if ([key] in towns === false) {
            towns[key] = 0;
        }
        
        towns[key] += value;
    }

    console.log(JSON.stringify(towns));
}

solve(['Sofia','20','Varna','3','Sofia','5','Varna','4']);