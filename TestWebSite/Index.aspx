<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" src="Scripts/jquery-2.2.1.js"></script>
<script type="text/javascript"> 
    $(function () {
        $.ajax({
            type: "POST",
            url: "http://localhost:8002/CounterService.svc/DoWork",
            data:  JSON.stringify({
                Ip: location.host,
                Tags: "tag1",
                HostName: document.cookie
            }),
            contentType: "application/json; charset=UTF-8",
            dataType: "json",
            processdata: true,
            crossDomain: true,
            success: function () {
               
            },
            error: function (msg) {
            }
        });
    });
function Button1_onclick() {        
    $.ajax({
        type: "POST",
        url: "http://localhost:8002/CounterService.svc/DoWork",
        data: JSON.stringify({
            Ip: "eeeee"
        }),
        contentType: "application/json; charset=UTF-8",
        dataType: "json",
        processdata: true,
        crossDomain: true,
        success: function () {
            
        },
        error: function (msg) {
        }
    });
    return false;
}
</script>
<head runat="server">
    <title>FirstPage</title>
</head>
<body>
<form id="HtmlForm" runat="server">
    <div>
        <input type="button" onclick="window.location.href ='SecondPage.aspx'" value="Go next"/>
    </div>
</form>
</body>
</html>
