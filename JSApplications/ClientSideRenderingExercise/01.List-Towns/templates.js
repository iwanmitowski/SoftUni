import { html } from '../node_modules/lit-html/lit-html.js';

let listTemplate = (items) =>
    html`
    <ul>
    ${items.map(i=> html`<li>${i}</li>`)}
    </ul>
    `;

export{
    listTemplate,
}