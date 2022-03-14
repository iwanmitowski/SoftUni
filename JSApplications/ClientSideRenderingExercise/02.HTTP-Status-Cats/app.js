import { render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';
import { catsTemplate } from './templates.js'

let catsDiv = document.getElementById('allCats');

render(catsTemplate(cats), catsDiv);