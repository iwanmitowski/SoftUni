function solve() {
  let buttonElements = document.getElementsByTagName('button');

  let generateButton = buttonElements[0];
  let buyButton = buttonElements[1];

  generateButton.addEventListener('click', generateItem)
  buyButton.addEventListener('click', buyFurniture);

  let tableBody = document.getElementsByTagName('tbody')[0];
  let textareaElement = document.getElementsByTagName('textarea')[0];
  let textareaResultElement = document.getElementsByTagName('textarea')[1];

  console.log(tableBody);

  let arrayOfNames = [];
  let arrayOfPrices = [];
  let arrayOfFactors = [];


  function buyFurniture(e) {
    let arrayOfCheckedBoxes = Array.from(document.getElementsByTagName('input'));

    arrayOfCheckedBoxes.forEach(cb =>{
        if (cb.checked) {
         arrayOfNames.push(cb.parentNode.parentNode.children[1].children[0].textContent);
         arrayOfPrices.push(Number(cb.parentNode.parentNode.children[2].children[0].textContent));
         arrayOfFactors.push(Number(cb.parentNode.parentNode.children[3].children[0].textContent));
        }
    });

    let totalPrice = arrayOfPrices.reduce((a, b) => a + b, 0);
    let avgFactor = arrayOfFactors.reduce((a, b) => a + b, 0) / arrayOfFactors.length;

    textareaResultElement.value = `Bought furniture: ${arrayOfNames.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${avgFactor}`;
  }

  function generateItem(e ){
    let input = JSON.parse(textareaElement.value);

    input.forEach(furniture =>{
      let tr = document.createElement('tr');
      let tdImage = document.createElement('td');
      let tdName = document.createElement('td');
      let tdPrice = document.createElement('td');
      let tdFactor = document.createElement('td');
      let tdCheckBox = document.createElement('td');

      let img = document.createElement('img');
      img.src = furniture.img;

      tdImage.appendChild(img);
      
      pName = document.createElement('p');
      pName.textContent = furniture.name;
      tdName.appendChild(pName);

      pPrice = document.createElement('p');
      pPrice.textContent = furniture.price;
      tdPrice.appendChild(pPrice);

      pFactor = document.createElement('p');
      pFactor.textContent = furniture.decFactor
      tdFactor.appendChild(pFactor);

      let checkBox = document.createElement('input');
     checkBox.type = 'checkbox';
     tdCheckBox.appendChild(checkBox);

      tr.appendChild(tdImage);
      tr.appendChild(tdName);
      tr.appendChild(tdPrice);
      tr.appendChild(tdFactor);
      tr.appendChild(tdCheckBox);

      tableBody.appendChild(tr);
      })
  }
}