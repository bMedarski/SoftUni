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
    });

    app.run();
});