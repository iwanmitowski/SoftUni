function subtract() {
    let firstNumberElement = document.getElementById('firstNumber');
    let secondNumberElement = document.getElementById('secondNumber');

    let n1 = Number(firstNumberElement.value);
    let n2 = Number(secondNumberElement.value);

    let result = n1 - n2;

    let resultElement = document.getElementById('result');

    resultElement.innerHTML = result;
}