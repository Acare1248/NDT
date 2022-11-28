$(document).ready(
    function () 
    { 
        ReloadSelectMenu(); 
        datepickup(); 
    }
        );

function ReloadSelectMenu()
        {
            $.ajax({  
                type: "POST",  
                url: "/Config/RetrieveReportList",  
                data: "{}",  
                success: function (data) {  
                    var s = '<option value="">Please Select Report</option>';
                    for (var i = 0; i < data.length; i++) {
                        s += '<option dkf="'+data[i].deviceKeyFrom +'" value="' + data[i].mailReportId + '">' + data[i].reportName + '</option>';
                        
                    }
                    $("#InputReportID").append(s);
                },
                
            });
        }

function datepickup()
        {    //Date picker
            $('#reservationdate').datetimepicker({ format: 'DD/MM/YYYY'});
        }