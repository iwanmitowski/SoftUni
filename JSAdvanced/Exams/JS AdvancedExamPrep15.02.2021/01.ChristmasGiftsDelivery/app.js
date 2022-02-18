function solution() {
    let giftNameElement = document.querySelector('section.card:nth-child(1) > div:nth-child(2) > input:nth-child(1)');
    let addGiftButton = document.querySelector('section.card:nth-child(1) > div:nth-child(2) > button:nth-child(2)');
    let listOfGifsElement = document.querySelector('section.card:nth-child(2) > ul:nth-child(2)');
    let sentGiftsElement = document.querySelector('section.card:nth-child(3) ul');
    let discardedGiftsElement = document.querySelector('section.card:nth-child(4) > ul:nth-child(2)');
    
    addGiftButton.addEventListener('click', (e)=>{
        let gifts = Array.from(listOfGifsElement.children);
        let currentGiftName = giftNameElement.value;
        
        listOfGifsElement.innerHTML = '';

        let currentGift = document.createElement('li');
        currentGift.classList.add('gift');
        currentGift.textContent = currentGiftName;

        let sendButton = document.createElement('button');
        let discardButton = document.createElement('button');

        sendButton.textContent = 'Send';
        discardButton.textContent = 'Discard';

        sendButton.setAttribute('id', 'sendButton');
        discardButton.setAttribute('id', 'discardButton');

        currentGift.appendChild(sendButton);
        currentGift.appendChild(discardButton);
        
        sendButton.addEventListener('click', (e)=>{

            currentGift = document.createElement('li');
            currentGift.classList.add('gift');
            currentGift.textContent = currentGiftName;

            sentGiftsElement.appendChild(currentGift);

            e.currentTarget.parentNode.remove();
        });

        discardButton.addEventListener('click', (e)=>{

            currentGift = document.createElement('li');
            currentGift.classList.add('gift');
            currentGift.textContent = currentGiftName;

            discardedGiftsElement.appendChild(currentGift);

            e.currentTarget.parentNode.remove();
        });

        gifts.push(currentGift);

        gifts.sort((a,b) => a.textContent.localeCompare(b.textContent));

        gifts.forEach(gift => {
            listOfGifsElement.appendChild(gift);
        });

        giftNameElement.value = '';
    });
}