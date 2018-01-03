function Solve(input){

    ProcessChunk(input[0],input[1]);


    function ProcessChunk(desiredThikness, thikness){

        let initialMicrons  = thikness;
        initialMicrons = Cut(desiredThikness,initialMicrons);
        TransAndWash(initialMicrons);
        initialMicrons = Lap(desiredThikness,initialMicrons);
        TransAndWash(initialMicrons);
        initialMicrons = Grind(desiredThikness,initialMicrons);
        TransAndWash(initialMicrons);
        initialMicrons = Etch(desiredThikness,initialMicrons);
        TransAndWash(initialMicrons);
        console.log(initialMicrons)
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
        if(counter>0){
            console.log("Etch x"+counter);
        }
        return leftMicrons;
    }
    function XRay(desiredThikness, thikness){
        let leftMicrons = 0;
    }
    function TransAndWash(microns){
        console.log("Transporting and washing");
        return Math.floor(microns);
    }
}

Solve([1375, 50000]);