function Solve(num){

    var isPrime = true;

    for (var divider = 2; divider <= Math.sqrt(num); divider++) {
        if (num % divider === 0) {
            isPrime = false;
            break;
        }
    }
    if(num==0){
        console.log("false")
    }else if(num==1){
        console.log("false")
    }
    else if(num<0){
        console.log("false")
    }
    else if (isPrime) {
       console.log("true")
    }else{
        console.log("false")
    }
}

Solve(5);
Solve(7);
Solve(8);
Solve(81);