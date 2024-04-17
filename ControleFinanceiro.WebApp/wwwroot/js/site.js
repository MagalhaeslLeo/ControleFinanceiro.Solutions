// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.showModalButton4').on('click', function () {
    var targetId = $(this).data('target');
    $(targetId).modal('show');
})