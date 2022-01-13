function solve(x1, y1, x2, y2){
    calculate(x1, y1, 0, 0);
    calculate(x2, y2, 0, 0);
    calculate(x1, y1, x2, y2);

    function calculate(xVal1, yVal1, xVal2, yVal2){
        let length = Math.sqrt((xVal2 - xVal1) ** 2 + (yVal2 - yVal1) ** 2);

        if (Number.isInteger(length)) {
            console.log(`{${xVal1}, ${yVal1}} to {${xVal2}, ${yVal2}} is valid`)
        }
        else{
            console.log(`{${xVal1}, ${yVal1}} to {${xVal2}, ${yVal2}} is invalid`)
        }
    }
}

solve(3, 0, 0, 4);