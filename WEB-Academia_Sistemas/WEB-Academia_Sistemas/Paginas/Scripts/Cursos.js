

$(document).ready(function () {
    let BaseURL = "http://acsiappservweb.runasp.net";
    let URL = BaseURL + "/api/Cursos/ConsultarTodos";
    LlenarTablaXServicios(URL, "#tblCursos");

});
