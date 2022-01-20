function solve(){
    
    //passing hero, creating method to it
    casting = (hero) => {
        hero.cast = (spellName) => {
            console.log(`${hero.name} cast ${spellName}`);
            hero.mana--;
        }
    }

    fighting = (hero) => {
        hero.fight = () => {
            console.log(`${hero.name} slashes at the foe!`);
            hero.stamina--;
        }
    }

    //hero accepting name, passed as parameter
    const mage = (name) => {
        const baseHero = {
            name,
            health: 100,
            mana: 100
        }
        
        return Object.assign(baseHero, casting(baseHero));
    }

    const fighter = (name) => {
        const baseHero = {
            name,
            health: 100,
            stamina: 100
        }
        
        return Object.assign(baseHero, fighting(baseHero));
    }

    return{
        mage,
        fighter
    }
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);

