function Solve(args){
    function ReplaceSymbols(input){
        input = Replace(input,'&','&amp;');
        input = Replace(input,'<','&lt;');
        input = Replace(input,'>','&gt;');
        input = Replace(input,'"','&quot;');
        input = Replace(input,'\'','&#39;');
        return input;
    }
    function Replace(text, stringForReplace,replacementString){
        let regex = new RegExp(stringForReplace,"g");
        text = text.replace(regex,replacementString);
        return text;
    }
    let obj = JSON.parse(args);
    console.log('<table>');
    console.log('  <tr><th>name</th><th>score</th></tr>');
    for (let i = 0; i < obj.length; i++) {

        let name = ReplaceSymbols(obj[i].name);
        let score = ReplaceSymbols(obj[i].score.toString());

        console.log(`<tr><td>${name}</td><td>${score}</td></tr>`);
    }
    console.log('</table>');
}

Solve('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]');