import { html, nothing } from "../node_modules/lit-html/lit-html.js";
import * as carsService from "./api/data.js";

const detailsTemplate = (car, isOwner, onDelete) => html`
        <section id="listing-details">
            <h1>Details</h1>
            <div class="details-info">
                <img src="${car.imageUrl}">
                <hr>
                <ul class="listing-props">
                    <li><span>Brand:</span>${car.brand}</li>
                    <li><span>Model:</span>${car.model}</li>
                    <li><span>Year:</span>${car.year}</li>
                    <li><span>Price:</span>${car.price}$</li>
                </ul>

                <p class="description-para">${car.description}</p>

                ${isOwner ? html`
                <div class="listings-buttons">
                    <a href="/edit/${car._id}" class="button-list">Edit</a>
                    <a href="#" @click="${onDelete}" class="button-list">Delete</a>
                </div>` : nothing}
                
            </div>
        </section>
`;

export async function detailsPage(ctx){
    let id = ctx.params.id;
    let car = await carsService.getById(id);

    let user = JSON.parse(localStorage.getItem('user'));

    let isOwner = user ? user._id == car._ownerId : false;

    ctx.render(detailsTemplate(car, isOwner, onDelete));

    async function onDelete(e){
        console.log(1232321);
        e.preventDefault();
        const isConfirmed = confirm(`Are you sure you want to delete ?`);

        if (isConfirmed) {
            await carsService.deleteData(id);
            ctx.page.redirect('/all');
        }
    }
}