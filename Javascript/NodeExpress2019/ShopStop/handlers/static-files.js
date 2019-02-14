const url = require('url');
const fs = require('fs');
const path = require('path');

function getContentType(url){

}


module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname;

    if (req.pathname.startsWith('/content') && req.method === 'GET') {

        let filepath = path.normalize(path.join(__dirname, `..${req.pathname}`));

        fs.readFile(filepath, (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });
                res.write('Resource not Found');
                res.end();
                return;

            };

            res.writeHead(200, {
                'Content-Type': getContentType(req.pathname)
            })
            res.write(data);
            res.end();
            return;
        });
    } else {
        return true;
    }
}