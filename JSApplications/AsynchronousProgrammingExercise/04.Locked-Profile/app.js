function lockedProfile() {
  let mainElement = document.getElementById("main");
  mainElement.innerHTML = "";

  const url = `http://localhost:3030/jsonstore/advanced/profiles`;

  fetch(url)
    .then((res) => res.json())
    .then((data) => {
      let useers = Object.values(data);
      let counter = 0;

      useers.forEach((u) => {
        const profileHtmlTemplate = `<div class="profile">
            <img src="./iconProfile2.png" class="userIcon" />
            <label>Lock</label>
            <input type="radio" name="user${++counter}Locked" value="lock" checked>
            <label>Unlock</label>
            <input type="radio" name="user${counter}Locked" value="unlock"><br>
            <hr>
            <label>Username</label>
            <input type="text" name="user${counter}Username" value="${
          u.username
        }" disabled readonly />
            <div class="hiddenInfo" disabled readonly>
                <hr>
                <label>Email:</label>
                <input type="email" name="user${counter}Email" value="${
          u.email
        }"/>
                <label>Age:</label>
                <input type="email" name="user${counter}Age" value="${u.age}"/>
            </div>
    
            <button>Show more</button>
        </div>`;

        mainElement.innerHTML += profileHtmlTemplate + "\n";
      });
    })
    .finally(() => {
      const buttons = Array.from(document.getElementsByTagName("button"));
      buttons.forEach((b) => {
        b.addEventListener("click", (e) => {
          if (e.currentTarget.parentNode.children[2].checked) {
            return;
          }
          console.log(2);
          if (e.currentTarget.textContent === "Show more") {
            e.currentTarget.parentNode.children[9].style.display = "block";
            e.currentTarget.parentNode.children[9].classList.remove(
              "hiddenInfo"
            );
            e.currentTarget.parentNode.children[9].children[2].style.display =
              "block";
            e.currentTarget.parentNode.children[9].children[3].style.display =
              "block";
            e.currentTarget.textContent = "Hide it";
          } else {
            e.currentTarget.parentNode.children[9].style.display = "none";
            e.currentTarget.parentNode.children[9].classList.add("hiddenInfo");

            e.currentTarget.textContent = "Show more";
          }
        });
      });
    });
}
