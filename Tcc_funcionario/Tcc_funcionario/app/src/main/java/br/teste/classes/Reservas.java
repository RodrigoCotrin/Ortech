package br.teste.classes;

public class Reservas {
    String cpf, dataReserva, quantidadePessoas, horareserva;
    public String getHorareserva() {
        return horareserva;
    }
    public void setHorareserva(String horareserva) {
        this.horareserva = horareserva;
    }

    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) {
        this.cpf = cpf;
    }
    public String getDataReserva() {
        return dataReserva;
    }
    public void setDataReserva(String dataReserva) {
        this.dataReserva = dataReserva;
    }
    public String getQuantidadePessoas() {
        return quantidadePessoas;
    }
    public void setQuantidadePessoas(String quantidadePessoas) {this.quantidadePessoas = quantidadePessoas;}
    public Reservas(String cpf, String dataReserva, String quantidadePessoas, String horareserva) {
        this.cpf = cpf;
        this.dataReserva = dataReserva;
        this.quantidadePessoas = quantidadePessoas;
        this.horareserva = horareserva;
    }
}
