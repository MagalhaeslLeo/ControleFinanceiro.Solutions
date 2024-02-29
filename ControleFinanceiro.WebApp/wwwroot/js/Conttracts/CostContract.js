$(document).ready(function () {
    $('#btnSave').on('click', function () {
        //var frmCost = $('#frmCost');

        //var post = {};
        //frmCost.serializeArray().forEach(item => {
        //    post[item.name] = item.value || null;
        //});

        var post = {
           
            description: $('#description').val(),
           cost: $('#cost').val()
          
        };

        var jsonCost = JSON.stringify(post);
     
        $.ajax({
            method: 'POST',
            url: '/api/ApiContractCost/SaveCost',
            data: jsonCost,
            contentType: 'application/json/'
        }).done(function (response) {

            Swal.fire({
                title: "Concluido!",
                text: "Com Sucessso",
                icon: "success",
                buttonsStyling: false,
                confirmButtonText: "Ok!",
                customClass: {
                    confirmButton: "btn btn-success"
                }

            }).then(function () {

                window.location.href = "/Contract/ContractList";

            });
        });

    });
});