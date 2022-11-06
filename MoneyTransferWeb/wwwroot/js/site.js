// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $(document).on('click', 'input[type=text]', function () { this.select(); });
    $(document).on('click', 'input[type=number]', function () { this.select(); });
});




$(function() {
    var placeholderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        })
    })

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        $.post(actionUrl, dataToSend).done(function (data) {
            var newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);

            // find IsValid input field and check it's value
            // if it's valid then hide modal window
            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                placeholderElement.find('.modal').modal('hide');
            }
        });
    });
    /*PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        //alert(actionUrl); return;
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
            location.reload(true);
        })
    })*/
    placeholderElement.on('click', '[data-dismiss="modal"]', function (event) {
        placeholderElement.find('.modal').modal('hide');
    })
})