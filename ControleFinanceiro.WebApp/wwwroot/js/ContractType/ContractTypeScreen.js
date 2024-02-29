
(function () {
    $('.type').hide();
    
    $('#btnSalvar').on('click', function () {
        var frm = $('#idtype');
        var post = {};
        frm.serializeArray().forEach(item => {
            post[item.name] = item.value || null;
        });
        var json = JSON.stringify(post);       
        $('.form-control').removeClass('is-invalid');
        $('.msg-error').remove();
        $('.form-control').not('.is-invalid').addClass('is-valid');
        $('.type').prop("disabled", false);
        $.ajax({
            method: 'POST',
            url: '/Api/ApiContractType/SaveContractType',
            data: json,
            contentType: 'application/json',
        }).done(function (response) {
            Swal.fire({
                title: "Concluido!",
                text: "Dados Cadatrados!",
                icon: "success",
                buttonsStyling: false,
                confirmButtonText: "Ok!",
                customClass: {
                    confirmButton: "btn btn-success"
                }
            }).then(function () {
                window.location.href = "/TypeContract/GetAllContractType";
            });
        }).fail(function (response) {
            var errors = response.responseJSON.errors; 
            Object.keys(errors).forEach(item => {
                $(`#${item.toLowerCase()}`).addClass('is-invalid');
                errors[item].forEach(mensage => {
                    $(`#id${item.toLowerCase()}`).append('<div class="msg-error">'
                        + mensage + '</div>')
                })
            });
        });
    });

    if ($('#Id').val() !== '') {
        $.ajax({
            method: 'get',
            url: '/Api/ApiContractType/GetByIdType?id=' + $('#Id').val(),
        }).done(function (response) {
            Object.keys(response).forEach((item) => {
                $('#' + item).val(response[item])
            });
            if ($('#action').val() === 'Consult') {
                $('#description').attr('readonly', 'readonly');
                $('#description').prop("disabled", true);
                $('#btnSalvar').hide();
                $('a.voltar').text('Voltar');
            }            
        });
    }

    if ($('#Id').val() !== '') {
        $.ajax({
            method: 'get',
            url: '/Api/ApiContractType/GetByIdType?id=' + $('#Id').val(),

        }).done(function (response) {
            Object.keys(response).forEach((item) => {
                $('#' + item).val(response[item])
            });
            if ($('#action').val() === 'Edit') {
                $('.type').hide();
                $('.type').prop("disabled", false);
                $('.type').attr('readonly', false);            
            } 
        });
    }
})();