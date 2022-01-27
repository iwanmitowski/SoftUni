function addItem() {
    
    let text = document.getElementById('newItemText').value;

    let li = document.createElement('li');
    li.textContent = text;

    let a = document.createElement('a');
    a.textContent = '[Delete]';
    a.href = '#';
    

    li.appendChild(a);

    let items = document.getElementById('items');

    items.appendChild(li);


    a.addEventListener('click' , function (){
        a.parentNode.remove()
    })

}