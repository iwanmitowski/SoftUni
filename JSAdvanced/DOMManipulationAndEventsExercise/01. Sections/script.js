function create(words) {
   let contentElement = document.getElementById('content');
   
   words.forEach(word => {
      let div = document.createElement('div');

      let p = document.createElement('p');
      p.style.display = 'none';
      p.textContent = word;

      div.addEventListener('click', showParagraphs);

      div.appendChild(p);
      contentElement.appendChild(div);
   });

   function showParagraphs (e){
      e.currentTarget.children[0].style.display = 'block'
   }
}