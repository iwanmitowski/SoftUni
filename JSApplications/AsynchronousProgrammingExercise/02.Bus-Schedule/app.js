function solve() {
  let info = document.querySelector("#info .info");
  let departBtn = document.getElementById('depart');
  let arriveBtn = document.getElementById('arrive');
  let id = '';

  function depart() {
    if (info.textContent == 'Not Connected') {
        id = "depot";
    }

    let url = `http://localhost:3030/jsonstore/bus/schedule/${id.toLocaleLowerCase()}`;
    fetch(url)
        .then((res) => res.json())
        .then((data) => {
            let { next, name } = data;

            id = next;
            info.textContent = `Next stop: ${name}`;
            departBtn.setAttribute('disabled', true);
            arriveBtn.removeAttribute('disabled');
        })
        .catch(err =>{
            info.textContent == 'Error'
            departBtn.setAttribute('disabled', true);
            arriveBtn.setAttribute('disabled', true);
        });
  }

  function arrive() {
    let input = info.textContent.split(' ');
    input.shift();
    input.shift();
    let arriving = input.join(' ');
    info.textContent = `Arriving at ${arriving}`;

    arriveBtn.setAttribute('disabled', true);
    departBtn.removeAttribute('disabled');
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
