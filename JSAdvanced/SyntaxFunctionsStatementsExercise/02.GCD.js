function solve(number1, number2){
    let n1 = Number(number1);
    let n2 = Number(number2);
    
    let greatest = 1;
    for (let i = 1; i < 10; i++) {
        if (n1 % i == 0 && n2 % i == 0) {
            greatest = i;
        }
    }

    console.log(greatest);
}

solve(2154, 458);