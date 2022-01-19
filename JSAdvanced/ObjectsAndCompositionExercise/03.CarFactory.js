function solve(requirements){
    let {model, power: powerAsString, color, carriage: givenCarriage, wheelsize: wheelsizeAsString} = requirements;

    let power = Number(powerAsString);
    let wheelSize = Number(wheelsizeAsString);
    wheelSize = wheelSize % 2 == 0 ? wheelSize-1 : wheelSize;    

    let engines = {
        smallEngine: { power: 90, volume: 1800 },
        normalEngine: { power: 120, volume: 2400 },
        monsterEngine: { power: 200, volume: 3500 }
    }

    let closestPower = Number.MAX_SAFE_INTEGER;

    for (const engine of Object.keys(engines)) {
        var currentPower = Math.abs(engines[engine].power - power);
        if (currentPower < closestPower) {
            closestPower = currentPower;
        }   
    }

    let engine = Object.keys(engines).find(x => engines[x].power - power === closestPower);
    let carriage = {
        type: givenCarriage,
        color,
    }

    let wheels = new Array(4).fill(wheelSize);

    let car = {
        model,
        engine: engines[engine],
        carriage,
        wheels,
    };

    return(car);
}

solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
);