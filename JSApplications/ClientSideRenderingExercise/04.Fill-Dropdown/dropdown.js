import { html, render } from '../node_modules/lit-html/lit-html.js';

let text = document.getElementById('itemText');
let menu = document.getElementById('menu').parentElement;
menu.replaceChildren();
let options;
let optionTemplate = (items) => html`
    <select id="menu">
        ${items.map(i => html`<option value="${i._id}">${i.text}</option>`)}
    </select>
`

let form = document.querySelector('form');

form.addEventListener('submit', addItem);

await getData();
render(optionTemplate(options),menu);

async function addItem(e) {
    e.preventDefault();

    let value ={text: text.value};

    await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'post',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(value),
    })

    await getData();

    render(optionTemplate(options),menu);
}

async function getData(){
    let request = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    let data = await request.json();
    options = Object.values(data);
}


