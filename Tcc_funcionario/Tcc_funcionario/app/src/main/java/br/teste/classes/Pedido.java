package br.teste.classes;

import android.graphics.Bitmap;

public class Pedido {
    String quantidade, nome_prato;
    Bitmap img;
    public Bitmap getImg() {return img;}
    public void setImg(Bitmap img) {this.img = img;}
    public String getQuantidade() {
        return quantidade;
    }

    public void setQuantidade(String quantidade) {
        this.quantidade = quantidade;
    }

    public String getNome_prato() {
        return nome_prato;
    }

    public void setNome_prato(String nome_prato) {
        this.nome_prato = nome_prato;
    }

    public Pedido(String quantidade, String nome_prato, Bitmap img) {
        this.quantidade = quantidade;
        this.nome_prato = nome_prato;
        this.img = img;
    }
}
