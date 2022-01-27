function addItem() {
    
    let text = document.getElementById('newItemText').value;

    let li = document.createElement('li');
    li.textContent = text;

    let items = document.getElementById('items');

    items.appendChild(li);
}