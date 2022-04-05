import { html } from "../../node_modules/lit-html/lit-html.js";
import * as petsService from "./api/data.js";

const dashboardTemplate = (cards) => html`
   <section id="dashboard">
        <h2 class="dashboard-title">Services for every animal</h2>
        <div class="animals-dashboard">
            ${cards.length ? cards.map(cardTemplate) : html`<div>
                <p class="no-pets">No pets in dashboard</p>
            </div>`}
        </div>
    </section>`
;

const cardTemplate = (item) => html`<div class="animals-board">
<article class="service-img">
    <img class="animal-image-cover" src="${item.image}">
</article>
<h2 class="name">${item.name}</h2>
<h3 class="breed">${item.breed}</h3>
<div class="action">
    <a class="btn" href="/details/${item._id}">Details</a>
</div>
</div>`;

export async function dashboardPage(ctx) {
  let pets = await petsService.get();

  ctx.render(dashboardTemplate(pets));
}
