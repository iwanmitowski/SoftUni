function result(matrix){
    let pairs = 0;
    
    let rows = matrix.length;
    let cols = matrix[0].length;

    for (let i = 0; i < rows; i++) {
        for (let j = 0; j < cols; j++) {
            let currentElement = matrix[i][j];

            try{
                if (matrix[i][j+1] !== undefined && currentElement === matrix[i][j+1]) {
                    pairs++;
                }
                if (matrix[i+1][j] !== undefined && currentElement === matrix[i+1][j]) {
                    pairs++;
                }
            }
            catch(err){
                continue;
            } 
        }
    }

    return pairs;
}

console.log(result([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]

))