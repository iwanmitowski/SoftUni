const cinema = require('./cinema');
const {assert, expect} = require('chai');

describe("Tests …", function() {
    describe("showMovies …", ()=>{
        it("should return error …", ()=> {
            expect(cinema.showMovies([])).to.equal('There are currently no movies to show.');
        });

        it("should return result …", ()=> {
            expect(cinema.showMovies(['a', 'b'])).to.equal('a, b');
            expect(cinema.showMovies(['a'])).to.equal('a');

        });
     });

     describe('ticketPrice', ()=>{
        it('should return correct price', ()=>{
            expect(cinema.ticketPrice('Premiere')).equal(12);
            expect(cinema.ticketPrice('Normal')).equal(7.50);
            expect(cinema.ticketPrice('Discount')).equal(5.50);
        })

        it('should throw error', ()=>{
            expect(() => cinema.ticketPrice('1')).to.throw('Invalid projection type.');
            expect(() => cinema.ticketPrice('2')).to.throw('Invalid projection type.');
            expect(() => cinema.ticketPrice('3')).to.throw('Invalid projection type.');
            expect(() => cinema.ticketPrice(1)).to.throw('Invalid projection type.');
            expect(() => cinema.ticketPrice({})).to.throw('Invalid projection type.');
            expect(() => cinema.ticketPrice([])).to.throw('Invalid projection type.');
        })
     });

     describe('swapSeats', ()=>{
        it('unsuccessful',()=>{
            expect(cinema.swapSeatsInHall({},1)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall([],1)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall('',1)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(0,1)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(-1,1)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(21,1)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(2.1,1)).equal('Unsuccessful change of seats in the hall.')

            expect(cinema.swapSeatsInHall(21,21)).equal('Unsuccessful change of seats in the hall.')

            expect(cinema.swapSeatsInHall(1,{})).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(1,[])).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(1,'')).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(1,0)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(1,-1)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(1,21)).equal('Unsuccessful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(1,2.1)).equal('Unsuccessful change of seats in the hall.')
        });
        it('successful', ()=>{
            expect(cinema.swapSeatsInHall(3,2)).equal('Successful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(2,3)).equal('Successful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(20,3)).equal('Successful change of seats in the hall.')
            expect(cinema.swapSeatsInHall(3,20)).equal('Successful change of seats in the hall.')
        });
     });
     // TODO: …
});
