window.addEventListener("load", start);

//Método para añadir EventListener a todas las acciones de la barra de navegacion
function start()
{
    document.getElementById("btnListar").addEventListener("click", listar);
    document.getElementById("btnInsertar").addEventListener("click", mostrarFormulario);
    document.getElementById("btnBorrar").addEventListener("click", borrar);
    //document.getElementById("btnEditar").addEventListener("click", getPersona);
}

//Método para obtener todas las personas de la api
function listar()
{
    //1. Instanciar objeto XMLHttpRequest
    var json = new XMLHttpRequest();

    //2. Definir método open
    json.open("GET", "../api/persona");

    //3. Definir cabeceras
    //En ese caso nada

    //4. Definir qué hacer cuando va cambiando el estado
    json.onreadystatechange = function ()
    {
        if (json.readyState < 4)
        {
            document.getElementById("contenedorListaPersonas").innerHTML = "Cargando...";
        }
        else
            if (json.readyState == 4 && json.status == 200)
            {
                //6.Tratamiento de los datos recibidos del servidor

                //Si SOLO queremos ver todo el texto que contiene el XML
                //document.getElementById("txtContenedor").innerHTML = xml.responseText;

                //Si queremos tratar la respuesta
                var arrayPersonas = JSON.parse(json.responseText);
                escribirPersonas(arrayPersonas);
            }
    }

    //5. Enviar la solicitud, send tiene parámetros opcionales
    json.send();
}

//Método para obtener una persona de la api
function getPersona(id)
{
    //1. Instanciar objeto XMLHttpRequest
    var json = new XMLHttpRequest();

    //2. Definir método open
    json.open("GET", "../api/persona/"+ id);

    //3. Definir cabeceras
    //En ese caso nada

    //4. Definir qué hacer cuando va cambiando el estado
    json.onreadystatechange = function ()
    {
        if (json.readyState == 4 && json.status == 200)
        {
            //6.Tratamiento de los datos recibidos del servidor

            //Si SOLO queremos ver todo el texto que contiene el XML
            //document.getElementById("txtContenedor").innerHTML = xml.responseText;

            //Si queremos tratar la respuesta
            var persona = JSON.parse(json.responseText);
            return persona;
        }
    }

    //5. Enviar la solicitud, send tiene parámetros opcionales
    json.send();
}


//Método para generar el formulario de insertar persona
function mostrarFormulario()
{
    if (document.getElementById("formularioPersona").hasChildNodes())
        document.getElementById("formularioPersona").innerHTML = "";
    var parraf = document.createElement("p");
    var texto;
    var input;
    texto = document.createTextNode("Nombre");
    parraf.appendChild(texto);
    input = document.createElement("input");
    input.setAttribute("type", "text");
    input.setAttribute("id", "txtNombre");
    parraf.appendChild(input);
    document.getElementById("formularioPersona").appendChild(parraf);

    parraf = document.createElement("p");
    texto = document.createTextNode("Apellidos");
    parraf.appendChild(texto);
    input = document.createElement("input");
    input.setAttribute("type", "text");
    input.setAttribute("id", "txtApellidos");
    parraf.appendChild(input);
    document.getElementById("formularioPersona").appendChild(parraf);

    parraf = document.createElement("p");
    texto = document.createTextNode("Fecha de nacimiento");
    parraf.appendChild(texto);
    input = document.createElement("input");
    input.setAttribute("type", "text");
    input.setAttribute("id", "txtFechaNac");
    parraf.appendChild(input);
    document.getElementById("formularioPersona").appendChild(parraf);

    parraf = document.createElement("p");
    texto = document.createTextNode("Teléfono");
    parraf.appendChild(texto);
    input = document.createElement("input");
    input.setAttribute("type", "text");
    input.setAttribute("id", "txtTelefono");
    parraf.appendChild(input);
    document.getElementById("formularioPersona").appendChild(parraf);

    parraf = document.createElement("p");
    texto = document.createTextNode("Direccion");
    parraf.appendChild(texto);
    input = document.createElement("input");
    input.setAttribute("type", "text");
    input.setAttribute("id", "txtDireccion");
    parraf.appendChild(input);
    document.getElementById("formularioPersona").appendChild(parraf);

    var boton = document.createElement("input");
    boton.setAttribute("type", "button");
    boton.setAttribute("id", "btnGuardar");
    boton.setAttribute("value", "Guardar");
    document.getElementById("formularioPersona").appendChild(boton);

    boton.addEventListener("click", insertar);
}

//Método para generar el formulario de edicitar persona
function mostrarFormularioEditar(e)
{
    var id = e.target.parentNode.childNodes[0].childNodes[0].innerText;
    var persona = getPersona(id);
    if (persona != null && persona != "")
    {
        if (document.getElementById("formularioPersona").hasChildNodes())
            document.getElementById("formularioPersona").innerHTML = "";
        var parraf = document.createElement("p");
        var texto;
        var input;
        texto = document.createTextNode("Nombre");
        parraf.appendChild(texto);
        input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("id", "txtNombre");
        input.value = persona.nombre;
        parraf.appendChild(input);
        document.getElementById("formularioPersona").appendChild(parraf);

        parraf = document.createElement("p");
        texto = document.createTextNode("Apellidos");
        parraf.appendChild(texto);
        input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("id", "txtApellidos");
        input.value = persona.apellidos;
        parraf.appendChild(input);
        document.getElementById("formularioPersona").appendChild(parraf);

        parraf = document.createElement("p");
        texto = document.createTextNode("Fecha de nacimiento");
        parraf.appendChild(texto);
        input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("id", "txtFechaNac");
        input.value = persona.fechaNac;
        parraf.appendChild(input);
        document.getElementById("formularioPersona").appendChild(parraf);

        parraf = document.createElement("p");
        texto = document.createTextNode("Teléfono");
        parraf.appendChild(texto);
        input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("id", "txtTelefono");
        input.value = persona.telefono;
        parraf.appendChild(input);
        document.getElementById("formularioPersona").appendChild(parraf);

        parraf = document.createElement("p");
        texto = document.createTextNode("Direccion");
        parraf.appendChild(texto);
        input = document.createElement("input");
        input.setAttribute("type", "text");
        input.setAttribute("id", "txtDireccion");
        input.value = persona.direccion;
        parraf.appendChild(input);
        document.getElementById("formularioPersona").appendChild(parraf);

        var boton = document.createElement("input");
        boton.setAttribute("type", "button");
        boton.setAttribute("id", "btnGuardar");
        boton.setAttribute("value", "Guardar");
        document.getElementById("formularioPersona").appendChild(boton);

        boton.addEventListener("click", actualizar);
    }
    
}

//Método para actualizar una persona
function actualizar()
{
    var json = new XMLHttpRequest();
    var id = document.getElementById("txtIDaEditar").value;

    json.open("PUT", "../api/persona/"+id);
    var persona = new Persona(0, document.getElementById("txtNombre").value, document.getElementById("txtApellidos").value, document.getElementById("txtFechaNac").value, document.getElementById("txtTelefono").value, document.getElementById("txtDireccion").value);
    json.setRequestHeader("Content-Type", "application/json");
    json.onreadystatechange = function ()
    {
        if (json.readyState < 4)
        {
            document.getElementById("contenedorListaPersonas").innerHTML = "Cargando...";
        }
        else
            if (json.readyState == 4 && json.status == 204)
            {
                listar();
            }
            else
                if (json.readyState == 4 && json.status != 204)
                {
                    document.getElementById("contenedorListaPersonas").innerHTML = "Error, persona no actualizada.";
                }
    }
    json.send(JSON.stringify(persona));
}

//Método para insertar una persona en la api
function insertar()
{
    var json = new XMLHttpRequest();

    json.open("POST", "../api/persona");
    var persona = new Persona(0, document.getElementById("txtNombre").value, document.getElementById("txtApellidos").value, document.getElementById("txtFechaNac").value, document.getElementById("txtTelefono").value, document.getElementById("txtDireccion").value);
    json.setRequestHeader("Content-Type", "application/json");
    json.onreadystatechange = function () {
        if (json.readyState < 4) {
            document.getElementById("contenedorListaPersonas").innerHTML = "Cargando...";
        }
        else
            if (json.readyState == 4 && json.status == 204)
            {
                listar();
            }
            else
                if (json.readyState == 4 && json.status != 204)
                {
                    document.getElementById("contenedorListaPersonas").innerHTML = "Error, persona no insertada.";
                }
    }
    json.send(JSON.stringify(persona));
}

//Método para borrar una persona de la api
function borrar()
{
    if (document.getElementById("txtIDaBorrar").innerHTML != " " && document.getElementById("txtIDaBorrar").innerHTML != null)
    {
        var json = new XMLHttpRequest();
        var id = document.getElementById("txtIDaBorrar").value;

        json.open("DELETE", "../api/persona/" + id);
        
        json.onreadystatechange = function ()
        {
            if (json.readyState < 4)
            {
                document.getElementById("contenedorListaPersonas").innerHTML = "Cargando...";
            }
            else
                if (json.readyState == 4 && json.status == 204)
                {
                    listar();
                }
                else
                    if (json.readyState == 4 && json.status != 204)
                    {
                        document.getElementById("contenedorListaPersonas").innerHTML = "No existe ninguna persona con ese ID.";
                    }
        }

        json.send();        
    }
}

//Método para crear una tabla con todas las personas de la api
    function escribirPersonas(arrayPersonas)
    {
        var table = document.createElement("TABLE");
        table.setAttribute("class","tablaPersonas");
        var fila = document.createElement("TR");
        var columna = document.createElement("TH");
        var texto;
        texto = document.createTextNode("ID");
        columna.appendChild(texto);
        fila.appendChild(columna);

        columna = document.createElement("TH");
        texto = document.createTextNode("Nombre");
        columna.appendChild(texto);
        fila.appendChild(columna);

        columna = document.createElement("TH");
        texto = document.createTextNode("Apellidos");
        columna.appendChild(texto);
        fila.appendChild(columna);

        columna = document.createElement("TH");
        texto = document.createTextNode("Fecha de nacimiento");
        columna.appendChild(texto);
        fila.appendChild(columna);

        columna = document.createElement("TH");
        texto = document.createTextNode("Teléfono");
        columna.appendChild(texto);
        fila.appendChild(columna);

        columna = document.createElement("TH");
        texto = document.createTextNode("Dirección");
        columna.appendChild(texto);
        fila.appendChild(columna);
    
        table.appendChild(fila);

        for (i = 0; i < arrayPersonas.length; i++)
        {
            var persona = new Persona(arrayPersonas[i].id,arrayPersonas[i].nombre,arrayPersonas[i].apellidos,arrayPersonas[i].fechaNac,arrayPersonas[i].telefono,arrayPersonas[i].direccion);
            fila = document.createElement("TR");
            fila.addEventListener("click", mostrarFormularioEditar,false);
            columna = document.createElement("TD");
            texto = document.createTextNode(persona.id);
            columna.appendChild(texto);
            fila.appendChild(columna);

            columna = document.createElement("TD");
            texto = document.createTextNode(persona.nombre);
            columna.appendChild(texto);
            fila.appendChild(columna);

            columna = document.createElement("TD");
            texto = document.createTextNode(persona.apellidos);
            columna.appendChild(texto);
            fila.appendChild(columna);

            columna = document.createElement("TD");
            texto = document.createTextNode(persona.fechaNac);
            columna.appendChild(texto);
            fila.appendChild(columna);

            columna = document.createElement("TD");
            texto = document.createTextNode(persona.telefono);
            columna.appendChild(texto);
            fila.appendChild(columna);

            columna = document.createElement("TD");
            texto = document.createTextNode(persona.direccion);
            columna.appendChild(texto);
            fila.appendChild(columna);

            table.appendChild(fila);
        }

        document.getElementById("contenedorListaPersonas").innerHTML = "";

        document.getElementById("contenedorListaPersonas").appendChild(table);
    }