function Solve(a,b,c,d){

    let area1 = a * b;
    let area2 = c * d;

    let area3 = Math.min(a,c)*Math.min(b,d);

    console.log(area1+area2-area3)

}