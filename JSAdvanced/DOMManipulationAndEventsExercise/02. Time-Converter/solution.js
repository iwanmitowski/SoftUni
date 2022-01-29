function attachEventsListeners() {
    let convertButtons = Array.from(document.querySelectorAll('input[type="button"]'));

    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours'); 
    let minutesInput = document.getElementById('minutes'); 
    let secondsInput = document.getElementById('seconds'); 

    convertButtons.forEach(btn => 
        btn.addEventListener('click', converValues)
    )

    function converValues(e){
        let days = Number(daysInput.value);
        let hours = Number(hoursInput.value);
        let minutes = Number(minutesInput.value);
        let seconds = Number(secondsInput.value);

        console.log(days);
        if (days) {
            hoursInput.value = days * 24;
            minutesInput.value = days * 1440;
            secondsInput.value = days * 86400;
        }
        else if (!!hours) {
            daysInput.value = hours / 24;
            minutesInput.value = hours * 60;
            secondsInput.value = hours * 3600;
        }
        else if (!!minutes) {
            hours = minutes / 60;
            hoursInput.value = hours;
            daysInput.value = hours / 24;
            secondsInput.value = minutes * 60;
        }
        else if (!!seconds) {
            minutes = seconds / 60;
            hours = minutes / 60;
            minutesInput.value = minutes;
            hoursInput.value = minutes / 60;
            daysInput.value = hours / 24;
        }
    }
}