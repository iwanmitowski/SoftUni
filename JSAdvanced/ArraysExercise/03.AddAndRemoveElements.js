function solve(commands){
    let start = 0;
    let result = [];
    for (let i = 0; i < commands.length; i++) {
        start++;

        let command = commands[i];

        switch (command) {
            case 'add':
                result.push(start);
                break;
            case 'remove':
            result.pop();
                break;
        }
        
    }
    
    if (result.length > 0) {
        result.forEach(n => console.log(n));
    }
    else{
        console.log('Empty');
    }
}

solve(['add', 
'add', 
'add', 
'add']
);

solve(
    ['add', 
'add', 
'remove', 
'add', 
'add']
);

solve(
    ['remove', 
'remove', 
'remove']
)