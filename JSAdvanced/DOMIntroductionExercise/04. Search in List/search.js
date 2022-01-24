function search() {
   let searchText = document.getElementById('searchText').value.toLowerCase();

   let townElements = document.getElementsByTagName('li');

   let matches = 0;

   for (const town of townElements) {
      console.log(town.textContent);
      if (town.textContent.toLowerCase().includes(searchText)) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline'
         matches++;
      }
      else {
         town.style.fontWeight = 'normal';
         town.style.textDecoration = 'none'
      }
   }

   let resultElement = document.getElementById('result');

   resultElement.textContent = `${matches} matches found`;
}
