function Solve(year){

    if((year%4==0&&year%100!=0)||(year%400==0))
    {
        return "yes"
    }else{
        return "no"
    }
}
console.log(Solve(1999));
console.log(Solve(2000));
console.log(Solve(1900));