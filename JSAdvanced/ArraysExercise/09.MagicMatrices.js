function solve(matrix){
    let isMagical = true;

    let matrixCols = matrix[0].length
    let matrixRows = Object.keys(matrix).length;
    
    let firstRowSum = matrix[0].reduce((a, b) => a+=b,0);

    for (let i = 1; i < matrixRows; i++) {
        currentSum = matrix[i].reduce((a, b) => a += b, 0)
        
        if (firstRowSum !== currentSum) {
            isMagical = false;
            break;
        }
    }

    if (isMagical) {
        let firstColSum = 0;

        for (const key in matrix) {
            firstColSum += matrix[key][0];
        }

        for (let i = 0; i < matrixCols; i++) {
            currentSum = 0;

            for (const key in matrix) {
                currentSum += matrix[key][i];
            }

            if (currentSum !== firstColSum ){
                isMagical = false;
                break;
            }
        }
    }
    
    console.log(isMagical);
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   
   )

solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
   
)   