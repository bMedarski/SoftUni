let receiptService = (() => {
    function getActiveReceipt() {
        const userId = sessionStorage.getItem('userId');
        const endpoint = `receipts?query={"_acl.creator":"${userId}","active":"true"}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }
    function createNewActiveReceipt(){
        const endpoint = `receipts`;
        const data = {
          "active": true,
          "productCount": 0,
          "total": 0
        };
        return kinveyService.post(APP_DATA, endpoint, AUTH_METHOD,data)
    }

    return {
        getActiveReceipt,
        createNewActiveReceipt,
    }
})();