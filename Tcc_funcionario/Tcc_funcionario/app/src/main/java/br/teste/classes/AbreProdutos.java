package br.teste.classes;

import android.graphics.Bitmap;

public class AbreProdutos
{
    static String idProduto, nome, descricao, preco;
    static Bitmap imgProduto;
    public static Bitmap getImgProduto() {return imgProduto;}
    public static void setImgProduto(Bitmap imgProduto) {AbreProdutos.imgProduto = imgProduto;}
    public static String getIdProduto() {return idProduto;}
    public static void setIdProduto(String idProduto) {AbreProdutos.idProduto = idProduto;}
    public static String getNome() {return nome;}
    public static void setNome(String nome) {AbreProdutos.nome = nome;}
    public static String getDescricao() {return descricao;}
    public static void setDescricao(String categoria) {AbreProdutos.descricao = categoria;}
    public static String getPreco() {return preco;}
    public static void setPreco(String preco) {AbreProdutos.preco = preco;}
}