function Solve(str){
    let validServey = /<svg><cat>(.*?)<\/cat>\s*<cat>(.*?)<\/cat><\/svg>/.exec(str);
    
    let count = 0;
    let sum = 0;
    let label = "";
    if(validServey==null){
        console.log("No survey found");
        return;
    }else{
        // console.log(validServey)
        //let serveyArgs = validServey[1].split("<cat>").filter(s=>s!=="");
        //console.log(serveyArgs)
        //if(validServey.length!=2){
        //    console.log("Invalid format");
        //
        //    return;
        //}else{
        //if(!serveyArgs[0].trim().startsWith("<text>")||!serveyArgs[0].trim().endsWith("</text></cat>")||!serveyArgs[1].trim().endsWith("</cat>")){
        //    console.log("Invalid format");
        //    return;
        //}else{

        label = /\[(.+?)\]/.exec(validServey[1]);
        label = label[1];
        if(label==null){
            console.log("Invalid format");
            return;
        }

        let pattern = /<g><val>([0-9]*\.?[0-9]*)<\/val>([0-9]*\.?[0-9]*)<\/g>/g;
        let match = validServey[2].match(pattern);
        if(match==null){
            console.log("Invalid format");
            return;
        }

        while ((m = pattern.exec(validServey[2])) !== null) {
            // This is necessary to avoid infinite loops with zero-width matches
            if (m.index === pattern.lastIndex) {
                pattern.lastIndex++;
            }

            //console.log(m[1])
            //console.log(m[2])
            //console.log()
            let value = Number(m[1]);
            if(value<0||value>10){
                continue
            }
            let currentCount = Number(m[2]);
            if(currentCount<0){
                continue;
            }
            sum += value*currentCount;
            count+=currentCount;
            //}
            //console.log(value)
            //console.log(currentCount)
            //console.log()

        }
        //}
        // }
    }
    console.log(`${label}: ${Math.round(sum/count * 100) / 100}`);
}