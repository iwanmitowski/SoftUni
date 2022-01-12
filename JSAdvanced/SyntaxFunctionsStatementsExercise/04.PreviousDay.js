function solve(year, month, day){
    
    givenDate = new Date(year, month + 1, day);

    givenDate.setDate(givenDate.getDate() - 1);

    let yr = givenDate.getFullYear();
    let mnth = givenDate.getMonth();
    let dy = givenDate.getDate();

    console.log(`${yr}-${mnth - 1}-${dy}`);
}

solve(2016, 9, 30);
solve(2016, 10, 1);
