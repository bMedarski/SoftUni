function Solve(args){

    let num = args[0];
    let persentige = args[1];

    if(persentige>15){
        persentige = 15;
    }
    console.log(parseFloat(num.toFixed(persentige)));

}
Solve([10.5, 3]);