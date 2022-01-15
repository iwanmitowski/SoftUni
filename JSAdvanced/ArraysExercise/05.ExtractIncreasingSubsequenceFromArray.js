function solve(input){
    
    let result = []
    input.reduce((acc, x) => {
        if(x > acc){
            result.push(x);
            acc = x;
        } 
    }, Number.MIN_VALUE)
    
    return result;
}

console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24,
    24]));
console.log(solve([1, 
    2, 
    3,
    4]));
console.log(solve([20, 20]));