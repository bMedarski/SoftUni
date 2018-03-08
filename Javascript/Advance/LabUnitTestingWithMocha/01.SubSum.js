function subsum(arr, startIndex, endIndex) {
    if (!Array.isArray(arr)) {
        return NaN;
    }

    if (startIndex < 0) startIndex = 0;
    if (endIndex>=arr.length) endIndex=arr.length-1;

    let sum = 0;
    for (let index = startIndex; index <= endIndex; index++) {
        sum += Number(arr[index]);

    }
    return sum;
}