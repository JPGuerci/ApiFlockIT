Api de evaluaci�n con dos EndPoints:
	-Localizacion:Contiene el m�todo "GetLocalizacion" el cual realiza un GET y obtiene las coordenadas de la provincia solicitada.
	 Tiene como par�metro "Provincia"= nombre de la provincia que se desea obtener su localizaci�n.
	
	-User:Ejecuta el m�todo "Login" el cual se env�a por POST para su validacion. El body debe tener el "username" y "password".
	Devuelve en caso de ser exitoso, los datos del usuario.
	
Documentaci�n de la API https://[URL]/swagger/index.html
Ubicaci�n de Logs \ApiFlockIT\bin\Debug\net5.0\Logs
Usuario V�lido :Username="Test" PassWord="123"