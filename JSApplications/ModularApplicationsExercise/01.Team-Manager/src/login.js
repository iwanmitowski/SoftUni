import { html } from "../../node_modules/lit-html/lit-html.js";
import { login } from "./api/users.js";

const loginTemplate = (onSubmit) => html`
            <section id="login">
                <article class="narrow">
                    <header class="pad-med">
                        <h1>Login</h1>
                    </header>
                    <form id="login-form" class="main-form pad-large" @submit=${onSubmit}>
                        <div class="error">Error message.</div>
                        <label>E-mail: <input type="text" name="email"></label>
                        <label>Password: <input type="password" name="password"></label>
                        <input class="action cta" type="submit" value="Sign In">
                    </form>
                    <footer class="pad-small">Don't have an account? <a href="/register" class="invert">Sign up here</a>
                    </footer>
                </article>
            </section>
`;

export function loginPage(ctx){
    ctx.render(loginTemplate(onSubmit, null));

    async function onSubmit(e){
        e.preventDefault();
        let formData = new FormData(e.target);
        
        let email = formData.get('email');
        let password = formData.get('password');

        // Validation
        let error = '';

        if (!email) {
            error += 'email: required\n';
        }
        if (!password) {
            error += 'password: required\n';
        }
        
        if (error) {
            ctx.render(loginTemplate(onSubmit, error));
            return;
        }

        await login(email, password);
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}