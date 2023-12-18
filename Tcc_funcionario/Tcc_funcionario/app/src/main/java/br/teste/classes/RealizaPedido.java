package br.teste.classes;

import java.util.List;

public class RealizaPedido {
    String id_func, formapagamento, numeroMesa, dataPedido;
    List<Carrinho> pedidosProduto;
    public String getId_func() {return id_func;}
    public void setId_func(String id_func) {this.id_func = id_func;}
    public String getFormapagamento() {return formapagamento;}
    public void setFormapagamento(String formapagamento) {this.formapagamento = formapagamento;}
    public String getNumeroMesa() {return numeroMesa;}
    public void setNumeroMesa(String numeroMesa) {this.numeroMesa = numeroMesa;}
    public String getDataPedido() {return dataPedido;}
    public void setDataPedido(String dataPedido) {this.dataPedido = dataPedido;}
    public List<Carrinho> getPedidosProduto() {return pedidosProduto;}
    public void setPedidosProduto(List<Carrinho> pedidosProduto) {this.pedidosProduto = pedidosProduto;}

}
