function Solve(arguments){
    let goldMined = 0;
    let dayOfFirstBought = 0;
    let moneyMade = 0;

    for (let i = 0; i < arguments.length; i++) {
        let currentGold = Number(arguments[i]);
        if((i+1)%3 == 0){
            currentGold = currentGold*0.7;
        }
        goldMined += currentGold;
        moneyMade = goldMined*67.51;
        if(moneyMade>=11949.16&&dayOfFirstBought==0){
            dayOfFirstBought = 1+i;
        }
    }
    moneyMade = goldMined*67.51;
    let bitCoin = Math.floor(moneyMade/11949.16);
    let goldLeft = moneyMade - bitCoin*11949.16;
    console.log(`Bought bitcoins: ${bitCoin}`);
    if(dayOfFirstBought>0){
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstBought}`)
    }
    console.log(`Left money: ${goldLeft.toFixed(2)} lv.`)

}

//Solve(["100", "200","300"]);
Solve([
    "50",
    "100"
]);