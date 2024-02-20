$(document).ready(function () {
    $('#menu-suspenso').click(function () {
        document.querySelector('.menu-nav').style.display = 'block';
       
    });
    //$('#menu-suspenso').click(function () {
    //    loadMenuSuspenso();
    //    $('#spinner-div').show();
    //});

    //function loadMenuSuspenso() {
    //    $.ajax({
    //        url: '/ModuloMenu/GetAllModuloMenuSuspenso',
    //        type: 'POST',
    //        success: function (response) {
    //            $('#navigator ul').html(response);
    //            document.querySelector('.menu-nav').style.display = 'block';
    //        },
    //        complete: function () {
    //            $('#spinner-div').hide();
    //        },
    //        error: function (error) {
    //            console.log(error);
    //        }
    //    });
    //}
});