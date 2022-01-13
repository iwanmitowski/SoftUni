function solve(input){
    input = input.toUpperCase();
    const regex = /[A-z0-9]+/g
    let words = [...input.matchAll(regex)];

    console.log(words.join(', '));
}

solve('12');