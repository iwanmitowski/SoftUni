import { html } from "../../node_modules/lit-html/lit-html.js";
import * as teamsApi from "./api/data.js";

const detailsTemplate = (team, status, remove, approve, decline, requests) => html`
            <section id="team-home">
                <article class="layout">
                    <img src="${team.logoUrl}" class="team-logo left-col">
                    <div class="tm-preview">
                        <h2>Team Rocket</h2>
                        <p>Gotta catch 'em all!</p>
                        <span class="details">${team.members} Members</span>
                        <div class="user">
                            ${ status.isOwner ? html`<a href="/edit/${team._id}" class="action">Edit team</a>` : ''}
                            ${ status.isNotIn ? html`<a href="#" @click= ${approve(status.userId)}class="action">Join team</a>` : ''}
                            ${ status.isIn ? html` <a href="#" @click=${remove(status.userId)} class="action invert">Leave team</a>` : ''}                           
                            Membership pending. <a href="#">Cancel request</a>
                        </div>
                    </div>
                    <div class="pad-large">
                        <h3>Members</h3>
                        <ul class="tm-members">
                            ${team.participants.map(p => html`<li> ${p._id}${status.userId != team._ownerId ? 
                            html`<a href="#" @click=${remove(p._id)} class="tm-control action">Remove from team</a>` : ''}</li>`)}
                        </ul>
                    </div>
                    <div class="pad-large">
                        <h3>Membership Requests</h3>
                        <ul class="tm-members">
                        ${requests.map(p => html`<li> ${p._id}<a href="#" @click=${approve(p._id)} class="tm-control action">Approve</a><a href="#" @click=${decline(p._id)} class="tm-control action">Decline</a></li>`)}
                        </ul>
                    </div>
                </article>
            </section>`;

export async function detailsPage(ctx){
    let id = ctx.params.id;

    let team = await teamsApi.getDataById(id);

    await teamsApi.setMembersInTeam([team]);

    let user = JSON.parse(localStorage.getItem('user'));

    let requests = await teamsApi.getAllMemberships(team._id);
    console.log(team);
    let status = {
        userId: user._id,
        isOwner: user._id == team._ownerId, 
        isIn: team.participants.some(u => u._id == user._id),
        isNotIn: !team.participants.some(u => u._id == user._id),
    }

    ctx.render(detailsTemplate(team, status, remove, approve, decline, requests));

    async function remove(id){
        // api remove
    }

    async function approve(id){
        // api approve
    }

    async function decline(id){
        // api decline
    }
}