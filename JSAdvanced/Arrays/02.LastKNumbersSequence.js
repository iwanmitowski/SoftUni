function result(n, k){  
    array = [1]; 

    for (let i = 0; i < n - 1; i++) {
        let currentSum = 0;

        for (let j = i; j > i - k; j--) {
            let element = array[j];
            
            if (element !== undefined) {
                currentSum+=element;
            }
        }

        array.push(currentSum);
    }

    return array;
}

console.log(result(8,2));