function solve(input){
    let [width, height, x, y] = input;

    let matrix = [];

    for (let i = 0; i < height; i++) {
        matrix[i] = [];
        for (let j = 0; j < width; j++) {
            //the further distance is taken
            matrix[i][j] = Math.max(Math.abs(i - x), Math.abs(j - y)) + 1;
        }
    }

    console.log(matrix.map(r => r.join(" ")).join("\n"));
}

solve([4, 4, 1, 1]);
