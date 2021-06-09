// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function deleteGadget(id) {
    let url = "/gadgets/delete?id="+ id;
    let formElement = document.getElementById("deleteForm");
    formElement.setAttribute("action", url);
    $("#deleteModal").modal('show');
}