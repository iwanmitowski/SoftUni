const flowerShop = require('./flowerShop');
const {assert, expect} = require('chai');

describe("Tests …", function() {
    describe("calcPriceOfFlowers …", function() {
        it("throw error …", function() {
            expect(() => flowerShop.calcPriceOfFlowers({},1,1)).throws('Invalid input!')
            expect(() => flowerShop.calcPriceOfFlowers([],1,1)).throws('Invalid input!')
            expect(() => flowerShop.calcPriceOfFlowers(1,1,1)).throws('Invalid input!')

            expect(() => flowerShop.calcPriceOfFlowers('a',{},1)).throws('Invalid input!')
            expect(() => flowerShop.calcPriceOfFlowers('a',[],1)).throws('Invalid input!')
            expect(() => flowerShop.calcPriceOfFlowers('a','',1)).throws('Invalid input!')
            expect(() => flowerShop.calcPriceOfFlowers('a',1.1,1)).throws('Invalid input!')
        
            expect(() => flowerShop.calcPriceOfFlowers('a', 1, {})).throws('Invalid input!')
            expect(() => flowerShop.calcPriceOfFlowers('a', 1, [])).throws('Invalid input!')
            expect(() => flowerShop.calcPriceOfFlowers('a', 1, '')).throws('Invalid input!')
            expect(() => flowerShop.calcPriceOfFlowers('a', 1, 1.1)).throws('Invalid input!')
        });

        it('correct', ()=>{
            expect(flowerShop.calcPriceOfFlowers('a', 1, 1)).equal('You need $1.00 to buy a!')
            expect(flowerShop.calcPriceOfFlowers('a', 0, 1)).equal('You need $0.00 to buy a!')
            expect(flowerShop.calcPriceOfFlowers('a', 1, 0)).equal('You need $0.00 to buy a!')
            expect(flowerShop.calcPriceOfFlowers('a', 2, 3)).equal('You need $6.00 to buy a!')
        });
     });

     describe('checkFlowersAvailable', ()=>{
        it('available', ()=>{
            expect(flowerShop.checkFlowersAvailable('a', ['a','b'])).equal('The a are available!');
            expect(flowerShop.checkFlowersAvailable('b', ['a','b'])).equal('The b are available!');
            expect(flowerShop.checkFlowersAvailable('b', ['b'])).equal('The b are available!');
        });

        it('sold', ()=>{
            expect(flowerShop.checkFlowersAvailable('a', ['b'])).equal('The a are sold! You need to purchase more!')
            expect(flowerShop.checkFlowersAvailable('a', ['c'])).equal('The a are sold! You need to purchase more!')
            expect(flowerShop.checkFlowersAvailable('a', ['b','c'])).equal('The a are sold! You need to purchase more!')
        });
     });

     describe('sell',()=>{
        it('throw error', ()=>{
            expect(() => flowerShop.sellFlowers({}, 1)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(1, 1)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers('', 1)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(undefined, 1)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(NaN, 1)).throws('Invalid input!');
       
            expect(() => flowerShop.sellFlowers(['a'], {})).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], 1.1)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], '')).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], undefined)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], NaN)).throws('Invalid input!');

            expect(() => flowerShop.sellFlowers(['a'], -1)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], -2)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], -3)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], -4)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], -5)).throws('Invalid input!');

            expect(() => flowerShop.sellFlowers(['a'], 1)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], 2)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], 3)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], 4)).throws('Invalid input!');
            expect(() => flowerShop.sellFlowers(['a'], 5)).throws('Invalid input!');
        });

        it('sell', ()=>{
            expect(flowerShop.sellFlowers(['a'], 0)).equals('')
            expect(flowerShop.sellFlowers(['a', 'b'], 0)).equals('b')
            expect(flowerShop.sellFlowers(['a', 'b'], 1)).equals('a')
            expect(flowerShop.sellFlowers(['a', 'b', 'c'], 1)).equals('a / c')
            expect(flowerShop.sellFlowers(['a', 'b', 'c'], 2)).equals('a / b')
            expect(flowerShop.sellFlowers(['a', 'b', 'c'], 0)).equals('b / c')

        });
     });
     // TODO: …
});
