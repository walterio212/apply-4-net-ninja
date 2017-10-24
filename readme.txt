Introducción:
Solucion 'ninja' es una aplicación que permite generar, modificar y eliminar facturas


Proyecto ninja.test

1- Escribir el código necesario para que la prueba 'DeleteInvoice' ejecute correctamente
2- Escribir el código necesario para que la prueba 'UpdateInvoiceDetail' ejecute correctamente
3- Solucionar el bug para que la prueba 'CalculateInvoiceTotalPriceWithTaxes' ejecute correctamente

Proyecto ninja.web
1- Crear la controller 'InvoiceController.cs' con las siguientes acciones
	* Index
	* Detail
	* New
	* Update
	* Delete
	
2- Crear las 4 vistas que respondan a las 4 acciones creadas en el punto anterior
	* Index - Lista todas las facturas en una grilla
	* Detail - Lista el detalle de una factura especifica
	* New - Da de alta una factura, a esta opción se accede desde Index
	* Update - Modifica una factura, a esta opción se accede desde Index
	* Delete - Elimina una factura, a esta opción se accede desde Index
	
Si la clase InvoiceManager no provee alguna funcionalidad solicitada, crearla