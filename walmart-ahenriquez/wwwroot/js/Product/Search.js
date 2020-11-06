$(function () {

    $('#Search').click(function () {

        $.ajax({

            url: '/Product/SearchResults',

            method: 'GET',

            success: function (data) {

                $('#SearchResults').html(data);

            }

        });

    });

});