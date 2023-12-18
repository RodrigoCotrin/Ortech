package com.example.hot_rolls_club.classes;

import android.graphics.Bitmap;

public class Produtos {
    String id_produto, nomeProduto, categoriaProduto, precoProduto, descricaoProduto, estrelaProduto;
    Bitmap imgProduto;
    public String getId_produto() {
        return id_produto;
    }
    public void setId_produto(String id_produto) {
        this.id_produto = id_produto;
    }
    public String getNomeProduto() {
        return nomeProduto;
    }
    public void setNomeProduto(String nomeProduto) {
        this.nomeProduto = nomeProduto;
    }
    public String getCategoriaProduto() {
        return categoriaProduto;
    }
    public void setCategoriaProduto(String categoriaProduto) {this.categoriaProduto = categoriaProduto;}
    public String getPrecoProduto() {
        return precoProduto;
    }
    public void setPrecoProduto(String precoProduto) {
        this.precoProduto = precoProduto;
    }
    public String getDescricaoProduto() {
        return descricaoProduto;
    }
    public void setDescricaoProduto(String descricaoProduto) {this.descricaoProduto = descricaoProduto;}
    public String getEstrelaProduto() {
        return estrelaProduto;
    }
    public void setEstrelaProduto(String estrelaProduto) {
        this.estrelaProduto = estrelaProduto;
    }
    public Bitmap getImgProduto() {
        return imgProduto;
    }
    public void setImgProduto(Bitmap imgProduto) {
        this.imgProduto = imgProduto;
    }

    private int quantidadeSelecionada; // Para armazenar a quantidade selecionada no carrinho
    private double valorTotalItem; // Para armazenar o valor total do item no carrinho

    public Produtos(String id_produto, String nomeProduto, String descricaoProduto, String precoProduto, String estrelaProduto, String categoriaProduto, Bitmap imgProduto) {
        this.id_produto = id_produto;
        this.nomeProduto = nomeProduto;
        this.descricaoProduto = descricaoProduto;
        this.precoProduto = precoProduto;
        this.estrelaProduto = estrelaProduto;
        this.categoriaProduto = categoriaProduto;
        this.imgProduto = imgProduto;
    }

    public int getQuantidadeSelecionada() {
        return quantidadeSelecionada;
    }

    public void setQuantidadeSelecionada(int quantidadeSelecionada) {
        this.quantidadeSelecionada = quantidadeSelecionada;
    }

    public double getValorTotalItem() {
        return valorTotalItem;
    }

    public void setValorTotalItem(double valorTotalItem) {
        this.valorTotalItem = valorTotalItem;
    }

    public void setIdProduto(String idProduto) {
    }
}