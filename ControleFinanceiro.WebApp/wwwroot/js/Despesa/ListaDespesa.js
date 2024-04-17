"use strict";
// Class definition

var DataTableList = function () {
    // Private functions

    // basic demo
    var buildTable = function () {

        var datatable = $('#kt_datatable').KTDatatable({
            // datasource definition
            data: {
                type: 'remote',
                source: {
                    read: {
                        url: '/api/ApiDespesa/GetDespesa/'
                    }
                },
                pageSize: 10,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true,
            },

            // layout definition
            layout: {
                scroll: false,
                footer: false,
            },

            // column sorting
            sortable: true,

            pagination: true,

            search: {
                input: $('#kt_datatable_search_query'),
                key: 'generalSearch'
            },

            // columns definition
            columns: [                
                {

                    field: 'descricao',
                    title: 'Descrição',
                    sortable: 'asc',
                    type: 'text',
                    selector: false,
                    textAlign: 'left',
                },

                {

                    field: 'periodo',
                    title: 'Data da despesa',
                    sortable: 'asc',
                    type: 'text',
                    selector: false,
                    textAlign: 'left',
                },


                {
                    field: 'valor',
                    title: 'Valor',
                    sortable: 'asc',
                    type: 'text',
                    selector: false,
                    textAlign: 'left',
                },
                {
                    field: 'Actions',
                    title: 'Ações',
                    sortable: false,
                    width: 200,
                    overflow: 'visible',
                    autoHide: false,
                    template: function (item) {
                        return '\
                            <a data-target="#modalDespesa" data-toggle="tooltip" data-placement="top" data-original-title="Consultar Despesa" class="showModalButton4" href="/Despesa/ConsultDespesa/'+ item.id + '" class="btn btn-sm btn-clean btn-icon mr-2">\
                                <i class="far fa-eye"></i>\
                            </a>\
                            <a data-target="#modalDespesa" data-toggle="tooltip" data-placement="top" data-original-title="Editar Despesa" class="showModalButton4" href="/Despesa/EditDespesa/'+ item.id + '" class="btn btn-sm btn-clean btn-icon mr-2 update">\
                                <i class="fas fa-pencil-alt"></i>\
                            </a>\
                             <a data-id="' + item.id + '" class="btn btn-sm btn-clean btn-icon mr-2 btn-deletar-item delete">\
                             <i class="fas fa-trash-alt"></i>\
                            </a>';
                    },


                }
            ],

        });      
        $('#kt_datatable').on('click', '.delete', function () {

            var delet = $(this).data('id');

            Swal.fire({
                title: "Excluir ?",
                text: "Não Será possível reverte esta exclusão !",
                icon: "warning",
                showCancelButton: true,
                confirmButtonText: "Ok",
                cancelButtonText: " Cancelar",
                reverseButtons: true
            }).then(function (result) {
                if (result.value) {

                    $.ajax({
                        method: 'POST',
                        url: '/Api/ApiDespesa/DeleteDespesa/' + delet,
                    }).done(function (response) {

                        Swal.fire({
                            title: "Concluido!",
                            text: "Dados Deletados !",
                            icon: "success",
                            buttonsStyling: false,
                            confirmButtonText: "Ok!",
                            customClass: {
                                confirmButton: "btn btn-success"
                            }
                        }).then(function () {
                            $('#kt_datatable').KTDatatable('reload');
                        });
                      
                    });
                }

            });

           
        });
    }; 

    return {
        // public functions
        init: function () {
            buildTable();
        },
    };
}()

jQuery(document).ready(function () {
    DataTableList.init();
});
