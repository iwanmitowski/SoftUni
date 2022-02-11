function solution(){
    class Post{
        constructor(title, content){
            this.title = title;
            this.content = content;
        }

        toString(){
            return `Post: ${this.title}\nContent: ${this.content}`
        }
    }
    
    class SocialMediaPost extends Post{
        constructor(title, content, likes, dislikes){
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);

            this.comments = [];
        }

        addComment(comment){
            this.comments.push(comment);
        }

        toString(){
            let stringToReturn = `${super.toString()}\nRating: ${this.likes - this.dislikes}`;
            let comments = this.comments.length > 0 ? `\nComments:\n` + this.comments.map(c => ` * ${c}`).join('\n') : ''

            return stringToReturn + comments;
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content);
            this.views = views;
        }

        view(){
            this.views++;
            return this;
        }

        toString(){
            return `${super.toString()}\nViews: ${this.views}`
        }
    }

    return {
        Post, BlogPost, SocialMediaPost,
    }
}

const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

