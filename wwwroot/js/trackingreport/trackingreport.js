
let pReportID;
let mm;
$(document).ready(
  function () 
              { 
                $("#submitSearchreport").click(function (e) 
                {
                  e.preventDefault();
                  getData(); 
                  FindretreiveReport();
                });

                defaultgetData(); 
                retreiveReport();
                //FindretreiveReport();
              }
);
$(document).on( 'destroy.dt', function ( e, settings ) {
  var api = new $.fn.dataTable.Api( settings );
  api.off('order.dt');
  api.off('preDraw.dt');
  api.off('column-visibility.dt');
  api.off('search.dt');
  api.off('page.dt');
  api.off('length.dt');
  api.off('xhr.dt');
  });

  function defaultgetData() {
    pReportID = $('#InputReportID').val();
    mm;

    var columns = [];

    $.ajax({
        type: "POST",
        url: "/TrackingTheReport/ReportTrackingResult",
        data: { 
          ReportID: pReportID,
          Monthly: mm,
        },
        success: function (data) {
            columnNames = Object.keys(data[0]);
            for (var i in columnNames) {
                columns.push({
                    data: columnNames[i],
                    title: columnNames[i]
                });
            }

            $('#trackreport').DataTable( 
              {
                createdRow: function (td) {
                  $(td).css('padding', '.1rem')
                },
                  dom: "<'row'<'col-sm-12'B>>",
                  buttons: ["copy", "csv", "excel", "pdf", "print"],
                  data: data,
                  columns: columns,
                  autoWidth: true,
                  rowsGroup:[0,0],
                  autoWidth : false,
                  columnDefs: [
                              /*{ targets: [0], 
                                orderable: false,
                              },*/
                              {
                               targets: "_all",
                               className: "reportfont", 
                               orderable: false,
                               render: function ( data, type, row, meta ) 
                               {
                                  if (data === '1') {
                                    return '<i class="fas fa-check-circle" style="color:green"></i>';
                                   // return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
                                  }else if(data === null){
                                    return '<a href="'+data+'">'+data+'</a>';
                                  } else if(data === '2'){
                                    return '<i class="fas fa-times-circle" style="color:red"></i>';
                                  }
                                  else if(data === '3'){
                                    return '<i class="fas fa-exclamation-triangle"></i>';
                                  }
                                  else if(data === '0' || data === 0){
                                  return '<a href="'+data+'">-</a>';
                                  }
                                  else {
                                    return data;
                                  }
                                }
                              }
                            ],
      
              }
            );
        }
    });
  }
  
  function getData() {

    pReportID = $('#InputReportID').val();
    var moment = $("#reservationdate").datetimepicker("date");
    mm = (moment.format('YYYY-MM-DD'));

    var columns = [];

    $.ajax({
        type: "POST",
        url: "/TrackingTheReport/ReportTrackingResult",
        data: { 
          ReportID: pReportID,
          Monthly: mm,
        },
        success: function (data) {

            //tableData = JSON.parse(JSON.stringify(data));  
            //columnNames = Object.keys(tableData.Table[0]);
            columnNames = Object.keys(data[0]);
            for (var i in columnNames) {
                columns.push({
                    data: columnNames[i],
                    title: columnNames[i]
                });
            }
           
           $('#trackreport').DataTable().destroy();
           $('#trackreport').empty();
      
           $('#trackreport').DataTable( 
                {
                  createdRow: function (td) {
                    $(td).css('padding', '.1rem')
                  },
                    destroy:true,
                    dom: "<'row'<'col-sm-12'B>>",
                    buttons: ["copy", "csv", "excel", "pdf", "print"],
                    data: data,
                    columns: columns,
                    autoWidth: true,
                    rowsGroup:[0,0],
                    autoWidth : false,
                    columnDefs: [
                                /*{ targets: [0], 
                                  orderable: false,
                                },*/
                                {
                                targets: "_all",
                                className: "reportfont", 
                                orderable: false,
                                render: function ( data, type, row, meta ) 
                                {
                                    if (data === '1') {
                                      return '<i class="fas fa-check-circle" style="color:green"></i>';
                                    // return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
                                    }else if(data === null){
                                      return '<a href="'+data+'">'+data+'</a>';
                                    } else if(data === '2'){
                                      return '<i class="fas fa-times-circle" style="color:red"></i>';
                                    }
                                    else if(data === '3'){
                                      return '<i class="fas fa-exclamation-triangle"></i>';
                                    }
                                    else if(data === '0' || data === 0){
                                    return '<a href="'+data+'">-</a>';
                                    }
                                    else {
                                      return data;
                                    }
                                  }
                                }
                              ],
        
                }
              );
              
        }
     
    });

  }

  function retreiveReport(){
    $('#reportStatusDetails').DataTable( {
      //processing: true,
      //serverSide: true,
      ajax: {
          url: "/TrackingTheReport/ReportTrackingDetailResult",
          type: "POST",
          dataSrc: ""
      },
      columnDefs: [
        { width: 150, targets: 0 }
      ],
      columns: [
          //{"data":"mailLogId"},
          //{"data":"mailid"},
          {"data":"datetimest"},
          //{"data":"monthly"},
          //{"data":"yearly"},
          //{"data":"reportId"},
          //{"data":"deviceId"},
         // {"data":"typesofJobId"},
          {"data":"mailBody"},
         // {"data":"keySuccess"},
         // {"data":"keyFailed"},
         // {"data":"keyWarning"},
          {"data":"logStatus"},
      ]
  } );
   /* $.ajax({
      type: "POST",
      url: "/TrackingTheReport/ReportTrackingDetailResult",
    });*/
    /*var table = $('#reportStatusDetails').DataTable({
      ajax : {
        type: "POST",
        url: "/TrackingTheReport/ReportTrackingDetailResult",
        dataSrc: ""
      },
      dom:   
      "<'row'<'col-sm-12'B>>" +
        "<'row'<'col-sm-6'l><'col-sm-6'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-5'i><'col-sm-7'p>>",
      buttons: ["copy", "csv", "excel", "pdf", "print"],
      responsive: true,
      columns: [
        {
            "orderable":      false,
            "data":           null,
            "defaultContent": ''
        },
        {"data":"MailLogId"},
        {"data":"Mailid"},
        {"data":"Datetimest"},
        {"data":"Monthly"},
        {"data":"Yearly"},
        {"data":"ReportId"},
        {"data":"DeviceId"},
        {"data":"TypesofJobId"},
        {"data":"MailBody"},
        {"data":"KeySuccess"},
        {"data":"KeyFailed"},
        {"data":"KeyWarning"},
        {"data":"logStatus"},
        
    ],
    "order": [[20, 'desc']],
    "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]]
    });*/
  }

  function FindretreiveReport(){

    ReportID = $('#InputReportID').val();
    //var moment = $("#reservationdate").datetimepicker("date");
    //mm = (moment.format('YYYY-MM-DD'));

    $('#reportStatusDetails').DataTable().destroy();
    //$('#reportStatusDetails').empty();
    $('#reportStatusDetails').DataTable( {
      //processing: true,
      //serverSide: true,
      ajax: {
          url: "/TrackingTheReport/ReportTrackingDetailResult",
          type: "POST",
          dataSrc: "",
          data: { 
            ReportID: pReportID,
            Monthly: mm,
          },
      },
      destroy:true,
      columnDefs: [
        {
          targets: 0,
          width: 150,
          className: "reportfont", 
        },
        { width: 50, 
          targets: 2,
          className: "reportfont", 
          //orderable: false,
          render: function ( data, type, row, meta ) 
          {
             if (data === '1') {
               return '<i class="fas fa-check-circle" style="color:green"></i>';
              // return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
             }else if(data === null){
               return '<a href="'+data+'">'+data+'</a>';
             } else if(data === '2'){
               return '<i class="fas fa-times-circle" style="color:red"></i>';
             }
             else if(data === '3'){
               return '<i class="fas fa-exclamation-triangle"></i>';
             }
             else if(data === '0' || data === 0){
             return '<a href="'+data+'">-</a>';
             }
             else {
               return data;
             }
           }
        }
      ],
      columns: [
          {"data":"datetimest"},
          {"data":"mailBody"},
          {"data":"logStatus"},
      ]
  } );

  }