import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import * as booksService from "./api/data.js";

const detailsTemplate = (book, isOwner, onDelete, onLike) => html` <section
  id="details-page"
  class="details"
>
  <div class="book-information">
    <h3>${book.title}</h3>
    <p class="type">Type: ${book.type}</p>
    <p class="img"><img src="${book.imageUrl}" /></p>
    <div class="actions">
      <!-- Edit/Delete buttons ( Only for creator of this book )  -->
      ${isOwner
        ? html`<a class="button" href="/edit/${book._id}">Edit</a>
            <a class="button" @click=${onDelete}>Delete</a>`
        : nothing}

      <!-- Bonus -->
      <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
      ${isOwner || book.isLiked
        ? nothing
        : html`<a class="button" id="user" @click=${onLike}>Like</a>`}

      <!-- ( for Guests and Users )  -->
      <div class="likes">
        <img class="hearts" src="/images/heart.png" />
        <span id="total-likes">Likes: ${book.likes}</span>
      </div>
      <!-- Bonus -->
    </div>
  </div>
  <div class="book-description">
    <h3>Description:</h3>
    <p>${book.description}</p>
  </div>
</section>`;

export async function detailsPage(ctx) {
  let id = ctx.params.id;

  let book = await booksService.getById(id);

  let user = JSON.parse(localStorage.getItem("user"));

  let isOwner = user ? user._id == book._ownerId : false;

  ctx.render(detailsTemplate(book, isOwner, onDelete, onLike));
  ctx.updateNav();

  await setLikes();

  async function onDelete(e) {
    e.preventDefault();
    const isConfirmed = confirm(`Are you sure you want to delete ?`);

    if (isConfirmed) {
      await booksService.remove(id);
      ctx.page.redirect("/");
    }
  }

  async function onLike(e) {
    e.preventDefault();
    await booksService.like({ bookId: book._id });
    await setLikes();
    ctx.render(detailsTemplate(book, isOwner, onDelete, onLike));
    ctx.updateNav();
  }

  async function setLikes() {
    if (user) {
      let [likes, isLiked] = await Promise.all([
        booksService.getLikes(book._id),
        booksService.isLiked(user._id, book._id),
      ]);
      if (!likes) {
        likes = 0;
      }
      book.likes = likes;
      book.isLiked = isLiked;
    }
  }
}
