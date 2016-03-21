<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="TestWebSite.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript" src="Scripts/jquery-2.2.1.js"></script>
<script type="text/javascript"> 
    $(function () {
        $.ajax({
            type: "POST",
            url: "http://localhost:8002/CounterService.svc/DoWork",
            data:  JSON.stringify({
                Ip: location.host,
                Tags: "tag2",
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
</script>
<head runat="server">
    <title>SecondPage</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>I am The Second Page</h1>
    </div>
    </form>
</body>
</html>
