import { html } from "../../node_modules/lit-html/lit-html.js";
import * as postsService from "./api/data.js";

const dashboardTemplate = (cards) => html`
    <section id="dashboard-page">
            <h1 class="title">All Posts</h1>

            <!-- Display a div with information about every post (if any)-->
            <div class="all-posts">
                ${cards.length ? cards.map(cardTemplate) : html `<h1 class="title no-posts-title">No posts yet!</h1>`}
            </div>

            <!-- Display an h1 if there are no posts -->
        </section>
`;

const cardTemplate = (item) => html`<div class="post">
<h2 class="post-title">${item.title}</h2>
<img class="post-image" src="${item.imageUrl}" alt="Material Image">
<div class="btn-wrapper">
    <a href="/details/${item._id}" class="details-btn btn">Details</a>
</div>
</div>`;

export async function dashboardPage(ctx) {
  let posts = await postsService.get();
    console.log(posts);
  ctx.render(dashboardTemplate(posts));
}
