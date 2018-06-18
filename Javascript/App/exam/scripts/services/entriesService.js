let entriesService = (() => {

    function getEntries(receiptId) {
        const userId = sessionStorage.getItem('userId');
        const endpoint = `entries?query={"receiptId":"${receiptId}"}`;
        return kinveyService.get(APP_DATA, endpoint, AUTH_METHOD);
    }

    function addEntry(ctx) {
        let type = ctx.params.type;
        let qty = Number(ctx.params.qty);
        let price = Number(ctx.params.price);
        let receiptId = $('#recId').val();
        let data = {
            type,qty,price,receiptId
        };
        const userId = sessionStorage.getItem('userId');
        const endpoint = `entries`;
        return kinveyService.post(APP_DATA, endpoint, AUTH_METHOD,data);
    }

    return {
        getEntries,
        addEntry,
    }
})
();