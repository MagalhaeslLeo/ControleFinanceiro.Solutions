﻿var KTInputmask = function () {

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

    $('#btnCancelar').on('click', function () {
        $('#modalDespesa').modal('hide');
    });
    
    $('#btnSalvar').on('click', function () {
        debugger;
        var periodoDate = $('[name="periodo"]').val();
        // Criando novo objeto do tipo Date com o valor vindo do formulário e colocado na variável periodoValue

        var periodoValue = new Date(periodoDate);

        // Convertendo o valor do objeto do tipo Date para um objeto do tipo DateTime
        var periodoFormatado = periodoValue ? periodoValue.toISOString() : null;
        var post = {};
        debugger;
        post = {
            id: $('[name="id"]').val() || null,
            descricao: $('[name="descricao"]').val() || null,
            periodo: periodoFormatado,
            valor: $('[name="valor"]').val() || null
        };

        var json = JSON.stringify(post);

        $.ajax({
            method: 'POST',
            url: '/api/ApiDespesa/AdicionarDespesa',
            data: json,
            contentType: 'application/json',
        }).done(function (response) {
            if (response === true) {
                // Caso a despesa já esteja cadastrada
                Swal.fire({
                    title: "Negado!",
                    text: "Despesa já cadastrada",
                    icon: "error",
                    buttonsStyling: false,
                    confirmButtonText: "Ok",
                    customClass: {
                        confirmButton: "btn btn-success"
                    }
                }).then(function () {
                    // Fechar o modal
                    $('#modalDespesa').modal('hide');
                    // Limpar os campos do modal
                    $('[name="id"]').val('');
                    $('[name="descricao"]').val('');
                    $('[name="periodo"]').val('');
                    $('[name="valor"]').val('');
                    // Recarregar os dados na tabela, se necessário
                    $('#kt_datatable').KTDatatable('reload');
                });
            } else {
                // Caso a despesa seja cadastrada com sucesso
                Swal.fire({
                    title: "Concluído!",
                    text: "Despesa cadastrada com sucesso",
                    icon: "success",
                    buttonsStyling: false,
                    confirmButtonText: "Ok",
                    customClass: {
                        confirmButton: "btn btn-success"
                    }
                }).then(function () {
                    // Fechar o modal
                    $('#modalDespesa').modal('hide');
                    // Limpar os campos do modal
                    $('[name="id"]').val('');
                    $('[name="descricao"]').val('');
                    $('[name="periodo"]').val('');
                    $('[name="valor"]').val('');
                    // Recarregar os dados na tabela, se necessário
                    $('#kt_datatable').KTDatatable('reload');
                });
            }
        });
    });


    if ($('#Id').val() !== '') {
        $.ajax({
            method: 'Get',
            url: '/api/ApiDespesa/GetByIdDespesa?Id=' + $('#Id').val(),
        }).done(function (response) {

            $('#descricao').val(response.descricao);

            var periodo = new Date(response.periodo);
            var periodoFormatado = periodo.toLocaleDateString('pt-BR');

            $('#periodo').val(periodoFormatado);
            $('#valor').val(response.valor);

            if ($('#action').val() === 'Consult') {
                $('.readOnly').attr('readonly', 'readonly');
                $('.readOnly').prop("disabled", true);
                $('.readOnly').css('background-color', '#EBEBE4');
                $('.btnHide').hide();
                $('a.voltar').text('Voltar');
            }
        });
    }
})(); 