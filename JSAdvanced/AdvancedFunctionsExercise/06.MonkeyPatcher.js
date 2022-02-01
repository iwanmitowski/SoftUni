function solution(param){
    switch (param) {
        case 'upvote':
            this.upvotes++;
            break;
        case 'downvote':
            this.downvotes++;
            break;
        case 'score':
            let higherNumber = Math.ceil(Math.max(this.upvotes, this.downvotes) * 0.25);

            let totalVotes = this.upvotes + this.downvotes;

            let positiveRating = this.upvotes / totalVotes * 100;

            let balance = this.upvotes - this.downvotes;

            let rate = 'new';

            if (positiveRating > 66) {
                rate = 'hot'
            }
            else{
                if (balance >= 0 && totalVotes > 100) {
                    rate = 'controversial'
                }
                else if (balance < 0) {
                    rate = 'unpopular'
                }
            }
            
            if (totalVotes < 10) {
                rate = 'new'
            }
            
            let resultUpvotes = totalVotes > 50 ? this.upvotes + higherNumber : this.upvotes;
            let resultDownvotes = totalVotes > 50 ? this.downvotes + higherNumber : this.downvotes;
            let result = [resultUpvotes,
                          resultDownvotes,
                          balance,
                          rate];

            return result;
    }
}

var forumPost = {
    id: '1',
    author: 'pesho',
    content: 'hi guys',
    upvotes: 0,
    downvotes: 0
};

solution.call(forumPost, 'upvote');

var answer = solution.call(forumPost, 'score');
console.log(answer);
