function solve(input){
    let matrix = [,];

    for (let i = 0; i < input.length; i++) {
        matrix[i] = [];

        input[i].split(' ').map(x=> Number(x)).forEach(element => {
            matrix[i].push(element);
        });
        
    }

    let mainDiagonal = 0;
    let secondaryDiagonal = 0;

    for (let i = 0; i < matrix.length; i++) {
        mainDiagonal+= matrix[i][i];
        secondaryDiagonal+= matrix[i][matrix.length - 1 - i]
    }

    if (mainDiagonal === secondaryDiagonal) {
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix.length; j++) {
                if (i + j === matrix.length -1 || i == j) {
                    continue;
                } 
                matrix[i][j] = mainDiagonal;
            }
        }
    }

    for (let i = 0; i < matrix.length; i++) {
        console.log(matrix[i].join(' '));
    }
}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
);