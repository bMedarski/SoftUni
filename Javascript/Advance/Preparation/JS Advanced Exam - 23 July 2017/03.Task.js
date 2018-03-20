class Task {
    constructor(title, deadline) {
        this.title = title;
        this.deadline = deadline;
        this.status = 'Open';
    }

    get title() {
        return this._title;
    }

    set title(value) {
        this._title = value;
    }

    get deadline() {
        return this._deadline;
    }

    set deadline(value) {

        if (value < Date.now()) {
            throw new Error('cant deadline be in the past');
        }
        this._deadline = value;
    }

    get status() {
        return this._status;
    }

    set status(value) {
        this._status = value;
    }

    get isOverdue() {
        if (this.status !== 'Complete' && this.deadline < Date.now()) {
            return true;
        } else {
            return false;
        }
    }

    get comparerLevel() {
        //if (this.isOverdue && this.status === 'Complete') {
        //    return 1;
        //} else {
            if (this.isOverdue) {
                return 5;
            }
            if (this.status === 'Complete') {
                return 2;
            } else if (this.status === 'Open') {
                return 3;
            } else {
                return 4;
            }
       // }
    }

    static comparator(a, b) {
        if (a.comparerLevel > b.comparerLevel) {
            return -1;
        } else if (a.comparerLevel < b.comparerLevel) {
            return 1;
        } else {
            if(a.deadline<b.deadline){
                return -1;
            }else if(a.deadline>b.deadline){
                return 1;
            }else{
                return 0;
            }

        }
    }

    toString() {
        if (this.status === 'Complete') {
            return `[\u2714] ${this.title}`
        }
        if (this.isOverdue) {
            return `[\u26A0] ${this.title} (overdue)`
        }
        if (this.status === 'Open') {
            return `[\u2731] ${this.title} (${this.deadline})`
        }
        if (this.status === 'In Progress') {
            return `[\u219D] ${this.title} (${this.deadline})`
        }

    }
}
