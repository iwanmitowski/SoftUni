function solve(input){
    let carOutput = new Map();

    input.forEach(carInput => {
        let [brand, model, count] = carInput.split(' | ');

        if (!carOutput.has(brand)) {
            carOutput.set(brand, {});
        }
    
        if (!carOutput.get(brand)[model]) {
            carOutput.get(brand)[model] = 0;
        }
    
        carOutput.get(brand)[model] += Number(count);
    });

    for (const [car, models] of carOutput) {
        console.log(car);
        Object.keys(models).forEach(model =>{
            console.log(`###${model} -> ${models[model]}`);
        })
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']);

