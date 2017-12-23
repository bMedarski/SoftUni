function Solve(input){

    let [x, y, xMin, xMax, yMin, yMax] = input;
    if(x>=xMin&&x<=xMax&&y<=yMax&&y>=yMin){
        return "inside";
    }else{
        return "outside";
    }
}
console.log(Solve([8,-1,2,12,-3,3]));
console.log(Solve([12.5,-1,2,12,-3,3]));