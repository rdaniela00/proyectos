<?php 
// Conexion a la base de datos
include'../conexion/conexion.php';

// Codificacion de lenguaje
mysql_query("SET NAMES utf8");

// Consulta a la base de datos
$consulta=mysql_query("SELECT
							id_alumno,
							no_control,
							id_persona,
							id_carrera,
							activo,
							(SELECT personas.nombre FROM personas WHERE personas.id_persona=alumnos.id_persona) AS nUsuario,
							(SELECT personas.ap_paterno FROM personas WHERE personas.id_persona=alumnos.id_persona) AS pUsuario,
							(SELECT personas.ap_materno FROM personas WHERE personas.id_persona=alumnos.id_persona) AS mUsuario,
							(SELECT carreras.nombre FROM carreras WHERE carreras.id_carrera=alumnos.id_carrera) AS nCarrera,
							fecha_registro
							FROM
						    alumnos",$conexion) or die (mysql_error());
// $row=mysql_fetch_row($consulta)
 ?>
				            <div class="table-responsive">
				                <table id="example1" class="table table-responsive table-condensed table-bordered table-striped">

				                    <thead align="center">
				                      <tr class="info" >
				                        <th>#</th>
				                        <th>Número de control</th>
				                        <th>Alumno</th>
				                        <th>Carrera</th>
				                        <th>Registro</th>
				                        <th>Editar</th>
										<th>Estatus</th>
				                      </tr>
				                    </thead>

				                    <tbody align="center">
				                    <?php 
				                    $n=1;
				                    while ($row=mysql_fetch_row($consulta)) {
										$idAlumno           = $row[0];
										$activo             = $row[4];
										$nomUsuarioCompleto = $row[6].' '.$row[7].' '.$row[5];
										$iPersona           = $row[2];
										$nomControl         = $row[1];
										$carrera            = $row[8];
										$idCarrera          = $row[3];
										$registro           = $row[9];

										$checado         = ($activo == 1)?'checked' : '';		
										$desabilitar     = ($activo == 0)?'disabled': '';
										$claseDesabilita = ($activo == 0)?'desabilita':'';
															?>
				                      <tr>
				                        <td >
				                          <p id="<?php echo "tConsecutivo".$n; ?>" class="<?php echo $claseDesabilita; ?>">
				                          	<?php echo "$n"; ?>
				                          </p>
				                        </td>
				                         <td>
											<p id="<?php echo "tNControl".$n; ?>" class="<?php echo $claseDesabilita; ?>">
				                          	<?php echo $nomControl; ?>
				                          </p>
				                        </td>
				                        <td>
											<p id="<?php echo "tNcompleto".$n; ?>" class="<?php echo $claseDesabilita; ?>">
				                          	<?php echo $nomUsuarioCompleto; ?>
				                          </p>
				                        </td>
				                        <td>
											<p id="<?php echo "tCarrera".$n; ?>" class="<?php echo $claseDesabilita; ?>">
				                          	<?php echo $carrera; ?>
				                          </p>
				                        </td>
				                        <td>
											<p id="<?php echo "tRegistro".$n; ?>"  class="<?php echo $claseDesabilita; ?>">
				                          	<?php echo $registro; ?>
				                          </p>
				                        </td>	
				                        <td>

				                          <button id="<?php echo "boton".$n; ?>" <?php echo $desabilitar ?>  type="button" class="btn btn-login btn-sm" 
				                          onclick="abrirModalEditar(
				   
										  '<?php echo $Ncontrol ?>',
										  '<?php echo $idPersona ?>',
										  '<?php echo $idCarrera ?>'
				                          							);">
				                          	<i class="far fa-edit"></i>
				                          </button>
				                        </td>
				                        <td>
											<input  data-size="small" data-style="android" value="<?php echo "$valor"; ?>" type="checkbox" <?php echo "$checado"; ?>  id="<?php echo "interruptor".$n; ?>"  data-toggle="toggle" data-on="Desactivar" data-off="Activar" data-onstyle="danger" data-offstyle="success" class="interruptor" data-width="100" onchange="status(<?php echo $n; ?>,<?php echo $idAlumno; ?>);">
				                        </td>
				                      </tr>
				                      <?php
				                      $n++;
				                    }
				                     ?>

				                    </tbody>

				                    <tfoot align="center">
				                      <tr class="info">
										<th>#</th>
				                        <th>Número de control</th>
				                        <th>Alumno</th>
				                        <th>Carrera</th>
				                        <th>Registro</th>
				                        <th>Editar</th>
										<th>Estatus</th>
				                      </tr>
				                    </tfoot>
				                </table>
				            </div>
			
      <script type="text/javascript">
        $(document).ready(function() {
              $('#example1').DataTable( {
                 "language": {
                         // "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                          "url": "../plugins/datatables/langauge/Spanish.json"
                      },
                 "order": [[ 0, "asc" ]],
                 "paging":   true,
                 "ordering": true,
                 "info":     true,
                 "responsive": true,
                 "searching": true,
                 stateSave: false,
                  dom: 'Bfrtip',
                  lengthMenu: [
                      [ 10, 25, 50, -1 ],
                      [ '10 Registros', '25 Registros', '50 Registros', 'Todos' ],
                  ],
                 columnDefs: [ {
                      // targets: 0,
                      // visible: false
                  }],
                  buttons: [
                            {
                                extend: 'pageLength',
                                text: 'Registros',
                                className: 'btn btn-default'
                            },
                          {
                              extend: 'excel',
                              text: 'Exportar a Excel',
                              className: 'btn btn-default',
                              title:'Bajas-Estaditicas',
                              exportOptions: {
                                  columns: ':visible'
                              }
                          },
                         {
                              text: 'Nuevo Alumno',
                              action: function (  ) {
							  ver_alta();
					          llenar_persona();
					          llenar_carrera();
                              },
                              counter: 1
                          },
                  ]
              } );
          } );

      </script>
      <script>
            $(".interruptor").bootstrapToggle('destroy');
            $(".interruptor").bootstrapToggle();
      </script>
    
    
