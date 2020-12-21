$(function () {
    for (var i = 0; i <= 10; i++) {
        GetMessage();
    }
    
});

function GetMessage() {
    
    $.ajax({
        type: 'Get',
        url: 'http://localhost:52234/api/HelloWorld',
        dataType: 'json',
        success: function (data) {
            var items = '';
            $('#divMessage').append(data.message +'<br/>');
        },
        error: function (ex) {
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });  
}
