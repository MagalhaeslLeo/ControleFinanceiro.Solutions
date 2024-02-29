(function () {
    $.ajax({
        method: 'get',
        url: '/Api/ApiContractStatus/GetByIdStatus?id=' + $('#Id').val(),

    }).done(function (response) {
        Object.keys(response).forEach((item) => {
            $('#' + item).val(response[item])
        });
    });

    if ($('#Id').val() !== '') {
        $.ajax({

            method: 'get',
            url: '/Api/ApiContractStatus/GetByIdStatus?id=' + $('#Id').val()

        }).done(function (response) {
            Object.keys(response).forEach((item) => {
                $('#' + item).val(response[item])
                $('#description').attr('readonly', 'readonly');
            });

            if ($('#Action') === 'Consult') {
                $('#btnSalvar').hide();
                $('a.voltar').text('Voltar');
            }

        });
    }

    $('#btnSalvar').on('click', function () {
        var form = $('#idstatus');
        var contrat = {};

        form.serializeArray().forEach(item => {
            contrat[item.name] = item.value
        });

        var json = JSON.stringify(contrat);

        $.ajax({
            method: 'POST',
            url: '/api/ApiContractStatus/SaveStatusContract',
            data: json,
            contentType: 'application/json'
        }).done(function (response) {
            alert('ok');
        });
    });

})();
