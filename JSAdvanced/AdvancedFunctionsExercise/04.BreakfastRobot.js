function solution(){
    let nutrients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    let recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20,
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1,
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
        }
    }

    function manageOrders (input){
        let [command, val, secondVal] = input.split(' ');
        
        switch (command) {
            case 'restock':
                nutrients[val] += Number(secondVal);
                return 'Success'

            case 'prepare':
                let currentFood = recipes[val];
                
                let canBeCooked = true;
                let failedNutrient = '';

                Object.keys(currentFood).forEach(key =>{
                    for (const nutrient in nutrients) {
                        if (currentFood[nutrient] * Number(secondVal) >= nutrients[nutrient]) {
                            canBeCooked = false;
                            failedNutrient = nutrient;
                            break;
                        }
                    }
                });
                
                if (canBeCooked) {
                    Object.keys(nutrients).forEach(key =>{
                        if (currentFood[key]) {
                            nutrients[key] -= currentFood[key] * Number(secondVal);
                        }
                    });
                    return 'Success'
                }
                
            return `Error: not enough ${failedNutrient} in stock`;

            case 'report':
                let result ='';

                Object.keys(nutrients).forEach(x=> result+= `${x}=${nutrients[x]} `);
                
            return result.trimEnd();
        }
    }

    return manageOrders;
}

let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4"));
console.log (manager ("restock carbohydrate 10")); // Error: not enough carbohydrate in stock 
console.log (manager ("restock flavour 10")); // Error: not enough carbohydrate in stock 
console.log (manager ("prepare apple 1")); // Error: not enough carbohydrate in stock 
console.log (manager ("restock fat 10")); // Error: not enough carbohydrate in stock 
console.log (manager ("prepare burger 1")); // Error: not enough carbohydrate in stock 
console.log (manager ("report")); // Error: not enough carbohydrate in stock
// Error: not enough carbohydrate in stock 
