import { html } from "../../node_modules/lit-html/lit-html.js";

const createTemplate = (onSubmit,
invalidMake,
invalidModel,
invalidYear,
invalidDescription,
invalidPrice,
invalidImg) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Create New Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class=${"form-control" + (invalidMake ? ' is-invalid' : ' is-valid')} id="new-make" type="text"
                    name="make">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${"form-control" + (invalidModel ? ' is-invalid' : ' is-valid')} id="new-model"
                    type="text" name="model">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${"form-control" + (invalidYear ? ' is-invalid' : ' is-valid')} id="new-year"
                    type="number" name="year">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${"form-control" + (invalidDescription ? ' is-invalid' : ' is-valid')}
                    id="new-description" type="text" name="description">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${"form-control" + (invalidPrice ? ' is-invalid' : ' is-valid')} id="new-price"
                    type="number" name="price">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${"form-control" + (invalidImg ? ' is-invalid' : ' is-valid')} id="new-image" type="text"
                    name="img">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material">
            </div>
            <input type="submit" class="btn btn-primary" value="Create" />
        </div>
    </div>
</form>`;

export function createPage(ctx){
    ctx.render(createTemplate(onSubmit));

    async function onSubmit(e){
        e.preventDefault();
        let formData = new FormData(e.target);

        let make = formData.get('make');
        let model = formData.get('model');
        let year = Number(formData.get('year'));
        let description = formData.get('description');
        let price = Number(formData.get('price'));
        let img = formData.get('img');
        let material = formData.get('material');

        let isInvalid = validation(make, model, year, description, price, img, material);

        ctx.render(createTemplate(onSubmit, isInvalid[0], isInvalid[1], isInvalid[2], isInvalid[3], isInvalid[4], isInvalid[5]));

        if (isInvalid.includes(true)) {
            return;
        }

        let data = {
            make,
            model,
            year,
            description,
            price,
            img,
            material,
        }

        await createFurniture(data);

        ctx.page.redirect('/');
    }
}

function validation(make, model, year, description, price, img) {
    let invalidMake = false;
    let invalidModel = false;
    let invalidYear = false;
    let invalidDescriprion = false;
    let invalidPrice = false;
    let invalidImg = false;

    if (make.length < 4) {
        invalidMake = true;
    }
    if (model.length < 4) {
        invalidModel = true;
    }
    if (year < 1950 || year > 2500) {
        invalidYear = true;
    }
    if (description.length < 10) {
        invalidDescriprion = true;
    }
    if (price <= 0) {
        invalidPrice = true;
    }
    if (img == '') {
        invalidImg = true;
    }
    
    
    
    return [
        invalidMake,
        invalidModel,
        invalidYear,
        invalidDescriprion,
        invalidPrice,
        invalidImg,
    ];
}