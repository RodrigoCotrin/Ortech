package com.example.hot_rolls_club.classes;

import java.util.ArrayList;
import java.util.List;

public class PegarLista {
    private static PegarLista instance;
    private List<Produtos> listaProdutos = new ArrayList<>();
    public static synchronized PegarLista getInstance() {
        if (instance == null) {
            instance = new PegarLista();
        }
        return instance;
    }
    public List<Produtos> getListaProdutos() {
        return listaProdutos;
    }
    public void setListaProdutos(List<Produtos> listaProdutos) {
        this.listaProdutos = listaProdutos;
    }
}

