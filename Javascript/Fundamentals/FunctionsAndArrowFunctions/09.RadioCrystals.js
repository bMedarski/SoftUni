function Solve(input){

    let neededThickness = input[0];
    for(let i = 1; i< input.length;i++){
        ProcessChunk(neededThickness,input[i]);
    }
    function ProcessChunk(desiredThikness, thikness){

        console.log("Processing chunk "+thikness+" microns");
        let currentMicrons  = thikness;
        currentMicrons = Cut(desiredThikness,currentMicrons);
       // console.log(currentMicrons)
        currentMicrons = Lap(desiredThikness,currentMicrons);
       // console.log(currentMicrons)
        currentMicrons = Grind(desiredThikness,currentMicrons);
        //console.log(currentMicrons)
        currentMicrons = Etch(desiredThikness,currentMicrons);
        //console.log(currentMicrons)
        currentMicrons = XRay(desiredThikness,currentMicrons);
        console.log("Finished crystal "+currentMicrons+" microns")
    }
    function Cut(desiredThikness, thikness){
        let leftMicrons = thikness;
        let counter = 0;
        while(desiredThikness<=leftMicrons*0.25){
            leftMicrons*=0.25;
            counter++;
        }
        if(counter>0){
            console.log("Cut x"+counter);
            leftMicrons = TransAndWash(leftMicrons);
        }
        return leftMicrons;
    }
    function Lap(desiredThikness, thikness){
        let leftMicrons = thikness;
        let counter = 0;
        while(desiredThikness<=leftMicrons*0.80){
            leftMicrons*=0.80;
            counter++;
        }
        if(counter>0){
            console.log("Lap x"+counter);
            leftMicrons = TransAndWash(leftMicrons);
        }
        return leftMicrons;
    }
    function Grind(desiredThikness, thikness){
        let leftMicrons = thikness;
        let counter = 0;
        while(desiredThikness<=leftMicrons-20){
            leftMicrons-=20;
            counter++;
        }
        if(counter>0){
            console.log("Grind x"+counter);
            leftMicrons = TransAndWash(leftMicrons);
        }
        return leftMicrons;
    }
    function Etch(desiredThikness, thikness){
        let leftMicrons = thikness;
        let counter = 0;
        while(desiredThikness<=leftMicrons-2){
            leftMicrons-=2;
            counter++;
        }
        if(leftMicrons-1 == desiredThikness){
            leftMicrons-=2;
            counter++;
        }
        if(counter>0){
            console.log("Etch x"+counter);
            leftMicrons = TransAndWash(leftMicrons);
        }
        return leftMicrons;
    }
    function XRay(desiredThikness, thikness){
        let leftMicrons = thikness;
        if(desiredThikness==thikness+1){
            leftMicrons++;
            console.log("X-ray x1");
        }
        return leftMicrons;
    }
    function TransAndWash(microns){
        console.log("Transporting and washing");
        return Math.floor(microns);
    }
}

//Solve([1375, 50000]);
Solve([1000, 8100]);