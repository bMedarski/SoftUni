function solve(args){

    let number = args[0]*1;
    let hex = number.toString(16).toUpperCase();
    let binary = number.toString(2);
    console.log(hex);
    console.log(binary);

}
solve(["10"]);