let carsService = (() => {

    function getAll() {
        const endpoint = `cars?query={}&sort={"_kmd.ect": -1}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function getMy() {
        const username = sessionStorage.getItem('username');
        const endpoint = `cars?query={"seller":"${{username}}"}&sort={"_kmd.ect": -1}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function create(params) {
        const endpoint = `cars`;
        let brand = params.brand;
        let description = params.description;
        let fuel = params.fuelType;
        let imageUrl = params.imageUrl;
        let isAuthor = true;
        let model = params.model;
        let price = params.price;
        let seller = sessionStorage.getItem('username');
        let title = params.title;
        let year = params.year;
        let data = {brand,description,fuel,imageUrl,isAuthor,model,price,seller,title,year};
        data = validatorService.validateCreateCar(data);
        if (data.error === undefined) {
            return kinveyService.post(APP_DATA, endpoint, AUTH_METHOD,data)
        } else {
            return Promise.reject(data.error)
        }
    }
    function edit(params) {
        const userId = sessionStorage.getItem('userId');
        const endpoint = `cars`;
        let brand = params.brand;
        let description = params.description;
        let fuel = params.fuelType;
        let imageUrl = params.imageUrl;
        let isAuthor = true;
        let model = params.model;
        let price = params.price;
        let seller = sessionStorage.getItem('username');
        let title = params.title;
        let year = params.year;
        let data = {brand,description,fuel,imageUrl,isAuthor,model,price,seller,title,year};
        return kinveyService.put(APP_DATA, endpoint, AUTH_METHOD,data);
    }
    function remove(carId) {
        const endpoint = `cars/${carId}`;
        return kinveyService.remove(APP_DATA, endpoint, AUTH_METHOD)
    }
    function details(carId) {
        const endpoint = `cars/${carId}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD)
    }
    return {
        getAll,
        getMy,
        edit,
        remove,
        create,
        details
    }
})
();