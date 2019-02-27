const storage = require('./storage');
storage.put('a',1);
storage.put('b',1);
storage.update('a',2)
storage.save();
storage.update('a',3)
console.log(storage.getAll());
storage.loadAsync();
console.log(storage.getAll());