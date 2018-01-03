function Solve(args){

    const regex = /[a-zA-Z0-9_]+/g;
    const str = args;
    let m;

    let foundWords = [];
    while ((m = regex.exec(str)) !== null) {
        // This is necessary to avoid infinite loops with zero-width matches
        if (m.index === regex.lastIndex) {
            regex.lastIndex++;
        }

        // The result can be accessed through the `m`-variable.
        m.forEach((match, groupIndex) => {
            foundWords.push(match.toUpperCase());
            //console.log(`${match}`.toUpperCase());
        });
    }
    foundWords = foundWords.filter(w => w != '');
    return foundWords.join(", ");
}
//console.log(Solve('Hi, how are you?'));
//console.log(Solve('Functions in JS can be nested, i.e. hold other functions'));

function solve ([input]) {
    console.log(input
        .toUpperCase()
        .split(/\W+/)
        .filter(w=>w!='')
        .join(', '));
}
function wordsUppercase(str) {
    var strToUpper = str.toUpperCase();
    //console.log(strToUpper);
    function extractWords() {
        return strToUpper.split(/\W+/);
    }

    var words = extractWords();
    words = words.filter(w => w != '');
    return words.join(', ');
}
console.log(wordsUppercase('Hi, how are you?'));
console.log(wordsUppercase('Functions in JS can be nested, i.e. hold other functions'));