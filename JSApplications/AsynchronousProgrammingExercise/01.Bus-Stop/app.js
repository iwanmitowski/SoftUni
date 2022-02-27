function getInfo() {
    let stopNameElement = document.getElementById('stopName');
    let busesElement = document.getElementById('buses');

    let stopIdInput = document.getElementById('stopId');
    let submitButton = document.getElementById('submit');

    let id = stopIdInput.value;

    let url = `http://localhost:3030/jsonstore/bus/businfo/${id}`
    busesElement.innerHTML = '';

    fetch(url)
        .then(res => {
            if (res.ok) {
                return res.json();
            }

            throw new res.statusText;
        })
        .then(data =>{
            console.log(data);

            let name = data.name;
            let buses = data.buses;

            stopNameElement.textContent = name;
            
            Object.keys(buses).forEach(
                stop => {
                    let li = document.createElement('li');
                    li.textContent = `Bus ${stop} arrives in ${buses[stop]} minutes`

                    busesElement.appendChild(li);
                }
            )
        })
        .catch(_ =>{
            stopNameElement.textContent = 'Error';
        });

}