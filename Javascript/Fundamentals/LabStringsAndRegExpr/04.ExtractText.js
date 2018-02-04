'use strict'
function Solve(text){

    let openBracket = 1;
    let closeBracket = 0;
    let extractText = [];

    while (openBracket>0){
        openBracket = text.indexOf('(',closeBracket+1);
        closeBracket = text.indexOf(')',closeBracket+1);
        //console.log(openBracket);
        //console.log(closeBracket);
        //console.log(text.substring(openBracket+1,closeBracket));
        if(closeBracket<openBracket){
            break;
        }
        if(text.length==openBracket+1){
            break;
        }
        if(openBracket>0&&closeBracket>0&&closeBracket>openBracket){
            extractText.push(text.substring(openBracket+1,closeBracket))
        }


    }
    console.log(extractText.join(", "))
}

Solve('Rakiya (Bulgarian brandy) is self-made liquor (alcoholic drink)(');