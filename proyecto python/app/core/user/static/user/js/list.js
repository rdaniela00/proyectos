//cuando se caiga la pagina ejecutar esto
//ponemos el atributo de nuestra tabla que es data 
$(function (){
	$('#data').DataTable({
		responsive: true,
		autoWidth: false,
		destroy: true,
		deferRender: true,
		ajax: {
    		url: window.location.pathname,
    		type: 'POST',
    		data: {
    			'action': 'searchdata'
    		}, // parametros
   	 		dataSrc: ""
		},
		columns: [
			{"data": "id"},
            {"data": "full_name"},
            {"data": "username"},
            {"data": "date_joined"},
            {"data": "image"},
            {"data": "groups"},
            {"data": "id"},
		],
		//personalizando las columnas 
		columnDefs: [
            {
                targets: [-3],
                class: 'text-center',
                orderable: false,
                render: function (data, type, row) {
                    return '<img src="' + row.image + '" class="img-fluid mx-auto d-block" style="width: 20px; height: 20px;">';
                }
            },
            {
                targets: [-2],
                class: 'text-center',
                orderable: false,
                render: function (data, type, row) {
                    var html = '';
                    $.each(row.groups, function (key, value) {
                        html += '<span class="badge badge-success">' + value.name + '</span> ';
                    });
                    return html;
                }
            },
           
    		{
                targets: [-1],
                class: 'text-center',
                orderable: false,
                render: function (data, type, row) {
                    var buttons = '<a href="/user/update/' + row.id + '/" class="btn btn-warning btn-xs btn-flat"><i class="fas fa-edit"></i></a> ';
                    buttons += '<a href="/user/delete/' + row.id + '/" type="button" class="btn btn-danger btn-xs btn-flat"><i class="fas fa-trash-alt"></i></a>';
                    return buttons;
                }
            },
		],
		//se ejecuta una ves que este cargada
		initComplete: function(settings, json) {
			
  		}
	});


});