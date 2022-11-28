$(document).ready( function () {
    var table = $('#tbReportList').DataTable(
        {
            ajax:{
                url: "/Config/GetAllReportList",
                dataSrc: ""
            },
            columns: [
                {"data":"mailReportId"},
                {"data":"reportName"},
                {"data":"mailSubject"},
                {"data":"mailBody"},
                {"data":"mailAccount"},
                {
                    data: "keyWordFrom",
                    render: function (data, type) {
                        if (data === 1) {
                            let result = 'Subject';
                            return result;
                        } else {
                            let result = 'Body';
                            return result;
                        }
                        return data;
                        
                    },
                },
                {"data":"keySuccess"},
                {"data":"keyFailed"},
                {"data":"keyWarning"},
                {
                    "data": "deviceKeyFrom",
                    render: function (data, type) {
                        if (data === 1) {
                            let result = 'Subject';
                            return result;
                        } else {
                            let result = 'Body';
                            return result;
                        }
                        return data;

                    },
                },
                { "defaultContent": '<button type="button" id="dt-edit" class="btn-sm"><i class="far fa-edit"></i></button>' },
                { "defaultContent": '<button type="button"  id="dt-delete" class="btn-sm dt-delete"><i class="far fa-trash-alt"></i></button>' }
            ],
            
        });

    $('#tbReportList').on('click', '#dt-edit', function () {
        var data = table.row($(this).parents('tr')).data();

            $('#DescModal').modal("show");
            $('#report-ID').val(data.mailReportId);
            $('#report-name').val(data.reportName);
            $('#Mail-Subject').val(data.mailSubject);
            $('#Email-Body').val(data.mailBody);
            $('#Email-Address').val(data.mailAccount);
            //$('#KeywordSource')[n5];
            document.getElementById("keywordSource").value = data.keyWordFrom;
            $('#Keyword-Success').val(data.keySuccess);
            $('#Keyword-Failed').val(data.keyFailed);
            $('#Keyword-Warning').val(data.keyWarning);
            //$('#Device-Key').val(n9);
            document.getElementById("keywordDevices").value = data.deviceKeyFrom;
        });


    $(document).on('click','#dt-delete', function () {
        var data = table.row($(this).parents('tr')).data();
        if (confirm("Are you sure to delete " + data.reportName + " ?") == true) {
            DeleteData(data.mailReportId);
        }
    });
}); //Document ready

function DeleteData(reportID) {

    $.post('/Config/DeleteMailTrackingReport', { reportID })
       .done(function () {
            $('#tbReportList').DataTable().ajax.reload();
        })
}



