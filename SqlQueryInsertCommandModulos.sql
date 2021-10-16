

INSERT INTO ModuloCommands VALUES
('PedidoFormDeclare', 'PedidosListForm pedidosListForm = PedidosListForm.Instante(this);', 1),
('PedidoWindowsState', 'pedidosListForm.WindowsState = FormWindowsState.Normal;', 1),
('PedidoMDIParent','pedidosListForm.MdiParent = this;', 1),
('PedidoShow','pedidosListForm.Show();',1),

('VendedoraFormDeclare', 'VendedorasListForm vendedorasListForm = VendedorasListForm.Instante(this);',2),
('VendedoraText', 'vendedorasListForm.Text = "Cadastro de Vendedoras";',2),
('VendedoraWindowsState', 'vendedorasListForm.WindowState = FormWindowState.Normal;',2),
('VendedoraMDIParent', 'vendedorasListForm.MdiParent = this;',2),
('VendedoraShow', 'vendedorasListForm.Show();',2),

('FornecedorFormDeclare', 'FornecedoresListForm fornecedoresListForm = FornecedoresListForm.Instance(this);',3),
('FornecedorWindwsState', 'fornecedoresListForm.WindowState = FormWindowState.Normal;',3),
('FornecedorMDIParent', 'fornecedoresListForm.MdiParent = this;',3),
('FornecedorShow', 'fornecedoresListForm.Show();',3)
GO
