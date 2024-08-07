﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function () {
    getDatatable('#table-usuario')
});

$(document).ready(function () {
    getDatatable('#table-veiculo')
});

$(document).ready(function () {
    getDatatable('#table-corrida')
});

$(document).ready(function () {
    getDatatable('#table-manutencao')
});
$(document).ready(function () {
    getDatatable('#table-boletim')   
});


function getDatatable(id) {
    $(id).DataTable({
        "responsive": true,
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
};

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

// Fecha o alerta automaticamente após 3 segundos
setTimeout(function () {
    $('.alert').hide('hide');
}, 3000);


