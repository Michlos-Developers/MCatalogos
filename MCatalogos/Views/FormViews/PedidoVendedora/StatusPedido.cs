namespace MCatalogos.Views.FormViews.PedidoVendedora
{
    enum StatusPedido
    {
        Aberto,
        Enviado, //BLOQUEIA INCLUSÃO/EXCLUSÃO DE ITEMS
        Separado, //
        Conferido, //TIRA FALTA DEFINITIVA BLOQUEIA INCLUSÃO E EXCLUSÃO DE ITENS
        Finalizado, //GERA CONTAS A RECEBER E CONTAS A PAGAR.
        Despachado, //
        Entregue, //
        Cancelado, //
        Todos //
    }
}
