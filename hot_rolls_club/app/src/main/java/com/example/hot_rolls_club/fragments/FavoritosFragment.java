package com.example.hot_rolls_club.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.adapters.ProdutoAdapter;
import com.example.hot_rolls_club.adapters.RecyclerProdutosInterface;
import com.example.hot_rolls_club.classes.AbreProdutos;
import com.example.hot_rolls_club.classes.Cliente;
import com.example.hot_rolls_club.classes.ConexaoSQL;
import com.example.hot_rolls_club.classes.ContaCli;
import com.example.hot_rolls_club.classes.PegarLista;
import com.example.hot_rolls_club.classes.Produtos;
import com.example.hot_rolls_club.databinding.FragmentFavoritosBinding;
import com.example.hot_rolls_club.databinding.FragmentPerfilBinding;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class FavoritosFragment extends Fragment implements RecyclerProdutosInterface {

    FragmentFavoritosBinding binding;
    List<Produtos> listaFavoritos = new ArrayList<>();
    RecyclerProdutosInterface RecyclerProdutosInterface;
    ConexaoSQL conexaoSQL = new ConexaoSQL();
    Connection connection = conexaoSQL.connectionclass();

    ContaCli contaCli;


    public FavoritosFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentFavoritosBinding.inflate(inflater, container, false);
        View view = binding.getRoot();

        List<Produtos> produtos = PegarLista.getInstance().getListaProdutos();
        String cpf = ContaCli.getCpf();



        try {
            String exibirFavoritos = "select * from Favorito where cpf = '" + cpf + "'";
            Statement statement = conexaoSQL.createStatement(connection);
            ResultSet resultSet = statement.executeQuery(exibirFavoritos);

            while (resultSet.next()) {
                String idProduto = resultSet.getString("id_Produto");

                // Procurar o produto correspondente na lista de produtos
                for (Produtos produto : produtos) {
                    if (produto.getId_produto().equals(idProduto)) {
                        // Se encontrar, adicione-o à lista de favoritos
                        listaFavoritos.add(produto);
                        break; // Sai do loop após encontrar o produto correspondente
                    }
                }
            }

            // Atualize o RecyclerView com os pratos favoritos
            ProdutoAdapter produtoAdapter = new ProdutoAdapter(listaFavoritos, RecyclerProdutosInterface);
            binding.recycler.setAdapter(produtoAdapter);
            GridLayoutManager gridLayoutManager = new GridLayoutManager(getContext(), 2);
            binding.recycler.setLayoutManager(gridLayoutManager);
            binding.recycler.setHasFixedSize(true);

            // Feche a conexão após o uso
            conexaoSQL.closeConnection(connection);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return view;
    }


    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
    }

    @Override
    public void onItemClick(int position) {
        List<Produtos> listaFavoritos = PegarLista.getInstance().getListaProdutos();
        if(position>=0 && position < listaFavoritos.size())
        {
            Produtos produtosClicado = listaFavoritos.get(position);
            AbreProdutos.setIdProduto(produtosClicado.getId_produto());
            AbreProdutos.setNome(produtosClicado.getNomeProduto());
            AbreProdutos.setPreco(produtosClicado.getPrecoProduto());
            AbreProdutos.setDescricao(produtosClicado.getDescricaoProduto());
            AbreProdutos.setImgProduto(produtosClicado.getImgProduto());
        }
        openChildFragment();
    }

    private void openChildFragment() {
        FragmentTransaction fragmentTransaction = getChildFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.fram299, new TelaPratoFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
}