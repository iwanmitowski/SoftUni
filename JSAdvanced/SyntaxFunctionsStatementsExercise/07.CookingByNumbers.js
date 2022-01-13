function solve(n1, ...params){

    n1 = Number(n1);

    params.forEach(word => {
        switch (word) {
          case "chop":
            n1 /= 2;
            break;
          case "dice":
            n1 = Math.sqrt(n1);
            break;
          case "spice":
            n1++;
            break;
          case "bake":
            n1 *= 3;
            break;
          case "fillet":
            n1 *= 0.8;
            break;
        }

        console.log(n1);
    });
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');

solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');