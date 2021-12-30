function result(array){
    let result = [];

    array.sort((a,b) => a - b);
  
    let firstHalf = array.slice(0, array.length/2);
    let secondHalf = array.slice(array.length/2);

    if (firstHalf.length > secondHalf.length) {
        result = firstHalf;
    }
    else{
        let firstSum = firstHalf.reduce((a,x) => a+x, 0);
        let secondSum = secondHalf.reduce((a,x) => a+x, 0);

        if (firstSum > secondSum) {
            result = firstHalf;
        }
        else{
            result = secondHalf;
        }
    }

    return result;
}

console.log(result([3, 19, 14, 7, 2, 19, 6]));