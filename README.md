# Apply for Java Ninja in Syntagma Team

Pre-requisites
------------------------------------

- Git (used to clone this project)
- Visual Studio 2015
- NET Framework v4.5.2
- MVC 5.2

Instructions
------------------------------------

1. (Github) Fork this project (https://github.com/syntagma/apply-4-java-ninja/) with your Github's account.
2. (Jboss official page) Download Jboss Wildfly 9.0.2 Final
3. Run It (wildfly-folder/bin/standalone.sh or bat)
4. Deploy this app (command: mvn clean package wildfly:deploy)
5. Go sleep for a while.
6. Write http://localhost:8080/wildfly-kitchensink-angularjs/#/home in your browser
7. Wait for Syntagma's customer email from job@syntagma.com.ar with the detailed new requirement to be solved.
8. (Github) Push the changes to your forked repository and ask for a git's pull request on our project.
9. Answer the customer's email explaining the changes you made and how did you solved the problem.

Test
------------------------------------

#### Introducción:
Solucion 'ninja' es una aplicación que permite generar, modificar y eliminar facturas

#### Pasos

###### Proyecto ninja.test

1. Escribir el código necesario para que la prueba 'DeleteInvoice' ejecute correctamente
2. Escribir el código necesario para que la prueba 'UpdateInvoiceDetail' ejecute correctamente
3. Solucionar el bug para que la prueba 'CalculateInvoiceTotalPriceWithTaxes' ejecute correctamente

###### Proyecto ninja.web
1. Crear la controller 'InvoiceController.cs' con las siguientes acciones
	* Index
	* Detail
	* New
	* Update
	* Delete
	
2. Crear las 4 vistas que respondan a las 4 acciones creadas en el punto anterior
	* Index - Lista todas las facturas en una grilla
	* Detail - Lista el detalle de una factura especifica
	* New - Da de alta una factura, a esta opción se accede desde Index
	* Update - Modifica una factura, a esta opción se accede desde Index
	* Delete - Elimina una factura, a esta opción se accede desde Index
	
###### Si la clase InvoiceManager no provee alguna funcionalidad solicitada, crearla