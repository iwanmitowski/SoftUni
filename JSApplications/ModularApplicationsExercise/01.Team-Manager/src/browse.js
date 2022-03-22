import { html } from "../../node_modules/lit-html/lit-html.js";
import * as teamsApi from "./api/data.js"
import { teamTemplate } from "./templates/Team.js"

const browseTemplate = (teams) => html`
<section id="browse">

<article class="pad-med">
    <h1>Team Browser</h1>
</article>
<article class="layout narrow">
    <div class="pad-small"><a href="/create" class="action cta user">Create Team</a></div>
</article>
${teams.map(teamTemplate)}

</section>
`;

export async function browsePage(ctx){
    let teams = await teamsApi.getAllData();

    await teamsApi.setMembersInTeam(teams);

    ctx.render(browseTemplate(teams));
}

