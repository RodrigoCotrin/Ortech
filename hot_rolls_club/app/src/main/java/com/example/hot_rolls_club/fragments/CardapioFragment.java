package com.example.hot_rolls_club.fragments;

import android.graphics.Color;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.widget.SearchView;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.GridLayoutManager;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.hot_rolls_club.R;
import com.example.hot_rolls_club.adapters.ProdutoAdapter;
import com.example.hot_rolls_club.adapters.RecyclerProdutosInterface;
import com.example.hot_rolls_club.classes.AbreProdutos;
import com.example.hot_rolls_club.classes.CategoriaSelecioada;
import com.example.hot_rolls_club.classes.PegarLista;
import com.example.hot_rolls_club.classes.Produtos;
import com.example.hot_rolls_club.databinding.FragmentCardapioBinding;

import java.util.List;

public class CardapioFragment extends Fragment implements RecyclerProdutosInterface {

    FragmentCardapioBinding binding;
    ProdutoAdapter produtoAdapter;
    //List<Produtos> listaProdutos = new ArrayList<Produtos>();
    CategoriaSelecioada categoriaSelecioada;
    Boolean clicked = false;
    public CardapioFragment() {}

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentCardapioBinding.inflate(inflater, container, false);
        View view = binding.getRoot();


        List<Produtos> produtos = PegarLista.getInstance().getListaProdutos();

        produtoAdapter = new ProdutoAdapter(produtos, this);
        GridLayoutManager gridLayoutManager = new GridLayoutManager(getContext(), 2);
        binding.recycler.setLayoutManager(gridLayoutManager);
        binding.recycler.setHasFixedSize(true);
        binding.recycler.setAdapter(produtoAdapter);


        if(CategoriaSelecioada.getCategoria() == 0){
            binding.todos.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.todos.setTextColor(Color.WHITE);
            produtoAdapter.filtrarPorCategoria("");
        }

        if (CategoriaSelecioada.getCategoria() == 1){
            binding.sushi.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.sushi.setTextColor(Color.WHITE);
            binding.todos.setTextColor(Color.DKGRAY);
            binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
            produtoAdapter.filtrarPorCategoria("Sushi");
        }
        if (CategoriaSelecioada.getCategoria() == 2){
            binding.yakisoba.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.yakisoba.setTextColor(Color.WHITE);
            binding.todos.setTextColor(Color.DKGRAY);
            binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
            produtoAdapter.filtrarPorCategoria("Yakissoba");
        }
        if (CategoriaSelecioada.getCategoria() == 3){
            binding.bebidas.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.bebidas.setTextColor(Color.WHITE);
            binding.todos.setTextColor(Color.DKGRAY);
            binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
            produtoAdapter.filtrarPorCategoria("Bebidas");
        }
        if (CategoriaSelecioada.getCategoria() == 4){
            binding.robata.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.robata.setTextColor(Color.WHITE);
            binding.todos.setTextColor(Color.DKGRAY);
            binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
            produtoAdapter.filtrarPorCategoria("Robata");;
        }
        if (CategoriaSelecioada.getCategoria() == 5){
            binding.temaki.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.temaki.setTextColor(Color.WHITE);
            binding.todos.setTextColor(Color.DKGRAY);
            binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
            produtoAdapter.filtrarPorCategoria("Temaki");
        }
        if (CategoriaSelecioada.getCategoria() == 6){
            binding.tempura.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.tempura.setTextColor(Color.WHITE);
            binding.todos.setTextColor(Color.DKGRAY);
            binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
            produtoAdapter.filtrarPorCategoria("Tempurá");
        }
        if (CategoriaSelecioada.getCategoria() == 7){
            binding.sashimi.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.sashimi.setTextColor(Color.WHITE);
            binding.todos.setTextColor(Color.DKGRAY);
            binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
            produtoAdapter.filtrarPorCategoria("Sashimi");
        }
        if (CategoriaSelecioada.getCategoria() == 8){
            binding.nigiri.setBackgroundResource(R.drawable.bg_button_enabled);
            binding.nigiri.setTextColor(Color.WHITE);
            binding.todos.setTextColor(Color.DKGRAY);
            binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
            produtoAdapter.filtrarPorCategoria("Nigiri");
        }
        return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        binding.searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                produtoAdapter.filtrarPorNome(newText);
                return true;
            }
        });

        binding.todos.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.todos.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.todos.setTextColor(Color.WHITE);
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sushi.setTextColor(Color.DKGRAY);
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sashimi.setTextColor(Color.DKGRAY);
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.temaki.setTextColor(Color.DKGRAY);
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.yakisoba.setTextColor(Color.DKGRAY);
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.bebidas.setTextColor(Color.DKGRAY);
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.nigiri.setTextColor(Color.DKGRAY);
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.tempura.setTextColor(Color.DKGRAY);
                    binding.robata.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.robata.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("");
                }
            }
        });
        binding.sushi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.sushi.setTextColor(Color.WHITE);
                    binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.todos.setTextColor(Color.DKGRAY);
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sashimi.setTextColor(Color.DKGRAY);
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.temaki.setTextColor(Color.DKGRAY);
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.yakisoba.setTextColor(Color.DKGRAY);
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.bebidas.setTextColor(Color.DKGRAY);
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.nigiri.setTextColor(Color.DKGRAY);
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.tempura.setTextColor(Color.DKGRAY);
                    binding.robata.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.robata.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("Sushi");
                }
            }
        });
        binding.bebidas.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.bebidas.setTextColor(Color.WHITE);
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sushi.setTextColor(Color.DKGRAY);
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sashimi.setTextColor(Color.DKGRAY);
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.temaki.setTextColor(Color.DKGRAY);
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.yakisoba.setTextColor(Color.DKGRAY);
                    binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.todos.setTextColor(Color.DKGRAY);
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.nigiri.setTextColor(Color.DKGRAY);
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.tempura.setTextColor(Color.DKGRAY);
                    binding.robata.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.robata.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("Bebidas");
                }
            }
        });
        binding.sashimi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.sashimi.setTextColor(Color.WHITE);
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sushi.setTextColor(Color.DKGRAY);
                    binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.todos.setTextColor(Color.DKGRAY);
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.temaki.setTextColor(Color.DKGRAY);
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.yakisoba.setTextColor(Color.DKGRAY);
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.bebidas.setTextColor(Color.DKGRAY);
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.nigiri.setTextColor(Color.DKGRAY);
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.tempura.setTextColor(Color.DKGRAY);
                    binding.robata.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.robata.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("Sashimi");
                }
            }
        });

        binding.tempura.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.tempura.setTextColor(Color.WHITE);
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sushi.setTextColor(Color.DKGRAY);
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sashimi.setTextColor(Color.DKGRAY);
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.temaki.setTextColor(Color.DKGRAY);
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.yakisoba.setTextColor(Color.DKGRAY);
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.bebidas.setTextColor(Color.DKGRAY);
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.nigiri.setTextColor(Color.DKGRAY);
                    binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.todos.setTextColor(Color.DKGRAY);
                    binding.robata.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.robata.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("Tempurá");
                }
            }
        });
        binding.yakisoba.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.yakisoba.setTextColor(Color.WHITE);
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sushi.setTextColor(Color.DKGRAY);
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sashimi.setTextColor(Color.DKGRAY);
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.temaki.setTextColor(Color.DKGRAY);
                    binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.todos.setTextColor(Color.DKGRAY);
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.bebidas.setTextColor(Color.DKGRAY);
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.nigiri.setTextColor(Color.DKGRAY);
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.tempura.setTextColor(Color.DKGRAY);
                    binding.robata.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.robata.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("Yakissoba");
                }
            }
        });
        binding.robata.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.robata.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.robata.setTextColor(Color.WHITE);
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sushi.setTextColor(Color.DKGRAY);
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sashimi.setTextColor(Color.DKGRAY);
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.temaki.setTextColor(Color.DKGRAY);
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.yakisoba.setTextColor(Color.DKGRAY);
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.bebidas.setTextColor(Color.DKGRAY);
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.nigiri.setTextColor(Color.DKGRAY);
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.tempura.setTextColor(Color.DKGRAY);
                    binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.todos.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("Robata");
                }
            }
        });
        binding.nigiri.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.nigiri.setTextColor(Color.WHITE);
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sushi.setTextColor(Color.DKGRAY);
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sashimi.setTextColor(Color.DKGRAY);
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.temaki.setTextColor(Color.DKGRAY);
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.yakisoba.setTextColor(Color.DKGRAY);
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.bebidas.setTextColor(Color.DKGRAY);
                    binding.robata.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.robata.setTextColor(Color.DKGRAY);
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.tempura.setTextColor(Color.DKGRAY);
                    binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.todos.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("Nigiri");
                }
            }
        });
        binding.temaki.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                clicked = true;
                if(clicked)
                {
                    binding.temaki.setBackgroundResource(R.drawable.bg_button_enabled);
                    binding.temaki.setTextColor(Color.WHITE);
                    binding.sushi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sushi.setTextColor(Color.DKGRAY);
                    binding.sashimi.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.sashimi.setTextColor(Color.DKGRAY);
                    binding.robata.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.robata.setTextColor(Color.DKGRAY);
                    binding.yakisoba.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.yakisoba.setTextColor(Color.DKGRAY);
                    binding.bebidas.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.bebidas.setTextColor(Color.DKGRAY);
                    binding.nigiri.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.nigiri.setTextColor(Color.DKGRAY);
                    binding.tempura.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.tempura.setTextColor(Color.DKGRAY);
                    binding.todos.setBackgroundResource(R.drawable.bg_button_disabled);
                    binding.todos.setTextColor(Color.DKGRAY);

                    produtoAdapter.filtrarPorCategoria("Temaki");
                }
            }
        });

    }
    @Override
    public void onItemClick(int position) {
        List<Produtos> lista = PegarLista.getInstance().getListaProdutos();
        if(position>=0 && position < lista.size())
        {
            Produtos produtosClicado = lista.get(position);
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
        fragmentTransaction.replace(R.id.fram2, new TelaPratoFragment());
        fragmentTransaction.addToBackStack(null);
        fragmentTransaction.commit();
    }
}