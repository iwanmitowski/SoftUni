class ArtGallery{
    constructor(creator){
        this.creator= creator;
        this.possibleArticles  = {
            "picture":200,
            "photo":50,
            "item":250 
        }
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(model, name, quantity){
        model = model.toLowerCase();
        quantity = Number(quantity);

        if (!this.possibleArticles[model]) {
            throw new Error("This article model is not included in this gallery!");
        }

        let article = this.listOfArticles.find(x=>x.articleName == name && x.articleModel == model);

        if (!article) {
            this.listOfArticles.push({
                articleModel: model,
                articleName: name,
                quantity: quantity
            })
        }
        else{
            article.quantity += quantity;
        }

        return `Successfully added article ${name} with a new quantity- ${quantity}.`;
    }

    inviteGuest(name, personality){
        let isExisting = this.guests.find(x=>x.guestName == name);

        if (isExisting) {
            throw new Error(`${name} has already been invited.`)
        }

        this.guests.push({
            guestName: name,
            points: personality == 'Vip' ? 500 : personality == 'Middle' ? 250 : 50,
            purchaseArticle: 0
        })

        return `You have successfully invited ${name}!`
    }

    buyArticle(articleModel, articleName, guestName){
        let article = this.listOfArticles.find(x=>x.articleName == articleName && x.articleModel == articleModel);

        if (!article) {
            throw new Error("This article is not found.");
        }
        if (article.quantity == 0) {
            return `The ${articleName} is not available.`;
        }

        let guest = this.guests.find(x=>x.guestName == guestName);

        if (!guest) {
            return "This guest is not invited.";
        }

        if (guest.points < this.possibleArticles[articleModel]) {
            return "You need to more points to purchase the article.";
        }

        guest.points -= this.possibleArticles[articleModel];
        guest.purchaseArticle++;
        article.quantity--;

        return `${guestName} successfully purchased the article worth ${this.possibleArticles[articleModel]} points.`
    }

    showGalleryInfo (criteria){
        if (criteria == 'article') {
            let result = ['Articles information:'];

            this.listOfArticles.forEach(a => {
                result.push(`${a.articleModel} - ${a.articleName} - ${a.quantity}`)
            })

            return result.join('\n');
        }
        else if (criteria == 'guest'){
            let result = ['Guests information:'];

            this.guests.forEach(g => {
                result.push(`${g.guestName} - ${g.purchaseArticle}`)
            })

            return result.join('\n');
        }
    }
}
const artGallery = new ArtGallery('Curtis Mayfield');
console.log(artGallery.inviteGuest('John', 'Vip'));
console.log(artGallery.inviteGuest('Peter', 'Middle'));
console.log(artGallery.inviteGuest('John', 'Middle'));
