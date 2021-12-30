function calc(arr){
    let result = [];

    arr.forEach(element => {
        Number(element) < 0 ? result.unshift(element) : result.push(element);
    });

    return result.join('\n');
}

console.log(calc([7, -2, 8, 9]));