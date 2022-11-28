$(document).ready(
    function SelectReportList()
        {
            $('.select2bs4').select2({theme: 'bootstrap4'});
            ReloadSelectMenu();

            $("#submitReport").click(function () {
                $("#InputReportOfDevice").empty();
            });
            
            document.getElementById("InputTypesKeyw").disabled = true;

             $("#InputTypesName").change(function(){
                if(document.getElementById("InputTypesName").value.length!='') {
                    document.getElementById("InputTypesKeyw").disabled = false;}
                else{
                    document.getElementById("InputTypesKeyw").disabled = true;
                }
            });

            $('#InputReportOfDevice').change(function () {
                var deviceKeyfrom = $('#InputReportOfDevice option:selected').attr('dkf');
                deviceKeyfrom == '1' ? deviceKeyfrom = 'Subject' : deviceKeyfrom = 'Body';
                document.getElementById("deviceKeyTitle").innerHTML = deviceKeyfrom;
            });
        }
    );

function CheckDuplicateReport()
{
    var datas = 
    {      
        ReportName: $('#InputReportName').val(),
    };
    $.post('/Config/CheckReportDuplicate',{ChkReportDup: datas})
        .done(function(datas) {
            if (datas != null){
                alert( "The same report name or keyword already exists ");
                ReloadSelectMenu();
            }else{
                submitmailReportConfig();
                alert( "Report Form successful submitted.");
            }
        })
        .fail(function() {
          alert( "Cannot Check Duplicate Report Name!" );
        })
}

function CheckDuplicateDevices()
{
    var datas = 
    {      
        DeviceName: $('#InputDeviceName').val(),
        ReportIdOfDevices: $('#InputReportOfDevice').val(),
        //ReportIdOfDevices: $('#InputReportOfDevice option:selected').attr('dkf'),
        KeyDevice: $('#InputDeviceKeyw').val(),
        KeyTypes: $('#InputTypesKeyw').val(),
    };
    $.post('/Config/CheckReportDuplicate',{ChkReportDup: datas})
    //Try to check type name
        .done(function(datas) {
            // Not found All data ,add device
            if (datas == null) {
                submitDeviceReportmailConfig();
                alert("the device successful submitted.");
                // Found Device but not found types
            }else if(datas.keyDevice != '' && datas.keyTypes !=''){
                if(datas.keyTypes =='No Result Found'){
                        submitDeviceReportmailConfig();
                        $("#InputReportOfDevice").empty();
                        alert("the Type of Devices successful submittedx.");
                        ReloadSelectMenu();
                    }
                else if(datas.keyTypes !='No Result Found')
                {
                    if(datas.keyTypes == $('#InputTypesKeyw').val()){
                        console.log(JSON.stringify(datas.keyTypes))
                    alert("The Type of devices name or keyword already exists with this report.");
                    ReloadSelectMenu();
                    }else{
                        console.log(JSON.stringify(datas.keyTypes))
                        submitDeviceReportmailConfig();
                        $("#InputReportOfDevice").empty();
                        alert("the Type of Devices successful submitted.");
                        ReloadSelectMenu();
                    }
                }
            }
            else if( datas.keyDevice != ''){
                //console.log(JSON.stringify(datas.keyDevice))
                alert("The same devices name or keyword already exists with this report.");
                ReloadSelectMenu();
            }
        })
        .fail(function() {
          alert( "Cannot Check Duplicate Report!" );
        })
}

function ReloadSelectMenu()
{
    $.ajax({  
        type: "POST",  
        url: "/Config/RetrieveReportList",  
        data: "{}",  
        success: function (data) {  
            var s = '<option value="">Please Select</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option dkf="'+data[i].deviceKeyFrom +'" value="' + data[i].mailReportId + '">' + data[i].reportName + '</option>';
                
            }
            $("#InputReportOfDevice").append(s);
        },
          
    });
}


/*function RetrieveDevicekeyFrom(a) {
    ReloadSelectMenu();
  //document.getElementById("demox").innerHTML = "You selected: " + a;
}*/
