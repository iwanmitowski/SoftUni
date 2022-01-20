function solve(input){
    let result = {};

    input.forEach(product => {
        let firstLetter = product[0];

        if (!result[firstLetter]) {
            result[firstLetter] = [];
        }

        result[firstLetter].push(product);
    });

    let sortedLetters = Object.keys(result).sort();

    sortedLetters.forEach(letter => {
        console.log(letter);
        for (const product of result[letter].sort()) {
            let values = product.split(' : ');

            let key = values[0];
            let value = values[1];

            console.log(`  ${key}: ${value}`);
        }
    });
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);