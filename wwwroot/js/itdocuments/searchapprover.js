/*$('#mdfbtnclose').click(function () {
    $('form').find("input[name='fuser'][type='text']").val('');
    $('form').find("input[name='emailapvr'][type='text']").val('');
    var table = $('#example').DataTable().destroy();
});*/

$('#showPop').click(function () {
    //var url = '@Url.Action("ITRequest", "ITDocuments")';
        $.ajax({
            url: "/ITDocuments/ITRequestUserAD",
            //url: url,
            type: 'post',
            //data: { "para": $("#Text1").val() },
            data: { "para": $("#Username").val() },
            success: function (data) {
                //$('#popup').html(data);
               // $('form').find("input[name='fuser'][type='text']").val('');
                $('form').find("input[name='Username'][type='text']").val('');
                $('form').find("input[name='UserEmail'][type='text']").val('');

                var table = $('#example').DataTable
                    (
                        {
                            destroy: true,
                            //paging: false,
                            //searching: false,
                            data: data,
                            columns: [
                                { data: 'name' },
                                { data: 'email' },
                            ]
                        }
                );

                table.destroy();
              
                //Choose data from row
                $('#example tbody').on('click', 'tr', function () {
                    var cursor = table.row($(this));
                    var d = cursor.data();
                    //$('form').find("input[name='fuser'][type='text']").val(d['name']);
                    $('form').find("input[name='Username'][type='text']").val(d['name']);
                    $('form').find("input[name='UserEmail'][type='text']").val(d['email']);
                    
                    $('#example').DataTable().clear();
                    $('#example').empty();
                    $('#myModal').modal('hide')
                });
            }
        });
    
});