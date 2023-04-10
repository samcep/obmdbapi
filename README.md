# Iniciar el Proyecto Localmente

para levantar el proyecto localmente, este debe ser clonado o descargado de este repositorio.
al tener el repositorio localmente en nuestro ordenador, debemos instalar los paquetes de NuGet que utiliza la solución,
esto para su correcto funcionamiento.
para ello, en la solución del proyecto, damos click derecho y seleccionamos la opción "Restore NuGet Package" y este empezara a restaurar los paquetes.

![solution](https://user-images.githubusercontent.com/79492688/230802371-3313307b-c794-46ca-b88b-9fcec20428f2.png)

# Configurar ApiKey del proyecto

para el correcto funcionamiento del proyecto, debemos tener acceso a la api, para ello nos dirigimos a sitio
https://www.omdbapi.com y nos registramos para que este nos brinde una apiKey para realizar las peticiones.

Este ApiKey se debe configurar en el archivo del proyecto llamando appsetting.Development.json y en "ApiKey" colocar nuestra propia ApiKey

![appdevelopment](https://user-images.githubusercontent.com/79492688/230802261-1b266dd6-3237-4402-b49f-ecdaa59fbb71.png)

Luego de Realizar estos pasos ya podemos tener funcionando el proyecto!
