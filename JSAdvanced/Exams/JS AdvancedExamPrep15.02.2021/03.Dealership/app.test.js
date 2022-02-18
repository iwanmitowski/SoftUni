const dealership = require('./app');
const {assert, expect} = require('chai');

describe("Tests …", function() {
    describe("newCarCost …", function() {

        it("should return tsame price if car is missing …", function() {
            expect(dealership.newCarCost('a', 10)).equal(10);
            expect(dealership.newCarCost('b', 10)).equal(10);
            expect(dealership.newCarCost('c', 10)).equal(10);
        });

        it("should return reduced price if car is there …", function() {
            expect(dealership.newCarCost('Audi A4 B8', 15000)).equal(0);
            expect(dealership.newCarCost('Audi A6 4K', 20000)).equal(0);
            expect(dealership.newCarCost('Audi A8 D5', 25000)).equal(0);
            expect(dealership.newCarCost('Audi TT 8J', 14000)).equal(0);
        });
     });

     describe('carEquipment', ()=>{
        it('should return correct extras', ()=>{
            expect(dealership.carEquipment(['a','b'], [0,1])).deep.equal(['a','b'])
            expect(dealership.carEquipment(['a','b'], [1])).deep.equal(['b'])
            expect(dealership.carEquipment(['a','b'], [0])).deep.equal(['a'])
        });
     });

     describe('euroCategory', ()=>{
        it('should return correct with cat >=4', ()=>{
            expect(dealership.euroCategory(4)).equal(`We have added 5% discount to the final price: 14250.`)
            expect(dealership.euroCategory(5)).equal(`We have added 5% discount to the final price: 14250.`)
            expect(dealership.euroCategory(6)).equal(`We have added 5% discount to the final price: 14250.`)
        });

        it('should return correct with cat <4', ()=>{
            expect(dealership.euroCategory(3)).equal('Your euro category is low, so there is no discount from the final price!')
            expect(dealership.euroCategory(2)).equal('Your euro category is low, so there is no discount from the final price!')
            expect(dealership.euroCategory(1)).equal('Your euro category is low, so there is no discount from the final price!')
        });
     });
     // TODO: …
});
