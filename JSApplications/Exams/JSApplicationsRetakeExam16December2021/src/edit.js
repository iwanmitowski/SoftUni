import { html } from "../../node_modules/lit-html/lit-html.js";
import * as eventsService from "./api/data.js";

const editTemplate = (theater, onSubmit) => html`
  <section id="editPage">
    <form class="theater-form" @submit=${onSubmit}>
      <h1>Edit Theater</h1>
      <div>
        <label for="title">Title:</label>
        <input
          id="title"
          name="title"
          type="text"
          placeholder="Theater name"
          value="${theater.title}"
        />
      </div>
      <div>
        <label for="date">Date:</label>
        <input
          id="date"
          name="date"
          type="text"
          placeholder="Month Day, Year"
          value="${theater.date}"
        />
      </div>
      <div>
        <label for="author">Author:</label>
        <input
          id="author"
          name="author"
          type="text"
          placeholder="Author"
          value="${theater.author}"
        />
      </div>
      <div>
        <label for="description">Theater Description:</label>
        <textarea id="description" name="description" placeholder="Description">
${theater.description}</textarea
        >
      </div>
      <div>
        <label for="imageUrl">Image url:</label>
        <input
          id="imageUrl"
          name="imageUrl"
          type="text"
          placeholder="Image Url"
          value="${theater.imageUrl}"
        />
      </div>
      <button class="btn" type="submit">Submit</button>
    </form>
  </section>
`;

export async function editPage(ctx) {
  let id = ctx.params.id;

  let theater = await eventsService.getById(id);

  ctx.render(editTemplate(theater, onSubmit));

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
      description,
    };
    
    await eventsService.edit(data, id);
    ctx.page.redirect(`/details/${id}`);
  }
}
