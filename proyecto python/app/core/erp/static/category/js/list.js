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
			{ "data": "id"},
    		{ "data": "name"},
    		{ "data": "desc"},
    		{ "data": "desc"},
            
		],
		//personalizando las columnas
		columnDefs: [
    		{
        		targets: [-1],
        		class: 'text-center',
        		orderable: false,
        		render: function (data, type, row) {
            		var buttons = '<a href="/erp/category/update/'+row.id+'/" class="btn btn-warning btn-xs btn-flat"><i class="far fa-edit"></i></a>  ';
            		buttons+= '<a href="/erp/category/delete/'+row.id+'/" class="btn btn-danger btn-xs btn-flat"><i class="fas fa-trash-alt"></i></a>';
            		return buttons;
        		}
    		},
		],
		//se ejecuta una ves que este cargada
		initComplete: function(settings, json) {
			
  		}
	});


});