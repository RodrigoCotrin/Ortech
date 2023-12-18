package br.teste.classes;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import java.io.ByteArrayOutputStream;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;

public class ImageConverterToBD {
    public static byte[] convertBitmapToBytes(Bitmap imageBitmap) {
        ByteArrayOutputStream stream = new ByteArrayOutputStream();
        imageBitmap.compress(Bitmap.CompressFormat.PNG, 100, stream);
        return stream.toByteArray();
    }
    public static byte[] convertDrawableImageToBytes(Context context, int drawableResourceId) {
        Bitmap imageBitmap = BitmapFactory.decodeResource(context.getResources(), drawableResourceId);
        return convertBitmapToBytes(imageBitmap);
    }

    // Função para inserir a imagem no banco de dados
    public static void insertImageIntoDatabase(Context context, int drawableResourceId) {
        ConexaoSQL conexaoSQL = new ConexaoSQL();
        Connection connection = conexaoSQL.connectionclass();
        try
        {
         byte[] imageData = convertDrawableImageToBytes(context, drawableResourceId);
         String insertQuery = "UPDATE Produtos SET img_prato = ? WHERE descricao like '% %'";
         PreparedStatement preparedStatement = connection.prepareStatement(insertQuery);
         preparedStatement.setBytes(1, imageData);
         preparedStatement.executeUpdate();
        } catch (Exception e) {e.printStackTrace();}
    }
    public static void insertImageIntoDatabaseFunc(Context context, int drawableResourceId) {
        ConexaoSQL conexaoSQL = new ConexaoSQL();
        Connection connection = conexaoSQL.connectionclass();
        try
        {
            byte[] imageData = convertDrawableImageToBytes(context, drawableResourceId);
            String insertQuery = "UPDATE Funcionario SET img_func = ? WHERE id_funcionario = 1";
            PreparedStatement preparedStatement = connection.prepareStatement(insertQuery);
            preparedStatement.setBytes(1, imageData);
            preparedStatement.executeUpdate();
        } catch (Exception e) {e.printStackTrace();}
    }
    public static byte[] getImageDataFromDatabase(String nome) {
        try {
            ConexaoSQL conexaoSQL = new ConexaoSQL();
            Connection connection = conexaoSQL.connectionclass();
            Statement st = conexaoSQL.createStatement(connection);

            String selectQuery = "SELECT img_Func FROM Funcionario WHERE id_Funcionario = " + nome;
            ResultSet resultSet = st.executeQuery(selectQuery);

            if (resultSet.next()) {
                return resultSet.getBytes("img_func");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        return null;
    }
}

