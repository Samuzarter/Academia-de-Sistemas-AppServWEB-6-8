var BaseURL = "http://acsiappservweb.runasp.net/";

$(function () {
    $("#dvMenu").load("../Paginas/MenuEstudiante.html");
});

async function Inscribirse() {
    const token = ObtenerToken(); // usa sessionStorage o cookies
    if (!token || token === "0") {
        $("#dvMensaje").removeClass().addClass("text-danger").html("Debe iniciar sesión para inscribirse.");
        return;
    }

    const datos = {
        IdEstudiante: parseInt($("#txtIdEstudiante").val()),
        IdCurso: parseInt($("#txtIdCurso").val()),
        IdSede: parseInt($("#txtIdSede").val()),
        fecha_inicio: $("#txtFechaInicio").val(),
        fecha_fin: $("#txtFechaFin").val(),
        Monto: parseFloat($("#txtMonto").val()) || 0,
        MetodoPago: $("#txtMetodoPago").val()
    };

    const URL = BaseURL + "api/Estudiantes/InscribirseCurso";

    try {
        const response = await fetch(URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token
            },
            body: JSON.stringify(datos)
        });

        const texto = await response.text();

        if (response.ok) {
            $("#dvMensaje").removeClass().addClass("text-success").html(texto);
            $("#frmInscripcion")[0].reset();
        } else {
            $("#dvMensaje").removeClass().addClass("text-danger").html("Error: " + texto);
        }

    } catch (err) {
        $("#dvMensaje").removeClass().addClass("text-danger").html("Error al inscribirse: " + err.message);
    }
}
function ObtenerToken() {
    const token = sessionStorage.getItem("token");
    if (token) return token;

    const cookies = document.cookie.split(';');
    for (let c of cookies) {
        const [nombre, valor] = c.trim().split('=');
        if (nombre === "token") return valor;
    }
    return null;
}
