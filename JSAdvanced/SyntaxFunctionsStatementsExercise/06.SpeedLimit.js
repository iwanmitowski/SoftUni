function solve(speed, zone){

    let limit = 
    zone === 'motorway' ? 130 :
    zone === 'interstate' ? 90 :
    zone === 'city' ? 50 : 20 //residential

    let status 

    if (speed > limit) {
        let diff = speed - limit;
        let status;

        if (diff <= 20) {
            status = 'speeding';    
        }
        else if (diff > 20 && diff <= 40) {
            status = 'excessive speeding'
        }
        else {
            status = 'reckless driving'
        }

        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
    else{
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }

}

solve(40, 'city')
solve(21, 'residential')
solve(120, 'interstate')
solve(200, 'motorway')

