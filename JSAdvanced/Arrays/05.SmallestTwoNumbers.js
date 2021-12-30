function calc(arr){
    let result = [];

    for (let i = 0; i < 2; i++) {
        let smallest = Math.min(...arr);
        let indexOfSmallest = arr.indexOf(smallest);

        arr.splice(indexOfSmallest,1);
        result.push(smallest);
    }

    return result;
}

console.log(calc([30, 15, 50, 5]));