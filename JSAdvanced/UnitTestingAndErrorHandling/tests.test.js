const {expect} = require('chai');

const sum = require('./04.SumOfNumbers');
const isSymmetric = require('./05.CheckForSymmetry');
const rgbToHexColor = require('./06.RGBToHex');
const calculator = require('./07.AddSubtract');

describe('Sum of numbers tests', () => {
    it('Should return correct sum', () => {
        let expected = 3

        let actualResult = sum([1, 2]);
        
       expect(expected).to.equal(actualResult);
    })

    it('Should return correct sum with negative', () => {
        let expected = -3

        let actualResult = sum([-1, -2]);
        
        expect(expected).to.equal(actualResult);
    })

    it('Should return 0', () => {
        let expected = 0

        let actualResult = sum([0]);
        
        expect(expected).to.equal(actualResult);
    })
});

describe('Is symetric', ()=>{
    it('Should accept array', ()=>{
        let expected = false;

        let actual = isSymmetric('a');

        expect(expected).to.equal(actual);
    })

    it('Should be symmetric with 3 elements', ()=>{
        let expected = true;

        let actual = isSymmetric([1,2,1]);

        expect(expected).to.equal(actual);
    })

    it('Should not be symmetric with 3 different elements', ()=>{
        let expected = false;

        let actual = isSymmetric([3,2,1]);

        expect(expected).to.equal(actual);
    })

    it('Should be symmetric with 3 strings elements', ()=>{
        let expected = true;

        let actual = isSymmetric(['a', 'b', 'a']);

        expect(expected).to.equal(actual);
    })

    it('Should not be symmetric with 3 strings elements', ()=>{
        let expected = false;

        let actual = isSymmetric(['1', 2, 1]);

        expect(expected).to.equal(actual);
    })
});

describe('RGB to HEX', () => {

    it('should not pass with invalid red numbers', ()=>{
        let expected = undefined;
        
        let actualResult = rgbToHexColor(-1,0,9);

        expect(actualResult).to.equal(expected);
    });

    it('should not pass with invalid red numbers', ()=>{
        let expected = undefined;
        
        let actualResult = rgbToHexColor(266,0,9);

        expect(actualResult).to.equal(expected);
    });

    it('should not pass with invalid green numbers', ()=>{
        let expected = undefined;
        
        let actualResult = rgbToHexColor(0,-1,9);

        expect(actualResult).to.equal(expected);
    });

    it('should not pass with invalid green numbers', ()=>{
        let expected = undefined;
        
        let actualResult = rgbToHexColor(0,266,9);

        expect(actualResult).to.equal(expected);
    });

    it('should not pass with invalid blue numbers', ()=>{
        let expected = undefined;
        
        let actualResult = rgbToHexColor(0, 0, -1);

        expect(actualResult).to.equal(expected);
    });

    it('should not pass with invalid blue numbers', ()=>{
        let expected = undefined;
        
        let actualResult = rgbToHexColor(0, 0, 266);

        expect(actualResult).to.equal(expected);
    });

    it('should return expected hex', ()=>{
        let expected = '#FF9EAA';

        let actualResult = rgbToHexColor(255, 158, 170);

        expect(actualResult).to.equal(expected);
    })

    it('should return expected hex', ()=>{
        let expected = '#00FF00';

        let actualResult = rgbToHexColor(0, 255, 0);

        expect(actualResult).to.equal(expected);
    })

    it('should return expected hex', ()=>{
        let expected = '#0000FF';

        let actualResult = rgbToHexColor(0, 0, 255);

        expect(actualResult).to.equal(expected);
    })

    it('should undefined if string num', ()=>{
        let expected = undefined;

        let actualResult = rgbToHexColor('', 158, 170);

        expect(actualResult).to.equal(expected);
    })

    it('should undefined if string num', ()=>{
        let expected = undefined;

        let actualResult = rgbToHexColor(2, '', 2);

        expect(actualResult).to.equal(expected);
    })

    it('should undefined if string num', ()=>{
        let expected = undefined;

        let actualResult = rgbToHexColor(2, 2, '');

        expect(actualResult).to.equal(expected);
    })

});

describe('add subtract', ()=>{
    it('should return obj', ()=>{
        let expectedType = 'object'

        let actualResult = typeof(calculator());

        expect(actualResult).to.equal(expectedType);
    })

    it('should contain given properties', ()=>{
        let obj = calculator();
        
        expect(obj).haveOwnProperty('add');
        expect(obj).haveOwnProperty('subtract');
        expect(obj).haveOwnProperty('get');
    })

    it('should add with number or num as stirng', ()=>{
        let calculating = calculator();
        
        calculating.add('1');
        calculating.add(1);
        
        let expected = 2;
        expect(calculating.get()).equal(expected);
    })

    it('should subtract with number or num as stirng', ()=>{
        let calculating = calculator();
        
        calculating.subtract('1');
        calculating.subtract(1);
        
        let expected = -2;
        expect(calculating.get()).equal(expected);
    })

    it('should not do calc stirng', ()=>{
        let calculating = calculator();
        
        calculating.subtract('asd');
        
        expect(calculating.get()).to.be.NaN;
    })

    it('get propertly', ()=>{
        let calculating = calculator();
        
        calculating.add(1);

        let actualResult = calculating.get();
        
        expect(actualResult).equal(1);
    })
})