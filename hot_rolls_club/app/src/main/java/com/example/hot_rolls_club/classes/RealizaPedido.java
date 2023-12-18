package com.example.hot_rolls_club.classes;

import java.util.List;

public class RealizaPedido {

    String cpf, formapagamento, numeroMesa, dataPedido;
    List<Produtos> pedidosProduto;

    public String getFormapagamento() {return formapagamento;}

    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) {
        this.cpf = cpf;
    }
    public void setFormapagamento(String formapagamento) {this.formapagamento = formapagamento;}
    public String getNumeroMesa() {return numeroMesa;}
    public void setNumeroMesa(String numeroMesa) {this.numeroMesa = numeroMesa;}
    public String getDataPedido() {return dataPedido;}
    public void setDataPedido(String dataPedido) {this.dataPedido = dataPedido;}
    public List<Produtos> getPedidosProduto() {return pedidosProduto;}
    public void setPedidosProduto(List<Produtos> pedidosProduto) {this.pedidosProduto = pedidosProduto;}

}
