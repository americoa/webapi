Ext.require(['Ext.data.*', 'Ext.grid.*']);

// Modelo de dados
Ext.define('Client', {
    extend: 'Ext.data.Model',
    fields: [
        { name: 'ClientID', type: 'int' },
        { name: 'FirstName', type: 'string' },
        { name: 'LastName', type: 'string' },
        { name: 'DateBirth', type: 'date', dateFormat: 'd/m/Y' },
        { name: 'State', type: 'string' },
        { name: 'City', type: 'string' },
        { name: 'Zip', type: 'float' },
        { name: 'Country', type: 'string' },
        { name: 'Phone', type: 'float' },
        { name: 'Email', type: 'float' }
    ]
});

Ext.application({
    name: 'MyApp',

    launch: function () {     
                        

        // Store para armazenar os dados que terá o proxy contendo o CRUD
        var store = Ext.create('Ext.data.Store', {
            autoLoad: true,
            autoSync: true,
            model: 'Client',
            proxy: {
                type: 'rest',
                url: '/api/Client/List',
                reader: {
                    type: 'json',
                    root: 'data',
                    totalProperty: 'total'
                },
                writer: {
                    type: 'json',
                    root: 'data',
                    encode: false,
                    listful: true,
                    writeAllFields: true
                },
                headers: { 'Content-Type': 'application/json; charset=UTF-8' }
            }
        });        

        // Grid              
        var rowEditing = Ext.create('Ext.grid.plugin.RowEditing');

        var grid = Ext.create('Ext.grid.Panel', {
            renderTo: document.body,
            plugins: [rowEditing],           
            height: 300,
            frame: true,
            title: 'Clientes',
            store: store,
            columns: [
            {
                text: 'ID',
                width: 40,               
                dataIndex: 'ClientID'
            },
            {
                text: 'Nome',                              
                dataIndex: 'FirstName',
                field: {
                    xtype: 'textfield'
                }
            },
            {
                xtype: 'datecolumn',
                text: 'Data de Aniversário',                
                dataIndex: 'DateBirth',
                editor: {
                    xtype: 'datefield',
                    format: 'd/m/y'
                }
            },
            {
                text: 'Estado',                
                dataIndex: 'State',
                field: {
                    xtype: 'textfield'
                }
            },
            {
                text: 'Cidade',                
                dataIndex: 'City',
                field: {
                    xtype: 'textfield'
                }
            },
            {
                text: 'Cep',                
                dataIndex: 'Zip',
                field: {
                    xtype: 'textfield'
                }
            },
            {
                text: 'Pais',                
                dataIndex: 'Country',
                field: {
                    xtype: 'textfield'
                }
            },
            {
                text: 'Telefone',                
                dataIndex: 'Phone',
                field: {
                    xtype: 'textfield'
                }
            },
            {
                text: 'Email',                
                dataIndex: 'Email',
                field: {
                    xtype: 'textfield'
                }
            }
            ],
            dockedItems: [{
                xtype: 'toolbar',
                items: [{
                    text: 'Adicionar',
                    icon: 'http://cdn.sencha.com/ext/gpl/5.0.0/build/examples/shared/icons/fam/add.gif',
                    handler: function () {
                        store.insert(0, new Client());
                        rowEditing.startEdit(0, 0);
                    }
                }, '-', {
                    itemId: 'delete',
                    text: 'Remover',
                    icon: 'http://cdn.sencha.com/ext/gpl/5.0.0/build/examples/shared/icons/fam/delete.gif',
                    disabled: true,
                    handler: function () {
                        var selection = grid.getView().getSelectionModel().getSelection()[0];
                        if (selection) {
                            store.remove(selection);
                        }
                    }
                }]
            }]
        });

        grid.getSelectionModel().on('selectionchange', function (selModel, selections) {
            grid.down('#delete').setDisabled(selections.length === 0);
        });
    }
});