'use strict';

function Solve(input){
    let juices = {};
    for (let i = 0; i < input.length; i++) {
        const regex = /\s=>\s/g;
        let juiceArgs = input[i].split(regex).filter(w=>w !== "");
        let juice = juiceArgs[0];
        let litres = Number(juiceArgs[1]);
        //console.log(juice)
        if(juices.hasOwnProperty(juice)){
            juices[juice] += Number(litres);
        }else{
            juices[juice] = Number(litres);
        }
    }
    //juices.map(k=>console.log(juices[k]));
    //console.log(JSON.stringify(juices));
    for (let k in juices){
       if(juices[k]>=1000){
           juices[k] = Math.floor(juices[k]/1000);
           console.log(`${k} => ${juices[k]}`);
       //    delete juices[k];
       //}else{
       //    juices[k] = juices[k]/1000
       }
    }
    //console.log(JSON.stringify(juices));
}

Solve(["Orange => 2902","Banana => 450"]);

function cappyJuice(input) {
    let quantities = {};
    let bottles = {};

    for(let line of input) {
        let tokens = line.split(" => ");
        let fruit = tokens[0];
        let quantity = Number(tokens[1]);

        if(! quantities.hasOwnProperty(fruit)) {
            quantities[fruit] = 0;
        }

        quantities[fruit] += quantity;
        if(quantities[fruit] >= 1000) {
            bottles[fruit] = parseInt(quantities[fruit]/1000);
        }
    }

    for(let key of Object.keys(bottles)) {
        console.log(`${key} => ${bottles[key]}`);
    }
}