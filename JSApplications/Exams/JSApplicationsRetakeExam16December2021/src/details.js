import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as eventsService from "./api/data.js";

const detailsTemplate = (theater, isOwner, onDelete, onLike) => html` <section
  id="detailsPage"
>
  <div id="detailsBox">
    <div class="detailsInfo">
      <h1>Title: ${theater.title}</h1>
      <div>
        <img src="${theater.imageUrl}" />
      </div>
    </div>

    <div class="details">
      <h3>Theater Description</h3>
      <p>${theater.description}</p>
      <h4>Date: ${theater.date}</h4>
      <h4>Author: ${theater.author}</h4>
      <div class="buttons" id="user">
        ${isOwner
          ? html`
              <a class="btn-delete" @click=${onDelete}>Delete</a>
              <a class="btn-edit" href="/edit/${theater._id}">Edit</a>
            `
          : `<a class="btn-like" @click=${onLike}>Like</a>`}

      </div>
      <p class="likes">Likes: ${theater.likes}</p>
    </div>
  </div>
</section>`;

export async function detailsPage(ctx) {
  let id = ctx.params.id;

  let theater = await eventsService.getById(id);
  console.log(theater);
  let user = JSON.parse(localStorage.getItem("user"));

  let isOwner = user ? user._id == theater._ownerId : false;

  ctx.render(detailsTemplate(theater, isOwner, onDelete, onLike));
  ctx.updateNav();

  await setLikes();

  async function onDelete(e) {
    e.preventDefault();
    const isConfirmed = confirm(`Are you sure you want to delete ?`);

    if (isConfirmed) {
      await eventsService.remove(id);
      ctx.page.redirect("/");
    }
  }

  async function onLike(e) {
    e.preventDefault();
    await eventsService.like({ theaterId: theater._id });
    await setLikes();
    ctx.render(detailsTemplate(theater, isOwner, onDelete, onLike));
    ctx.updateNav();
  }

  async function setLikes() {
    if (user) {
      let [likes, isLiked] = await Promise.all([
        eventsService.getLikes(theater._id),
        eventsService.isLiked(user._id, theater._id),
      ]);
      if (!likes) {
        likes = 0;
      }
      book.likes = likes;
      book.isLiked = isLiked;
    }
  }
}
