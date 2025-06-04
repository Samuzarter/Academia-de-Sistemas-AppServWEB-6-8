var BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaCursos();
});

function LlenarTablaCursos() {
    let URL = BaseURL + "api/Cursos/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblCursos");
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "api/Cursos/" + Funcion;

    // Construir objeto curso
    const curso = new Curso(
        $("#txtDato1").val(),  // IdCurso
        $("#txtDato2").val(),  // Nombre
        $("#txtDato3").val(),  // Descripción
        $("#txtDato4").val(),  // Duración
        $("#txtDato5").val(),  // Costo
        $("#txtDato6").val(),  // IdCategoria
        $("#txtDato7").val()   // IdModalidad
    );

    // Ejecutar servicio
    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, curso);
    LlenarTablaCursos();
}

async function Consultar() {
    let IdCurso = $("#txtDato1").val();
    let URL = BaseURL + "api/Cursos/ConsultarXId?IdCurso=" + IdCurso;

    const curso = await ConsultarServicioAuth(URL);
    if (curso != null) {
        $("#txtDato2").val(curso.Nombre);
        $("#txtDato3").val(curso.Descripcion);
        $("#txtDato4").val(curso.Duracion);
        $("#txtDato5").val(curso.Costo);
        $("#txtDato6").val(curso.IdCategoria);
        $("#txtDato7").val(curso.IdModalidad);
    } else {
        $("#dvMensaje").html("El curso no está en la base de datos");
        $("#txtDato2").val("");
        $("#txtDato3").val("");
        $("#txtDato4").val("");
        $("#txtDato5").val("");
        $("#txtDato6").val("");
        $("#txtDato7").val("");
    }
}

class Curso {
    constructor(IdCurso, Nombre, Descripcion, Duracion, Costo, IdCategoria, IdModalidad) {
        this.IdCurso = IdCurso;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.Duracion = Duracion;
        this.Costo = Costo;
        this.IdCategoria = IdCategoria;
        this.IdModalidad = IdModalidad;
    }
}
