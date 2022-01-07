Api de evaluacion con dos EndPoints:
	-Localizacion:Contiene el metodo "GetLocalizacion" el cual realiza un GET y obtiene las coordenadas de la provincia solicitada.
	 Tiene como parametro "Provincia"= nombre de la provincia que se desea obtener su localizacion.
	
	-User:Ejecuta metodo "Login" el cual se envia por POST para su validacion .El body debe tener el "username" y "password".
	Devuelve en caso de ser exitoso los datos del usuario.
	
Documentacion de la API https://[URL]/swagger/index.html
Ubicacion de Logs \ApiFlockIT\bin\Debug\net5.0\Logs
Usuario Valido :Username="Test" PassWord="123"