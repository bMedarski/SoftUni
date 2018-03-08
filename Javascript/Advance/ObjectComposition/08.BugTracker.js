function bugTracker() {
    let obj = (() => {
        let idCounter = 0;
        let container = [];
        let selector;
        let report=function(author, description, reproducible, severity) {
            container[idCounter] = {
                ID: idCounter,
                author: author,
                description: description,
                reproducible: reproducible,
                severity: severity,
                status: 'Open'
            };

            idCounter++;

            if (selector) {
                display();
            }
        };

        let setStatus=function(id, newStatus) {
            container[id].status = newStatus;

            if (selector) {
                display();
            }
        };

        let remove=function(id) {
            container = container.filter(el => el.ID != id);

            if (selector) {
                display();
            }

        };

        let sort=function(method) {
            switch (method) {
                case 'author':
                    container = container.sort((a, b) => a.author.localeCompare(b.author));
                    break;
                case 'severity':
                    container = container.sort((a, b) => a.severity - b.severity);
                    break;
                default:
                    container = container.sort((a, b) => a.ID - b.ID);
            }
            if (selector) {
                display();
            }

        };

        let output=function(sel) {
            selector = sel;
        };

        let display=function() {
            $(selector).html('');
            for (let bug of container) {
                $(selector)
                    .append($('<div>').attr('id', "report_" + bug.ID).addClass('report')
                        .append($('<div>').addClass('body').append($('<p>').text(bug.description)))
                        .append($('<div>').addClass('title').append($('<span>').addClass('author').text('Submitted by: ' + bug.author))
                            .append($('<span>').addClass('status').text(bug.status + " | " + bug.severity))));
            }
        };

        return { report, setStatus, remove, sort, output };
    })();

    return obj;
}