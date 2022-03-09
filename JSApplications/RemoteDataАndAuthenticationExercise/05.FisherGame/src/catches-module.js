const baseUrl = `http://localhost:3030/data/catches`;

function enableCatchButtons() {

    const catchesDivButtons = document.querySelectorAll('.catch button');

    Array.from(catchesDivButtons).forEach(button => {

        if (sessionStorage.user) {

            const sessionUserObject = JSON.parse(sessionStorage.user);

            if (sessionUserObject._id === button['data-id']) {

                button.disabled = false;

            }
        }
    })
};

export const loadCatches = async () => {

    fetch(baseUrl)
    .then(res => res.json())
    .then(data =>{
        const catchesContainer = document.getElementById('catches');
    catchesContainer.innerHTML = '';

    for (const item of catchesResult) {

        const divCatchElement = document.createElement('div');
        divCatchElement.classList.add('catch');
        divCatchElement.id = item._id;
        catchesContainer.appendChild(divCatchElement);

        //label/input angler
        const labelAnglerElement = document.createElement('label');
        labelAnglerElement.textContent = 'Angler';
        divCatchElement.appendChild(labelAnglerElement);

        const inputAnglerElement = document.createElement('input');
        inputAnglerElement.type = 'text';
        inputAnglerElement.classList.add('angler');
        inputAnglerElement.value = item.angler;
        divCatchElement.appendChild(inputAnglerElement);

        const labelWeightElement = document.createElement('label');
        labelWeightElement.textContent = 'Weight';
        divCatchElement.appendChild(labelWeightElement);

        const inputWeightElement = document.createElement('input');
        inputWeightElement.type = 'number';
        inputWeightElement.classList.add('weight');
        inputWeightElement.value = item.weight;
        divCatchElement.appendChild(inputWeightElement);

        //label/input species
        const labelSpeciesElement = document.createElement('label');
        labelSpeciesElement.textContent = 'Species';
        divCatchElement.appendChild(labelSpeciesElement);

        const inputSpeciesElement = document.createElement('input');
        inputSpeciesElement.type = 'text';
        inputSpeciesElement.classList.add('species');
        inputSpeciesElement.value = item.species;
        divCatchElement.appendChild(inputSpeciesElement);

        //label/input location
        const labelLocationElement = document.createElement('label');
        labelLocationElement.textContent = 'Location';
        divCatchElement.appendChild(labelLocationElement);

        const inputLocationElement = document.createElement('input');
        inputLocationElement.type = 'text';
        inputLocationElement.classList.add('location');
        inputLocationElement.value = item.location;
        divCatchElement.appendChild(inputLocationElement);

        //label/input bait
        const labelBaitElement = document.createElement('label');
        labelBaitElement.textContent = 'Bait';
        divCatchElement.appendChild(labelBaitElement);

        const inputBaitElement = document.createElement('input');
        inputBaitElement.type = 'text';
        inputBaitElement.classList.add('bait');
        inputBaitElement.value = item.bait;
        divCatchElement.appendChild(inputBaitElement);

        const labelCaptureTimeElement = document.createElement('label');
        labelCaptureTimeElement.textContent = 'Capture Time';
        divCatchElement.appendChild(labelCaptureTimeElement);

        const inputCaptureTimeElement = document.createElement('input');
        inputCaptureTimeElement.type = 'text';
        inputCaptureTimeElement.classList.add('captureTime');
        inputCaptureTimeElement.value = item.captureTime;
        divCatchElement.appendChild(inputCaptureTimeElement);

        const updateButton = document.createElement('button');
        updateButton.textContent = `Update`;
        updateButton.classList.add('update');
        updateButton['data-id'] = item._ownerId;
        updateButton.disabled = true;
        updateButton.addEventListener('click', updateCatch);
        divCatchElement.appendChild(updateButton);

        const deleteButton = document.createElement('button');
        deleteButton.textContent = `Delete`;
        deleteButton.classList.add('delete');
        deleteButton['data-id'] = item._ownerId;
        deleteButton.disabled = true;
        deleteButton.addEventListener('click', deleteCatch);
        divCatchElement.appendChild(deleteButton);
    }})

    enableCatchButtons();
}

export const enableAddButton = () => {
    if (sessionStorage.user) {
        document.getElementsByClassName('add')[0].disabled = false;
    }
}

export const addCatch = async (ev) => {

    ev.preventDefault();

    const addForm = document.getElementById('add-form');
    const formData = new FormData(addForm);

    const sessionAuthToken = JSON.parse(sessionStorage.user).accessToken;

    const catchRequestBody = {

        angler: formData.get('angler'),
        weight: formData.get('weight'),
        species: formData.get('species'),
        location: formData.get('location'),
        bait: formData.get('bait'),
        captureTime: formData.get('captureTime')

    };

    addForm.reset();

    await fetch(baseUrl, {

        method: 'POST',
        headers: {

            "Content-Type": "application/json",
            "X-Authorization": sessionAuthToken

        },
        body: JSON.stringify(catchRequestBody)

    });

}

async function updateCatch(ev) {

    const catchDiv = ev.target.parentNode;
    const currentCatchId = catchDiv.id;

    const sessionAuthToken = JSON.parse(sessionStorage.user).accessToken;

    const [angler, weight, species, location, bait, captureTime] = [...catchDiv.getElementsByTagName('input')];

    const putRequestBody = {
        angler: angler.value,
        weight: weight.value,
        species: species.value,
        location: location.value,
        bait: bait.value,
        captureTime: captureTime.value
    };

    await fetch(`${baseUrl}/${currentCatchId}`, {

        method: 'PUT',
        headers: {

            "Content-Type": "application/json",
            "X-Authorization": sessionAuthToken

        },
        body: JSON.stringify(putRequestBody)

    })
    .finally(()=>loadCatches());
}

async function deleteCatch(ev) {

    const catchDiv = ev.target.parentNode;
    const currentCatchId = catchDiv.id;

    const sessionAuthToken = JSON.parse(sessionStorage.user).accessToken;

    await fetch(`${baseUrl}/${currentCatchId}`,{
        method: 'DELETE',
        headers: {
            "Content-Type": "application/json",
            "X-Authorization": sessionAuthToken
        }
    })
    .finally(()=>loadCatches());


}