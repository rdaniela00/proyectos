var tblProducts;
var tblSearchProducts;
var vents ={
	items : {
		cli: '',
    tables: '',
		date_joined: '',
		subtotal: 0.0,
		iva: 0.00,
		total: 0.00,
		pagorecibio: 0.00,
    pagocambio:0.00,
		products: []

	},
  //funcion para no selecc el mismo id de prods
  get_ids: function(){
    var ids = []; 
    //recorrido de mis productos
    $.each(this.items.products, function(key, value){
      ids.push(value.id);

    });
    return ids;

  },
	calculate_factura: function(){
		var subtotal = 0.00;
		var iva = $('input[name="iva"]').val();
		var recibio = $('input[name="pagorecibio"]').val();
	
		//tis hace ref a vents me voy moviendo con posision diciionario
		$.each(this.items.products, function(pos, dict){
			//pvp era string
			dict.subtotal = dict.cant * parseFloat(dict.pvp);
			subtotal+=dict.subtotal;
		});
		this.items.subtotal= subtotal;
		this.items.iva= this.items.subtotal * iva;
		this.items.total= this.items.subtotal + this.items.iva;
    
    

		$('input[name="subtotal"]').val(this.items.subtotal.toFixed(2));
		$('input[name="ivacalc"]').val(this.items.iva.toFixed(2));
		$('input[name="total"]').val(this.items.total.toFixed(2));
    


	},
  calc_cantidad: function(){
    var recibio = $('input[name="pagorecibio"]').val();

    this.items.pagocambio= recibio-this.items.total;
    $('input[name="pagorecibio"]').val(this.items.pagorecibio.toFixed(2));
    $('input[name="pagocambio"]').val(this.items.pagocambio.toFixed(2)); 

  },
	add: function(item){
		//agrega los productosy se enlistan 
		this.items.products.push(item);
		this.list();

	},
	list: function(){
		this.calculate_factura();
		tblProducts = $('#tblProducts').DataTable({
		responsive: true,
		autoWidth: false,
		destroy: true,
		deferRender: true,
		//this hace referencia que estoy dentro de 
		data: this.items.products,
		columns:[
			{ "data": "id"},
    		{ "data": "full_name"},
    		{ "data": "stock"},
    		{ "data": "pvp"},
    		{ "data": "cant"},
        { "data": "subtotal"},

		],
		//personalizando las columnas
		columnDefs: [
    {
            targets: [-4],
            class: 'text-center',
            orderable: false,
            render: function (data, type, row) {
                return '<span class="badge badge-success">'+data+'</span>'
                
            }
        },
    		{
        		targets: [0],
        		class: 'text-center',
        		orderable: false,
        		render: function (data, type, row) {
            		return '<a rel="remove" class="btn btn-danger btn-xs btn-flat" style="color: white;"><i class="fas fa-trash-alt"></i></a>';
            		
        		}
    		},
    		{
        		targets: [-3],
        		class: 'text-center',
        		orderable: false,
        		render: function (data, type, row) {
        			//retorne a flotantey solo dos dijitos
            		return '$'+parseFloat(data).toFixed(2);
            		
        		}
    		},
    		{
        		targets: [-2],
        		class: 'text-center',
        		orderable: false,
        		render: function (data, type, row) {
        			//retorne a flotantey solo dos dijitos
            		return '<input type="text" name="cant" class="form-control form-control-sm input-sm" autocomplete="off" value="'+row.cant+'">';
            		
        		}
    		},
    		{
        		targets: [-1],  
        		class: 'text-center',
        		orderable: false,
        		render: function (data, type, row) {
        			//retorne a flotantey solo dos dijitos
            		return '$'+parseFloat(data).toFixed(2);
            		
        		}
    		},
		],
		rowCallback(row, data, displayNum, displayIndex, dataIndex){
			//tengo el objeto y luego busco el componente llamado cant y le agrego el touchpin
			$(row).find('input[name="cant"]').TouchSpin({
                    min: 1,
                    max: data.stock,
                    step: 1
                });
 
                
		},
		//se ejecuta una ves que este cargada
		initComplete: function(settings, json) {
			
  		}
	});
    console.clear();
    console.log(this.items);
    console.log(this.get_ids());

	},



};

function formatRepo(repo) {
	//recien vacio
    if (repo.loading) {
        return repo.text;
    }
    /*if (repo.id ===0){
      return repo.text;

    }*/
    if (!Number.isInteger(repo.id)) {
        return repo.text;
    }

    var option = $(
        '<div class="wrapper container">' +
        '<div class="row">' +
        '<div class="col-lg-1">' +
        '<img src="' + repo.image + '" class="img-fluid img-thumbnail d-block mx-auto rounded">' +
        '</div>' +
        '<div class="col-lg-11 text-left shadow-sm">' +
        //'<br>' +
        '<p style="margin-bottom: 0;">' +
        '<b>Nombre:</b> ' + repo.full_name + '<br>' +
        '<b>stock:</b> <span class="badge badge-success">' + repo.stock + '</span>'+ '<br>'+
        '<b>PVP:</b> <span class="badge badge-warning">$' + repo.pvp + '</span>' +
        '</p>' +
        '</div>' +
        '</div>' +
        '</div>');

    return option;
}


$(function(){
	$('.select2').select2({
    	theme: "bootstrap4",
    	language: "es"

    });
    $('#date_joined').datetimepicker({
    	format: 'YYYY-MM-DD',
    	date: moment().format("YYYY-MM-DD"),
    	locale: 'es',
    	//minDate: moment().format("YYYY-MM-DD")
    });

    $("input[name='iva']").TouchSpin({
                min: 0,
                max: 100,
                step: 0.01,
                decimals: 2,
                boostat: 5,
                maxboostedstep:10,
                postfix: '%'
    }).on('change', function () {
    	vents.calculate_factura();
    }).val(0.16);

    $("input[name='pagorecibio']").on('change', function () {
        vents.calc_cantidad();
    });
   
    //search clientes
    $('select[name="cli"]').select2({
          theme: "bootstrap4",
          language: "es",
          allowClear: true,
          ajax: {
              delay: 250,
              type: 'POST',
              url: window.location.pathname,
              data: function (params) {
                  var queryParameters = {
                      term: params.term,
                      action: 'search_clients'
                  }
                  return queryParameters;
                    },
            processResults: function(data){
              return{
                results: data
                
                
              };

            },
          },
          placeholder: 'Ingrese una descripcion',
          //empieza a buscar cuando tenga un caracter
          
          minimumInputLength: 1,


        });
    $('.btnAddClient').on('click', function(){
      $('#myModalClient').modal('show');

    });

    $('#myModalClient').on('hidden.bs.modal', function(){
      //limpio el modal
      $('#frmClient').trigger('reset');
    });
    $('#frmClient').on('submit', function (e){
        e.preventDefault();
        var parameters = new FormData(this);
        parameters.append('action', 'create_client');
        submit_with_ajax(window.location.pathname, 'Notificación', '¿Estas seguro de crear nuevo cliente?', parameters, function (response) {
          //console.log(response);
          var newOption = new Option(response.full_name, response.id, false, true);
          $('select[name="cli"]').append(newOption).trigger('change');
          $('#myModalClient').modal('hide');
        });
    });
    //busqueda de productos
   	/*$('input[name="search"]' ).autocomplete({
      source: function(request, response){
        $.ajax({
          //sinnecesidad de recargar la pagina
                  url: window.location.pathname,
                  type: 'POST',
                  data: {
                    'action': 'search_products',
                    //obtener lo que voy escribiendo
                    'term': request.term,
                  },
                  dataType:'json',
                  

                }).done(function(data) {
              //si no tiene la palabra error retorna a list url
                 response(data);

             
                }).fail(function(jqXHR, textStatus, errorThrown) {
                //alert(textStatus+': '+ errorThrown);
                }).always(function(data) {
            
              });

      },
      //lo que tarda en cargar la pagina
      delay: 500,
      //a partir del 3 caracter busqye
      minLength: 2,
      
      select: function(event, ui){
      	//detenemos el evento, lo agregamos para que nos deje hacer lo de abajo
      	event.preventDefault();
      	console.clear();
      	ui.item.cant = 1;
      	ui.item.subtotal = 0.00;
		console.log(vents.items);
        //llamamos la funcion add
		vents.add(ui.item);
        
        //vacio
        $(this).val('');

      }
    });*/
  

    $('.btnRemoveAll').on('click', function () {
        if (vents.items.products.length === 0) return false;
        alert_action('Notificación', '¿Estas seguro de eliminar todos los productos de tu detalle?', function () {
            vents.items.products = [];
            vents.list();
        }, function () {

        });
    });

   	//event cantidad 
   	$('#tblProducts tbody').on('click', 'a[rel="remove"]', function (){
      //obtengo la posicion 
      var tr = tblProducts.cell($(this).closest('td, li')).index();
      alert_action('Notificación', '¿Estas seguro de eliminar el Producto de tu detalle?', function () {
        //elimino la linea
        vents.items.products.splice(tr.row, 1);
        //se vuelve a refrescar el listado
        vents.list();
        }, function(){

        });

   	})
   	.on('change ', 'input[name="cant"]', function() {
   		console.clear();
   		var cant = 	parseInt($(this).val());
   		var tr = tblProducts.cell($(this).closest('td, li')).index();
   		vents.items.products[tr.row].cant = cant;
   		vents.calculate_factura();
   		$('td:eq(5)', tblProducts.row(tr.row).node()).html('$' + vents.items.products[tr.row].subtotal.toFixed(2));

  
   	});

    $('.btnSearchProducts').on('click', function(){
        tblSearchProducts=$('#tblSearchProducts').DataTable({
        responsive: true,
        autoWidth: false,
        destroy: true,
        deferRender: true,
        ajax: {
            url: window.location.pathname,
            type: 'POST',
            data: {
                'action': 'search_products',
                'ids': JSON.stringify(vents.get_ids()),
                'term': $('select[name="search"]').val()
            },
            dataSrc: ""
        },
        columns: [
            {"data": "full_name"},
            {"data": "image"},
             {"data": "stock"},
            {"data": "pvp"},
            {"data": "id"},
        ],
        columnDefs: [
            {
                targets: [-4],
                class: 'text-center',
                orderable: false,
                render: function (data, type, row) {
                    return '<img src="'+data+'" class="img-fluid d-block mx-auto" style="width: 20px; height: 20px;">';
                }
            },
            {
                targets: [-3],
                class: 'text-center',
                orderable: false,
                render: function (data, type, row) {
                    return '<span class="badge badge-primary">'+data+'</span>'
                }
            },
            {
                targets: [-2],
                class: 'text-center',
                orderable: false,
                render: function (data, type, row) {
                    return '$'+parseFloat(data).toFixed(2);
                }
            },
            {
                targets: [-1],
                class: 'text-center',
                orderable: false,
                render: function (data, type, row) {
                    var buttons = '<a rel="add" class="btn btn-success btn-xs btn-flat"><i class="fas fa-plus" style="color: #ffffff;"></i></a> ';
                    return buttons;
                }
            },
        ],
        initComplete: function (settings, json) {

        }
    });
       $('#myModalSearchProducts').modal('show');
    });

    $('#tblSearchProducts tbody').on('click', 'a[rel="add"]', function() {
      var tr = tblSearchProducts.cell($(this).closest('td, li')).index();
      //aqui le digo la posicion que estoy sacando del obj y con data obtengo al objeto completo
      var product = tblSearchProducts.row(tr.row).data();
      product.cant= 1;
      product.subtotal = 0.00;
      vents.add(product);
      //va desapareciendo los productos que vamos agregando del modal
      tblSearchProducts.row($(this).parents('tr')).remove().draw();
    });

    /*$('.btnClearSearch').on('click', function () {
        $('select[name="search"]').val('').focus();
    });*/
   	//vent list
   	$('select[name="search"]').select2({
        theme: "bootstrap4",
        language: 'es',
        allowClear: true,
        ajax: {
            delay: 250,
            type: 'POST',
            url: window.location.pathname,
            data: function (params) {
                var queryParameters = {
                    term: params.term,
                    action: 'search_autocomplete',
                    //como es array convertimos a strings
                    ids: JSON.stringify(vents.get_ids())

                }
                return queryParameters;
            },
            processResults: function (data) {
                return {
                    results: data
                };
            },
        },
        placeholder: 'Ingrese una descripción',
        minimumInputLength: 1,
        templateResult: formatRepo,
    }).on('select2:select', function (e) {
        var data = e.params.data;
        if(!Number.isInteger(data.id)){
            return false;
        }
        data.cant = 1;
        data.subtotal = 0.00;
        vents.add(data);
        $(this).val('').trigger('change.select2');
    });
		
        	
        //event submit cobrar
       $('#frmSale').on('submit', function (e) {
        e.preventDefault();

        if(vents.items.products.length === 0){
          message_error('Debe al menos tener un producto');
          return false;
        }


        vents.items.date_joined = $('input[name="date_joined"]').val();
        vents.items.cli = $('select[name="cli"]').val();
        vents.items.tables = $('select[name="tables"]').val();
        var parameters = new FormData();
        parameters.append('action', $('input[name="action"]').val());
        parameters.append('vents', JSON.stringify(vents.items));
        submit_with_ajax(window.location.pathname, 'Notificación', '¿Estas seguro de realizar la siguiente acción?', parameters, function (response) {
          alert_action('notificacion', '¿desea imprimir el ticket?', function(response){
            //es para traer el ticket 
            window.print('/erp/sale/factura/pdf/'+response.id+'/');
            location.href = '/erp/sale/list';
          }, function(){
            location.href = '/erp/sale/list';

          });
            
            

        });
    });
   
    vents.list();
  
      

});

