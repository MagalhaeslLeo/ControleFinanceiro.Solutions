$(document).ready(function () {

    $('#menu-suspenso').click(function () {
        loadMenuSuspenso();
    });

    function loadMenuSuspenso() {
        $.ajax({
            url: '/ModuloMenu/GetAllModuloMenuSuspenso',
            type: 'POST',
            success: function (response) {
                $('#navigator ul').html(response);
                document.querySelector('.menu-nav').style.display = 'block';
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
});