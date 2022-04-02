import { html } from "../../node_modules/lit-html/lit-html.js";
import * as usersService from "./api/users.js";

const registerTemplate = (onSubmit) => html`
        <section id="registerPage">
            <form class="registerForm" @submit=${onSubmit}>
                <h2>Register</h2>
                <div class="on-dark">
                    <label for="email">Email:</label>
                    <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
                </div>

                <div class="on-dark">
                    <label for="password">Password:</label>
                    <input id="password" name="password" type="password" placeholder="********" value="">
                </div>

                <div class="on-dark">
                    <label for="repeatPassword">Repeat Password:</label>
                    <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
                </div>

                <button class="btn" type="submit">Register</button>

                <p class="field">
                    <span>If you have profile click <a href="#">here</a></span>
                </p>
            </form>
        </section>
`;

export function registerPage(ctx){
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(e){
        e.preventDefault();
        let formData = new FormData(e.target);
        
        let email = formData.get('email');
        let password = formData.get('password');
        let repeatPassword = formData.get('repeatPassword');

        if (password !== repeatPassword ||
            !email ||
            !password ||
            !repeatPassword) {
            return;
        }

        // Pass all the given fields!
        await usersService.register(email, password);
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}

