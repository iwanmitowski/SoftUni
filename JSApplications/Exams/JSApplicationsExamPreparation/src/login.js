import { html } from "../node_modules/lit-html/lit-html.js";
import * as usersService from "./api/users.js";

const loginTemplate = (onSubmit) => html`
        <section id="login">
            <div class="container">
                <form id="login-form" @submit=${onSubmit}>
                    <h1>Login</h1>
                    <p>Please enter your credentials.</p>
                    <hr>

                    <p>Username</p>
                    <input placeholder="Enter Username" name="username" type="text">

                    <p>Password</p>
                    <input type="password" placeholder="Enter Password" name="password">
                    <input type="submit" class="registerbtn" @click=${(e) => e.preventDefault} value="Login">
                </form>
                <div class="signin">
                    <p>Dont have an account?
                        <a href="/register">Sign up</a>.
                    </p>
                </div>
            </div>
        </section>
`;

export function loginPage(ctx){
    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(e){
        e.preventDefault();
        let formData = new FormData(e.target);
        
        let username = formData.get('username');
        let password = formData.get('password');
        
        if (!username ||
            !password) {
            return;
        }

        await usersService.login(username, password);
        ctx.updateNav();
        ctx.page.redirect('/all');
    }
}

