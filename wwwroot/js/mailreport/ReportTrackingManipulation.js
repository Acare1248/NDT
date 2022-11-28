$(document).ready(function () {

    $("#update").click(function () {
        UpdateMailReportConfig();
    });
});

function UpdateMailReportConfig() {
    
    var datas =
    {
        MailReportId: document.getElementById('report-ID').value,
        ReportName: document.getElementById('report-name').value,
        MailSubject: document.getElementById('Mail-Subject').value,
        MailBody: document.getElementById('Email-Body').value,
        MailAccount: document.getElementById('Email-Address').value,
        KeyWordFrom: document.getElementById("keywordSource").value,
        KeySuccess: document.getElementById('Keyword-Success').value,
        KeyFailed: document.getElementById('Keyword-Failed').value,
        KeyWarning: document.getElementById('Keyword-Warning').value,
        DeviceKeyFrom: document.getElementById('keywordDevices').value,
    };
    $.post('/Config/InsertMailTrackingReport', { InsertMailTR: datas })
        .done(function () {
            $('#tbReportList').DataTable().ajax.reload();
        });

}