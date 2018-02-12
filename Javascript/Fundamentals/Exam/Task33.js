function Solve(str) {
    let validServey = /<svg>(.+)<\/svg>/.exec(str);

    let count = 0;
    let sum = 0;
    let label = "";
    if (validServey == null) {
        console.log("No survey found");
        return;
    } else {

        let serveyArgs = validServey[1].split("<cat>").filter(s=>s !== "");
        //console.log(serveyArgs);
        if (serveyArgs.length != 2) {
            console.log("Invalid format");

            return;
        } else {
            if (!serveyArgs[0].trim().startsWith("<text>") || !serveyArgs[0].trim().endsWith("</text></cat>") || !serveyArgs[1].trim().endsWith("</cat>")) {
                console.log("Invalid format");
                return;
            } else {

                label = /\[(.+?)\]/.exec(serveyArgs[0]);
                label = label[1];
                if (label == null) {
                    console.log("Invalid format");
                    return;
                }
                let pattern = /<g><val>([0-9]*\.?[0-9]*)<\/val>([0-9]*\.?[0-9]*)<\/g>/g;
                let match = serveyArgs[1].match(pattern);
                if (match == null) {
                    console.log("Invalid format");
                    return;
                }
                while ((m = pattern.exec(serveyArgs[1])) !== null) {
                    if (m.index === pattern.lastIndex) {
                        pattern.lastIndex++;
                    }

                    let value = Number(m[1]);
                    if (value < 0 || value > 10) {
                        continue
                    }
                    let currentCount = Number(m[2]);
                    if (currentCount < 0) {
                        continue;
                    }
                    sum += value * currentCount;
                    count += currentCount;
                }
            }
        }
    }
    console.log(`${label}: ${Math.round(sum / count * 100) / 100}`);
}
Solve('<p>Some random text</p><svg><cat><text>How do you rate our food? [Food - General]</text></cat><cat><g><val>1</val>0</g><g><val>2</val>1</g><g><val>3</val>3</g><g><val>4</val>10</g><g><val>5</val>7</g></cat></svg><p>Some more random text</p>');
