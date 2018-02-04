function Solve(arguments){
    for (let i = 0; i < arguments.length; i++) {
        const regex = /\*[A-Z]{1}[a-zA-Z]*(?= |\t|$)|\+[0-9-]{10,10}(?= |\t|$)|![a-zA-Z0-9]+(?= |\t|$)|_[a-zA-Z0-9]+(?= |\t|$)/g;
        let str = arguments[i];
        let m;
        while ((m = regex.exec(str)) !== null) {
            if (m.index === regex.lastIndex) {
                regex.lastIndex++;
            }
            m.forEach((match) => {
                let replacement = "|".repeat(match.length);
                str = str.replace(match,replacement);
            });
        }
        console.log(str)
    }
}
hide(["Agent*Ivankov was in the *Ivankov room when it all happened.",
    "The person in the room was heavily armed.",
    "Agent *Ivankov had to act quick in order.",
    "He picked up his phone and called some unknown number.",
    "I think it was +555-49-796 *Ivankov5.",
    "I can't really remember...",
    "He said something about 'finishing work' with subject !2491a23BVB34Q and returning to Base __Aurora21",
    "Then after that he disappeared from my sight.",
    "As if he vanished in the shadows.",
    "A moment, shorter than a second, later, I saw the person flying off the top floor.",
    "I really don't know what happened there.",
    "This is all I saw, that night.",
    "I cannot explain it myself..."]);



function secretData(input) {
    let nameRegex = /\*[A-Z]{1}[a-zA-Z]*(?= |\t|$)/g;
    let phoneRegex = /\+[0-9\-]{10}(?=\t| |$)/g;
    let idRegex = /![a-zA-Z0-9]+(?=\t| |$)/g;
    let baseRegex = /_[a-zA-Z0-9]+(?=\t| |$)/g;

    for(let sentence of input) {
        sentence = sentence.replace(nameRegex, m => "|".repeat(m.length));
        sentence = sentence.replace(phoneRegex, m => "|".repeat(m.length));
        sentence = sentence.replace(idRegex, m => "|".repeat(m.length));
        sentence = sentence.replace(baseRegex, m => "|".repeat(m.length));

        console.log(sentence);
    }
}



