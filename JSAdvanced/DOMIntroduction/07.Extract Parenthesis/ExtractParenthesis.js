function extract(content) {
    let regex = /([(])([\w+\s+\d+])+([)])/g
    let bracketsRegex = /[()]/
    let text = document.getElementById(content).textContent;
    
    let matches = text.match(regex, 'g').map(x=>x.replace('(', '').replace(')', ''));

    return matches.join('; ')
}