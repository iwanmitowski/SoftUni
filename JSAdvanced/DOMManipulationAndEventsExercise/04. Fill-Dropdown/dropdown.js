function addItem() {
    let newItemTextElement = document.getElementById('newItemText');
    let newItemValue = document.getElementById('newItemValue');

    let option = document.createElement('option');
    option.textContent = newItemTextElement.value;
    option.value = newItemValue.value;

    let selectElement = document.getElementById('menu');
    
    selectElement.appendChild(option);

    newItemTextElement.value = '';
    newItemValue.value = '';
}