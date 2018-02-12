function Solve(input){
    const regex = /\s<->\s/g;
    let population = new Map();

    for (let i = 0; i < input.length; i++) {

        let townsArgs = input[i].trim().split(regex).filter(w=>w!=="");
        let town = townsArgs[0];
        let popu = Number(townsArgs[1]);
        if (population.has(town)) {
            let val = population.get(town) + popu;
            population.set(town, val);
        } else {
            population.set(town, popu);
        }
    }
    for (let [key, value] of population) // Print
        console.log(`${key} : ${value}`);
}
Solve([
    "Sofia <-> 1200000",
    "Montana <-> 20000",
    "New York <-> 10000000",
    "Washington <-> 2345000",
    "Sofia <-> 120",
    "Las Vegas <-> 1000000"
]);