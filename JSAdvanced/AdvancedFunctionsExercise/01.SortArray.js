function solve(numbers, order){

    return order == 'asc' ? numbers.sort((a,b) => a-b) : numbers.sort((a,b) => b-a);
}

solve([14, 7, 17, 6, 8], 'asc')