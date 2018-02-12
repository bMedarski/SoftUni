function Solve(input) {
    const regex = /\s->\s/g;
    let market = new Map();

    for (let i = 0; i < input.length; i++) {

        let marketsArgs = input[i].trim().split(regex).filter(w=>w !== "");
        let town = marketsArgs[0];
        let product = marketsArgs[1];

        const regex1 = /\s:\s/g;
        let quantityPriceArgs = marketsArgs[2].split(regex1).filter(w=>w !== "");
        let quantity = Number(quantityPriceArgs[0]);
        let price = Number(quantityPriceArgs[1]);
        let income = quantity * price;

        if (!market.has(town)) {
            market.set(town, new Map());
        }
        if (!market.get(town).has(product)) {
            market.get(town).set(product, 0);
        }
        market.get(town).set(product, market.get(town).get(product) + income);
    }


            for (let [key, value] of market){ // Print
                console.log(`Town - ${key}`);
                for (let [k, v] of market.get(key)){
                    console.log(`$$$${k} : ${v}`);
                }
        }
}
Solve([
        "Sofia -> Laptops HP -> 200 : 2000",
        "Sofia -> Raspberry -> 200000 : 1500",
        "Sofia -> Audi Q7 -> 200 : 100000",
        "Montana -> Portokals -> 200000 : 1",
        "Montana -> Qgodas -> 20000 : 0.2",
        "Montana -> Chereshas -> 1000 : 0.3",

]);