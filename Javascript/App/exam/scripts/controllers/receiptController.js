let receiptController = (() => {

    function showActiveReceipt(ctx) {
        ctx.isAuth = AuthService.isAuth();
        ctx.author = sessionStorage.getItem('username');

        let activeReceipt = receiptService.getActiveReceipt();
        activeReceipt.then((response)=> {
            let activeReceipt;
            if (response.length === 0) {

            } else {
                activeReceipt = response[0]._id;
            }
            $('#recId').val(activeReceipt);
            entriesController.getEntriesById(activeReceipt).then((entries)=>{

            });
        });

        if (AuthService.isAuth()) {
            ctx.loadPartials({
                header: './templates/partials/header.hbs',
                footer: './templates/partials/footer.hbs',
                navigation: './templates/partials/navigation.hbs',
                receiptForm: './templates/receipt/receiptForm.hbs',
                entryRow: './templates/receipt/entryRow.hbs'

            }).then(function () {
                this.partial('./templates/receipt/activeReceipt.hbs');
            })
        }
    }

    return {
        showActiveReceipt
    }
})
();