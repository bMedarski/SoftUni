function Solve(date){
    let dateObj = new Date(date[2], date[1]-1, 1);
    var day = dateObj.getUTCDate();
    console.log(day);
}
Solve([17, 3, 2002]);
Solve([13, 12, 2004]);