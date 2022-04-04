import { html } from "../node_modules/lit-html/lit-html.js";
import * as usersService from "./api/users.js";

const loginTemplate = (onSubmit) => html`
        <section id="login-page" class="login">
            <form id="login-form" action="" method="" @submit=${onSubmit}>
                <fieldset>
                    <legend>Login Form</legend>
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
                    <input class="button submit" type="submit" value="Login">
                </fieldset>
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

