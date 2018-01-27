function Solve(arguments){
    let step = arguments.pop()*1;

    for (let i = 0; i < arguments.length; i+=step) {
        console.log(arguments[i])
    }
}
Solve([5,20,31,4,20,2]);