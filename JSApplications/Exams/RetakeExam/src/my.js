import { html } from "../../node_modules/lit-html/lit-html.js";
import * as postsService from "./api/data.js";

const dashboardTemplate = (cards) => html`
  <section id="my-posts-page">
    <h1 class="title">My Posts</h1>
    <div class="my-posts">
      ${cards.length
        ? cards.map(cardTemplate)
        : html`<h1 class="title no-posts-title">You have no posts yet!</h1>`}
    </div>
  </section>
`;

const cardTemplate = (item) => html`<div class="post">
  <h2 class="post-title">${item.title}</h2>
  <img class="post-image" src="${item.imageUrl}" alt="Material Image" />
  <div class="btn-wrapper">
    <a href="/details/${item._id}" class="details-btn btn">Details</a>
  </div>
</div>`;

export async function myPage(ctx) {
  let user = JSON.parse(localStorage.getItem("user"));

  let posts = await postsService.getMine(user._id);
  console.log(posts);
  ctx.render(dashboardTemplate(posts));
}
