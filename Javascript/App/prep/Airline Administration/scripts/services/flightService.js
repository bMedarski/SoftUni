let flightsService = (() => {

    function getPublishedFlights() {
        const endpoint = `flights?query={"isPublished":"true"}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function createFlight(flight) {
        const endpoint = `flights`;
        let data = {
        };
        data = validatorService.validateFlight(data);
        if (data.error=== undefined){
            return kinveyService.post(APP_DATA, endpoint, AUTH_METHOD, data);
        }
        else {
            return Promise.reject(data.error)
        }
    }
    function editFlight(flight) {
        const endpoint = `flights/${flight.id}`;
        let data = {
        };
        data = validatorService.validateFlight(data);
        if (data.error=== undefined){
            return kinveyService.update(APP_DATA, endpoint, AUTH_METHOD, data);
        }
        else {
            return Promise.reject(data.error)
        }
    }
    function deleteFlight(id) {
        const endpoint = `flights/${id}`;
        return kinveyService.remove(APP_DATA, endpoint, AUTH_METHOD);
    }
    function getFlight(id) {
        const endpoint = `flights/${id}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function getMyFlights(user_id) {
        const endpoint = `flights?query={"_acl.creator":"${user_id}"}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    return {
        getPublishedFlights,
        createFlight,
        editFlight,
        deleteFlight,
        getFlight,
        getMyFlights
    }
})
();