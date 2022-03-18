import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllData } from "../api/data.js";

import { cardTemplate } from "./templates/CardTemplate.js";

const homeTemplate = (cards) => html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
            </div>
        </div>
        <div class="row space-top">
            ${cards.map(cardTemplate)}
        </div>
`;

export async function homePage(ctx){
    const cards = await getAllData();

    ctx.render(homeTemplate(cards));
}