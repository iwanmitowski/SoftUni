function solve(input){
    let products = {};
    
    input.forEach(town => {
        let townValues = town.split(' | ');
        
        let townName = townValues[0];
        let product = townValues[1];
        let price = Number(townValues[2]);

        let currentTown = {
            townName,
            price: Number(price),
        }

        if (!products[product]){
            products[product] = [];
        }

        let existingTown = products[product].find(x => x.townName == townName);
        if (existingTown) {

            for (let i = 0; i < products[product].length; i++) {
                if (products[product][i].townName === townName) {
                    products[product][i].price = price;
                }
            }
        }
        else{
            products[product].push(currentTown);
        }
    });

    for (const product in products) {
        
        products[product] = products[product].sort((a, b) => a.price - b.price || a);

        
        console.log(product + ' -> ' + products[product][0].price + ' (' + products[product][0].townName + ')');
    }
}

solve(['Sofia City | Audi | 100000',
'Mexico City | Audi | 1000',
'Mexico City | Audi | 100000']
);