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
    let keys = Object.keys(obj[0]);
    console.log('<table>');
    console.log('<tr><th>'+keys.join('</th><th>')+'</th></tr>');

    for (let i = 0; i < obj.length; i++) {

        let line = [];
        let values = Object.values(obj[i]);
        //console.log(values)
        for (let j = 0; j < values.length; j++) {
            //console.log(values[j]);
            let value = ReplaceSymbols(values[j].toString());
            //console.log(value);
            line.push(value);
        }
        console.log('<tr><td>'+line.join('</td><td>')+'</td></tr>');
    }
    console.log('</table>');
}

//Solve('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');
Solve('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]');