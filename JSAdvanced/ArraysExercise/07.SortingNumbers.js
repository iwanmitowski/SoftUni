function solve(numbers){ 
    numbers.sort((a, b) => a-b);

    let result = [];

    while (numbers.length > 0) {
        result.push(numbers.shift());

        if (numbers.length > 0) {
            result.push(numbers.pop());
        }
    }
    
    return result;
}

console.log(solve([4,3,2]));
