class Story{
    #likes;
    
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
        this.#likes = [];
        this.comments = [];
    }

    get likes(){
        if (this.#likes.length == 0) {
             return `${this.title} has 0 likes`;
        }
        
        if (this.#likes.length == 1) {
            return `${this.#likes[0]} likes this story!`
        }

        return `${this.#likes[0]} and ${this.#likes.length - 1} others like this story!`
    }

    like(username){
        if (this.#likes.some(x=>x == username)) {
            throw new Error("You can't like the same story twice!")
        }
        
        if (username == this.creator) {
            throw new Error(`You can't like your own story!`);
        }

        this.#likes.push(username);

        return `${username} liked ${this.title}!`;
    }

    dislike(username){
        if (!(this.#likes.some(x=>x == username))) {
            throw new Error("You can't dislike this story!");
        }
        
        this.#likes = this.#likes.filter(x=>x != username);

        return `${username} disliked ${this.title}`
    }

    comment(username, content, id){
        if (id == undefined || !(this.comments.find(x=>x.id == id))) {
            this.comments.push({
                id: this.comments.length +1,
                username,
                content,
                relpies: []
            });

            return `${username} commented on ${this.title}`
        }

        let comment = this.comments.find(x=>x.id == id)
        if (comment) {
            comment.relpies.push({
                id: Number(comment.id + '.' + (comment.relpies.length + 1)),
                username,
                content
            });

            return "You replied successfully";
        }
    }

    toString(sortingType){
        let result = [];

        if (sortingType == 'asc') {
            this.comments.sort((a,b) => a.id - b.id).forEach(c => {
                    c.relpies.sort((a, b) => b.id - a.id);
                });
        }
        else if(sortingType == 'desc'){
            this.comments.sort((a,b) => b.id - a.id).forEach(c => {
                    c.relpies.sort((a, b) => b.id - a.id);
                });
        }
        else if(sortingType == 'username'){
            this.comments.sort((a,b) => a.username.localeCompare(b.username))
                .forEach(c => {
                    c.relpies.sort((a,b) => a.username.localeCompare(b.username));
                });
        }

        result.push(`Title: ${this.title}`)
        result.push(`Creator: ${this.creator}`)
        result.push(`Likes: ${this.#likes.length}`)
        result.push(`Comments:`)
        this.comments.forEach(c=>{
            result.push(`-- ${c.id}. ${c.username}: ${c.content}`);

            c.relpies.forEach(r => {
                result.push(`--- ${r.id}. ${r.username}: ${r.content}`);
            })
        })

        return result.join('\n');
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));

