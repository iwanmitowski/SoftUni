function solve(input){
    let operations = {
        '+': (first, second) => first + second, 
        '-': (first, second) => first - second, 
        '*': (first, second) => first * second, 
        '/': (first, second) => first / second, 
    }

    let numbers = input.filter(n => typeof(n) == 'number');
    let operators = input.filter(n => typeof(n) != 'number');

    if (operators.length >= numbers.length) {
        console.log("Error: not enough operands!");
        return;
    }

    if (numbers.length - 1 != operators.length) {
        console.log("Error: too many operands!");
        return;
    }

    numbers = [];

    for (const item of input) {
        if (Number.isInteger(item)) {
            numbers.push(item);
        }
        else {
           let n2 = numbers.pop();
           let n1 = numbers.pop();

           let result = operations[item](n1, n2);
           numbers.push(result);
        }
    }

    console.log(numbers.pop());
}

solve([15, '/'])

solve([31,
    2,
    '+',
    11,
    '/'])

solve([-1,
    1,
    '+',
    101,
    '*',
    18,
    '+',
    3,
    '/']);
