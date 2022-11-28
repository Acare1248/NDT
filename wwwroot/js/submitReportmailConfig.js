function submitmailReportConfig()
{
    var datas = 
    {      
        ReportName: $('#InputReportName').val(),
        MailSubject: $('#InputEmailSubject').val(),
       //MailBody: $('InputReportName').val(),
        MailAccount: $('#InputEmailAddress').val(),
        KeyWordFrom: $("input[type='radio'][name='radioKeyFrom']:checked").val(),
        KeySuccess: $('#InputKeywSuccess').val(),
        KeyFailed: $('#InputKeywFailed').val(),
        KeyWarning: $('#InputKeywWarning').val(),
        DeviceKeyFrom: $("input[type='radio'][name='DeviceKeyFrom']:checked").val(),
    };
    //console.log(JSON.stringify(datas.DeviceKeyFrom))
    $.post('/Config/InsertMailTrackingReport',{InsertMailTR: datas}
    )
    .always(function(){
        ReloadSelectMenu();
    });
}