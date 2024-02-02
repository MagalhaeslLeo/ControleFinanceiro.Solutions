$(document).ready(function () {

    $('#icon-suspenso').click(function () {
        $(this).siblings(".menu-nav").toggle();
    });

    $('#cadastro').click(function () {
        $.ajax({
            url: "/ModuloMenu/GetAllModuloMenu", // URL do método na controller
            type: "GET",
            dataType: "html",
            success: function (data) {
                // Manipular os dados recebidos
                debugger;
                $("#navigator").html(data);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});