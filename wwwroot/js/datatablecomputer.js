$(document).ready(function (){
  var table = $('#dt-ComputerList').DataTable({
      
      ajax : {
        url: "/InventoryList/GetAllCom",
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
          {
              "data": "idcomputerList",
              "visible": false,
          },
          {
              "data": "computerName",
              render: function (data, type) {
                  if (type === 'display') {
                      data = '<a href="#" id="updateStatus"> '+data+'</a>';
                  }
                  return data;
              }
          },
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
        { "data": "dataUpdate" },
          {
              data: "status",
              render: function (data, type) {
                 // let result = 'Stand-Alone';
                  if (data === 1) {
                      result = 'Active';
                      return result;
                  } else if (data === 2) {
                      result = 'Spare';
                      return result;
                  } else if (data === 3) {
                      result = 'Obsolete';
                      return result;
                  } else if (data == 4) {
                      result = 'Stand-Alone';
                      return result;
                  } else if (data == 5) {
                      result = 'Rename';
                      return result;
                  }else if (data == 0) {
                      result = 'Non-Active';
                      return result;
                  }
                  return data;
              }
          },
    ],
    "order": [[20, 'desc']]
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

    $('#dt-ComputerList').on('click', '#updateStatus', function () {
        var data = table.row($(this).parents('tr')).data();

        $('#ComputerStatusModal').modal("show");
        $('#idcomputerList').val(data.idcomputerList);
        $('#Computer-Name').val(data.computerName);
    });

    $(document).on('click', '#update', function () { 
        updateComputerStatus();
    });

}); //Document ready

function updateComputerStatus() {

    idcomputerList = document.getElementById('idcomputerList').value;
    Status = document.getElementById('vStatus').value;

    $.post('/InventoryList/UpdateComputerStatus', { IdcomputerList: idcomputerList, compStatus: Status })
        .done(function () {
            $('#dt-ComputerList').DataTable().ajax.reload();
        });
};

// Show Only Used checkbox code
$.fn.dataTable.ext.search.push(
    function (settings, searchData, index, rowData, counter) {

        var data = rowData['status'];

        var complete = true;

        if (data == '5') {
            complete = false;
        }
        var ShowAll = $('#showall').is(':checked');
        if (ShowAll || complete) {
            return true;
        }
        return false;
    }
);

$(document).ready(function () {
    var table = $('#dt-ComputerList').DataTable();
    $('#showall').change(function () {
        table.draw();
    });
});