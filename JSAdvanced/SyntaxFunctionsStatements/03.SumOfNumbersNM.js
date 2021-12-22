function loop(n, m){
    let start = Number(n);
    let end = Number(m);
    let sum = 0;

    for(let i  = start; i <= end; i++){
        sum += i;
    };

    return sum;
}

console.log(loop(1.0, 1.9));