// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var mainPopUp = document.querySelector(".big");
var closeButton = document.getElementById("close-popup");

closeButton.addEventListener("click", function () {
    mainPopUp.classList.add("d-none");
    alert("asdfasdf");
});
