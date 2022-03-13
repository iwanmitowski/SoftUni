const { chromium } = require('playwright-chromium');
const { expect } = require('chai');
const { test } = require('mocha');

let browser, page; // Declare reusable variables
let clientUrl = 'http://127.0.0.1:5500/01.Messenger/'

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

let testMessages = {
    1: {
        author: 'Pesho',
        content: 'My message'
    },
    2: {
        author: 'George',
        content: 'My george message'
    }
}

let testCreateMessage = {
    3: {
        author: 'Ivan',
        content: 'Ivan message',
        _id: 3
    }
}

describe('E2E tests', function () {
    before(async () => { 
        // browser = await chromium.launch( { headless: false, slowMo: 1000}); 
        browser = await chromium.launch(); 
    });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    describe('load messages', () => {

        it('should show data in text area', async () => {
            await page.route('**/jsonstore/messenger', route => {
                route.fulfill(fakeResponse(testMessages))
            });

            await page.goto(clientUrl);

            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#refresh')
            ]);
            
            let textAreaText = await page.$eval('#messages', (textArea) => textArea.value);

            let text = Object.values(testMessages).map(v => `${v.author}: ${v.content}`).join('\n');
            expect(textAreaText).to.eql(text);
        });
    })

    describe('create message', () => {
        it('should clear inputs', async () => {
            let requestData = undefined;
            let expected = {
                author: 'Ivan',
                content: 'Ivans message'
            };
            await page.route('**/jsonstore/messenger', (route, request) => {
                if(request.method().toLowerCase() === 'post'){
                    requestData = request.postData();
                    route.fulfill(fakeResponse(testCreateMessage))
                }
            });

            await page.goto(clientUrl);

            await page.fill('#author', expected.author);          
            await page.fill('#content', expected.content);          

            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('#submit')
            ]);

            let authorValue = await page.$eval('#author', a => a.value);
            let contentValue = await page.$eval('#content', a => a.value);

            expect(authorValue).to.equal('');
            expect(contentValue).to.equal('');
        });
    })
});