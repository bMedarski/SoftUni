function Solve(r,h){

    let volume = Math.PI*r*r*h/3;
    let surface = Math.PI*r*(r+Math.sqrt(r*r+h*h));

    console.log("volume = "+volume);
    console.log("surface = "+surface);
}
Solve(3,5);