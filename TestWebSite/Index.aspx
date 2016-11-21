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
                Cookie: readCookie("SCA")
            }),
            contentType: "application/json; charset=UTF-8",
            dataType: "json",
            processdata: true,
            crossDomain: true,
            //success: function (result, status, xhr) {
            //    alert(result);
            //    document.cookie = location.host + ";" + result ;
            //},
            complete: function (result) {
                //document.cookie = location.host + ";" + result.responseText;
                createCookie("SCA", result.responseText, 365);
                //alert(document.cookie);
            }
            
        });

        function createCookie(name, value, days) {
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                var expires = "; expires=" + date.toGMTString();
            }
            else var expires = "";
            document.cookie = name + "=" + value + expires + "; path=/";
        }

        function readCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }
    });
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
