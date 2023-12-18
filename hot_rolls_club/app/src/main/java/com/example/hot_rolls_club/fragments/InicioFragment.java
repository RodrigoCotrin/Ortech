package com.example.hot_rolls_club.fragments;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.classes.AbreProdutos;
import com.example.hot_rolls_club.classes.CategoriaSelecioada;
import com.example.hot_rolls_club.classes.Cliente;
import com.example.hot_rolls_club.classes.ConexaoSQL;
import com.example.hot_rolls_club.classes.DominioCategoria;
import com.example.hot_rolls_club.classes.PegarLista;
import com.example.hot_rolls_club.classes.Produtos;
import com.example.hot_rolls_club.databinding.FragmentInicioBinding;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;


public class InicioFragment extends Fragment {

    FragmentInicioBinding binding;
    ConexaoSQL conexaoSQL = new ConexaoSQL();
    Connection connection = conexaoSQL.connectionclass();
    CategoriaSelecioada categoriaSelecioada;
    AbreProdutos abreProdutos;

    Cliente cl = new Cliente();

    public InicioFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.btnSushi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openChildFragment();
                CategoriaSelecioada.setCategoria(1);
            }
        });
        binding.btnYakisoba.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openChildFragment();
                CategoriaSelecioada.setCategoria(2);
            }
        });
        binding.btnBebidas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openChildFragment();
                CategoriaSelecioada.setCategoria(3);
            }
        });
        binding.btnRobata.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openChildFragment();
                CategoriaSelecioada.setCategoria(4);
            }});
        binding.btnTemaki.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openChildFragment();
                CategoriaSelecioada.setCategoria(5);
            }
        });
        binding.btnTempura.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openChildFragment();
                CategoriaSelecioada.setCategoria(6);
            }
        });
        binding.btnSashimi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openChildFragment();
                CategoriaSelecioada.setCategoria(7);
            }
        });
        binding.btnNigiri.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openChildFragment();
                CategoriaSelecioada.setCategoria(8);
            }
        });

        binding.btnYakisobaPrato.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String consulta = "Select img_prato from Produtos where nome_produto = 'Yakisoba de Frango'";
                ConexaoSQL conexaoSQL = new ConexaoSQL();
                Connection connection;
                connection = conexaoSQL.connectionclass();
                Statement st = conexaoSQL.createStatement(connection);
                try {
                    ResultSet rs1 = st.executeQuery(consulta);
                    if (rs1.next()) {
                        byte[] imageData = rs1.getBytes("img_prato");
                        Bitmap imageBitmap = BitmapFactory.decodeByteArray(imageData, 0, imageData.length);
                        AbreProdutos.setImgProduto(imageBitmap);
                    }
                }catch (SQLException e){throw new RuntimeException(e);}

                openChildFragment2();
                AbreProdutos.setIdProduto("9");
                AbreProdutos.setNome("Yakisoba de Frango");
                AbreProdutos.setPreco("15.99");
                AbreProdutos.setDescricao("Macarrão frito com pedaços de frango e legumes");

                AbreProdutos.getIdProduto();
                AbreProdutos.getNome();
                AbreProdutos.getPreco();
                AbreProdutos.getDescricao();
                AbreProdutos.getImgProduto();
            }
        });
        binding.btnDorayakipopular.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String consulta = "Select img_prato from Produtos where nome_produto = 'Dorayaki'";
                ConexaoSQL conexaoSQL = new ConexaoSQL();
                Connection connection;
                connection = conexaoSQL.connectionclass();
                Statement st = conexaoSQL.createStatement(connection);
                try {
                    ResultSet rs1 = st.executeQuery(consulta);
                    if (rs1.next()) {
                        byte[] imageData = rs1.getBytes("img_prato");
                        Bitmap imageBitmap = BitmapFactory.decodeByteArray(imageData, 0, imageData.length);
                        AbreProdutos.setImgProduto(imageBitmap);
                    }
                }catch (SQLException e){throw new RuntimeException(e);}

                openChildFragment2();
                AbreProdutos.setIdProduto("17");
                AbreProdutos.setNome("Dorayaki");
                AbreProdutos.setPreco("5.99");
                AbreProdutos.setDescricao("Bolo recheado com pasta de feijão doce");

                AbreProdutos.getIdProduto();
                AbreProdutos.getNome();
                AbreProdutos.getPreco();
                AbreProdutos.getDescricao();
                AbreProdutos.getImgProduto();
            }
        });
        binding.btnHotrollpopular.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String consulta = "Select img_prato from Produtos where nome_produto = 'Hot Roll'";
                ConexaoSQL conexaoSQL = new ConexaoSQL();
                Connection connection;
                connection = conexaoSQL.connectionclass();
                Statement st = conexaoSQL.createStatement(connection);
                try {
                    ResultSet rs1 = st.executeQuery(consulta);
                    if (rs1.next()) {
                        byte[] imageData = rs1.getBytes("img_prato");
                        Bitmap imageBitmap = BitmapFactory.decodeByteArray(imageData, 0, imageData.length);
                        AbreProdutos.setImgProduto(imageBitmap);
                    }
                }catch (SQLException e){throw new RuntimeException(e);}

                openChildFragment2();
                AbreProdutos.setIdProduto("1");
                AbreProdutos.setNome("Hot Roll");
                AbreProdutos.setPreco("12.99");
                AbreProdutos.setDescricao("Sushi roll recheado com salmão, cream cheese, pepino");

                AbreProdutos.getIdProduto();
                AbreProdutos.getNome();
                AbreProdutos.getPreco();
                AbreProdutos.getDescricao();
                AbreProdutos.getImgProduto();
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentInicioBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        try {
            Statement st = conexaoSQL.createStatement(connection);
            String consulta = "Select nome from Cliente where email = '" + cl.getEmail() + "'";
            ResultSet rs = st.executeQuery(consulta);

            if (rs.next()) {
                cl.setNome(rs.getString("nome"));
            }
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
        binding.txtNomeUsuario.setText("Olá, " + cl.getNome());
        return view;
    }

    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram2, new CardapioFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
    private void openChildFragment2() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram2, new TelaPratoFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
}