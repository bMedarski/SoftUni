(function Solve(){
    Array.prototype.last = function(){
        return this[this.length-1];
    };
    Array.prototype.skip = function(n){
        let newArr = [];
        for (let i = 0; i < this.length; i++) {
            if(i>=n){
                newArr.push(this[i]);
            }
        }
        return newArr
    };
    Array.prototype.take = function(n){
        let newArr = [];
        for (let i = 0; i < n; i++) {
                newArr.push(this[i]);
        }
        return newArr
    };
    Array.prototype.sum = function(){
        return this.reduce((a,b)=>a+b)
    };
    Array.prototype.average = function(){
        let average = this.sum()/this.length;
        return average
    };
}());