import { html } from "../../node_modules/lit-html/lit-html.js";
import * as eventsService from "./api/data.js";

const createTemplate = (onSubmit) => html` 
<section id="createPage">
            <form class="create-form" @submit=${onSubmit}>
                <h1>Create Theater</h1>
                <div>
                    <label for="title">Title:</label>
                    <input id="title" name="title" type="text" placeholder="Theater name" value="">
                </div>
                <div>
                    <label for="date">Date:</label>
                    <input id="date" name="date" type="text" placeholder="Month Day, Year">
                </div>
                <div>
                    <label for="author">Author:</label>
                    <input id="author" name="author" type="text" placeholder="Author">
                </div>
                <div>
                    <label for="description">Description:</label>
                    <textarea id="description" name="description" placeholder="Description"></textarea>
                </div>
                <div>
                    <label for="imageUrl">Image url:</label>
                    <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url" value="">
                </div>
                <button class="btn" type="submit">Submit</button>
            </form>
        </section>`;

export function createPage(ctx) {
  ctx.render(createTemplate(onSubmit));

  async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.target);

    let title = formData.get("title");
    let date = formData.get("date");
    let author = formData.get("author");
    let imageUrl = formData.get("imageUrl");
    let description = formData.get("description");

    if (!title || !date || !author || !imageUrl || !description) {
      return;
    }

    let data = {
      title,
      date,
      author,
      imageUrl,
      description
    };

    let event = await eventsService.create(data);
    console.log(event);
    ctx.page.redirect("/");
  }
}
