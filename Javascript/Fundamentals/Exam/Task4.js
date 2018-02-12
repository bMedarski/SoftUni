function Solve(arguments,fights){

    class General{
        constructor(name,army){
            this.name = name;
            this.army = army;
            this.wins = 0;
            this.losses = 0;
        }
    }

    class Kingdom{
        constructor(name){
            this.name = name;
            this.generals = [];
        }
        isGeneral(general){
            for (let i = 0; i < this.generals.length; i++) {
                if(this.generals[i].name==general){
                    return true
                }
            }
            return false
        }
        get wins() {
            return this.Wins();
        }
        get losses() {
            return this.Loses();
        }

         Wins(){
            let wins = 0;
            for (let i = 0; i < this.generals.length; i++) {
                wins+=this.generals[i].wins;
            }
            return wins;
        }
        Loses(){
            let loses = 0;
            for (let i = 0; i < this.generals.length; i++) {
                loses+=this.generals[i].losses;
            }
            return loses;
        }
    }
    let kingdoms = [];

    for (let i = 0; i < arguments.length; i++) {
        let line = arguments[i];
        let kingdom = line.kingdom;
        let general = line.general;
        let army = Number(line.army);

        if(isKingdomExist(kingdom)){
            let currentKingdom = kingdoms.filter(s=>s.name == kingdom)[0];
            if(currentKingdom.isGeneral(general)){
                let currentGeneral = currentKingdom.generals.filter(s=>s.name == general)[0];
                currentGeneral.army += army;
            }
            else{
                let currentGeneral = new General(general,army);
                currentKingdom.generals.push(currentGeneral);
            }
        }else{
            let currentKingdom = new Kingdom(kingdom);
            let currentGeneral = new General(general,army);
            currentKingdom.generals.push(currentGeneral);
            kingdoms.push(currentKingdom);
        }
    }
    for (let i = 0; i < fights.length; i++) {
        let line = fights[i];
        let firstKingdomName = line[0];
        let firstGeneralName = line[1];
        let secondKingdomName = line[2];
        let secondGeneralName = line[3];
        let firstKingdom = kingdoms.filter(k=>k.name==firstKingdomName)[0];
        let firstGeneral = firstKingdom.generals.filter(g=>g.name == firstGeneralName)[0];
        let secondKingdom = kingdoms.filter(k=>k.name==secondKingdomName)[0];
        let secondGeneral = secondKingdom.generals.filter(g=>g.name == secondGeneralName)[0];
       // console.log(firstGeneral)

        if(firstKingdom==secondKingdom){
            continue;
        }
        if(firstGeneral.army>secondGeneral.army){
            firstGeneral.army = Math.floor(firstGeneral.army*1.1);
            secondGeneral.army = Math.floor(secondGeneral.army*0.9);
            firstGeneral.wins +=1;
            secondGeneral.losses +=1;
        }else if(secondGeneral.army>firstGeneral.army){
            firstGeneral.army = Math.floor(firstGeneral.army*0.9);
            secondGeneral.army = Math.floor(secondGeneral.army*1.1);
            firstGeneral.losses+=1;
            secondGeneral.wins+=1;
        }
    }

    kingdoms.sort((a,b)=>a.name.localeCompare(b.name)).sort((a,b)=>a.losses-b.losses).sort((a,b)=>b.wins-a.wins);
    //kingdoms.sort((a,b)=>b.wins-a.wins).sort((a,b)=>a.losses-b.losses).sort((a,b)=>a.name-b.name);



    let winner = kingdoms[0];
    winner.generals.sort((a,b)=>b.army-a.army);
    //for (let i = 0; i < kingdoms.length; i++) {
    //    console.log(kingdoms[i])
    //}

    //console.log()
    console.log(`Winner: ${winner.name}`);

    for (let i = 0; i < winner.generals.length; i++) {

        let general = winner.generals[i];
        console.log(`/\\general: ${general.name}`);
        console.log(`---army: ${general.army}`);
        console.log(`---wins: ${general.wins}`);
        console.log(`---losses: ${general.losses}`);
    }
    function isKingdomExist(kd){
        for (let i = 0; i < kingdoms.length; i++) {
             if(kd == kingdoms[i].name){
                return true
            }
        }
        return false
    }
}

//Solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
//        { kingdom: "Stonegate", general: "Ulric", army: 4900 },
//        { kingdom: "Stonegate", general: "Doran", army: 70000 },
//        { kingdom: "YorkenShire", general: "Quinn", army: 0 },
//        { kingdom: "YorkenShire", general: "Quinn", army: 2000 },
//        { kingdom: "Maiden Way", general: "Berinon", army: 100000 } ],
//    [ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
//        ["Stonegate", "Ulric", "Stonegate", "Doran"],
//        ["Stonegate", "Doran", "Maiden Way", "Merek"],
//        ["Stonegate", "Ulric", "Maiden Way", "Merek"],
//        ["Maiden Way", "Berinon", "Stonegate", "Ulric"] ]);
//Solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
//        { kingdom: "Stonegate", general: "Ulric", army: 4900 },
//        { kingdom: "Stonegate", general: "Doran", army: 70000 },
//        { kingdom: "YorkenShire", general: "Quinn", army: 20000 },
//        { kingdom: "Maiden Way", general: "Berinon", army: 100000 } ],
//    [ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
//        ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
//        ["Maiden Way", "Berinon", "Stonegate", "Ulric"] ]);

Solve([ { kingdom: "Maiden Way", general: "Merek", army: 5000 },
        { kingdom: "Stonegate", general: "Ulric", army: 4900 },
        { kingdom: "Stonegate", general: "Doran", army: 70000 },
        { kingdom: "YorkenShire", general: "Quinn", army: 0 },
        { kingdom: "YorkenShire", general: "Quinn", army: 2000 },
        { kingdom: "Maiden Way", general: "Berinon", army: 100000 } ],
    [ ["YorkenShire", "Quinn", "Stonegate", "Ulric"],
        ["Stonegate", "Ulric", "Stonegate", "Doran"],
        ["Stonegate", "Doran", "Maiden Way", "Merek"],
        ["Stonegate", "Ulric", "Maiden Way", "Merek"],
        ["Maiden Way", "Berinon", "Stonegate", "Ulric"] ])