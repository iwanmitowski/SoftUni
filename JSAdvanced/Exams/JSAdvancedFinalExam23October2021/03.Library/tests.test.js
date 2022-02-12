const {assert, expect} = require('chai');
const library = require('./library');

describe("Tests …", function() {
    describe('test body', ()=>{
        it('Should have 3 funtion in it', () => {
            let actual = library;
    
            expect(actual).to.haveOwnProperty('calcPriceOfBook').to.be.a('function');
            expect(actual).to.haveOwnProperty('findBook').to.be.a('function');
            expect(actual).to.haveOwnProperty('arrangeTheBooks').to.be.a('function');
        });
    })

    describe("calcPrice …", () => {
        it("error if args are not valid …", () => {
            expect(()=>library.calcPriceOfBook(1, 10)).to.throw(Error, "Invalid input");
            expect(()=>library.calcPriceOfBook([], 10)).to.throw('Invalid input');
            expect(()=>library.calcPriceOfBook({}, 10)).to.throw('Invalid input');
            expect(()=>library.calcPriceOfBook('a', '1')).to.throw('Invalid input');
            expect(()=>library.calcPriceOfBook('a', {})).to.throw('Invalid input');
            expect(()=>library.calcPriceOfBook('a', [])).to.throw('Invalid input');
            expect(()=>library.calcPriceOfBook('a', 12.12)).to.throw('Invalid input')
            ;
        });

        it("should return same price if over 1980", () => {
            expect(library.calcPriceOfBook('a', 1981)).equals(`Price of a is ${Number(20).toFixed(2)}`);
            expect(library.calcPriceOfBook('b', 2221)).equals(`Price of b is ${Number(20).toFixed(2)}`);
        });
        
        it("should return reduced price if under or 1980", () => {
            expect(library.calcPriceOfBook('a', 1980)).equals(`Price of a is ${Number(10).toFixed(2)}`);
            expect(library.calcPriceOfBook('a', 1979)).equals(`Price of a is ${Number(10).toFixed(2)}`);
            expect(library.calcPriceOfBook('c', 1000)).equals(`Price of c is ${Number(10).toFixed(2)}`);
        });
     });

     describe("findBook …", () => {
        it("error if booksArr empty", () => {
            expect(()=> library.findBook([],'desired')).to.throw('No books currently available');
            
        });

        it("book not found if booksArr is missing the book", () => {
            expect(library.findBook(['asd'],'desired')).equals('The book you are looking for is not here!');
            expect(library.findBook(['asd','abv'],'desired')).equals('The book you are looking for is not here!');
        });

        it('shoudl give positive message', ()=>{
            expect(library.findBook(['desired','asd'],'desired')).equals('We found the book you want.');
            expect(library.findBook(['desired'],'desired')).equals('We found the book you want.');

        });
     });

     describe("arrangeTheBooks …", () => {
        it('throw error if countBooks is not int', ()=>{
            expect(()=> library.arrangeTheBooks({})).to.throw('Invalid input');
            expect(()=> library.arrangeTheBooks([])).to.throw('Invalid input');
            expect(()=> library.arrangeTheBooks(12.2)).to.throw('Invalid input');
            expect(()=> library.arrangeTheBooks(-12.2)).to.throw('Invalid input');
            expect(()=> library.arrangeTheBooks(-12)).to.throw('Invalid input');
            expect(()=> library.arrangeTheBooks('')).to.throw('Invalid input');
            expect(()=> library.arrangeTheBooks(true)).to.throw('Invalid input');

        })

        it('pass if more space available', ()=>{
            expect(library.arrangeTheBooks(5)).equals('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(34)).equals('Great job, the books are arranged.');
            expect(library.arrangeTheBooks(40)).equals('Great job, the books are arranged.');
        })

        it('fail if less space available', ()=>{
            expect(library.arrangeTheBooks(41)).equals('Insufficient space, more shelves need to be purchased.');
            expect(library.arrangeTheBooks(444)).equals('Insufficient space, more shelves need to be purchased.');
            expect(library.arrangeTheBooks(666)).equals('Insufficient space, more shelves need to be purchased.');
        })
     });
});
