import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as petsService from "./api/data.js";

const detailsTemplate = (pet, isOwner, onDelete, onDonate) => html` <section
  id="details-page"
  class="details"
>
<section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="./images/Shiba-Inu.png">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${pet.name}</h1>
                    <h3>Breed: ${pet.breed}</h3>
                    <h4>Age: ${pet.age}</h4>
                    <h4>Weight: ${pet.weight}</h4>
                    <h4 class="donation">Donation: ${pet.donations}$</h4>
                </div>
                <!-- if there is no registered user, do not display div-->
                <div class="actionBtn" class="user">
                    ${isOwner ? html`
                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                    <a href="" @click=${onDelete} class="remove">Delete</a>
                    
                    ` : nothing}
                    
                    ${localStorage.user && !isOwner && !pet.isDonated ? html`<a href="" @click=${onDonate} class="donate" class="user">Donate</a>` : nothing}
                </div>
            </div>
        </div>
    </section>`;

export async function detailsPage(ctx) {
  let id = ctx.params.id;

  let pet = await petsService.getById(id);

  let user = JSON.parse(localStorage.getItem("user"));
  let isOwner = false;

  if (user) {
    isOwner = user._id == pet._ownerId;
  }

  await setUpDonations();

  ctx.render(detailsTemplate(pet, isOwner, onDelete, onDonate));
  ctx.updateNav();

  async function onDelete(e) {
    e.preventDefault();
    const isConfirmed = confirm(`Are you sure you want to delete ?`);

    if (isConfirmed) {
      await petsService.remove(id);
      ctx.page.redirect("/");
    }
  }

  async function onDonate(e){
    await petsService.donate({petId: id});
    await setUpDonations();
    ctx.render(detailsTemplate(pet, isOwner, onDelete, onDonate));
  }

  async function setUpDonations(){
    let [donations, isDonated] = await Promise.all([
      petsService.getDonationCount(id),
      petsService.isDonated(id, user._id)
    ])
  
    pet.donations = donations * 100;
    pet.isDonated = !!isDonated;
  }
}
