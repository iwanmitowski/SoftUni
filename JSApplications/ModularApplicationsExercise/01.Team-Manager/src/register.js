import { html } from "../../node_modules/lit-html/lit-html.js";
import { register } from "./api/users.js";
const regex = /\S+@\S+\.\S+/;
const registerTemplate = (onSubmit, error) => html`
            <section id="register">
                <article class="narrow">
                    <header class="pad-med">
                        <h1>Register</h1>
                    </header>
                    <form id="register-form" class="main-form pad-large" @submit=${onSubmit}>
                        ${error ? html`<div class="error">${error}</div>` : ''}
                        <label>E-mail: <input type="text" name="email"></label>
                        <label>Username: <input type="text" name="username"></label>
                        <label>Password: <input type="password" name="password"></label>
                        <label>Repeat: <input type="password" name="repass"></label>
                        <input class="action cta" type="submit" value="Create Account">
                    </form>
                    <footer class="pad-small">Already have an account? <a href="#" class="invert">Sign in here</a>
                    </footer>
                </article>
            </section>
`;

export function registerPage(ctx){
    ctx.render(registerTemplate(onSubmit, null));

    async function onSubmit(e){
        e.preventDefault();
        let formData = new FormData(e.target);
        
        let username = formData.get('username');
        let email = formData.get('email');
        let password = formData.get('password');
        let repass = formData.get('repass');

        // Validation
        let error = '';

        if (!email) {
            error += 'email: required\n';
        }
        if (!regex.test(email)) {
            error += 'invalid email\n';
        }
        if (!username || username.length < 3) {
            error += 'username: required, at least 3 characters\n';
        }
        if (password !== repass) {
            error += 'password and repeat password do not match\n';
        }
        if (!password || !repass) {
            error += 'password is required\n';
        }


        if (error) {
            ctx.render(registerTemplate(onSubmit, error));
            return;
        }

        await register(username, email, password);
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}