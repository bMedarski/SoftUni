let carsService = (() => {

    function listAllCars() {
        const endpoint = `cars?query={}&sort={"_kmd.ect": -1}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function getCar(id) {
        const endpoint = `cars/${id}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function createCar(car) {
            const endpoint = `cars`;
            let data = {
                    "brand": car.brand,
                    "description":car.description,
                    "fuel":car.fuel,
                    "imageUrl":car.imageUrl,
                    "isAuthor": true,
                    "model": car.model,
                    "price": car.price,
                    "seller": sessionStorage.getItem("username"),
                    "title": car.title,
                    "year": car.year,
            };
            data = validatorService.validateCreateCar(data);
            if (data.error=== undefined){
                return kinveyService.post(APP_DATA, endpoint, AUTH_METHOD, data);
            }
            else {
                return Promise.reject(data.error)
            }
        }
    function editCar(car) {
            const endpoint = `cars/${car.id}`;
            let data = {
                    "brand": car.brand,
                    "description":car.description,
                    "fuel":car.fuel,
                    "imageUrl":car.imageUrl,
                    "isAuthor": true,
                    "model": car.model,
                    "price": car.price,
                    "seller": sessionStorage.getItem("username"),
                    "title": car.title,
                    "year": car.year,
                };
            data = validatorService.validateCreateCar(data);
                   if (data.error=== undefined){
                       return kinveyService.update(APP_DATA, endpoint, AUTH_METHOD, data);
                   }
                   else {
                       return Promise.reject(data.error)
                   }
        }
    function deleteCar(id) {
        const endpoint = `cars/${id}`;
            return kinveyService.remove(APP_DATA, endpoint, AUTH_METHOD);
        }
    function listMyCars(id) {
            const username = sessionStorage.getItem('username');
            const endpoint = `cars?query={"seller":"${username}"}&sort={"_kmd.ect": -1}`;
            return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
        }
    return {
        listAllCars,
        listMyCars,
        getCar,
        createCar,
        deleteCar,
        editCar
    }
})
();