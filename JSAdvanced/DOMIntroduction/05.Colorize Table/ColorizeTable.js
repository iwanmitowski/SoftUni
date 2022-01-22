function colorize() {
    let tdElements = document.querySelectorAll('tr:nth-child(2n) td');
    
    let arr = Array.from(tdElements);

    arr.forEach(element => {
        element.style.backgroundColor = 'teal'
    });
}