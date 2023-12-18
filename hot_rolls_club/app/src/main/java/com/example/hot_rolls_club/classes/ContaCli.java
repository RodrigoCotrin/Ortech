package com.example.hot_rolls_club.classes;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class ContaCli {

    ImageConverterToBD imageConverterToBD = new ImageConverterToBD();
    static String nomeCli, cpf, telefoneCli, emailCli, dataCli, sexoCli, senhaCli;
    static Bitmap imgCli;
    public static String getNomeCli() {
        return nomeCli;
    }

    public static void setNomeCli(String nomeCli) {
        ContaCli.nomeCli = nomeCli;
    }

    public static String getCpf() {
        return cpf;
    }

    public static void setCpf(String cpf) {
        ContaCli.cpf = cpf;
    }

    public static String getTelefoneCli() {
        return telefoneCli;
    }

    public static void setTelefoneCli(String telefoneCli) {
        ContaCli.telefoneCli = telefoneCli;
    }

    public static String getEmailCli() {
        return emailCli;
    }

    public static void setEmailCli(String emailCli) {
        ContaCli.emailCli = emailCli;
    }

    public static String getDataCli() {
        return dataCli;
    }

    public static void setDataCli(String dataCli) {
        ContaCli.dataCli = dataCli;
    }

    public static String getSexoCli() {
        return sexoCli;
    }

    public static void setSexoCli(String sexoCli) {
        ContaCli.sexoCli = sexoCli;
    }

    public static String getSenhaCli() {
        return senhaCli;
    }

    public static void setSenhaCli(String senhaCli) {
        ContaCli.senhaCli = senhaCli;
    }

    public static Bitmap getImgCli() {
        return imgCli;
    }

    public static void setImgCli(Bitmap imgCli) {
        ContaCli.imgCli = imgCli;
    }



    public static void obter(){
        String consulta = "select *, CONVERT(VARCHAR, data_nascimento, 103) as dataNasc from Cliente WHERE email = '";
        ConexaoSQL conexaoSQL = new ConexaoSQL();
        Connection connection;
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);
        try {
            ResultSet rs1 = st.executeQuery(consulta + ContaCli.getEmailCli()+"'");
            if(rs1.next())
            {
                ContaCli.setCpf(rs1.getString(1));
                ContaCli.setNomeCli(rs1.getString(2));
                ContaCli.setTelefoneCli(rs1.getString(3));
                ContaCli.setDataCli(rs1.getString("dataNasc"));
                ContaCli.setSexoCli(rs1.getString(6));
                ContaCli.setSenhaCli(rs1.getString(7));
                /*byte[] imageData = rs1.getBytes("img_cliente");
                Bitmap imageBitmap = BitmapFactory.decodeByteArray(imageData, 0, imageData.length);
                ContaCli.setImgCli(imageBitmap);*/
            }
        } catch (SQLException e) {throw new RuntimeException(e);}

    }
}
