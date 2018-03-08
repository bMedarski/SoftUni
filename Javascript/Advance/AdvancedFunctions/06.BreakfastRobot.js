function result(){
    let ingerdients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    return function(str){
        if(!str) return;
        let params = str.split(' ');
        let cmd = params[0];

        let commands = {
            restock: function(){
                if(params.length<2) return;
                let product = params[1];
                let quantity = Number(params[2]);
                ingerdients[product] += quantity;
                return `Success`;
            },
            prepare: function(){
                if(params.length<2) return;
                let product = params[1];
                let quantity = Number(params[2]);
                let meals = {
                    apple: {
                        carbohydrate: 1,
                        flavour: 2
                    },
                    coke: {
                        carbohydrate: 10,
                        flavour: 20
                    },
                    burger: {
                        carbohydrate: 5,
                        fat: 7,
                        flavour: 3
                    },
                    omelet: {
                        protein: 5,
                        fat: 1,
                        flavour: 1
                    },
                    cheverme: {
                        protein: 10,
                        carbohydrate: 10,
                        fat: 10,
                        flavour: 10
                    }
                };

                let mealToPrepare = meals[product];
                if(!mealToPrepare) return;
                let keys = Object.keys(mealToPrepare);
                let isThereEnoughEng = true;

                for (let k of keys) {
                    let needed = mealToPrepare[k] * quantity;
                    let has = ingerdients[k];
                    if(needed > has){
                        isThereEnoughEng = false;
                        return `Error: not enough ${k} in stock`;
                    }
                }

                if(isThereEnoughEng){
                    for (let k of keys) {
                        let needed = mealToPrepare[k] * quantity;
                        ingerdients[k] -= needed;
                    }

                    return `Success`;
                }

            },
            report: function(){
                return `protein=${ingerdients.protein} carbohydrate=${ingerdients.carbohydrate} fat=${ingerdients.fat} flavour=${ingerdients.flavour}`;
            }
        };

        return commands[cmd]();
    }
}