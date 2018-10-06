$(function() {

    var name1;
    var season1;

    function btn1func() {
        document.addEventListener('click', function () {

            name1 = $('#name').val();
            season1 = $('#season').val();
            var nmrespon = "Welcome " + name1;

            $('#fid').append(nmrespon);

        });
    }
});