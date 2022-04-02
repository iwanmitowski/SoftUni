import { html } from "../../node_modules/lit-html/lit-html.js";
import * as teamsApi from "./api/data.js";

const createTemplate = (onSubmit, error) => html`
            <section id="create">
                <article class="narrow">
                    <header class="pad-med">
                        <h1>New Team</h1>
                    </header>
                    <form id="create-form" class="main-form pad-large" @submit=${onSubmit}>
                        ${error ? html`<div class="error">${error}</div>` : ''}
                        <label>Team name: <input type="text" name="name"></label>
                        <label>Logo URL: <input type="text" name="logoUrl"></label>
                        <label>Description: <textarea name="description"></textarea></label>
                        <input class="action cta" type="submit" value="Create Team">
                    </form>
                </article>
            </section>
            `;

export function createPage(ctx){
    ctx.render(createTemplate(onSubmit, null));
    
    async function onSubmit(e){
        e.preventDefault();

        let formData = new FormData(e.target);

        let name = formData.get('name');
        let logoUrl = formData.get('logoUrl');
        let description = formData.get('description');

        // Validation
        let error = '';

        if (!name) {
            error += 'Team name is required\n';
        }
        if (name.length < 4) {
            error += 'Team name 4 letters\n';
        }
        if (!logoUrl) {
            error += 'Logo url is required\n';
        }
        if (!description) {
            error += 'Descr is required\n';
        }
        if (description.length < 10) {
            error += 'Descr 10 letters\n';
        }
        if (error) {
            ctx.render(createTemplate(onSubmit, error));
            return;
        }

        let data = {
            name,
            logoUrl,
            description,
        };

        let team = await teamsApi.createTeam(data);

        ctx.page.redirect(`/details/${team._id}`);
    }
}