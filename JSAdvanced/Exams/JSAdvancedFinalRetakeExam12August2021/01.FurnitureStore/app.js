window.addEventListener('load', solve);

function solve() {
    let modelElement = document.getElementById('model');
    let yearElement = document.getElementById('year');
    let descriptionElement = document.getElementById('description');
    let priceElement = document.getElementById('price');

    let addButton = document.getElementById('add');

    let furnitureList = document.getElementById('furniture-list');
    let totalPriceElement = document.querySelector('.total-price');

    addButton.addEventListener('click', (e)=>{
        e.preventDefault();

        let model = modelElement.value;
        let year = yearElement.value;
        let description = descriptionElement.value;
        let price = Number(priceElement.value);

        if (!model ||
            !year ||
            !description ||
            !price ||
            price <= 0 ||
            year <= 0) {
            return;
        }
        
        let trElement = document.createElement('tr');
        let modelTd = document.createElement('td');
        let priceTd = document.createElement('td');
        let buttonsTd = document.createElement('td');
        let moreBtn = document.createElement('button');
        let buyBtn = document.createElement('button');

        trElement.classList.add('info');

        modelTd.textContent = model;
        priceTd.textContent = price.toFixed(2);

        moreBtn.textContent = 'More Info';
        moreBtn.classList.add('moreBtn');

        buyBtn.textContent = 'Buy it';
        buyBtn.classList.add('buyBtn');

        trElement.appendChild(modelTd);
        trElement.appendChild(priceTd);
        buttonsTd.appendChild(moreBtn);
        buttonsTd.appendChild(buyBtn);
        trElement.appendChild(buttonsTd);

        furnitureList.appendChild(trElement);

        trHideElement = document.createElement('tr');
        yearTd = document.createElement('td');
        descrTd = document.createElement('td');

        trHideElement.classList.add('hide');

        yearTd.textContent = `Year: ${year}`;
        descrTd.textContent = `Description: ${description}`;
        descrTd.setAttribute('colspan', 3);

        trHideElement.appendChild(yearTd);
        trHideElement.appendChild(descrTd);

        moreBtn.addEventListener('click', (e)=>{
            e.preventDefault();

            if (moreBtn.textContent == 'More Info') {
                trHideElement.style.display = 'contents';
                moreBtn.textContent = 'Less Info';
            }
            else{
                trHideElement.style.display = 'none';
                moreBtn.textContent = 'More Info';
            }

        });

        buyBtn.addEventListener('click', (e)=>{
            e.preventDefault();

            let currentPrice = Number(totalPriceElement.textContent);
            let totalPrice = currentPrice + price;
            totalPriceElement.textContent = totalPrice.toFixed(2);
            trElement.remove();
            trHideElement.remove();
        });

        modelElement.value = '';
        yearElement.value = '';   
        descriptionElement.value = ''; 
        priceElement.value = '';

        furnitureList.appendChild(trHideElement);
    });
}   
