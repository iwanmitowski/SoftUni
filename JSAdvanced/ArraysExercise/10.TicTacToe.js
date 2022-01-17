function solve(input){
    let winner = '';

    board = [[false, false, false],
            [false, false, false],
            [false, false, false]];
    
    let isWin;
    let turns = 0;

    for (let i = 0; i < input.length; i++) {
        let turn = turns % 2 == 0 ? 'X' : 'O';

        if (turns == 9) {
            break;
        }
        
        let indexes = input[i].split(' ');
        let row = Number(indexes[0]);
        let col = Number(indexes[1]);

        if (board[row][col]) {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        board[row][col] = turn;

        turns++;

        isWin = CheckForWin();

        if (isWin) {
            winner = turn;
            break;
        }
    }

    if (!isWin) {
        console.log("The game ended! Nobody wins :(");
    }
    else{
        console.log(`Player ${winner} wins!`);
    }

    for (let i = 0; i < 3; i++) {
        console.log(board[i].join('\t'))
    }

    function CheckForWin(){
        // console.log('cols');
        // console.log((!board[0][0] && board[0][0] && board[0][1] && board[0][2] === true));
        // console.log((!board[1][0] && board[1][0] == board[1][1] == board[1][2] && true));
        // console.log((!board[2][0] && board[2][0] == board[2][1] == board[2][2] && true));
        // console.log('rows');
        // console.log((!board[0][0] && board[0][0] == board[1][0] == board[2][0] && true));
        // console.log((!board[0][1] && board[0][1] == board[1][1] == board[2][1] && true));
        // console.log((!board[0][2] && board[0][2] == board[1][2] == board[2][2] && true));
        // console.log('d');
        // console.log((!board[0][0] && board[0][0] == board[1][1] == board[2][2] && true));
        // console.log((!board[2][0] && board[2][0] == board[1][1] == board[0][2] && true));

         return (typeof(board[0][0]) !== 'boolean' && (board[0][0] == board[0][1]) && (board[0][1] == board[0][2])) ||
                (typeof(board[1][0]) !== 'boolean' && (board[1][0] == board[1][1]) && (board[1][1] == board[1][2])) ||
                (typeof(board[2][0]) !== 'boolean' && (board[2][0] == board[2][1]) && (board[2][1] == board[2][2])) ||
        //Cols
                (typeof(board[0][0]) !== 'boolean' && (board[0][0] == board[1][0]) && (board[1][0] == board[2][0])) ||
                (typeof(board[0][1]) !== 'boolean' && (board[0][1] == board[1][1]) && (board[1][1] == board[2][1])) ||
                (typeof(board[0][2]) !== 'boolean' && (board[0][2] == board[1][2]) && (board[1][2] == board[2][2])) ||
        //Diagonals
                (typeof(board[0][0]) !== 'boolean' && (board[0][0] == board[1][1]) && (board[1][1] == board[2][2])) ||
                (typeof(board[2][0]) !== 'boolean' && (board[2][0] == board[1][1]) && (board[1][1] == board[0][2])) 
    }
}

solve(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]

);