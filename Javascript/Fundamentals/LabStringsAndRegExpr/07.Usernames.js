function Solve(arguments){

    let result = [];
    for (let i = 0; i < arguments.length; i++) {
        let a = arguments[i].indexOf('@');
        let name = arguments[i].substring(0,a);
        let abr = arguments[i].substr(a+1,1);

        let currentDot = arguments[i].indexOf('.',a);


        while(currentDot>0){
            abr += arguments[i].substr(currentDot+1,1);
            currentDot = arguments[i].indexOf('.',currentDot+1);
        }

        let res = name +"."+ abr;
        result.push(res)
    }
    console.log(result.join(", "));
}

Solve(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);