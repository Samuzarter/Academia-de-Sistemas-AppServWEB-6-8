var BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/MenuInstructor.html");
    LlenarTablaCursos();
});

function LlenarTablaCursos() {
    const idInstructor = getCookie("Id");
    let URL = BaseURL + `api/Instructore/VerCursosAsignados?IdInstructor=${idInstructor}`;
    LlenarTablaXServiciosAuth(URL, "#tblCursos");
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "api/CursoInstructor/" + Funcion;

    const curso = new CursoInstructor(
        $("#txtIdModalidad").val(),
        $("#txtIdCategoria").val(),
        $("#txtNombre").val(),
        $("#txtDescripcion").val(),
        $("#txtDuracion").val(),
        $("#txtCosto").val()
    );

    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, curso);
    LlenarTablaCursos();
}

async function Consultar() {
    let nombre = $("#txtNombre").val();
    let URL = BaseURL + "api/CursoInstructor/ConsultarXNombre?Nombre=" + encodeURIComponent(nombre);

    const curso = await ConsultarServicioAuth(URL);
    if (curso != null) {
        $("#txtIdModalidad").val(curso.IdModalidad);
        $("#txtIdCategoria").val(curso.IdCategoria);
        $("#txtDescripcion").val(curso.Descripcion);
        $("#txtDuracion").val(curso.Duracion);
        $("#txtCosto").val(curso.Costo);
    } else {
        $("#dvMensaje").html("El curso no está en la base de datos");
        $("#frmCursos")[0].reset();
    }
}

class CursoInstructor {
    constructor(IdModalidad, IdCategoria, Nombre, Descripcion, Duracion, Costo) {
        this.IdModalidad = parseInt(IdModalidad);
        this.IdCategoria = parseInt(IdCategoria);
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.Duracion = parseInt(Duracion);
        this.Costo = parseFloat(Costo);
    }
}
