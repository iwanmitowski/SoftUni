function solution(constant){    
    return ((a, b) => a + b).bind(null, constant);
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
