function Solve(arguments){
    console.log("<ul>");
    function Replace(text, stringForReplace,replacementString){

        let regex = new RegExp(stringForReplace,"g");
        text = text.replace(regex,replacementString);

        //while(true){
        //    let begin = 0;
        //    if(text.indexOf(stringForReplace,begin)<0){
        //        break;
        //    }
        //    text = text.replace(stringForReplace,replacementString);
        //    begin = text.indexOf(stringForReplace,begin)+1;
        //}
        return text;
    }
    function ReplaceSymbols(input){
        //console.log(input);
        input = Replace(input,'&','&amp;');
        input = Replace(input,'<','&lt;');
        input = Replace(input,'>','&gt;');
        input = Replace(input,'"','&quot;');
        return input;
    }

    for (let i = 0; i < arguments.length; i++) {

        console.log(`  <li>${ReplaceSymbols(arguments[i])}</li>`);
    }
    console.log("</ul>");
}

Solve(['<div style=\"color: red;\">Hello, Red!</div>', '<table><tr><td>Cell 1</td><td>Cell 2</td><tr>']);