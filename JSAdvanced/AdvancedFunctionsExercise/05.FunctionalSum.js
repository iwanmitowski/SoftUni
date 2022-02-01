function add(n){

    let sum = n;

    function inner(number){
        sum += number;

        return inner;
    }

    inner.toString = ()=>{
        return sum;
    }

    return inner;
}

console.log(Number(add(1)(1)));


