function getArticleGenerator(articles) {
    let articlesList = articles;
    let content = document.getElementById('content');
    return function (){

        if (!articlesList.length) {
            return;
        }

        let currentArticle = articlesList.shift();
        console.log(articlesList.length);
        
        let articleElement = document.createElement('article');

        articleElement.textContent = currentArticle;

        content.appendChild(articleElement);

    }
}
