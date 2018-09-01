let AuthService = (() => {
    function isAuth() {
        return sessionStorage.getItem('authtoken') !== null;
    }

    function saveSession(userData) {
        sessionStorage.setItem('authtoken', userData._kmd.authtoken);
        sessionStorage.setItem('username', userData.username);
        sessionStorage.setItem('userId', userData._id);
    }
    function register(params) {
        let username = params.username;
        let password = params.password;
        let repeatPass = params.repeatPass;
        let user = {
            username,
            password,
            repeatPass
        };
        user = validatorService.validateRegisterFields(user);

        if (user.error === undefined) {
            let obj = {username, password};
            return kinveyService.post('user', '', 'basic', obj);
        } else {
            return Promise.reject(user.error)
        }
    }
    function login(params) {
        let username = params.username;
        let password = params.password;
        let user = {username, password};

        return kinveyService.post('user', 'login', 'basic', user)
    }

    function logout() {
        return kinveyService.post('user', '_logout', 'kinvey');
    }
    return {
        isAuth,
        login,
        logout,
        register,
        saveSession
    }
})();