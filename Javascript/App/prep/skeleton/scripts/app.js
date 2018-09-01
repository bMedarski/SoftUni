$(() => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs');

        this.get('#/home', homeController.showIndexPage);
        this.get('index.html', homeController.showIndexPage);

        this.get('#/register',userController.registerGet);
        this.post('#/register', userController.registerPost);
        this.get('#/login',userController.loginGet);
        this.post('#/login', userController.loginPost);
        this.get('#/logout', userController.logout);

        this.get('#/cars/list', carController.listAll);
        this.get('#/cars/create',carController.createGet);
        this.post('#/cars/create',carController.createPost);
        this.get('#/cars/remove/:id',carController.remove);
        this.get('#/cars/edit/:id',carController.editGet);
        this.post('#/cars/edit',carController.editPost);
        this.get('#/cars/listMy',carController.listMy);
        this.get('#/cars/details/:id',carController.details);
    });

    app.run();
});