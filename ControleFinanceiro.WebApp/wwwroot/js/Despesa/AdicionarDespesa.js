var KTInputmask = function () {

    // Private functions
    var frmMask = function () {
        //CNPJ
        $("#cnpj").inputmask("mask", {
            "mask": "99.999.999/9999-99"
        });

        //Telefone
        $("#telefone").inputmask("mask", {
            "mask": "(99) 9999-9999"
        });

        //Cep
        $("#cep").inputmask("mask", {
            "mask": "99999-999"
        });

        //Email
        $("#email").inputmask({
            mask: "*{1,20}[.*{1,20}][.*{1,20}][.*{1,20}]@*{1,20}[.*{2,6}][.*{1,2}]",
            greedy: false,
            onBeforePaste: function (pastedValue, opts) {
                pastedValue = pastedValue.toLowerCase();
                return pastedValue.replace("mailto:", "");
            },
            definitions: {
                '*': {
                    validator: "[0-9A-Za-z!#$%&'*+/=?^_`{|}~\-]",
                    cardinality: 1,
                    casing: "lower"
                }
            }
        });
    }

    return {
        // public functions
        init: function () {
            frmMask();
        }
    };
}();

jQuery(document).ready(function () {
    KTInputmask.init();
});

var frmSave = (function () {
    $('#btnbuscarcnpj').on('click', function () {
        if ($('#cnpj').val() !== '') {
            var button = $(this);
            button.addClass('spinner spinner-white spinner-right');

            $.ajax({
                method: 'GET',
                url: '/api/ApiContractClient/GetAddressBycnpj?cnpj=' + $('#cnpj').val(),
                contentType: 'application/json'
            }).done(function (response) {
                Object.keys(response).forEach(item => {
                    $('[data-receitaws="' + item + '"]').val(response[item]);
                    $('[data-receitaws="' + item + '"]').removeAttr('disabled');
                });

                button.removeClass('spinner spinner-white spinner-right');
            });
        }
    });
    $('#btnbuscarCep').on('click', function () {
        if ($('#cep').val() !== '') {
            var button = $(this);
            button.addClass('spinner spinner-white spinner-right');

            $.ajax({
                method: 'GET',
                url: '/api/ApiContractClient/GetAddressByCep?cep=' + $('#cep').val(),
                contentType: 'application/json'
            }).done(function (response) {
                Object.keys(response).forEach(item => {
                    $('[data-viacep="' + item + '"]').val(response[item]);
                    $('[data-viacep="' + item + '"]').removeAttr('disabled');
                });

                button.removeClass('spinner spinner-white spinner-right');
            });
        }
    });

    $('#btnSalvar').on('click', function () {

        //var frmDespesa = $('#frmDespesa');
        var post = {};

        post = {
            id: $('[name="Id"]').val || null,
            descricao: $('[name="descricao"]').val() || null,
            periodo: $('[name="periodo"]').val() || null,
            valor: $('[name="valor"]').val() || null
        };

        //frmDespesa.serializeArray().forEach(item => {
        //	post[item.name] = item.value || null;
        //});

        var json = JSON.stringify(post);

        $.ajax({
            method: 'POST',
            url: '/api/ApiDespesa/AdicionarDespesa',
            data: json,
            contentType: 'application/json',
        }).done(function (response) {

            if (response === true) {
                Swal.fire({
                    title: "Negado !",
                    text: "Despesa já Cadastrada",
                    icon: "error",
                    buttonsStyling: false,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-success"
                    }
                }).then(function () {
                    window.location.href = "/Despesa/GetAllDespesa";
                });
            } else {
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
                    window.location.href = "/Despesa/GetAllDespesa";
                });
            }
            if (response === false) {
                Swal.fire({
                    title: "Negado !",
                    text: "Cnpj não pode ser Alterado",
                    icon: "error",
                    buttonsStyling: false,
                    confirmButtonText: "Ok!",
                    customClass: {
                        confirmButton: "btn btn-success"
                    }
                }).then(function () {
                    window.location.href = "/Despesa/GetAllDespesa";
                });
            }
        });
    });

    debugger;
    if ($('#Id').val() !== '') {
        $.ajax({
            method: 'Get',
            url: '/api/ApiDespesa/GetByIdDespesa?Id=' + $('#Id').val(),
        }).done(function (response) {
            Object.keys(response).forEach((item) => {
                $('#' + item).val(response[item]);
                id: $('[name="Id"]').val() = item.id.val() || null;
                descricao: $('[name="descricao"]').val() = item.descricao.val();
                periodo: $('[name="periodo"]').val() = item.periodo;
                valor: $('[name="valor"]').val() = item.valor;
            });
            if ($('#action').val() === 'Consult') {
                $('.readOnly').attr('readonly', 'readonly');
                $('.readOnly').prop("disabled", true);
                $('.btnHide').hide();
                $('a.voltar').text('Voltar');
            }
        });
    }
})(); 