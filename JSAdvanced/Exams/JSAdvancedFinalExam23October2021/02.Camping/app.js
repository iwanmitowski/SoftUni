class SummerCamp{
    constructor(organizer, location){
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            "child": 150,
            "student": 300,
            "collegian": 500
        };

        this.listOfParticipants = [];
    }
    
    registerParticipant(name, condition, money){
        if (!this.priceForTheCamp[condition]) {
            throw new Error("Unsuccessful registration at the camp.");
        }

        let participant = this.listOfParticipants.find(x=> x.name == name);

        if (participant != undefined) {
            return `The ${name} is already registered at the camp.`
        }

        if (money < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({
            name,
            condition,
            power:100,
            wins: 0});

        return `The ${name} was successfully registered.`
    }

    unregisterParticipant (name){
        let participant = this.listOfParticipants.find(x=>x.name == name);

        if (participant == undefined) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants = this.listOfParticipants.filter(x=> x.name != name);

        return `The ${name} removed successfully.`
    }

    timeToPlay (typeOfGame, participant1, participant2){
        let player1 = this.listOfParticipants.find(x=>x.name == participant1);

        if (player1 == undefined) {
            throw new Error(`Invalid entered name/s.`);
        }

        if (typeOfGame == 'WaterBalloonFights') {
            let player2 = this.listOfParticipants.find(x=>x.name == participant2);

            if (player2 == undefined) {
                throw new Error(`Invalid entered name/s.`);
            }

            if (player1.condition != player2.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            let winner = ''

            if (player1.power > player2.power) {
                player1.wins++;
                winner = player1.name;
            }
            else if(player1.power < player2.power){
                player2.wins++;
                winner = player2.name;
            }
            else{
                return `There is no winner.`
            }
            
            return `The ${winner} is winner in the game WaterBalloonFights.`;
        }
        else{
            player1.power+=20;
            
            return `The ${participant1} successfully completed the game Battleship.`;
        }
    }

    toString(){
        let result = [`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`]


        this.listOfParticipants.sort((a,b) => b.wins - a.wins).forEach(p=>{
            result.push(`${p.name} - ${p.condition} - ${p.power} - ${p.wins}`)
        });

        return result.join('\n')
    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));
