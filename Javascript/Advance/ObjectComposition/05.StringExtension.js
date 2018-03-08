(() => {
    String.prototype.ensureStart = function (str) {
        if (!this.toString().startsWith(str)) {
            return this.replace(/^/, str).toString();
        }
        return this.toString();
    };
    String.prototype.ensureEnd = function (str) {
        if (!this.toString().endsWith(str)) {
            return this.replace(/$/, str).toString();
        }
        return this.toString();
    };
    String.prototype.isEmpty = function () {
        return this.length == 0 ? true : false;
    };
    String.prototype.truncate = function (n) {
        let result = '';
        let len = this.length;
        if (n <= 3) return '.'.repeat(n);

        if (len <= n) return this.toString();

        let lastIndex = this.toString().substr(0, n - 2).lastIndexOf(" ");
        if (lastIndex != -1) {
            return this.toString().substr(0, lastIndex) + "...";
        } else {
            return this.toString().substr(0, n - 3) + "...";
        }
    };
    String.format = function (str, ...params) {
        for (let i = 0; i < params.length; i++) {
            let index = str.indexOf("{" + i + "}");
            while (index != -1) {
                str = str.replace("{" + i + "}", params[i]);
                index = str.indexOf("{" + i + "}");
            }
        }
        return str;
    };
})();