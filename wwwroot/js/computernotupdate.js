$(document).ready(function ()
{
  var table = $('#tableComNOtUpdate').DataTable({
      ajax : {
        url: "/InventoryList/GetAllComNotUpdate",  /*public JsonResult GetAllComNotUpdate()*/ 
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
            /*"className":      'dt-control',*/
            "orderable":      false,
            "data":           null,
            "defaultContent": ''
        },
        {"data":"computerName"},
        {"data":"os"},
        {"data":"ostype"},
        {"data":"comManufacturer"},
        {"data":"comModel"},
        {"data":"comSerialNo"},
        {"data":"cpuModel"},
        {"data":"ramsize"},
        {"data":"assetNo"},
        {"data":"nictype"},
        {"data":"ipadds"},
        {"data":"macAdds"},
        {"data":"domain"},
        /*{"data":"monitorId"},
        {"data":"userId"},
        {"data":"locationId"},
        {"data":"idUser"},*/
        {"data":"userName"},
        {"data":"userLastname"},
       /*{"data":"userLogin"},*/
        /*{"data":"idMonitorList"},*/
        {"data":"monitorManufacturer"},
        {"data":"monitorModel"},
        {"data":"monitorSerialNo"},
        {"data":"monitorAsset"},
        {"data":"dataUpdate"},
    ],
    "order": [[20, 'desc']],
    "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]]
    });

    table.buttons().container().appendTo($('#printbar'))
  // Handle click on "Expand All" button
  $('#btn-show-all-children').on('click', function(){
      // Expand row details
      table.rows(':not(.parent)').nodes().to$().find('td:first-child').trigger('click');
  });

  // Handle click on "Collapse All" button
  $('#btn-hide-all-children').on('click', function(){
      // Collapse row details
      table.rows('.parent').nodes().to$().find('td:first-child').trigger('click');
  });
});

/*$(document).ready(function() {
$.ajax ({
	url: "/InventoryList/GetAllComNotUpdate",
	success: function(data) {
    alert(data.length);
	}
});
});*/

$.get('/InventoryList/GetAllComNotUpdate', function(data) {
  var NumberOfPCNotUpdateSpan = document.getElementById('NumberOfPCNotUpdate');
  NumberOfPCNotUpdateSpan.innerHTML = data.length;
});


