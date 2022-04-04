import { html } from "../../node_modules/lit-html/lit-html.js";
import * as booksService from "./api/data.js";

const myTemplate = (books) => html` <section
  id="my-books-page"
  class="my-books"
>
  <h1>My Books</h1>
  <!-- Display ul: with list-items for every user's books (if any) -->
  ${books.length
    ? html`
        <ul class="my-books-list">">
          ${books.map(bookTemplate)}
        </ul>
      `
    : html`<p class="no-books">No books in database!</p>`}
</section>`;

const bookTemplate = (book) => html` <li class="otherBooks">
  <h3>${book.title}</h3>
  <p>Type: ${book.type}</p>
  <p class="img"><img src="${book.imageUrl}" /></p>
  <a class="button" href="/details/${book._id}">Details</a>
</li>`;

export async function myPage(ctx) {
    let user = JSON.parse(localStorage.getItem('user'));

    let books = await booksService.getMine(user._id);
    
    ctx.render(myTemplate(books));
  }