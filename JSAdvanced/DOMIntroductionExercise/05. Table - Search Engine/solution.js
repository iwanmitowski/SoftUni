function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchField = document.getElementById('searchField');
      let searchText = searchField.value.toLowerCase();

      console.log(searchText);
      let trElements = document.querySelectorAll('tbody tr');
      

      for (const tr of trElements) {
         tr.classList.remove('select');
         if (tr.innerHTML.toLowerCase().includes(searchText)) {
            tr.classList.add('select');
         }
      }

      searchField.value = '';
   }
}
