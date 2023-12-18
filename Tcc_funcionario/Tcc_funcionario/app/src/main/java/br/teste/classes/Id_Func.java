package br.teste.classes;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Id_Func {
    ImageConverterToBD imageConverterToBD = new ImageConverterToBD();
    static String nomeFunc, idFunc, contrataçãoFunc, MesasFunc, PedidosFunc, emailFunc, telefoneFunc, cargoFunc,
            turnoFunc, salarioFunc, enderecoFunc, cepFunc, cpfFunc, dataNasFunc, sexoFunc, senhaFunc;

    static Bitmap imgFunc;
    public static String getTelefoneFunc() {
        return telefoneFunc;
    }

    public static void setTelefoneFunc(String telefoneFunc) {
        Id_Func.telefoneFunc = telefoneFunc;
    }

    public static String getCargoFunc() {
        return cargoFunc;
    }

    public static void setCargoFunc(String cargoFunc) {
        Id_Func.cargoFunc = cargoFunc;
    }

    public static String getTurnoFunc() {
        return turnoFunc;
    }

    public static void setTurnoFunc(String turnoFunc) {
        Id_Func.turnoFunc = turnoFunc;
    }

    public static String getSalarioFunc() {
        return salarioFunc;
    }

    public static void setSalarioFunc(String salarioFunc) {
        Id_Func.salarioFunc = salarioFunc;
    }

    public static String getEnderecoFunc() {
        return enderecoFunc;
    }

    public static void setEnderecoFunc(String enderecoFunc) {
        Id_Func.enderecoFunc = enderecoFunc;
    }

    public static String getCepFunc() {
        return cepFunc;
    }

    public static void setCepFunc(String cepFunc) {
        Id_Func.cepFunc = cepFunc;
    }

    public static String getCpfFunc() {
        return cpfFunc;
    }

    public static void setCpfFunc(String cpfFunc) {
        Id_Func.cpfFunc = cpfFunc;
    }

    public static String getDataNasFunc() {
        return dataNasFunc;
    }

    public static void setDataNasFunc(String dataNasFunc) {
        Id_Func.dataNasFunc = dataNasFunc;
    }

    public static String getSexoFunc() {
        return sexoFunc;
    }

    public static void setSexoFunc(String sexoFunc) {
        Id_Func.sexoFunc = sexoFunc;
    }

    public static String getSenhaFunc() {
        return senhaFunc;
    }

    public static void setSenhaFunc(String senhaFunc) {
        Id_Func.senhaFunc = senhaFunc;
    }


    public static String getNomeFunc() {
        return nomeFunc;
    }

    public static void setNomeFunc(String nomeFunc) {
        Id_Func.nomeFunc = nomeFunc;
    }

    public static String getIdFunc() {
        return idFunc;
    }

    public static void setIdFunc(String idFunc) {
        Id_Func.idFunc = idFunc;
    }

    public static String getContrataçãoFunc() {
        return contrataçãoFunc;
    }

    public static void setContrataçãoFunc(String contrataçãoFunc) {Id_Func.contrataçãoFunc = contrataçãoFunc;}

    public static String getMesasFunc() {
        return MesasFunc;
    }

    public static void setMesasFunc(String mesasFunc) {
        MesasFunc = mesasFunc;
    }

    public static String getPedidosFunc() {
        return PedidosFunc;
    }

    public static void setPedidosFunc(String pedidosFunc) {
        PedidosFunc = pedidosFunc;
    }

    public static String getEmailFunc() {
        return emailFunc;
    }

    public static void setEmailFunc(String emailFunc) {
        Id_Func.emailFunc = emailFunc;
    }

    public static Bitmap getImgFunc() {
        return imgFunc;
    }

    public static void setImgFunc(Bitmap imgFunc) {
        Id_Func.imgFunc = imgFunc;
    }

    public static void obter(){
        String consulta = "select *, CONVERT(VARCHAR, data_nascimento, 103) as dataNasc from Funcionario WHERE email = '";
        ConexaoSQL conexaoSQL = new ConexaoSQL();
        Connection connection;
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);
        try {
            ResultSet rs1 = st.executeQuery(consulta + Id_Func.getEmailFunc()+"'");
            if(rs1.next())
            {
                Id_Func.setIdFunc(rs1.getString(1));
                Id_Func.setNomeFunc(rs1.getString(2));
                Id_Func.setTelefoneFunc(rs1.getString(3));
                Id_Func.setCargoFunc(rs1.getString(5));
                Id_Func.setTurnoFunc(rs1.getString(6));
                Id_Func.setSalarioFunc(rs1.getString(7));
                Id_Func.setEnderecoFunc(rs1.getString(8));
                Id_Func.setCepFunc(rs1.getString(9));
                Id_Func.setCpfFunc(rs1.getString(10));
                Id_Func.setDataNasFunc(rs1.getString("dataNasc"));
                Id_Func.setSexoFunc(rs1.getString(12));
                Id_Func.setSenhaFunc(rs1.getString(13));
                Id_Func.setContrataçãoFunc(rs1.getString(15));
                byte[] imageData = rs1.getBytes("img_func");
                Bitmap imageBitmap = BitmapFactory.decodeByteArray(imageData, 0, imageData.length);
                Id_Func.setImgFunc(imageBitmap);
            }
        } catch (SQLException e) {throw new RuntimeException(e);}

    }
    public static void obter1(){
        String consulta1 = "SELECT Count(*) FROM Pedido WHERE id_funcionario = '";
        ConexaoSQL conexaoSQL = new ConexaoSQL();
        Connection connection;
        connection = conexaoSQL.connectionclass();
        Statement st1 = conexaoSQL.createStatement(connection);
        try
        {
            ResultSet rs1 = st1.executeQuery(consulta1 + Id_Func.getIdFunc()+"'");
            if(rs1.next()) {Id_Func.setMesasFunc(rs1.getString(1));}
        } catch (SQLException e) {throw new RuntimeException(e);}
    }
}
