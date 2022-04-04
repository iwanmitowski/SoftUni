import { html } from "../../node_modules/lit-html/lit-html.js";
import * as booksService from "./api/data.js";

const editTemplate = (book, onSubmit) => html`
<section id="edit-page" class="edit">
            <form @submit=${onSubmit} id="edit-form" action="#" method="">
                <fieldset>
                    <legend>Edit my Book</legend>
                    <p class="field">
                        <label for="title">Title</label>
                        <span class="input">
                            <input type="text" name="title" id="title" value="${book.title}">
                        </span>
                    </p>
                    <p class="field">
                        <label for="description">Description</label>
                        <span class="input">
                            <textarea name="description"
                                id="description">${book.description}</textarea>
                        </span>
                    </p>
                    <p class="field">
                        <label for="image">Image</label>
                        <span class="input">
                            <input type="text" name="imageUrl" id="image" value="${book.imageUrl}">
                        </span>
                    </p>
                    <p class="field">
                        <label for="type">Type</label>
                        <span class="input">
                            <select id="type" name="type" value="${book.type}">
                                <option value="Fiction" class=${book.type == 'Fiction' ? 'selected' : ''}>Fiction</option>
                                <option value="Romance" class=${book.type == 'Romance' ? 'selected' : ''}>Romance</option>
                                <option value="Mistery" class=${book.type == 'Mistery' ? 'selected' : ''}>Mistery</option>
                                <option value="Classic" class=${book.type == 'Classic' ? 'selected' : ''}>Clasic</option>
                                <option value="Other">Other</option>
                            </select>
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Save">
                </fieldset>
            </form>
        </section>
`

export async function editPage(ctx){
    let id = ctx.params.id;

    let book = await booksService.getById(id);

    ctx.render(editTemplate(book, onSubmit));

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
    
        await booksService.edit(data, id);
        ctx.page.redirect(`/details/${id}`);
      }
}