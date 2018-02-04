function Solve(arguments){
    for (let i = 0; i < arguments.length; i++) {

        const regex = /www\.[a-zA-Z0-9-]+[a-zA-Z0-9]{1,}(\.[a-z]{1,}[a-z\.]+)/gm;
        //const regex = /www\.[a-zA-Z0-9-]+(\.[a-z]+)+/g;
        let str = arguments[i];
        let m;

        while ((m = regex.exec(str)) !== null) {
            if (m.index === regex.lastIndex) {
                regex.lastIndex++;
            }
            let end = m[1];
            let valid = true;
            for (let j = 1; j < end.length-1; j++) {
                if(end[j]=='.'){
                    if(end[j-1]=='-'||end[j+1]=='-'){
                        valid = false;
                        break;
                    }
                    if(end[j-1]=='.'||end[j+1]=='.'){
                        valid = false;
                        break;
                    }
                }
                if(end[j]=='-'){
                    if(end[j-1]=='-'||end[j+1]=='-'){
                        valid = false;
                        break;
                    }
                }
            }
            if(end[end.length-1]=='-'||end[end.length-1]=='.'){
                valid = false;
            }

            if(valid){
                console.log(m[0])
            }else{
                console.log("invalid")
            }

        }
    }
}

Solve([
    "www.justASite.bg.bg.bg.bg.bg.bg"
]);


