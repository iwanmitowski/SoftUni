function calc(array){
    let result = array
    .filter((x,y) => y % 2 != 0)
    .map(x=> x*2)
    .reverse()
    .join(', ');

    return result;
}

console.log(calc([10, 15, 20, 25]));