import { html } from "../../node_modules/lit-html/lit-html.js";
import * as eventsService from "./api/data.js";

const profileTemplate = (theaters, user) => html`
  <section id="profilePage">
    <div class="userInfo">
      <div class="avatar">
        <img src="./images/profilePic.png" />
      </div>
      <h2>${user.email}</h2>
    </div>
    <div class="board">
      <!--If there are event-->
      ${theaters.length
        ? theaters.map(theaterTemplate)
        : html`<div class="no-events">
            <p>This user has no events yet!</p>
          </div>`}
      <!--If there are no event-->
    </div>
  </section>
`;

const theaterTemplate = (theater) => html` <div class="eventBoard">
  <div class="event-info">
    <img src="${theater.imageUrl}" />
    <h2>${theater.title}</h2>
    <h6>${theater.date}</h6>
    <a href="/details/${theater._id}" class="details-button">Details</a>
  </div>
</div>`;

export async function profilePage(ctx) {
    let user = JSON.parse(localStorage.getItem("user"));
  let theaters = await eventsService.getMine(user._id);
  console.log(theaters);

  ctx.render(profileTemplate(theaters, user));
}
