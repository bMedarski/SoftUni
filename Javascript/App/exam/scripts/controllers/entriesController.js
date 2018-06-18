let entriesController = (() => {

    function getEntriesById(receiptId) {
        return entriesService.getEntries(receiptId);
    }

    function addNewEntry(ctx) {

        entriesService.addEntry(ctx)
            .then((res)=> {
                ctx.redirect('#/activeReceipt');
            });
    }

    return {
        getEntriesById,
        addNewEntry
    }
})
();