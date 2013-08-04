var JqGridHelper = {
    criarGrid: function(options) {

        var defaultOptions = {
            url: '/api/servidortef',
            datatype: "json",
            height: 250,
            width: 700,
            loadonce: true,
            colNames: ['Id', 'Nome', 'EnderecoIP'],
            colModel: [
                { name: 'Id', index: 'Id', width: 60, sorttype: "int", key: true },
                { name: 'Nome', index: 'Nome', width: 100, editable: true },
                { name: 'EnderecoIP', index: 'EnderecoIP', width: 100, editable: true }
            ],
            rowNum: 10,
            rowList: [10, 20, 30],
            pager: '#jqGridPaginador',
            sortname: 'Id',
            viewrecords: true,
            sortorder: "desc",
            caption: "Cadastro de Servidores TEF",
            editurl: "/api/servidortef",
            jsonReader: {
                repeatitems: false,
                root: function (obj) { return obj; },
                page: function (obj) { return 1; },
                total: function (obj) { return 1; },
                records: function (obj) { return obj.length; }
            }
        };

        $.extend(defaultOptions, options);

        jQuery("#jqGridTable").jqGrid(defaultOptions);

        jQuery("#jqGridTable").jqGrid('navGrid', '#jqGridPaginador', { edit: true, add: true, del: true }, {
            errorTextFormat: function (response) {
                var listaErros = $.parseJSON(response.responseText);
                return listaErros.join("<br>");
            },
            closeAfterEdit: true,
            afterSubmit: function () {
                $(this).jqGrid("setGridParam", { datatype: 'json' });
                return [true];
            }
        }, {
            errorTextFormat: function (response) {
                var listaErros = $.parseJSON(response.responseText);
                return listaErros.join("<br>");

            },
            closeAfterAdd: true,
            afterSubmit: function () {
                $(this).jqGrid("setGridParam", { datatype: 'json' });
                return [true];
            }
        }, {
            // Delete parameters
            mtype: "DELETE",
            onclickSubmit: function (params, postdata) {
                params.url = defaultOptions.editurl + '/' + encodeURIComponent(postdata);
            }
        });
    }
};