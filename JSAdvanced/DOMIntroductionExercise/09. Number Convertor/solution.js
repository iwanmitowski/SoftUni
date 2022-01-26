function solve() {
    let hexadecimalVal = 'Hexadecimal';
    let binaryVal = 'Binary';

    let menuToElement = document.querySelector('#selectMenuTo');

    let hexadecimalOption = document.createElement('option');
    hexadecimalOption.textContent = hexadecimalVal;
    hexadecimalOption.value = hexadecimalVal.toLowerCase();

    let binaryOption = document.createElement('option');
    binaryOption.textContent = binaryVal;
    binaryOption.value = binaryVal.toLowerCase();

    menuToElement.appendChild(hexadecimalOption);
    menuToElement.appendChild(binaryOption);

    let button = document.querySelector('#container button');

    button.addEventListener('click', convert);

    let resultElement = document.querySelector('#result');

    
    function convert(){
        let currentValue = menuToElement.value;
        let number = document.querySelector('#input').value;
        
        console.log(currentValue);
        let result;

        if (currentValue === '') {
            return;
        }

        if (currentValue === hexadecimalVal.toLowerCase()) {
            result = Number(number).toString(16).toUpperCase();   
        }
        else if (currentValue === binaryVal.toLowerCase()) {
            result = Number(number).toString(2).toUpperCase();   
        }

        console.log(result);
        resultElement.value = result;
    }
}