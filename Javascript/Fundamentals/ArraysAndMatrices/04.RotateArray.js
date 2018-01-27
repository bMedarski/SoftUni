function Solve(arguments){
    let flips = arguments.pop();
    flips %= arguments.length;
    //if(arguments.length>1){
    //    while(flips>0){
    //        let element = arguments.pop();
    //        arguments.unshift(element);
    //        flips--;
    //    }
    //}
    for (let i = 0; i < flips; i++) {
        let element = arguments.pop();
        arguments.unshift(element);
    }
    console.log(arguments.join(" "))
}