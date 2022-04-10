import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as postsService from "./api/data.js";

const detailsTemplate = (post, isOwner, onDelete, onDonate) => html` 

<section id="details-page">
            <h1 class="title">Post Details</h1>

            <div id="container">
                <div id="details">
                    <div class="image-wrapper">
                        <img src="${post.imageUrl}" alt="Material Image" class="post-image">
                    </div>
                    <div class="info">
                        <h2 class="title post-title">${post.title}</h2>
                        <p class="post-description">Description: ${post.description}</p>
                        <p class="post-address">Address: ${post.address}</p>
                        <p class="post-number">Phone number: ${post.phone}</p>
                        <p class="donate-Item">Donate Materials: ${post.donations}</p>

                        <!--Edit and Delete are only for creator-->
                        <div class="btns">
                        ${isOwner ? html`
                            <a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
                            <a href="" @click=${onDelete} class="delete-btn btn">Delete</a>
` : nothing}
                            <!--Bonus - Only for logged-in users ( not authors )-->
                            ${localStorage.user && !isOwner && !post.isDonated ? html`<a href="" @click=${onDonate} class="donate-btn btn">Donate</a>` : nothing}
                            
                        </div>

                    </div>
                </div>
            </div>
        </section>
`;

export async function detailsPage(ctx) {
  let id = ctx.params.id;

  let post = await postsService.getById(id);

  let user = JSON.parse(localStorage.getItem("user"));
  let isOwner = false;

  if (user) {
    isOwner = user._id == post._ownerId;
    await setUpDonations();
  } else {
    let donations = await postsService.getDonationCount(id);
    post.donations = donations;
  }

  ctx.render(detailsTemplate(post, isOwner, onDelete, onDonate));
  ctx.updateNav();

  async function onDelete(e) {
    e.preventDefault();
    const isConfirmed = confirm(`Are you sure you want to delete ?`);

    if (isConfirmed) {
      await postsService.remove(id);
      ctx.page.redirect("/");
    }
  }

  async function onDonate(e){
    e.preventDefault();
    await postsService.donate({postId: id});
    await setUpDonations();
    ctx.render(detailsTemplate(post, isOwner, onDelete, onDonate));
  }

  async function setUpDonations(){
    let [donations, isDonated] = await Promise.all([
      postsService.getDonationCount(id),
      postsService.isDonated(id, user._id)
    ])
  
    post.donations = donations;
    post.isDonated = !!isDonated;
  }
}
