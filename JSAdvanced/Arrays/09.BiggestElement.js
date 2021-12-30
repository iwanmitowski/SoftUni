function calc(matrix){
    let result = matrix
    .map(row => Math.max(...row))
    .reduce((a, b) => { return Math.max(a, b) });
  
    return result;
}

console.log(calc(
    [[20, 50, 10],
    [8, 33, 145]]));