Api de evaluación con dos EndPoints:
	-Localizacion:Contiene el método "GetLocalizacion" el cual realiza un GET y obtiene las coordenadas de la provincia solicitada.
	 Tiene como parámetro "Provincia"= nombre de la provincia que se desea obtener su localización.
	
	-User:Ejecuta el método "Login" el cual se envía por POST para su validacion. El body debe tener el "username" y "password".
	Devuelve en caso de ser exitoso, los datos del usuario.
	
Documentación de la API https://[URL]/swagger/index.html
Ubicación de Logs \ApiFlockIT\bin\Debug\net5.0\Logs
Usuario Válido :Username="Test" PassWord="123"