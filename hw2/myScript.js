        $(function(){
        $("button1").click(function(){
            $("#name").text(function(origText){
                $("#name-response").append("Welcome " + origText + " to my webpage!"){
                }); 
            });
        });
    });