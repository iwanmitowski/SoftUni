import { html } from "../../node_modules/lit-html/lit-html.js";
import * as usersService from "./api/users.js";

const registerTemplate = (onSubmit) => html`
        <section id="register-page" class="register">
            <form @submit=${onSubmit} id="register-form" action="" method="">
                <fieldset>
                    <legend>Register Form</legend>
                    <p class="field">
                        <label for="email">Email</label>
                        <span class="input">
                            <input type="text" name="email" id="email" placeholder="Email">
                        </span>
                    </p>
                    <p class="field">
                        <label for="password">Password</label>
                        <span class="input">
                            <input type="password" name="password" id="password" placeholder="Password">
                        </span>
                    </p>
                    <p class="field">
                        <label for="repeat-pass">Repeat Password</label>
                        <span class="input">
                            <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Register">
                </fieldset>
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
        let repeatPassword = formData.get('confirm-pass');

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

