function solve(tickets,criteria){
    let ticketsList = [];

    class Ticket{
        constructor(destination,price,status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    for (let i of tickets) {
        let ticketArgs = i.split('|');
        let ticket = new Ticket(ticketArgs[0],Number(ticketArgs[1]),ticketArgs[2]);
        ticketsList.push(ticket);
    }
    return ticketsList.sort((a,b)=>a[criteria]>b[criteria]);
}

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
));
console.log()
console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'status'
));
