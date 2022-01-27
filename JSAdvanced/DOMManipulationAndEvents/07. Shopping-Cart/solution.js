function solve() {
   let addButtons = document.getElementsByClassName('add-product');
   let checkoutButton = document.getElementsByClassName('checkout')[0];
   let buttonsArray = Array.from(addButtons);

   buttonsArray.forEach(b => b.addEventListener('click', purchase))
   checkoutButton.addEventListener('click', checkout);

   let products = [];

   let textAreaElement = document.querySelector('.shopping-cart textarea');

   function purchase(e){
      let name = e.currentTarget.parentElement.parentElement.children[1].children[0].textContent;
      let money = Number(e.currentTarget.parentElement.parentElement.children[3].textContent);

      products.push({
         name,
         money,
      });

      textAreaElement.value += `Added ${name} for ${money.toFixed(2)} to the cart.\n`
   }

   function checkout(){
      Array.from(document.getElementsByTagName('button')).forEach(x=>x.disabled = true);
      
      let uniqueProducts = [...new Set(products.map(p => p.name))];
      let totalPrice = products.reduce((a, b) => a + b.money, 0).toFixed(2);
      
      let finalMessage = `You bought ${uniqueProducts.join(', ')} for ${totalPrice}.`
      textAreaElement.value += finalMessage;
   }
}