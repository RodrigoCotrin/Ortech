package br.teste.fragments;

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

import java.util.List;

import br.teste.R;
import br.teste.adapters.ProdutoAdapter;
import br.teste.adapters.RecyclerProdutosInterface;
import br.teste.classes.AbreProdutos;
import br.teste.classes.PegarLista;
import br.teste.classes.Produtos;
import br.teste.databinding.FragmentCardapioBinding;

public class CardapioFragment extends Fragment implements RecyclerProdutosInterface {
    FragmentCardapioBinding binding;
    ProdutoAdapter produtoAdapter;
    //List<Produtos> listaProdutos = new ArrayList<Produtos>();
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

        produtoAdapter.filtrarPorCategoria("");

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