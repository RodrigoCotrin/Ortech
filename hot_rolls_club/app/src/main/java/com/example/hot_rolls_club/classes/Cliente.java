package com.example.hot_rolls_club.classes;

public class Cliente {
    private static String cpf;
    private static String nome;
    private static String telefone;
    private static String email;
    private static String dataNascimento;
    private static String sexo;
    private static String senha;
    private static String imgCliente;

    public static String getCpf() {
        return cpf;
    }

    public static void setCpf(String cpf) {
        Cliente.cpf = cpf;
    }

    public static String getNome() {
        return nome;
    }

    public static void setNome(String nome) {
        Cliente.nome = nome;
    }

    public static String getTelefone() {
        return telefone;
    }

    public static void setTelefone(String telefone) {
        Cliente.telefone = telefone;
    }

    public static String getEmail() {
        return email;
    }

    public static void setEmail(String email) {
        Cliente.email = email;
    }

    public static String getDataNascimento() {
        return dataNascimento;
    }

    public static void setDataNascimento(String dataNascimento) {
        Cliente.dataNascimento = dataNascimento;
    }

    public static String getSexo() {
        return sexo;
    }

    public static void setSexo(String sexo) {
        Cliente.sexo = sexo;
    }

    public static String getSenha() {
        return senha;
    }

    public static void setSenha(String senha) {
        Cliente.senha = senha;
    }

    public static String getImgCliente() {
        return imgCliente;
    }

    public static void setImgCliente(String imgCliente) {
        Cliente.imgCliente = imgCliente;
    }
}
