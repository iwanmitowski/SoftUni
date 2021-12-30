function calc(matrix){
    let mainDiagonal = 0;
    let secondaryDiagonal = 0;

    let length = matrix[0].length - 1;

    for (let i = 0; i <= length; i++) {
        mainDiagonal += Number(matrix[i][i]);
        secondaryDiagonal += Number(matrix[i][length - i]);
    }

    console.log(mainDiagonal + ' ' + secondaryDiagonal);
}


calc([[20, 40],
    [10, 60]]);
