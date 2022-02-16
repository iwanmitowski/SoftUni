function solve(){
   let authorElement = document.getElementById('creator');
   let titleElement = document.getElementById('title');
   let categoryElement = document.getElementById('category');
   let contentElement = document.getElementById('content');
   let createBtn = document.querySelector('.btn');

   let postsSectionElement = document.querySelector('.site-content main section');
   let archiveSectionElement = document.querySelector('.archive-section ol');

   createBtn.addEventListener('click', (e)=>{
      e.preventDefault();

      let author = authorElement.value;
      let title = titleElement.value;
      let category = categoryElement.value;
      let content = contentElement.value;
      
      let articleEl = document.createElement('article');

      let titleEl = document.createElement('h1');
      let categoryWrapperEl = document.createElement('p');
      let categoryEl = document.createElement('strong');
      let creatorWrapperEl = document.createElement('p');
      let creatorEl = document.createElement('strong');
      let conetntEl = document.createElement('p');

      titleEl.textContent= title;
      articleEl.appendChild(titleEl);

      categoryWrapperEl.textContent = 'Category:'
      categoryEl.textContent = category;
      categoryWrapperEl.appendChild(categoryEl)
      articleEl.appendChild(categoryWrapperEl);

      creatorWrapperEl.textContent = 'Creator:';
      creatorEl.textContent = author;
      creatorWrapperEl.appendChild(creatorEl);
      articleEl.appendChild(creatorWrapperEl);

      conetntEl.textContent = content;
      articleEl.appendChild(conetntEl);

      let buttonsWrapper = document.createElement('div');
      let deleteBtn = document.createElement('button');
      let archiveBtn = document.createElement('button');

      buttonsWrapper.classList.add('buttons');
      deleteBtn.classList.add('btn', 'delete');
      deleteBtn.textContent = 'Delete';
      archiveBtn.classList.add('btn', 'archive');
      archiveBtn.textContent = 'Archive';
      buttonsWrapper.appendChild(deleteBtn);
      buttonsWrapper.appendChild(archiveBtn);

      deleteBtn.addEventListener('click', (e)=>{
         e.currentTarget.parentNode.parentNode.remove();
      });

      archiveBtn.addEventListener('click', (e)=>{
         let liElement = document.createElement('li');
         liElement.textContent = title;

         let lis = Array.from(document.querySelectorAll('.archive-section ol li'));

         lis.push(liElement);

         lis.sort((a,b) => a.textContent.localeCompare(b.textContent));

         archiveSectionElement.innerHTML = '';

         lis.forEach(x=> archiveSectionElement.appendChild(x));

         e.currentTarget.parentNode.parentNode.remove();
      });

      articleEl.appendChild(buttonsWrapper);
      postsSectionElement.appendChild(articleEl);
   });
  }
