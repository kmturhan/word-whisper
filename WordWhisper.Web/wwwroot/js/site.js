// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var inputField = document.getElementById('username');

inputField.addEventListener('focus', function () {
    inputField.setAttribute('placeholder', '');
    alert("focus test");
});

inputField.addEventListener('blur', function () {
    if (inputField.value === '') {
        inputField.setAttribute('placeholder', 'Adınız');
        alert("blur test");

    }
});