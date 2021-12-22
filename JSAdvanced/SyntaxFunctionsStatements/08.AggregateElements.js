function read(numbers){
    let sum = numbers.reduce((res,b) => res + b, 0);
    let sumFraction = numbers.reduce((res,b) => res + 1/b, 0);
    let concat = numbers.join('');

    console.log(sum);
    console.log(sumFraction);
    console.log(concat);
}

read([2, 4, 8, 16]);
