import { html } from '../node_modules/lit-html/lit-html.js';

export let catsTemplate = (cats) =>
    html`
    <ul>${cats.map(c=> html`
        <li>
            <img src="images/${c.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button class="showBtn" @click=${toggleInfo}>Show status code</button>
                <div class="status" style="display: none" id="${c.id}">
                    <h4>Status Code: ${c.statusCode}</h4>
                    <p>${c.statusMessage}</p>
                </div>
            </div>
            </li>
    `)}</ul>
    `

function toggleInfo (e){
    let info = e.currentTarget.parentElement.children[1];
    console.log(info);
    if (info.style.display == 'none') {
        info.style.display = 'block';
    }
    else{
        info.style.display = 'none';
    }
}
