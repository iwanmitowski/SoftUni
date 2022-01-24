function toggle() {
    let accordionElement = document.getElementById('accordion');

    let moreButton = document.querySelector('.button');
    let buttonValue = moreButton.textContent;
    
    let style;

    if (buttonValue == 'More') {
        style = 'block';
        moreButton.textContent = 'Less'
    }
    else{
        style = 'none';
        moreButton.textContent = 'More'
    }

    let extraElement = document.getElementById('extra');

    extraElement.style.display = style;


}