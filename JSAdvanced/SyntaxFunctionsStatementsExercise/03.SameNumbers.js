function solve(word){
    
    word = word.toString();
    let same = true;
    let length = word.length;
    let sum = 0;

    for (let i = 1; i < length; i++) {
        
        sum += Number(word.charAt(i-1));

        if (word.charAt(i) != word.charAt(i-1)) {
            same = false;
        }
    }
    
    sum += Number(word.charAt(length-1));
    console.log(same);
    console.log(sum);
}

solve(1234);