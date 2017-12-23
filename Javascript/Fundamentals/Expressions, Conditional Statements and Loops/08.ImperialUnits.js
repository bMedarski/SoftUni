function Solve(inches){


    let inchs = inches%12;

    let feet  = (inches-inchs)/12;
    console.log(feet+"'-"+inchs+"\"");

}
Solve(36);
Solve(55);
Solve(11);