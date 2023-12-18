package com.example.hot_rolls_club.classes;

public class Carrinho {
    String nomeProduto;
    int quantidade;
    Double valor;
    Double valorqtde;
    String id_produto;
    public String getId_produto() {return id_produto;}
    public void setId_produto(String id_produto) {this.id_produto = id_produto;}
    public Double getValorqtde() {return valorqtde;}
    public void setValorqtde(Double valorqtde) {this.valorqtde = valorqtde;}
    public String getNomeProduto() {return nomeProduto;}
    public void setNomeProduto(String nomeProduto) {this.nomeProduto = nomeProduto;}
    public int getQuantidade() {return quantidade;}
    public void setQuantidade(int quantidade) {this.quantidade = quantidade;}

    public Double getValor() {return valor;}
    public void setValor(Double valor) {this.valor = valor;}
    public Carrinho(int quantidade, String id_produto) {
        this.nomeProduto = nomeProduto;
        this.quantidade = quantidade;
        this.valorqtde = valorqtde;
        this.id_produto = id_produto;
    }
}
