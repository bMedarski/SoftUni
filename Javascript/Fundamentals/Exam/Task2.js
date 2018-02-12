function Solve(arguments,factors){

    let matrix = arguments;
    let pollutionAreas = [];
    for (let i = 0; i < matrix.length; i++) {
        matrix[i] = matrix[i].trim().split(" ").filter(l=>l!='');
        for (let j = 0; j < matrix[0].length; j++) {
            matrix[i][j]= Number(matrix[i][j]);
        }
    }

    //Print();
    for (let i = 0; i < factors.length; i++) {
        let affectArgs = factors[i].split(" ").filter(l=>l!='');
        let affect = affectArgs[0];
        let affectAmmount = Number(affectArgs[1]);

        if(affect=="gale"){
            Gale(affectAmmount);

        }
        else if(affect=="breeze"){
            Breeze(affectAmmount);

        }
        else if(affect=="smog"){
            Smog(affectAmmount);

        }
    }
    function Print(){
        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(" "));
            for (let j = 0; j < matrix[0].length; j++) {

            }

        }
    }
    for (let i = 0; i < arguments.length; i++) {
        for (let j = 0; j < arguments[0].length; j++) {
            if(arguments[i][j]>=50){
                pollutionAreas.push(`[${i}-${j}]`);
            }
        }
    }
    if(pollutionAreas.length==0){
        console.log("No polluted areas");
    }else{
        console.log(`Polluted areas: ${pollutionAreas.join(", ")}`);
    }


    function Breeze(index){
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix[0].length; j++) {
               if(i==index){
                   matrix[i][j]-= 15;
                   if(matrix[i][j]<0){
                       matrix[i][j] = 0;
                   }
               }
            }
        }
    }
    function Gale(index){
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix[0].length; j++) {
                if(j==index){
                    matrix[i][j]-=20;
                    if(matrix[i][j]<0){
                        matrix[i][j] = 0;
                    }
                }
            }
        }
    }
    function Smog(index){
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix[0].length; j++) {
                matrix[i][j]+=index;
            }
        }
    }
}

Solve([
        "5 7 72 14 4",
        "41 35 37 27 33",
        "23 16 27 42 12",
        "2 20 28 39 14",
        "16 34 31 10 24",
    ],
    ["breeze 1", "gale 2", "smog 25"]);

//Solve([
//        "5 7 2 14 4",
//        "21 14 2 5 3",
//        "3 16 7 42 12",
//        "2 20 8 39 14",
//        "7 34 1 10 24",
//    ], ["breeze 1", "gale 2", "smog 35"]);