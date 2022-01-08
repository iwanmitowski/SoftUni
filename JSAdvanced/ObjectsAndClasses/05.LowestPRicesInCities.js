function solve(input){
    let products = {};
    let previous = {};

    input.forEach(town => {
        let townValues = town.split(' | ');
        
        let townName = townValues[0];
        let product = townValues[1];
        let price = Number(townValues[2]);

        let currentProduct = {
            TownName: townName,
            Price: Number(price),
        }

        if (!products[product] ||
            previous[product].TownName === townName ||
            products[product].Price > price
            ) {
            products[product] = currentProduct;
            previous[product] = products[product];

        }
    });

    for (const product in products) {
        console.log(product + ' -> ' + products[product].Price + ' (' + products[product].TownName + ')');
    }
}

solve(['Sofia City | Audi | 100000',
'Sofia City | BMW | 100000',
'Sofia City | Mitsubishi | 10000',
'Sofia City | Mercedes | 10000',
'Sofia City | NoOffenseToCarLovers | 0',
'Mexico City | Audi | 1000',
'Mexico City | BMW | 99999',
'New York City | Mitsubishi | 10000',
'New York City | Mitsubishi | 1000',
'Mexico City | Audi | 100000',
'Washington City | Mercedes | 1000']
);