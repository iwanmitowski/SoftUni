const testNumbers = require('./testNumbers');
const {assert, expect} = require('chai');

describe("Tests …", function() {
    describe("sumNumber …", function() {
        it("fail if invalid numbers …", function() {
            expect(testNumbers.sumNumbers({},1)).to.be.undefined;
            expect(testNumbers.sumNumbers([],1)).to.be.undefined;
            expect(testNumbers.sumNumbers('',1)).to.be.undefined;

            expect(testNumbers.sumNumbers(1,{})).to.be.undefined;
            expect(testNumbers.sumNumbers(1,[])).to.be.undefined;
            expect(testNumbers.sumNumbers(1,'')).to.be.undefined;
        });

        it("return correct", function() {
            expect(testNumbers.sumNumbers(2,1)).equals('3.00');
            expect(testNumbers.sumNumbers(-1,1)).equals('0.00');
            expect(testNumbers.sumNumbers(0,1)).equals('1.00');
            expect(testNumbers.sumNumbers(0,0)).equals('0.00');
            expect(testNumbers.sumNumbers(1.333,1)).equals('2.33');
            expect(testNumbers.sumNumbers(-1, -1)).equals('-2.00');
        });
     });

     describe('numberChecker', ()=>{
        it('throws error', ()=>{
            expect(() => {testNumbers.numberChecker('asd')}).throws('The input is not a number!');
            expect(() => {testNumbers.numberChecker('aazzzxcasd')}).throws('The input is not a number!');
        });

        it('is even', ()=>{
            expect(testNumbers.numberChecker(0)).equals('The number is even!');
            expect(testNumbers.numberChecker(2)).equals('The number is even!');
            expect(testNumbers.numberChecker(4)).equals('The number is even!');
            expect(testNumbers.numberChecker(-2)).equals('The number is even!');
        });

        it('is odd', ()=>{
            expect(testNumbers.numberChecker(-1)).equals('The number is odd!');
            expect(testNumbers.numberChecker(3)).equals('The number is odd!');
            expect(testNumbers.numberChecker(5)).equals('The number is odd!');
            expect(testNumbers.numberChecker(7)).equals('The number is odd!');
        });
     });

     describe('avgSum', ()=>{
         it('correct', ()=>{
             expect(testNumbers.averageSumArray([1,3,2])).equals(2);
             expect(testNumbers.averageSumArray([1.2,3.2,4.2])).equals(2.866666666666667);
             expect(testNumbers.averageSumArray([-1,-3,-2])).equals(-2);
             expect(testNumbers.averageSumArray([0, 0])).equals(0);
             expect(testNumbers.averageSumArray([1])).equals(1);

         })
     });

});
