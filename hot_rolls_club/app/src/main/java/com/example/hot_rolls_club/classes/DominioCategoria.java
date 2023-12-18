package com.example.hot_rolls_club.classes;

public class DominioCategoria {
    static private String titulo;
    static private String imagem;

    public DominioCategoria(String titulo, String imagem){
        this.titulo = titulo;
        this.imagem = imagem;
    }

    public static String getTitulo() {
        return titulo;
    }

    public static void setTitulo(String titulo) {
        DominioCategoria.titulo = titulo;
    }

    public static String getImagem() {
        return imagem;
    }

    public static void setImagem(String imagem) {
        DominioCategoria.imagem = imagem;
    }
}
