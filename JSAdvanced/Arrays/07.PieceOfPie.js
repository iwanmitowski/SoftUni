function calc(array, pieOne, pieTwo){
    let firstPieIndex = array.indexOf(pieOne);
    let secondPieIndex = array.indexOf(pieTwo);

    let result = array.filter((x,y) => y >= firstPieIndex && y <= secondPieIndex);

    return result;
}

console.log(calc(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
))