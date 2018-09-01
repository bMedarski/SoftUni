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

        this.get('#/list-all', carsController.listAllCars);
        this.get('#/list-my', carsController.listMyCars);

        this.get('#/car-create',carsController.createGet);
        this.post('#/car-create',carsController.createPost);

        this.get('#/car-edit/:id',carsController.editGet);
        this.post('#/car-edit/:id',carsController.editPost);

        this.get('#/car-delete/:id',carsController.deleteGet);
        this.get('#/car-details/:id',carsController.detailsGet);
    });

    app.run();
});