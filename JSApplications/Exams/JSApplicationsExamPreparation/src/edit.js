import { html } from "../node_modules/lit-html/lit-html.js";
import * as carsService from "./api/data.js";

const editTemplate = (car, onSubmit) => html`
        <section id="edit-listing">
            <div class="container">

                <form @submit=${onSubmit} id="edit-form">
                    <h1>Edit Car Listing</h1>
                    <p>Please fill in this form to edit an listing.</p>
                    <hr>

                    <p>Car Brand</p>
                    <input type="text" placeholder="Enter Car Brand" name="brand" value="${car.brand}">

                    <p>Car Model</p>
                    <input type="text" placeholder="Enter Car Model" name="model" value="${car.model}">

                    <p>Description</p>
                    <input type="text" placeholder="Enter Description" name="description" value="${car.description}">

                    <p>Car Year</p>
                    <input type="number" placeholder="Enter Car Year" name="year" value="${car.year}">

                    <p>Car Image</p>
                    <input type="text" placeholder="Enter Car Image" name="imageUrl" value="${car.imageUrl}">

                    <p>Car Price</p>
                    <input type="number" placeholder="Enter Car Price" name="price" value="${car.price}">

                    <hr>
                    <input type="submit" class="registerbtn" value="Edit Listing">
                </form>
            </div>
        </section>
`;

export async function editPage(ctx){
    let id = ctx.params.id;
    let car = await carsService.getById(id);

    ctx.render(editTemplate(car, onSubmit));

    async function onSubmit(e){
        e.preventDefault();

        let formData = new FormData(e.target);

        let brand = formData.get('brand'); 
        let model = formData.get('model'); 
        let description = formData.get('description'); 
        let year = Number(formData.get('year')); 
        let imageUrl = formData.get('imageUrl'); 
        let price = Number(formData.get('price')); 

        if (!brand ||
            !model ||
            !description ||
            !year ||
            !imageUrl ||
            !price ||
            price <= 0 ||
            year <= 0) {
            
            console.log('error');
            return;
        }
        
        let data = {
            id,
            brand,
            model,
            description,
            year,
            imageUrl,
            price
        }
        
        console.log(data);

        let car = await carsService.edit(data);
        ctx.page.redirect(`/details/${id}`);
    }
}