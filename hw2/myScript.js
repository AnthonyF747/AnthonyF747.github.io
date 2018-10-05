<script type="text/javascript"></script>

$(function () 
{
    $("button1").click(function(e) {
        var frm1val = $("#name").val();
        var frm1sval = $("#season").val();

        $("#name-response").append("Welcome " + frm1val + " !");
        $("season-response").append("Your favorite season is " + frm1sval);
    });
});
