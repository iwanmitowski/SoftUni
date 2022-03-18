import { html } from "../../node_modules/lit-html/lit-html.js";
import { cardTemplate } from "./templates/CardTemplate.js";
import { getMyData } from "../api/data.js";

myFurnitureTemplate = (cards) => html`
    <div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
            </div>
        </div>
        <div class="row space-top">
            ${cards.map(cardTemplate)}
        </div>
`

export async function myFurniturePage(ctx){
    const user = JSON.parse(localStorage.getItem('user'));
    
    if (user) {
        const cards = await getMyData(user._id);
        ctx.render(myFurnitureTemplate(cards));

        return;
    }

    ctx.page.redirect('/');
}