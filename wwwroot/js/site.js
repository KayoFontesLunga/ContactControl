// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let table = new DataTable('#table-contacts');
let table2 = new DataTable('#table-users');

$(document).on('click', '.close-alert', function () {
    $('.alert').hide();
});
