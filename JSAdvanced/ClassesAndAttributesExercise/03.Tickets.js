function solve(input, criteria){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];

    input.forEach(element => {
        let ticketInput = element.split('|');
        tickets.push(new Ticket(ticketInput[0], Number(ticketInput[1]), ticketInput[2]));
    });

    return criteria == 'price' ?
                 tickets.sort((a, b) => a.price - b.price) :
                 tickets.sort((a, b) => a[criteria].localeCompare(b[criteria]));
}


solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);
