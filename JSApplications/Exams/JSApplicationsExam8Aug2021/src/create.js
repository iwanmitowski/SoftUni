import { html } from "../../node_modules/lit-html/lit-html.js";
import * as booksService from "./api/data.js";

const createTemplate = (onSubmit) => html` 
<section
  id="create-page"
  class="create"
>
  <form @submit=${onSubmit} id="create-form" action="" method="">
    <fieldset>
      <legend>Add new Book</legend>
      <p class="field">
        <label for="title">Title</label>
        <span class="input">
          <input type="text" name="title" id="title" placeholder="Title" />
        </span>
      </p>
      <p class="field">
        <label for="description">Description</label>
        <span class="input">
          <textarea
            name="description"
            id="description"
            placeholder="Description"
          ></textarea>
        </span>
      </p>
      <p class="field">
        <label for="image">Image</label>
        <span class="input">
          <input type="text" name="imageUrl" id="image" placeholder="Image" />
        </span>
      </p>
      <p class="field">
        <label for="type">Type</label>
        <span class="input">
          <select id="type" name="type">
            <option value="Fiction">Fiction</option>
            <option value="Romance">Romance</option>
            <option value="Mistery">Mistery</option>
            <option value="Classic">Clasic</option>
            <option value="Other">Other</option>
          </select>
        </span>
      </p>
      <input class="button submit" type="submit" value="Add Book" />
    </fieldset>
  </form>
</section>`;

export function createPage(ctx) {
  ctx.render(createTemplate(onSubmit));

  async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.target);

    let title = formData.get("title");
    let description = formData.get("description");
    let imageUrl = formData.get("imageUrl");
    let type = formData.get("type");

    if (!title || !description || !imageUrl || !type) {
      return;
    }

    let data = {
      title,
      description,
      imageUrl,
      type,
    };

    let book = await booksService.create(data);
    console.log(book);
    ctx.page.redirect("/");
  }
}
