function solve(arr, start, end){
    if (!Array.isArray(arr)) {
        return NaN;
    }

    start = Math.max(start, 0);
    end = Math.min(end, arr.length - 1);

    let startIndex = Number(start);
    let endIndex = Number(end);

    return arr.slice(startIndex, endIndex +1).reduce((a, b) => a + Number(b), 0);
}

console.log(solve([10, 'twenty', 30, 40], 0, 2));