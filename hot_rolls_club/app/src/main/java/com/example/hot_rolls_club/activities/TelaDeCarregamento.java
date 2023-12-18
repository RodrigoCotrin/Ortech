package com.example.hot_rolls_club.activities;

import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.activities.TelaDeLogin;
import com.example.hot_rolls_club.classes.ConexaoSQL;
import com.example.hot_rolls_club.classes.PegarLista;
import com.example.hot_rolls_club.classes.Produtos;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;


public class TelaDeCarregamento extends AppCompatActivity {

    private final Timer timer = new Timer();
    TimerTask timerTask;
    List<Produtos> listaProdutos = new ArrayList<>();


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_de_carregamento);

        //ImageConverterToBD.insertImageIntoDatabase(this, R.drawable.yaki);

        obterProdutos();

        PegarLista.getInstance().setListaProdutos(listaProdutos);

        timerTask = new TimerTask() {
            @Override
            public void run() {
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        gotoApresentacaoActivity();
                    }
                });
            }
        };
        timer.schedule(timerTask, 1500);
    }

    private void gotoApresentacaoActivity() {
        Intent intent = new Intent(getApplicationContext(), TelaDeApresentacao.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(intent);
        finish();
    }
    public void obterProdutos(){
        String consulta = "Select p.id_produto, p.nome_produto,p.descricao, p.preco, p.img_prato, c.nome_categoria, a.estrelas\n" +
                "\tfrom Produtos p \n" +
                "\tleft Join CategoriaProduto c on p.id_categoriaprod = c.id_categoriaprod\n" +
                "\tleft join Avaliacao a on p.id_produto = a.id_produto";
        ConexaoSQL conexaoSQL = new ConexaoSQL();
        Connection connection;
        connection = conexaoSQL.connectionclass();
        Statement st = conexaoSQL.createStatement(connection);
        try {
            ResultSet rs1 = st.executeQuery(consulta);
            while(rs1.next())
            {
                byte[] imageData = rs1.getBytes("img_prato");
                Bitmap imageBitmap = BitmapFactory.decodeByteArray(imageData, 0, imageData.length);
                Produtos produtos = new Produtos(
                        rs1.getString(1),
                        rs1.getString(2),
                        rs1.getString(3),
                        rs1.getString(4),
                        rs1.getString(7),
                        rs1.getString(6),
                        imageBitmap);

                listaProdutos.add(produtos);
            }
        } catch (SQLException e) {throw new RuntimeException(e);}
    }
}