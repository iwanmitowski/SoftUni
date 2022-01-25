function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   let restaurants = {};

   function onClick () {
      let textareaValue = document.querySelector('#inputs textarea').value;

      let input = JSON.parse(textareaValue);
      console.log(input);

      let bestRestaurant = {
         name: '',
         maxSalary: 0,
         bestAvgSalary: 0,
         employees: '',
      };

      input.forEach(info => {
         let values = info.split(' - ');

         let restaurantName = values.shift();
         
         if (!restaurantName.restaurantName) {
            restaurants[restaurantName] = [];
         }
         
         let workers = values[0].split(', ');

         workers.forEach(w =>{
            let workerInfo = w.split(' ');
            
            let worker = {
               name: workerInfo[0],
               salary: Number(workerInfo[1])
            }

            restaurants[restaurantName].push(worker);
         });

         console.log(restaurants[restaurantName]);
         restaurants[restaurantName].sort((a, b) => b.salary - a.salary);
         console.log(restaurants[restaurantName]);

         let currentAvgSalary = restaurants[restaurantName].reduce((a, w) => a + w.salary, 0) / restaurants[restaurantName].length || 0;
         let salaries = restaurants[restaurantName].map(x => x.salary);
         let maxSalary = Math.max(...salaries);

         if (currentAvgSalary > bestRestaurant.bestAvgSalary) {
            bestRestaurant.name = restaurantName
            bestRestaurant.bestAvgSalary = currentAvgSalary;
            bestRestaurant.maxSalary = maxSalary;
            bestRestaurant.employees = restaurants[restaurantName].map(x=> `Name: ${x.name} With Salary: ${x.salary}`).join(' ');
         }

         console.log(restaurants[restaurantName]);
      });

      let bestRestaurantElement = document.querySelector('#bestRestaurant p');

      bestRestaurantElement.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.bestAvgSalary.toFixed(2)} Best Salary: ${bestRestaurant.maxSalary.toFixed(2)}`

      let bestRestaurantWorkers = document.querySelector('#workers p');

      bestRestaurantWorkers.textContent = bestRestaurant.employees;

      console.log(bestRestaurant);
   }
}