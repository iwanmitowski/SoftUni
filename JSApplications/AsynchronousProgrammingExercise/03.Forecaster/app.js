function attachEvents() {
    let submitBtn = document.getElementById('submit');
    let locationElement = document.getElementById('location');
    let forecastElement = document.getElementById('forecast');

    let currentElement = document.getElementById('current');
    let upcomingElement = document.getElementById('upcoming');

    const symbols = {
        ['Sunny']: '☀',
        ['Partly sunny']: '⛅',
        ['Overcast']: '☁',
        ['Rain']: '☂',
        ['Degrees']: '°',
    }

    submitBtn.addEventListener('click', ()=>{
        let location = locationElement.value;

        let locationsUrl = `http://localhost:3030/jsonstore/forecaster/locations`
   
        fetch(locationsUrl)
            .then(res =>{
                if (res.ok) {
                    return res.json()
                }

                throw new Error('Error');
            })  
            .then(data =>{
                let {code} = Object.values(data).find(x=>x.name == location);
                
                let todayUrl = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
                let upcomingUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;

                forecastElement.style.setProperty('display', 'block');

                fetch(todayUrl)
                    .then(res=>res.json())
                    .then(data =>{
                        let forecast = Object.values(data);
                        let name = forecast.pop();
                        let {condition, high, low} = forecast.pop();
                        
                        let forecastsDiv = document.createElement('div');
                        let conditionSymbolSpan = document.createElement('span');
                        let conditionSpan = document.createElement('span');

                        let nameSpan = document.createElement('span');
                        let degreesSpan = document.createElement('span');
                        let conditionTextSpan = document.createElement('span');

                        forecastsDiv.classList.add('forecasts');
                        conditionSymbolSpan.classList.add('condition', 'symbol');
                        conditionSpan.classList.add('condition');

                        nameSpan.classList.add('forecast-data');
                        degreesSpan.classList.add('forecast-data');
                        conditionTextSpan.classList.add('forecast-data');

                        conditionSymbolSpan.textContent = symbols[condition];
                        nameSpan.textContent = name;
                        degreesSpan.textContent	= `${low}${symbols.Degrees}/${high}${symbols.Degrees}`
                        conditionTextSpan.textContent = condition;

                        forecastsDiv.appendChild(conditionSymbolSpan);
                        forecastsDiv.appendChild(conditionSpan);
                        
                        conditionSpan.appendChild(nameSpan);
                        conditionSpan.appendChild(degreesSpan);
                        conditionSpan.appendChild(conditionTextSpan);
                        

                        currentElement.appendChild(forecastsDiv);
                    })
                    .catch();

                fetch(upcomingUrl)
                    .then(res=>res.json())
                    .then(data =>{
                        let forecast = Object.values(data).shift();
                        let forecastInfoElement = document.createElement('div');
                        
                        forecast.forEach(f=>{
                            let {condition, high, low} = f;
                            
                            let upcomingSpan = document.createElement('span')
                            let symbolUpcomingSpan = document.createElement('span');
                            let degreesUpcomingSpan = document.createElement('span');
                            let conditionUpcomingSpan = document.createElement('span');
                            
                            forecastInfoElement.classList.add('forecast-info')
                            upcomingSpan.classList.add('upcoming');
                            symbolUpcomingSpan.classList.add('symbol');
                            degreesUpcomingSpan.classList.add('forecast-data');
                            conditionUpcomingSpan.classList.add('forecast-data');

                            symbolUpcomingSpan.textContent = symbols[condition];
                            degreesUpcomingSpan.textContent = `${low}${symbols.Degrees}/${high}${symbols.Degrees}`;
                            conditionUpcomingSpan.textContent = condition;

                            upcomingSpan.appendChild(symbolUpcomingSpan);
                            upcomingSpan.appendChild(degreesUpcomingSpan);
                            upcomingSpan.appendChild(conditionUpcomingSpan);

                            forecastInfoElement.appendChild(upcomingSpan);
                            
                        });
                        upcomingElement.appendChild(forecastInfoElement);
                    })
                    .catch();
            })
            .catch(err =>{
                locationElement.value = 'Error';
                //Not sure where to visualize the error
            }); 
    });
}

attachEvents();