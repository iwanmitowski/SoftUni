function solve(input){

    let result = []; 

    input.forEach(line => {
        [name, level, items] = line.split(' / ');

        items = items ? items.split(', ') : [];

        let currentHero = {
            name,
            level: Number(level),
            items,
        }

        result.push(currentHero);
    });

    let jsonResult = JSON.stringify(result);
    console.log(jsonResult);
}

solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);