import { html } from "../../node_modules/lit-html/lit-html.js";
import * as postsService from "./api/data.js";

const createTemplate = (onSubmit) => html`
  <section id="create-page" class="auth">
    <form id="create" @submit=${onSubmit}>
      <h1 class="title">Create Post</h1>

      <article class="input-group">
        <label for="title">Post Title</label>
        <input type="title" name="title" id="title" />
      </article>

      <article class="input-group">
        <label for="description">Description of the needs </label>
        <input type="text" name="description" id="description" />
      </article>

      <article class="input-group">
        <label for="imageUrl"> Needed materials image </label>
        <input type="text" name="imageUrl" id="imageUrl" />
      </article>

      <article class="input-group">
        <label for="address">Address of the orphanage</label>
        <input type="text" name="address" id="address" />
      </article>

      <article class="input-group">
        <label for="phone">Phone number of orphanage employee</label>
        <input type="text" name="phone" id="phone" />
      </article>

      <input type="submit" class="btn submit" value="Create Post" />
    </form>
  </section>
`;

export function createPage(ctx) {
  ctx.render(createTemplate(onSubmit));

  async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.target);

    let title = formData.get("title");
    let description = formData.get("description");
    let imageUrl = formData.get("imageUrl");
    let address = formData.get("address");
    let phone = formData.get("phone");

    if (!title || !description || !imageUrl || !address || !phone) {
      return;
    }

    let data = {
      title,
      description,
      imageUrl,
      address,
      phone,
    };

    let post = await postsService.create(data);
    console.log(post);
    ctx.page.redirect("/");
  }
}
