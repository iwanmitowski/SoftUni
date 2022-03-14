import * as templates from './templates.js'
import { render } from '../node_modules/lit-html/lit-html.js';

let root = document.getElementById('root');
let input = document.getElementById('towns');
let form = document.querySelector('form');

form.addEventListener('submit', (e)=>{
    e.preventDefault();
    let towns = input.value.split(', ');

    render(templates.listTemplate(towns), root)
})
alert(1)