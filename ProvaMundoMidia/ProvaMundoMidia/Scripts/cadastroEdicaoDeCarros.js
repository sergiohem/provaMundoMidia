function exibirModalCadastroEdicaoDeCarro() {
    $("#modalCadastroEdicaoDeCarro").modal('show');
}

function exibirModalDetalhamentoDeCarro() {
    $("#modalDetalhamentoDeCarro").modal('show');
}

function atualizaLinhaTabelaCarro(idCarro, acao) {
    FecharModal("modalCadastroEdicaoDeCarro");
    var fadeoutDone = $("#linha_carro_" + idCarro).fadeOut().promise();

    if (acao == "EditarCarro") {
        $.ajax({
            type: "POST",
            url: "/Carro/ObterLinhaTabelaCarro",
            data: { idCarroEditado: idCarro },
            success: function (data) {
                fadeoutDone.then(function () {
                    $("#linha_carro_" + idCarro).html(data).fadeIn();
                });
            }
        })
    } else if (acao == "ExcluirCarro") {
        $("#linha_carro_" + idCarro).remove();
    }
}

function submeterFormulario() {
    if ($("#descricaoCarro").val() !== '' && $("#descricaoCarro").val() !== null && $("#modeloCarro").val() !== '' && $("#modeloCarro").val() !== null && $("#anoCarro").val() !== '' && $("#anoCarro").val() !== null) {
        $("#formCadastroEdicaoDeCarro").submit();
    } else {
        alert("Alguns campos estão inválidos. Tente novamente.");
    }
}