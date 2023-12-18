package com.example.hot_rolls_club.classes;

import java.util.ArrayList;
import java.util.List;

public class CartItems {
        private static CartItems instance;
        static List<Produtos> listacarrinho = new ArrayList<>();
        public static synchronized CartItems getInstance() {
            if (instance == null) {
                instance = new CartItems();
            }
            return instance;
        }
        public List<Produtos> getListacarrinho() {
            return listacarrinho;
        }
        public void setListacarrinho(List<Produtos> listacarrinho) {
            this.listacarrinho = listacarrinho;
        }

    public static void addToCart(Produtos produto) {
        listacarrinho.add(produto);
    }

    public static List<Produtos> getCartItems() {
        return listacarrinho;
    }
    }

