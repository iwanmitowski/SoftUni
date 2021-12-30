function calculate(array){
    let result = array.filter((x,y)=> y%2==0);

    return result.join(' ');
}

console.log(calculate(['20', '30', '40', '50', '60']));
