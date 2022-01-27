function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');

    let resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', function(e){
        console.log(e);
        let x = e.offsetX;
        let width = gradientElement.clientWidth;
        let percentage = Math.floor(x / width * 100);

        resultElement.textContent = percentage + '%';
    })
}