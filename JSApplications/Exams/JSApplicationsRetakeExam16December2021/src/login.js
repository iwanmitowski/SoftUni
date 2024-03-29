import { html } from "../node_modules/lit-html/lit-html.js";
import * as usersService from "./api/users.js";

const loginTemplate = (onSubmit) => html`
        <section id="loginaPage">
            <form class="loginForm" @submit=${onSubmit}>
                <h2>Login</h2>
                <div>
                    <label for="email">Email:</label>
                    <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
                </div>
                <div>
                    <label for="password">Password:</label>
                    <input id="password" name="password" type="password" placeholder="********" value="">
                </div>

                <button class="btn" type="submit">Login</button>

                <p class="field">
                    <span>If you don't have profile click <a href="/register">here</a></span>
                </p>
            </form>
        </section>
`;

export function loginPage(ctx){
    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(e){
        e.preventDefault();
        let formData = new FormData(e.target);
        
        let email = formData.get('email');
        let password = formData.get('password');

        if (!email ||
            !password) {
            return;
        }
        
        await usersService.login(email, password);
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}

