function sumTable() {
    let numberElements = document.querySelectorAll('tr td:nth-child(even)')

    let numArr = Array.from(numberElements);

    let sum = 0;

    for (let index = 0; index < numArr.length - 1; index++) {
       sum += Number(numArr[index].textContent);
    }

    let resultElement = document.getElementById('sum');

    resultElement.textContent = sum;
}