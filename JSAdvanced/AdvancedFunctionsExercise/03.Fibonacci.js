function getFibonator(){
    let prev = 0;
    let current = 1;
    return function(){
        let newest = prev + current;
        prev = current;
        current = newest;
        return prev;
    };
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
