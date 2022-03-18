import { html } from "../../node_modules/lit-html/lit-html.js";
import { getDataById, deleteData } from "../api/data.js";

const detailsTemplate = (item, isOwner, onDelete) => html`
    <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src="/images/chair.jpg" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${item.make}</span></p>
                <p>Model: <span>${item.model}</span></p>
                <p>Year: <span>${item.year}</span></p>
                <p>Description: <span>${item.description}</span></p>
                <p>Price: <span>${item.price}</span></p>
                <p>Material: <span>${item.material}</span></p>
                ${isOwner ? html`
                <div>
                    <a href=”/edit/${item._id}” class="btn btn-info">Edit</a>
                    <a @click=${onDelete} class="btn btn-red">Delete</a>
                </div>
                `: ''};
               
            </div>
        </div>
`;

export async function detailsPage(ctx){
    let id = ctx.params.id;

    let item = await getDataById(id);

    let user = JSON.parse(localStorage.getItem('user'));

    let isOwner = user._id == item._ownerId;

    ctx.render(detailsTemplate(item, isOwner, onDelete));

    async function onDelete(){
        const isConfirmed = confirm(`Are you sure you want to delete ?`);

        if (isConfirmed) {
            await deleteData(item._id);
            ctx.page.redirect('/');
        }
    }
}