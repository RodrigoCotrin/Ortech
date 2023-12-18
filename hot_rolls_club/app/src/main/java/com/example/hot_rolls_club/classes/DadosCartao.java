package com.example.hot_rolls_club.classes;

public class DadosCartao {
    private String numeroCartao;
    private String mesAno;
    private String cvv;

    public DadosCartao(String numeroCartao, String mesAno, String cvv) {
        this.numeroCartao = numeroCartao;
        this.mesAno = mesAno;
        this.cvv = cvv;
    }

    public String getNumeroCartao() {
        return numeroCartao;
    }

    public void setNumeroCartao(String numeroCartao) {
        this.numeroCartao = numeroCartao;
    }

    public String getMesAno() {
        return mesAno;
    }

    public void setMesAno(String mesAno) {
        this.mesAno = mesAno;
    }

    public String getCvv() {
        return cvv;
    }

    public void setCvv(String cvv) {
        this.cvv = cvv;
    }
}

