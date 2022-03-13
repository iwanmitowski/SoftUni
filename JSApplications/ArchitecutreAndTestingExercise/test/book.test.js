const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

let browser, page;

function fakeResponse(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    }
}

let mockData = {
    xxx: {
        author: 'Test author',
        title: 'Test title'
    },
    yyy: {
        author: 'FAKE',
        title: 'Fake title'
    }
}

describe('Test for Book library app', function () {
    this.timeout(5000); 
    before(async () => {
        //browser = await chromium.launch({ headless: false, slowMo: 1000 });
        browser = await chromium.launch();
    });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('should call server when load books button clicked', async () => {
        await page.route('**/jsonstore/collections/books', route => {
            route.fulfill(fakeResponse(mockData))
        });

        await page.goto('http://127.0.0.1:5500/02.Book-Library/');

        const [response] = await Promise.all([
            page.waitForResponse('**/jsonstore/collections/books'),
            page.click('#loadBooks')
        ]);
        let result = await response.json();
        assert.deepEqual(result,mockData);
    });
    it('check if content is loaded in table after click load books button', async ()=>{
        await page.route('**/jsonstore/collections/books', route => {
            route.fulfill(fakeResponse(mockData))
        });

        await page.goto('http://127.0.0.1:5500/02.Book-Library/');

        const [response] = await Promise.all([
            page.waitForResponse('**/jsonstore/collections/books'),
            page.click('#loadBooks')
        ]);
        let result = await page.textContent('tbody tr td');
        let editButton = await page.isVisible('.editBtn');
        let deleteButton = await page.isVisible('.deleteBtn');
        assert.equal(result,'Test title');
        assert.equal(editButton,true);
        assert.equal(deleteButton,true);
    });
    it('check if submit new book works correctly', async ()=>{
        await page.route('**/jsonstore/collections/books', route => {
            route.fulfill(fakeResponse(mockData));
        });
        await page.goto('http://127.0.0.1:5500/02.Book-Library/');
        await page.fill('#createForm input[name="title"]', 'Test author');
        await page.fill('#createForm input[name="author"]', 'Test title');
        const [response] = await Promise.all([
            page.waitForResponse('**/jsonstore/collections/books'),
            page.click('#createForm button')
        ]);
        let result = await response.json();
        assert.deepEqual(result, mockData);
        
    });
    it('check if new books is loaded in table after submit', async ()=>{
        await page.route('**/jsonstore/collections/books', route => {
            route.fulfill(fakeResponse(mockData));
        });
        await page.goto('http://127.0.0.1:5500/02.Book-Library/');
        await page.fill('#createForm input[name="title"]', 'Test author');
        await page.fill('#createForm input[name="author"]', 'Test title');
        const [response] = await Promise.all([
            page.waitForResponse('**/jsonstore/collections/books'),
            page.click('#createForm button'),
            page.click('#loadBooks')
        ]);
        let result = await page.textContent('tbody tr td');
        let editButton = await page.isVisible('.editBtn');
        let deleteButton = await page.isVisible('.deleteBtn');
        assert.equal(result,'Test title');
        assert.equal(editButton,true);
        assert.equal(deleteButton,true);
        
    });

    it("check if delete books works correctly", async () => {
        let bookList = {
          original: { id: "xxx", book: { author: 'Test author', title: 'Test title' } },
          deleted: { author: 'Test author', title: 'Test title' },
        };
    
        let respList = {
          fillTable: {
            status: 200,
            headers: {
              "Access-Control-Allow-Origin": "*",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(mockData),
          },
          del: {
            status: 200,
            headers: {
              "Access-Control-Allow-Origin": "*",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(bookList.deleted),
          },
          original: {
            status: 200,
            headers: {
              "Access-Control-Allow-Origin": "*",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(mockData.xxx),
          },
        };

        await page.goto('http://127.0.0.1:5500/02.Book-Library/');
    
        await page.route("**/jsonstore/collections/books*", (route) => {
          let replies = {
            get: respList.fillTable,
            delete: respList.del,
          };
    
          let method = route.request().method();
          route.fulfill(replies[method.toLowerCase()]);
        });
    
        await Promise.all([
          page.waitForResponse("**/jsonstore/collections/books*"),
          page.click("#loadBooks"),
        ]);
    
        page.on("dialog", (dialog) => {
          dialog.accept();
        });
    
        await page.route("**/jsonstore/collections/books/3", (route) => {
          assert.equal(route.request().method(), "DELETE");
          route.fulfill(respList.del);
        });
    
        await page.click('tr[data-id="xxx"] button.deleteBtn');
      });


      let mockData = {
        xxx: {
            author: 'Test author',
            title: 'Test title'
        },
        yyy: {
            author: 'FAKE',
            title: 'Fake title'
        }
    }


      it("check if edits books works correctly", async () => {
        let bookList = {
          original: { id: "xxx", book: { author: 'Test author', title: 'Test title' } },
          edited: { author: 'Test author-xxx', title: 'Test title-xxx' },
        };
    
        let respList = {
          fillTable: {
            status: 200,
            headers: {
              "Access-Control-Allow-Origin": "*",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(mockData),
          },
          edit: {
            status: 200,
            headers: {
              "Access-Control-Allow-Origin": "*",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(bookList.edited),
          },
          original: {
            status: 200,
            headers: {
              "Access-Control-Allow-Origin": "*",
              "Content-Type": "application/json",
            },
            body: JSON.stringify(mockData.xxx),
          },
        };
        await page.goto('http://127.0.0.1:5500/02.Book-Library/');
    
        await page.route("**/jsonstore/collections/books", (x) => x.fulfill(respList.fillTable));
    
        await Promise.all([
          page.waitForResponse("**/jsonstore/collections/books"),
          page.click("#loadBooks"),
        ]);
    
        await page.route("**/jsonstore/collections/books/**", (route) => {
          let replies = {
            get: respList.original,
            put: respList.edit,
            delete: respList.del,
          };
    
          let method = route.request().method();
          route.fulfill(replies[method.toLowerCase()]);
        });
    
        let [create, edit] = await Promise.all([
          page.isVisible("form#createForm"),
          page.isVisible("form#editForm"),
        ]);
    
        assert.equal(create, true);
        assert.equal(edit, false);
    
        await page.click('tr[data-id="xxx"] button.editBtn');
    
        [create, edit] = await Promise.all([
          page.isVisible("form#createForm"),
          page.isVisible("form#editForm"),
        ]);
    
        assert.equal(create, false);
        assert.equal(edit, true);
    
        let [tit, auth] = await Promise.all([
          page.$eval('#editForm > input[name="title"]', (el) => el.value),
          page.$eval('#editForm > input[name="author"]', (el) => el.value),
        ]);
    
        assert.equal(tit, bookList.original.book.title);
        assert.equal(auth, bookList.original.book.author);
    
        await page.fill('#editForm > input[name="title"]', bookList.edited.title);
        await page.fill('#editForm > input[name="author"]', bookList.edited.author);
    
        await page.click("#editForm > button");
    
        [tit, auth] = await Promise.all([
          page.$eval('#editForm > input[name="title"]', (el) => el.value),
          page.$eval('#editForm > input[name="author"]', (el) => el.value),
        ]);
    
        assert.equal(tit, "");
        assert.equal(auth, "");
      });
});