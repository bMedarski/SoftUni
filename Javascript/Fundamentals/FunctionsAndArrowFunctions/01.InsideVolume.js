function Solve(args)
{
    function InVolume(x, y, z) {

        let x1 = 10;
        let x2 = 50;
        let y1 = 20;
        let y2 = 80;
        let z1 = 15;
        let z2 = 50;
        if (x >= x1 && x <= x2 &&
            y >= y1 && y <= y2 &&
            z >= z1 && z <= z2) {
            console.log("inside")
        } else {
            console.log("outside")
        }
    }


    for(let i=0;i<args.length;i+=3){
        InVolume(args[i],args[i+1],args[i+2])
    }
}
Solve();
Solve();
Solve();