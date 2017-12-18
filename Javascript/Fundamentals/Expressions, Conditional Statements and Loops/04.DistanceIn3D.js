function Solve(args){
    let distance = Math.sqrt((args[0]-args[3])*(args[0]-args[3])+(args[1]-args[4])*(args[1]-args[4])+(args[2]-args[5])*(args[2]-args[5]));
    console.log(distance)
}
Solve([1, 1, 0, 5, 4, 0]);
Solve([3.5, 0, 1, 0, 2, -1]);
