$(document).ready(function () {

    $('#menu-suspenso').click(function () {
        document.querySelector('.menu-nav').style.display = 'block';
    });

    $('#icon-suspenso').click(function () {
        var moduleName = $(this).data('module');
        loadMenu(moduleName);
    });

    function loadMenu(moduleName) {
        $.ajax({
            url: '/ModuloMenu/GetAllModuloMenu',
            type: 'POST',
            data: { module: moduleName },
            success: function (response) {
                $('#navigator-func ul').html(response);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
});