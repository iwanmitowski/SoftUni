const {assert, expect} = require('chai');

const isOddOrEven = require('./02.EvenOrOdd');
const lookupChar = require('./03.CharLookup');
const mathEnforcer = require('./04.MathEnforcer');

describe('isOddOrEven', ()=>{
    it('should not accept non-string', ()=>{
        expect(isOddOrEven(1)).to.be.undefined;
        expect(isOddOrEven({})).to.be.undefined;
        expect(isOddOrEven([1, 2])).to.be.undefined;
    });

    it('should return even if the string length is even', ()=>{
        expect(isOddOrEven('')).equal('even');
        expect(isOddOrEven('ab')).equal('even');
        expect(isOddOrEven('abcd')).equal('even');
    });

    it('should return odd if the string length is odd', ()=>{
        expect(isOddOrEven('a')).equal('odd');
        expect(isOddOrEven('abc')).equal('odd');
        expect(isOddOrEven('abcde')).equal('odd');
    });
    
});

describe('lookUpChar', ()=>{
    it('should return undefined if non string is passed, and valid index', ()=>{
        expect(lookupChar({}, 0)).to.be.undefined;
        expect(lookupChar([], 0)).to.be.undefined;
        expect(lookupChar(1, 0)).to.be.undefined;
        expect(lookupChar(undefined, 0)).to.be.undefined;
    });

    it('should return undefined if string is passed, and non int index', ()=>{
        expect(lookupChar('a', 0.1)).to.be.undefined;
        expect(lookupChar('a', Number.isFinite)).to.be.undefined;
        expect(lookupChar('a', Number.NaN)).to.be.undefined;
        expect(lookupChar('a', '1')).to.be.undefined;
    });

    it('should return incorrect index', ()=>{
        expect(lookupChar('a', -1)).equal('Incorrect index');
        expect(lookupChar('a', 1)).equal('Incorrect index');
        expect(lookupChar('a', 3)).equal('Incorrect index');
    });

    it('should return correct char', ()=>{
        expect(lookupChar('abc', 0)).equal('a');
        expect(lookupChar('abc', 1)).equal('b');
        expect(lookupChar('abc', 2)).equal('c');
    });
});

describe('mathEnforcer', ()=>{
    describe('addFive', ()=>{
        it('should return correct value with int', ()=>{
            expect(mathEnforcer.addFive(0)).equal(5);
            expect(mathEnforcer.addFive(0.01)).equal(5.01);
            expect(mathEnforcer.addFive(-0.001)).equal(4.999);
            expect(mathEnforcer.addFive(-5)).equal(0);
        })

        it('should return undefined', ()=>{
            expect(mathEnforcer.addFive({})).to.be.undefined;
            expect(mathEnforcer.addFive([])).to.be.undefined;
            expect(mathEnforcer.addFive()).to.be.undefined;
            expect(mathEnforcer.addFive('a')).to.be.undefined;
        })
    });

    describe('subtractTen', ()=>{
        it('should return correct value with int', ()=>{
            expect(mathEnforcer.subtractTen(0)).equal(-10);
            expect(mathEnforcer.subtractTen(0.01)).equal(-9.99);
            expect(mathEnforcer.subtractTen(-0.01)).equal(-10.01);
            expect(mathEnforcer.subtractTen(-5)).equal(-15);
            expect(mathEnforcer.subtractTen(10.001)).equal(10.001-10) 
            expect(mathEnforcer.subtractTen(10)).equal(0);
        })

        it('should return undefined', ()=>{
            expect(mathEnforcer.subtractTen({})).to.be.undefined;
            expect(mathEnforcer.subtractTen([])).to.be.undefined;
            expect(mathEnforcer.subtractTen()).to.be.undefined;
        })
    });

    describe('sum', ()=>{
        it('should return correct value with int', ()=>{
            expect(mathEnforcer.sum(0, 0)).equal(0);
            expect(mathEnforcer.sum(0.001, 0.001)).equal(0.002, 0.01);
            expect(mathEnforcer.sum(-0.001, -0.001)).equal(-0.002, 0.01);
            expect(mathEnforcer.sum(-5, - 5)).equal(-10);
            expect(mathEnforcer.sum(5, - 5)).equal(0);
        })

        it('should return undefined', ()=>{
            expect(mathEnforcer.sum(0, {})).to.be.undefined;
            expect(mathEnforcer.sum([], 0)).to.be.undefined;
            expect(mathEnforcer.sum('','')).to.be.undefined;
            expect(mathEnforcer.sum('9','9')).to.be.undefined;

        })
    });
});