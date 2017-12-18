function Solve(args){

    let speedA = args[0];
    let speedB = args[1];
    let time = args[2]/3600;

    let distance = Math.abs(speedA*time-speedB*time)*1000;
    console.log(distance);
}

Solve([0, 60, 3600]);
Solve([11, 10, 120]);
Solve([5, -5, 40]);