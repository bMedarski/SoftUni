function Solve(input){



    let commandProcessor = (function(){
        let text = "";

        return {
            append: (newText) => text += newText,
            removeStart: (count) => text = text.slice(count),
            removeEnd: (count) => text = text.slice(0, text.length - count),
            print:()=>console.log(text)
        }

    })();

    for (let cmd of input) {
        let [cmdName, arg] = cmd.split(' ');
        commandProcessor[cmdName](arg);
    }
}
function processCommands(commands) {
    let commandProcessor = (function () {
      let text = "";
        return {
            append: newText => text += newText,
            removeStart: count => text = text.slice(count),
            removeEnd: count => text = text.slice(0, text.length-count),
            print: () => console.log(text)
        }
    }());

    for(let cmd of commands){
        let[cmdName, arg] = cmd.split(' ');
        commandProcessor[cmdName](arg);
    }
}



Solve(['append hello',
        'append again',
        'removeStart 3',
        'removeEnd 4',
        'print']
);