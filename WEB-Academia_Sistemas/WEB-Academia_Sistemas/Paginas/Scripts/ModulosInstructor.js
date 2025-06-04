var BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaModulos();
});

function LlenarTablaModulos() {
    let URL = BaseURL + "api/ModulosInstructor/ConsultarTodos";
    LlenarTablaXServiciosAuth(URL, "#tblModulos");
}

async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "api/ModulosInstructor/" + Funcion;

    const modulo = new ModuloInstructor(
        parseInt($("#txtIdModulo").val()) || 0,
        $("#txtTitulo").val(),
        $("#txtContenido").val(),
        $("#txtLinkVideo").val(),
        parseInt($("#txtIdCurso").val())
    );

    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, modulo);
    LlenarTablaModulos();
}

async function Consultar() {
    let IdModulo = $("#txtIdModulo").val();
    let URL = BaseURL + "api/ModulosInstructor/ConsultarXId?IdModulo=" + IdModulo;
    const modulo = await ConsultarServicioAuth(URL);
    if (modulo != null) {
        $("#txtTitulo").val(modulo.Titulo);
        $("#txtContenido").val(modulo.Contenido);
        $("#txtLinkVideo").val(modulo.LinkVideo);
        $("#txtIdCurso").val(modulo.IdCurso);
    } else {
        $("#dvMensaje").html("El módulo no está en la base de datos");
        $("#txtTitulo").val("");
        $("#txtContenido").val("");
        $("#txtLinkVideo").val("");
        $("#txtIdCurso").val("");
    }
}

class ModuloInstructor {
    constructor(IdModulo, Titulo, Contenido, LinkVideo, IdCurso) {
        this.IdModulo = IdModulo;
        this.Titulo = Titulo;
        this.Contenido = Contenido;
        this.LinkVideo = LinkVideo;
        this.IdCurso = IdCurso;
    }
}
