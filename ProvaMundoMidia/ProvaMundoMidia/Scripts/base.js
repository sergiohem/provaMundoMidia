function exibirMensagemDeRetorno(notificacao) {
    if (notificacao.responseText != undefined) {
        notificacao = $.parseJSON(notificacao.responseText);
    }

    var tema = '';
    var titulo = '';
    if (notificacao.message != "") {
        switch (notificacao.Tema) {
            case 0:
                //Sucesso
                tema = 'success';
                titulo = 'Sucesso';
                break;
            case 1:
                //Erro
                tema = 'error';
                titulo = 'Erro';
                break;
            case 2:
                //Informacao
                tema = 'info';
                titulo = 'Informação';
                break;
            default:
                break;
        }
    }

    toastr.options = {
        "closeButton": true,
        "positionClass": "toast-top-right"
    }

    toastr[tema](notificacao.Mensagem, titulo);

}

function FecharModal(idModal) {
    $("#" + idModal).modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();

}


function exibirAlertaDeSucesso(mensagem, idModal) {
    FecharModal(idModal);

    toastr.options = {
        "closeButton": true,
        "positionClass": "toast-top-right"
    }

    toastr['success'](mensagem, 'Sucesso');
}

function exibirAlertaDeErro(mensagem, idModal) {

    FecharModal(idModal);

    toastr.options = {
        "closeButton": true,
        "positionClass": "toast-top-right"
    }

    toastr['error'](mensagem, 'Erro');
}