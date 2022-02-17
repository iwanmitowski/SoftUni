const numberOperations = require('./03. Number Operations_Resources');
const {assert, expect} = require('chai');

describe("Tests …", function() {
    describe("powNumber …", function() {
        it("should return correct …", function() {
            expect(numberOperations.powNumber(2)).equals(4);
            expect(numberOperations.powNumber(0)).equals(0);
            expect(numberOperations.powNumber(3)).equals(9);
            expect(numberOperations.powNumber(1)).equals(1);
        });
     });

     describe("powNumber …", function() {
        it("should throw correct …", function() {
            expect(() => numberOperations.numberChecker('as')).throw('The input is not a number!');
            expect(() => numberOperations.numberChecker({})).throw('The input is not a number!');
            expect(() => numberOperations.numberChecker(NaN)).throw('The input is not a number!');
            expect(() => numberOperations.numberChecker(undefined)).throw('The input is not a number!');
        });

        it('should retur lower 100', ()=>{
            expect(numberOperations.numberChecker(10)).equals('The number is lower than 100!');
            expect(numberOperations.numberChecker(99)).equals('The number is lower than 100!');
            expect(numberOperations.numberChecker(0)).equals('The number is lower than 100!');
            expect(numberOperations.numberChecker(-10)).equals('The number is lower than 100!');
        });

        it('should retur bigger or eq 100', ()=>{
            expect(numberOperations.numberChecker(100)).equals('The number is greater or equal to 100!');
            expect(numberOperations.numberChecker(999)).equals('The number is greater or equal to 100!');
            expect(numberOperations.numberChecker(10000)).equals('The number is greater or equal to 100!');
            expect(numberOperations.numberChecker(12310)).equals('The number is greater or equal to 100!');
        });
     });


     describe("sumArrays …", function() {
        it("should return correct …", function() {
            expect(numberOperations.sumArrays([1, 2], [1,2])).to.deep.equals([2,4]);
            expect(numberOperations.sumArrays([0, 0], [0,0])).to.deep.equals([0, 0]);
            expect(numberOperations.sumArrays([1], [1])).to.deep.equals([2]);
            expect(numberOperations.sumArrays([-1], [1])).to.deep.equals([0]);
            expect(numberOperations.sumArrays([-1], [-1])).to.deep.equals([-2]);
            expect(numberOperations.sumArrays([-1], [-1])).to.deep.equals([-2]);
            expect(numberOperations.sumArrays([-1, 2], [-1])).to.deep.equals([-2, 2]);
            expect(numberOperations.sumArrays([-1], [-1, 2])).to.deep.equals([-2, 2]);
        });
     });
     // TODO: …
});
