const {assert, expect} = require('chai');
const PaymentPackage = require('./12.PaymentPackage');

describe('PaymentPackage', ()=>{
    it('name should throw exception', ()=>{
        expect(() => {new PaymentPackage('', 1)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage({}, 1)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage([], 1)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage(1, 1)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage(NaN, undefined)}).to.throw('Name must be a non-empty string');
        expect(() => {new PaymentPackage(NaN, 1)}).to.throw('Name must be a non-empty string');
    });

    it('value should throw exception', ()=>{
        expect(() => {new PaymentPackage('a', -1)}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('a', '')}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('a', {})}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('a', [])}).to.throw('Value must be a non-negative number');
        expect(() => {new PaymentPackage('a', undefined)}).to.throw('Value must be a non-negative number');
    });

    it('name should return correct', ()=>{
        var obj = new PaymentPackage('a', 12);
        expect(obj.name ==='a')
    });

    it('name should return correct if changed', ()=>{
        var obj = new PaymentPackage('a', 12);
        obj.name = 'b';
        expect(obj.name).to.equal('b');
    });

    it('value should return correct', ()=>{
        var obj = new PaymentPackage('a', 12);
        expect(obj.value === 12)
    });

    it('value should return correct if changed', ()=>{
        var obj = new PaymentPackage('a', 12);
        obj.value = 13;
        expect(obj.value).to.equal(13);
    });

    it('should return correct obj', ()=>{
        var obj = new PaymentPackage('a', 12);
        expect(obj.name === 'a')
        expect(obj.value === 12)
    });

    it('value should return correct if all changed', ()=>{
        var obj = new PaymentPackage('a', 12);
        obj.name = 'b';
        obj.value = 13;
        expect(obj.name).to.equal('b');
        expect(obj.value).to.equal(13);
    });

    it('should return correct default vat', ()=>{
        var obj = new PaymentPackage('a', 12);
        expect(obj.VAT === 20)
    });

    it('should throw error if invalid vat', ()=>{
        var obj = new PaymentPackage('a', 12);
        expect(() => {obj.VAT = -1}).to.throw('VAT must be a non-negative number');
        expect(() => {obj.VAT = {}}).to.throw('VAT must be a non-negative number');
        expect(() => {obj.VAT = []}).to.throw('VAT must be a non-negative number');
        expect(() => {obj.VAT = ''}).to.throw('VAT must be a non-negative number');
        expect(() => {obj.VAT = undefined}).to.throw('VAT must be a non-negative number');
    });

    it('should return correct active', ()=>{
        var obj = new PaymentPackage('a', 12);
        expect(obj.active === true);
    });
    
    it('should throw error if invalid active', ()=>{
        var obj = new PaymentPackage('a', 12);
        expect(() => {obj.active = {}}).to.throw('Active status must be a boolean');
        expect(() => {obj.active = []}).to.throw('Active status must be a boolean');
        expect(() => {obj.active = ''}).to.throw('Active status must be a boolean');
        expect(() => {obj.active = undefined}).to.throw('Active status must be a boolean');
    });

    it('should return correct active when changed', ()=>{
        var obj = new PaymentPackage('a', 12);
        obj.active = false;
        expect(obj.active === false);
    });

    it('should return correct toString', ()=>{
        var obj = new PaymentPackage('a', 120);
        obj.active = false;

        const output = [
            `Package: a (inactive)`,
            `- Value (excl. VAT): 120`,
            `- Value (VAT 20%): 144`
          ];

        let expected = output.join('\n');

        expect(obj.toString()).to.equal(expected);
    });

    it('should return correct toString', ()=>{
        var obj = new PaymentPackage('a', 120);

        const output = [
            `Package: a`,
            `- Value (excl. VAT): 120`,
            `- Value (VAT 20%): 144`
          ];

        let expected = output.join('\n');

        expect(obj.toString()).to.equal(expected);
    });

    it('should return correct toString', ()=>{
        var obj = new PaymentPackage('a', 0);
        obj.VAT = 0;

        const output = [
            `Package: a`,
            `- Value (excl. VAT): 0`,
            `- Value (VAT 0%): 0`
          ];

        let expected = output.join('\n');

        expect(obj.toString()).to.equal(expected);
    });
    
});