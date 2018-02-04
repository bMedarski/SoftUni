function Solve(arguments){
    let sum = 0;
    let purchases = [];

    for (let i = 0; i < arguments.length; i=i+2) {
        purchases.push(arguments[i]);
        sum += Number(arguments[i+1]);
    }

    console.log(`You purchased ${purchases.join(", ")} for a total sum of ${sum}`)
}

Solve(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);