function submitDeviceReportmailConfig()
{  
        var TypesofJobDetails = 
        {   DeviceName: $('#InputDeviceName').val(),
            ReportIdOfDevices: $('#InputReportOfDevice').val(),
            DeviceKeyFrom: $('#InputReportOfDevice option:selected').attr('dkf'),
            //DeviceKeyFrom: $("input[type='radio'][name='radioDeviceKeyFrom']:checked").val(),
            KeyDevice: $('#InputDeviceKeyw').val(),
            TypesofJobName: $('#InputTypesName').val(),
            TypesofJobKeyForm: $("input[type='radio'][name='radioTypesofJobKeyFrom']:checked").val(),
            KeyTypes: $('#InputTypesKeyw').val()
        };
        //console.log($('#InputReportOfDevice option:selected').attr('dkf'))
        $.post('/Config/InsertTypesJobsOfTrackingMailReport',{InsertTypesOfJobMailTR: TypesofJobDetails},
        );
}

