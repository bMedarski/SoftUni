function Solve(str){
    const regex = /\b_[a-zA-Z0-9]+\b/gm;
    let arr = [];
    let m;
    while ((m = regex.exec(str)) !== null) {

        if (m.index === regex.lastIndex) {
            regex.lastIndex++;
        }
        m.forEach((match) => {
            let replacement = match.substr(1);
            arr.push(replacement);
        });
    }
    console.log(arr.join(","));
}

Solve('The _id and _age variables are both integers.');
Solve('Calculate the _area of the _perfectRectangle object.');
Solve('__invalidVariable _evenMoreInvalidVariable_ _validVariable');