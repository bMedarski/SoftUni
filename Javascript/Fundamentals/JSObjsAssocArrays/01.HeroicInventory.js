function Solve(input) {

    const regex = /\s\/\s/g;
    const itemRegex = /, /g;
    let heroes = [];

    for (let i = 0; i < input.length; i++) {

        let hero = {};
        let heroesArgs = input[i].trim().split(regex).filter(w=>w !== "");
        let name = heroesArgs[0];
        let level = Number(heroesArgs[1]);
        let items = [];
        if(heroesArgs.length>2){
            items = heroesArgs[2].split(itemRegex).filter(w=>w !== "");
        }

        hero["name"] = name;
        hero["level"] = level;
        hero["items"] = items;

        heroes.push(hero);
        //    if (population.has(town)) {
        //        let val = population.get(town) + popu;
        //        population.set(town, val);
        //    } else {
        //        population.set(town, popu);
        //    }
        //}
        //for (let [key, value] of heroes) // Print
        //    console.log(`${key} : ${value}`);

    }
    console.log(JSON.stringify(heroes))
}
Solve([
    "Isacc / 25 /",
    "Derek / 12 / BarrelVest, DestructionSword",
    "Hes / 1 / Desolator, Sentinel, Antara"
]);

