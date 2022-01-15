function solve(input){  
    input.sort((a, b) => (a.length - b.length) || a.localeCompare(b))
                           //0 is falsy
    input.forEach(x => console.log(x));
}

solve(['aa', 
'aa', 
'bb', 
'cc', 
'vv'])