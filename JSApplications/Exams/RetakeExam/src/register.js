import { html } from "../../node_modules/lit-html/lit-html.js";
import * as usersService from "./api/users.js";

const registerTemplate = (onSubmit) => html`
  <section id="register-page" class="auth">
    <form id="register" @submit=${onSubmit}>
      <h1 class="title">Register</h1>

      <article class="input-group">
        <label for="register-email">Email: </label>
        <input type="email" id="register-email" name="email" />
      </article>

      <article class="input-group">
        <label for="register-password">Password: </label>
        <input type="password" id="register-password" name="password" />
      </article>

      <article class="input-group">
        <label for="repeat-password">Repeat Password: </label>
        <input type="password" id="repeat-password" name="repeatPassword" />
      </article>

      <input type="submit" class="btn submit-btn" value="Register" />
    </form>
  </section>
`;

export function registerPage(ctx) {
  ctx.render(registerTemplate(onSubmit));

  async function onSubmit(e) {
    e.preventDefault();
    let formData = new FormData(e.target);

    let email = formData.get("email");
    let password = formData.get("password");
    let repeatPassword = formData.get("repeatPassword");

    if (password !== repeatPassword || !email || !password || !repeatPassword) {
      return;
    }

    // Pass all the given fields!
    await usersService.register(email, password);
    ctx.updateNav();
    ctx.page.redirect("/");
  }
}
