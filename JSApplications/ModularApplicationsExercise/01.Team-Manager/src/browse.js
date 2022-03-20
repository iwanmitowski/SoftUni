import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllData, getAllMembers } from "./api/data.js"
import { teamTemplate } from "./templates/Team.js"

const browseTemplate = (teams) => html`
<section id="browse">

<article class="pad-med">
    <h1>Team Browser</h1>
</article>
${teams.map(teamTemplate)}
<article class="layout narrow">
    <div class="pad-small"><a href="/create" class="action cta user">Create Team</a></div>
</article>



<article class="layout">
    <img src="./assets/rocket.png" class="team-logo left-col">
    <div class="tm-preview">
        <h2>Team Rocket</h2>
        <p>Gotta catch 'em all!</p>
        <span class="details">3 Members</span>
        <div><a href="#" class="action">See details</a></div>
    </div>
</article>

<article class="layout">
    <img src="./assets/hydrant.png" class="team-logo left-col">
    <div class="tm-preview">
        <h2>Minions</h2>
        <p>Friendly neighbourhood jelly beans, helping evil-doers succeed.</p>
        <span class="details">150 Members</span>
        <div><a href="#" class="action">See details</a></div>
    </div>
</article>

</section>
`

export async function browsePage(ctx){
    let teams = await getAllData();
    let members = await getAllMembers();
    console.log(teams);
    console.log(members);
    teams.forEach(team => {
        team['members'] = 0;
        for(let i = 0; i < members.length; i++){
            if (team._id == members[i].teamId) {
                team['members'] += 1;
            }
        }
    });

    ctx.render(browseTemplate(teams));
}