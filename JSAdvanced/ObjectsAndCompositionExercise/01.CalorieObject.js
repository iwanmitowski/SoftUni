function solve(input){

    let foods = {};

    for (let i = 0; i < input.length - 1; i+=2) {
        let key = input[i];
        let value = Number(input[i+1]);
        
        foods[key] = value;
    }

    console.log(foods);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);