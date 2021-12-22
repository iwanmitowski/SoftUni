function draw(count){
    for(let i = 0; i < count; i++){
        let line = "";
        for(let j = 0; j < count; j++){
            line += '* ';
        }
        console.log(line);
    }
}

draw(2);