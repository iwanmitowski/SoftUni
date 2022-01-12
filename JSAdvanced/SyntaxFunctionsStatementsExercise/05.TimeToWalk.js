function solve(steps, foot, kmh){
    let distanceInM = steps * foot;
    let distanceInKm = distanceInM / 1000;
    let timeInMins = (distanceInKm / kmh) * 60;

    let distanceBasedAdditionalTime = distanceInM;

    for(let i = 500; i < distanceBasedAdditionalTime; i += 500){
        timeInMins += 1;
    }
    
    timeInMins += breakTime;

    let hours;
    let minutes;
    let seconds;

    if (timeInMins >= 60) {
        hours = Math.floor(timeInMins / 60);
        minutes = timeInMins - hours * 60;
    }
    else{
        hours = 0;
        minutes = Math.floor(timeInMins);
    }

    seconds = Math.round((timeInMins - Math.floor(timeInMins)) * 60);

    console.log(`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds}`)
}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);
