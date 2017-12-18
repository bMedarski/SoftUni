function Solve(minAge,firstName,firstAge,secondName,secondAge){

    if(firstAge>=minAge){
        console.log("{ name: '"+firstName+"', age: "+firstAge+" }");
    }
    if(secondAge>=minAge){
        console.log("{ name: '"+secondName+"', age: "+secondAge+" }");
    }

}